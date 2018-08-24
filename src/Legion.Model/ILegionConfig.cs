namespace Legion.Model
{
    public delegate void LanguageChangedEventHandler(string language);

    public interface ILegionConfig
    {
        string Language { get; }
        event LanguageChangedEventHandler LanguageChanged;
        
        int PlayersCount { get; }
        int MaxCitiesCount { get; }
        int MaxCityBuildingsCount { get; }

        int WorldWidth { get; }
        int WorldHeight { get; }

        bool GoDmOdE { get; }
    }
}