using Legion.Model.Types.Definitions;

namespace Legion.Views.Terrain
{
    public class TerrainItem
    {
        public int X { get; set; }
        public int Y { get; set; }
        public ItemDefinition Type { get; set; }
    }
}