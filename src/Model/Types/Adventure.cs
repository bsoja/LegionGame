using System.Collections.Generic;

namespace Legion.Model.Types
{
    // Dim PRZYGODY$(20,10),IM_PRZYGODY$(3),PRZYGODY(3,10)
    // PRZYGODY(3,10)
    // Line: 8186, 5923, Procedure MA_PRZYGODA[A,NR]
    public class Adventure : MapObject
    {
        //public int Id {get;set;}  // P_TYP=0
        //public int X {get;set;}  // P_X=1
        //public int Y {get;set;}  // P_Y=2
        public int Term { get; set; } // P_TERMIN=3 - Not used
        public WorldDirection? Direction { get; set; }  // P_KIERUNEK=4
        public int Level { get; set; }  // P_LEVEL=5
        public int Price { get; set; }  // P_CENA=6
        public List<Reward> Rewards { get; set; }  // P_NAGRODA=7 && P_BRON=8 - Could be amount of cash or Id of city Or Weapon
        public int Terrain { get; set; }  // P_TEREN=9
        public int PreviousCity { get; set; }  // P_STAREX=10
        public string RelatedPerson { get; set; }  // IM_PRZYGODY$(NR)

        public Adventure()
        {
            Rewards = new List<Reward>();
        }

        public void AddReward(RewardType type, int amountOrId)
        {
            var reward = new Reward { Type = type, AmountOrId = amountOrId };
            Rewards.Add(reward);
        }
    }
}