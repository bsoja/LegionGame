using Legion.Model.Types.Definitions;

namespace Legion.Model.Types
{
    // TODO
    public class Character
    {
        private static int _id;

        public Character()
        {
            Id = ++_id;
        }

        public int Id { get; set; }

        /// <summary>
        /// TRASA
        /// </summary>
        public CharacterDefinition Type { get; set; }
        
        public string Name { get; set; }

        public int X { get; set; } //TX=1
        public int Y { get; set; } //TY=2

        public int TargetX { get; set; } //TCELX=5
        public int TargetY { get; set; } //TCELY=6
        public int TargetId { get; set; }
        public CharacterTargetType TargetType { get; set; }

        /// <summary>
        /// TTRYB
        /// </summary>
        public CharacterActionType CurrentAction { get; set; }

        public CharacterEquipment Equipment { get; set; }

        /// <summary>
        /// SILA=ARMIA(A,NR,TSI) | TSI=3
        /// </summary>
        /// <value>The energy.</value>
        public int Strength { get; set; }

        /// <summary>
        /// ENERGIA=ARMIA(A,NR,TE)
        /// </summary>
        /// <value>The energy.</value>
        public int Energy { get; set; }

        /// <summary>
        /// ENERGIAM=ARMIA(A,NR,TEM)
        /// </summary>
        /// <value>The energy max.</value>
        public int EnergyMax { get; set; }

        /// <summary>
        /// SPEED=ARMIA(A,NR,TSZ) | TSZ=4
        /// </summary>
        /// <value>The speed.</value>
        public int Speed { get; set; }

        /// <summary>
        /// SPEEDM=ARMIA(A,NR,TAMO)
        /// </summary>
        /// <value>The speed max.</value>
        public int SpeedMax { get; set; }

        /// <summary>
        /// ARMIA(ARM,NUMER,TP)
        /// </summary>
        public int Resistance { get; set; }

        /// <summary>
        /// MAGIA=ARMIA(A,NR,TMAG)
        /// </summary>
        /// <value>The magic.</value>
        public int Magic { get; set; }

        /// <summary>
        /// MAGIAM=ARMIA(A,NR,TMAGMA)
        /// </summary>
        /// <value>The magic max.</value>
        public int MagicMax { get; set; }

        /// <summary>
        /// ARMIA(ARM,NUMER,TDOSW)
        /// </summary>
        public int Experience { get; set; }

        /// <summary>
        /// ARMIA(WRG,B,TKORP)=AGRESJA
        /// </summary>
        /// <value>The aggression.</value>
        public int Aggression { get; set; } //TKORP=14

        //public int B1 { get; set; }
        //public int B2 { get; set; }
        //public int Intelligence { get; set; }
        //public int Bob { get; set; }
        public int CurrentAnimFrame { get; set; }
        public int PrevAnimFrameTime { get; set; }
    }

    // TODO:
    public enum CharacterActionType
    {
        None = 0,
        Move = 1,
        Attack = 2,
        Shoot,
        Speak
        //...
        /*

        // MOVE:
        ARMIA(ARM,I,TTRYB)=1
        ARMIA(ARM,I,TCELX)=CX (position X)
        ARMIA(ARM,I,TCELY)=CY (position Y)

        // ATTACK:
        ARMIA(ARM,I,TTRYB)=2
        ARMIA(ARM,I,TCELX)=TARGET (character nr within army)
        ARMIA(ARM,I,TCELY)=WRG (army nr)

        */
    }

    public enum CharacterTargetType
    {
        Position,
        Character
    }

    /*
    TEM=0 : TX=1 : TY=2 : TSI=3 : TSZ=4 : TCELX=5 : TCELY=6 : TTRYB=7 : TE=8 : TP=9
    TBOB=10 : TKLAT=11 : TAMO=12 : TLEWA=16 : TPRAWA=17 : TNOGI=15 : TGLOWA=13
    TPLECAK=18 : TKORP=14 : TMAG=26 : TDOSW=27 : TRASA=28 : TWAGA=29 : TMAGMA=30
    */
}