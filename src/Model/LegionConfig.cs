namespace Legion.Model
{
    public class LegionConfig : ILegionConfig
    {
        public int PlayersCount { get; private set; } = 5;
        public int MaxCitiesCount { get; private set; } = 50;
        public int MaxCityBuildingsCount { get; private set; } = 7;

        public int WorldWidth { get; private set; } = 960;
        public int WorldHeight { get; private set; } = 768;

        public bool GoDmOdE { get; private set; } = false;
    }
}