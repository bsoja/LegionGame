using Legion.Model.Types;
using Legion.Model.Types.Definitions;
using Legion.Utils;

namespace Legion.Model.Repositories
{
    public class CharactersRepository : ICharactersRepository
    {
        public Character CreateCharacter(CharacterDefinition type)
        {
            // TODO
            return new Character
            {
                Type = type,
                Strength = GlobalUtils.Rand(10) + (type.Strength / 2),
                Speed = GlobalUtils.Rand(10) + type.Speed,
                Energy = (GlobalUtils.Rand(20) + type.Energy) * 3

            };
        }

        //Procedure NOWA_POSTAC[A,NR,RASA]
        //For I=0 To 30 : ARMIA(A,NR,I)=0 : Next I
        //ARMIA(A,NR,TRASA)=RASA
        //ARMIA(A,NR,TSI)=Rnd(10)+(RASY(RASA,1)/2)
        //ARMIA(A,NR,TSZ)=Rnd(10)+RASY(RASA,2)
        //ARMIA(A,NR,TE)=(Rnd(20)+RASY(RASA,0))*3
        //ARMIA(A,NR,TEM)=ARMIA(A,NR,TE)
        //ARMIA(A,NR,TKLAT)=Rnd(3)
        //'   ARMIA(A,NR,TDOSW)=99 
        //If RASA>9
        //ARMIA(A,NR,TKORP)=150+Rnd(60)
        //ARMIA(A,NR,TMAG)=BRON(RASY(RASA,6),B_MAG)*5
        //ARMIA(A,NR,TMAGMA)=ARMIA(A,NR,TMAG)
        //'potwory w plecaku przechowują czar  
        //ARMIA(A,NR,TPLECAK)=RASY(RASA,6)
        //ARMIA(A,NR,TAMO)=Rnd(20)
        //ODP=RASY(RASA,5)
        //ARMIA(A,NR,TP)=Rnd(ODP/2)+ODP/2
        //ARMIA(A,NR,TDOSW)=Rnd(30)
        //Else 
        //ARMIA(A,NR,TMAG)=Rnd(5)+RASY(RASA,3)
        //ARMIA(A,NR,TMAGMA)=ARMIA(A,NR,TMAG)
        //End If 
        //If PREFS(1)=1
        //ROB_IMIE
        //    ARMIA$(A,NR)=Param$
        //Else 
        //    ARMIA$(A,NR)="wojownik"+Str$(NR)
        //    End If 
        //    If A>19
        //If RASA<10
        //Add ARMIA(A,NR,TSI),Rnd(POWER)
        //ARMIA(A,NR,TP)=Rnd(POWER/2)+POWER/2
        //ARMIA(A,NR,TDOSW)=Rnd(POWER/2)+POWER/2
        //End If 
        //Else 
        //'zapasowa prędkość w tamo
        //ARMIA(A,NR,TAMO)=ARMIA(A,NR,TSZ)
        //'to jest tylko do testów nowej broni 
        //    If TESTING : For J=0 To 7 : ARMIA(A,NR,TPLECAK+J)=Rnd(MX_WEAPON) : Next J : End If 
        //'      ARMIA(A,NR,TPLECAK)=Rnd(3)+1

        //WAGA[A,NR]
        //End If 
        //End Proc
    }
}