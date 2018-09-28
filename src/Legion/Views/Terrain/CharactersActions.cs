using Legion.Model.Types;
using Legion.Utils;
using Microsoft.Xna.Framework;

namespace Legion.Views.Terrain
{
    public class CharactersActions
    {
        public Army UserArmy { get; set; }
        public Army EnemyArmy { get; set; }

        public Character FindTarget(Character character)
        {
            var target = EnemyArmy.Characters.Find(c => c.Id == character.TargetId);
            if (target == null)
            {
                target = UserArmy.Characters.Find(c => c.Id == character.TargetId);
            }
            return target;
        }

        public void CalculateRandomMove(Character character)
        {
            var x2 = character.X + GlobalUtils.Rand(120) - 60;
            var y2 = character.Y + GlobalUtils.Rand(100) - 50;

            if (x2 < 20)
                x2 = 20;
            if (x2 > 620)
                x2 = 620;
            if (y2 < 20)
                y2 = 20;
            if (y2 > 510)
                y2 = 510;

            character.TargetX = x2;
            character.TargetY = y2;
            character.CurrentAction = CharacterActionType.Move;
        }

        public void GiveTheOrder(Character character)
        {
            if (character.Aggression < 50)
            {
                CalculateRandomMove(character);
            }
            else
            {
                /*
               STARAODL=WIDOCZNOSC
     WIDAC=False
     For I=1 To 10
        If ARMIA(ARM,I,TE)>0
           X2=ARMIA(ARM,I,TX)
           Y2=ARMIA(ARM,I,TY)
           ODL[X1,Y1,X2,Y2]
           'ODLEG=Param 
           If ODLEG<STARAODL
              TARGET=I
              CX=X2 : CY=Y2
              STARAODL=ODLEG
              WIDAC=True
           End If 
        End If 
     Next I*/

                if (character.Aggression > 100)
                {
                    /*
                   If WIDAC
        If STARAODL<50
           Gosub _ATAKUJ
        Else 
           If STARAODL<WIDOCZNOSC-60 : Bob 10+NR,X1,Y1,ARMIA(WRG,NR,TBOB)+2 : End If 
           If(ARMIA(WRG,NR,TAMO)>0 or MAGIA>10)
              If RAN<5  //RAN=Rnd(10)
                 Gosub STRZELAJ
              End If 
           Else 
              If Rnd(1)=0
                 ARMIA(WRG,NR,TKORP)=90
              Else 
                 ARMIA(WRG,NR,TKORP)=155
              End If 
           End If 
        End If 
     End If */
                }

                if (character.Aggression > 150)
                {
                    /*
                   If WIDAC
        If(ARMIA(WRG,NR,TAMO)>0 or MAGIA>10) and RAN<2  //RAN=Rnd(10)
           Gosub STRZELAJ
        Else 
           Gosub _ATAKUJ
        End If 
     End If */
                }

                if (character.Aggression >= 50)
                {
                    /*
                   If STARAODL<50
        Gosub _ATAKUJ
     Else 
        Gosub RANDOM
     End If */
                }
            }

            //TODO: see rest of the body of Procedure WYDAJ_ROZKAZ[NR]
        }

        public void Attack(Character character, int gameTime)
        {
            var target = FindTarget(character);

            if (target != null)
            {
                character.TargetX = target.X;
                character.TargetY = target.Y;
            }
            else
            {
                //already killed
                character.CurrentAction = CharacterActionType.None;
            }
            Move(character, gameTime);
        }

        public void Move(Character character, int gameTime)
        {
            var dx = character.TargetX - character.X;
            var dy = character.TargetY - character.Y;

            var mx = 0;
            var my = 0;
            var t = 0;

            if (dx < 0)
            {
                mx = -1;
                t = -17;
            }
            if (dx > 0)
            {
                mx = 1;
                t = 17;
            }
            var moveXpos = new Point(character.X + mx + t, character.Y);
            if (!CharactersUtils.CheckCollision(character, moveXpos, UserArmy, EnemyArmy))
            {
                character.X += mx;
            }

            if (dy < 0)
            {
                my = -1;
                t = -21;
            }
            if (dy > 0)
            {
                my = 1;
                t = 2;
            }
            var moveYpos = new Point(character.X, character.Y + my + t);
            if (!CharactersUtils.CheckCollision(character, moveYpos, UserArmy, EnemyArmy))
            {
                character.Y += my;
            }

            character.PrevAnimFrameTime += gameTime;//gameTime.ElapsedGameTime.Milliseconds;
            if (character.PrevAnimFrameTime > 100)
            {
                character.PrevAnimFrameTime = 0;
                character.CurrentAnimFrame++;
                var frame = character.CurrentAnimFrame % 3;
                if (frame > 2)
                    frame = 0;

                if (mx < 0)
                {
                    character.CurrentAnimFrame = frame + 3;
                }
                if (mx > 0)
                {
                    character.CurrentAnimFrame = frame + 9;
                }

                if (my < 0)
                {
                    character.CurrentAnimFrame = frame;
                }
                if (my > 0)
                {
                    character.CurrentAnimFrame = frame + 6;
                }
            }

            if (dx == 0 && dy == 0)
            {
                character.CurrentAction = CharacterActionType.None;
                character.CurrentAnimFrame = 0;
            }
        }
    }
}