using Legion.Utils;

namespace Legion.Model.Types.Definitions
{
    public class BuildingDefinition
    {
        public string Name { get; set; }
        public BuildingType Type { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int DoorsPos { get; set; }
        public int Price { get; set; }
        public string Img { get; set; }
    }
}