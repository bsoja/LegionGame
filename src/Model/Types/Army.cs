using System.Collections.Generic;

namespace Legion.Model.Types
{
    public class Army : MapObject
    {
        private static int _id = 0;

        public Army()
        {
            Characters = new List<Character>();
            Id = ++_id;
        }

        //public int Id { get; set; }

        /// <summary>
        /// ARMIA(I,0,TMAG)=PL
        /// </summary>
        //public Player Owner { get; set; }

        /// <summary>
        /// ARMIA$(A,0)=A$  A$="Legion "+Str$(A+1)
        /// </summary>
        //public string Name { get; set; }

        /// <summary>
        /// ARMIA(AR,0,TX)=X
        /// </summary>
        //public int X { get; set; }

        /// <summary>
        /// ARMIA(AR,0,TY)=Y
        /// </summary>
        //public int Y { get; set; }

        /// <summary>
        /// X2=ARMIA (A,0, TCELX)
        /// </summary>
        //public int TargetX { get; set; }

        /// <summary>
        /// Y2=ARMIA (A,0, TCELY)
        /// </summary>
        //public int TargetY { get; set; }

        public ArmyTargetType TargetType { get; set; }
        public MapObject Target { get; set; }

		public int TurnTargetX { get; set; }
		public int TurnTargetY { get; set; }

        public bool IsMoving { get; set; }

        /// <summary>
        /// ARMIA(A,0,TSI)=SILA
        /// </summary>
        public int Strength
        {
            get
            {
                var s = 0;
                foreach (var c in Characters)
                {
                    s += c.Strength;
                    s += c.Energy;
                }
                return s;
            }
        }

        /// <summary>
        /// SPEED=ARMIA(A,0,TSZ)
        /// </summary>
        public int Speed
        {
            get
            {
                var s = 0;
                foreach (var c in Characters)
                {
                    s += c.Speed;
                }
                return (s / Characters.Count) / 5;
            }
        }

        /// <summary>
        /// AGRESJA=ARMIA(WRG,0,TKORP)
        /// </summary>
        //public int Aggression { get; set; }  // it seems it is not used - is only assigned never used anywhere

        /// <summary>
        /// ZARCIE=ARMIA(A,0,TAMO)
        /// </summary>
        public int Food { get; set; }

        //public int Terrain { get; set; } // ARMIA(AR,0,TNOGI)=LOK

        /// <summary>
        /// ARMIA(AR,0,TBOB)=B1
        /// </summary>
        //public int Bob { get; set; }

        /// <summary>
        /// ARMIA(AR,0,TMAGMA)=DNI
        /// </summary>
        public int DaysToGetInfo { get; set; }

		/// <summary>
		/// ARMIA(AR,0,TMAGMA) == 100
		/// </summary>
		public bool IsTracked { get; set; }

        public bool IsKilled
        {
            get { return Characters.Count == 0; }
        }

        /// <summary>
        /// ARMIA(A,0,TWAGA)=0
        /// </summary>
        public bool IsTerrainActionAvailable { get; set; } = true;

        /// <summary>
        /// TRYB=ARMIA(A,0,TTRYB)
        /// </summary>
        public ArmyActions CurrentAction { get; set; }

        /// <summary>
        /// WOJ=ARMIA(A,0,TE) -> Characters.Count
        /// </summary>
        public List<Character> Characters { get; set; }

    }
}