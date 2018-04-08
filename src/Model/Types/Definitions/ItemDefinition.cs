namespace Legion.Model.Types.Definitions
{
    //'nazwa            s p s e t w g d mag,cena,bob     
    // Data "lekki     ",5,1,0,0,2,2,4,1,0,100,28
    // B_SI=1 : B_PAN=2 : B_SZ=3 : B_EN=4 : B_TYP=5 : B_WAGA=6
    // B_PLACE=7 : B_DOSW=8 : B_MAG=9 : B_CENA=10 : B_BOB=11
    public class ItemDefinition
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }

        public int Strength { get; set; }
        public int Panic { get; set; }
        public int Speed { get; set; }
        public int Energy { get; set; }
        public int Weight { get; set; }
        public int Place { get; set; } // ?
        public int Experience { get; set; }
        public int Magic { get; set; }
        public int Price { get; set; }
        public int Bob { get; set; }
    }
}