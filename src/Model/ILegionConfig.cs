namespace Legion.Model
{
    public interface ILegionConfig
    {
        int PlayersCount { get; }
        int MaxCitiesCount { get; }
        int MaxCityBuildingsCount { get; }

        int WorldWidth { get; }
        int WorldHeight { get; }

        bool GoDmOdE { get; }
    }
}