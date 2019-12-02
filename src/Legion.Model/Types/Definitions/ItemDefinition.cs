using Legion.Utils;

namespace Legion.Model.Types.Definitions
{
    public class ItemDefinition
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Resistance { get; set; }
        public int Speed { get; set; }
        public int Energy { get; set; }
        public ItemType Type { get; set; }
        public int Weight { get; set; }
        public ItemTarget Target { get; set; }
        public int Experience { get; set; }
        public int Magic { get; set; }
        public int Price { get; set; }
        public string Img { get; set; }
    }
}