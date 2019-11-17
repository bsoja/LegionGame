using System.Collections.Generic;

namespace Legion.Model.Types
{
    public class Army : MapObject
    {
        private static int _id;

        public Army()
        {
            Characters = new List<Character>();
            Id = ++_id;
        }

        // NOTE
        // Moved to base class (MapObject):
        // Id
        // Owner: ARMIA(I,0,TMAG)=PL
        // Name: ARMIA$(A,0)=A$  A$="Legion "+Str$(A+1)
        // X: ARMIA(AR,0,TX)=X
        // Y: ARMIA(AR,0,TY)=Y
        //
        // Not used:
        // AGRESJA=ARMIA(WRG,0,TKORP)
        // ARMIA(A,0,TLEWA)=1
        // ARMIA(A,0,TPRAWA)=1
        //
        // Handled in different way:
        // TCELX,TCELY merged to Target,TargetType
        // Terrain: ARMIA(AR,0,TNOGI)=LOK
        // Sprite: ARMIA(AR,0,TBOB)=B1
        // Is terrain action available: ARMIA(A,0,TWAGA)=0
        // WOJ=ARMIA(A,0,TE) -> Characters.Count

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
        /// ZARCIE=ARMIA(A,0,TAMO)
        /// </summary>
        public int Food { get; set; }

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
        /// TRYB=ARMIA(A,0,TTRYB)
        /// </summary>
        public ArmyActions CurrentAction { get; set; }

        /// <summary>
        /// WOJ=ARMIA(A,0,TE) -> Characters.Count
        /// </summary>
        public List<Character> Characters { get; set; }

    }
}