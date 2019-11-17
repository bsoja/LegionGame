using System.Collections.Generic;
using Legion.Model.Types;
using Legion.Utils;

namespace Legion.Model.Repositories
{
    public class AdventuresRepository : IAdventuresRepository
    {
        public const int MaxAdventures = 4;

        private readonly List<Adventure> _userAdventures;

        public AdventuresRepository()
        {
            _userAdventures = new List<Adventure>(MaxAdventures);
            Adventures = new List<Adventure>();
        }

        public List<Adventure> Adventures { get; private set; }

        public Adventure Create(int id, int level) 
        {
            if (_userAdventures.Count >= MaxAdventures)
            {
                return null;
            }

            var adventure = new Adventure();
            adventure.Id = id;
            //PRZYGODY(NR,P_X)=ARMIA(A,0,TNOGI)-70
            adventure.Y = GlobalUtils.Rand(9) + 1;
            adventure.Direction = null;
            adventure.Level = level;

            switch (id)
            {
                case 1:
                {
                    // kopalnia
                    adventure.Price = 20 * level;
                    adventure.Terrain = 8;
                    adventure.AddReward(RewardType.Money, level * 10000);
                }
                break;
                case 2:
                {
                    // kurhan
                    adventure.Price = GlobalUtils.Rand(20 * level);
                    adventure.Terrain = 9;
                    adventure.RelatedPerson = NamesGenerator.Generate();
                    adventure.AddReward(RewardType.Money, level * 100);
                    /*
                        adventures.AddReward(RewardType.Weapon, weapon);
                        Repeat 
                            BRON=Rnd(MX_WEAPON)
                            BTYP=BRON(BRON,B_TYP)
                        Until BRON(BRON,B_CENA)>=1000 and BRON(BRON,BCENA)<100+LEVEL*1000 and BTYP<>5 and BTYP<>8 and BTYP<>13 and BTYP<>14 and BTYP<16
                        PRZYGODY(NR,P_BRON)=BRON
                     */
                }
                break;
                case 3:
                {
                    // bandyci
                    adventure.Price = 0;
                    adventure.AddReward(RewardType.Money, 4000 + GlobalUtils.Rand(2000) + level * 100);
                }
                break;
                case 4:
                {
                    // córa
                    adventure.Price = 0;
                    adventure.RelatedPerson = NamesGenerator.Generate();
                    /*
                        adventure.AddReward(RewardType.City, city.Id);
                        Repeat : MIASTO=Rnd(49) : Until MIASTA(MIASTO,0,M_CZYJE)<>1
                     */
                }
                break;

                default:
                    break;
            }

            _userAdventures.Add(adventure);
            return adventure;
        }
    }


/*
   If TYP=5
      'gï¿½ra jakaï¿½ tam
      PRZYGODY(NR,P_TERMIN)=100+Rnd(100)
      PRZYGODY(NR,P_CENA)=Rnd(100)+30
      'jedno z miast rnd(m_czyje)
      PRZYGODY(NR,P_NAGRODA)=MIASTO
      PRZYGODY(NR,P_TEREN)=4
      PRZYGODY(NR,P_BRON)=0
      ROB_IMIE
      IM_PRZYGODY$(NR)=Param$
   End If 
   If TYP=6
      'super mag 
      PRZYGODY(NR,P_TERMIN)=100+Rnd(100)
      PRZYGODY(NR,P_CENA)=Rnd(100)+10
      'jedno z miast rnd(m_czyje)
      PRZYGODY(NR,P_NAGRODA)=MIASTO
      PRZYGODY(NR,P_TEREN)=0
      PRZYGODY(NR,P_BRON)=0
      ROB_IMIE
      IM_PRZYGODY$(NR)=Param$
   End If 
   If TYP=7
      'grota paladyna ufola
      PRZYGODY(NR,P_TERMIN)=100+Rnd(100)
      PRZYGODY(NR,P_CENA)=Rnd(100)+10
      'jedno z miast rnd(m_czyje)
      PRZYGODY(NR,P_NAGRODA)=MIASTO
      PRZYGODY(NR,P_TEREN)=8
      PRZYGODY(NR,P_BRON)=0
      ROB_IMIE
      IM_PRZYGODY$(NR)=Param$
   End If 
   
   If TYP=8
      'magiczna ksiï¿½ga 
      PRZYGODY(NR,P_LEVEL)=3
      PRZYGODY(NR,P_TERMIN)=100+Rnd(100)
      PRZYGODY(NR,P_CENA)=100
      PRZYGODY(NR,P_TEREN)=9
      If Rnd(1)=0
         'GB
         PRZYGODY(NR,P_BRON)=52
      Else 
         'NAW 
         PRZYGODY(NR,P_BRON)=88
      End If 
   End If 
   
   If TYP=9
      'ï¿½wiï¿½tynia orkï¿½w 
      PRZYGODY(NR,P_TERMIN)=100+Rnd(100)
      PRZYGODY(NR,P_CENA)=Rnd(20)
      PRZYGODY(NR,P_TEREN)=9
      PRZYGODY(NR,P_BRON)=0
   End If 
   
   If TYP=10
      'barbrayï¿½ca na bagnach 
      PRZYGODY(NR,P_TERMIN)=100+Rnd(100)
      PRZYGODY(NR,P_CENA)=Rnd(100)+30
      PRZYGODY(NR,P_TEREN)=7
      PRZYGODY(NR,P_BRON)=0
      ROB_IMIE
      IM_PRZYGODY$(NR)=Param$
   End If 
   
   If TYP=11
      'wataha
      PRZYGODY(NR,P_TERMIN)=100+Rnd(100)
      PRZYGODY(NR,P_CENA)=0
      PRZYGODY(NR,P_NAGRODA)=3000*LEVEL
      PRZYGODY(NR,P_TEREN)=0
      AGAIN:
      RSA=Rnd(8)
      If RSA=4
         ' bez amazonek 
         Goto AGAIN
      End If 
      PRZYGODY(NR,P_BRON)=RSA
      ROB_IMIE
      IM_PRZYGODY$(NR)=Param$
   End If 
   
   If TYP=12
      'jaskinia wiedzy 
      PRZYGODY(NR,P_TERMIN)=100+Rnd(100)
      PRZYGODY(NR,P_CENA)=Rnd(100)+20
      PRZYGODY(NR,P_TEREN)=8
   End If 
   
   If TYP=13
      'wï¿½adca chaosu 
      PRZYGODY(NR,P_LEVEL)=4
      PRZYGODY(NR,P_TERMIN)=100+Rnd(100)
      PRZYGODY(NR,P_CENA)=500+Rnd(100)
      'jedno z miast rnd(m_czyje)
      PRZYGODY(NR,P_NAGRODA)=MIASTO
      PRZYGODY(NR,P_TEREN)=10
      PRZYGODY(NR,P_BRON)=0
   End If 
   
End Proc
*/
}