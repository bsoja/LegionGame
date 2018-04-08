namespace Legion.Model.Types.Definitions
{
    /*
     '               szer wys cena czas b1 b2 drzwi 
     Data "studnia   ",64,50,0,0,3,0,0
     */
    public class BuildingDefinition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Price { get; set; }
        public int Time { get; set; }
        public int B1 { get; set; }
        public int B2 { get; set; }
        public int Doors { get; set; }
    }
}