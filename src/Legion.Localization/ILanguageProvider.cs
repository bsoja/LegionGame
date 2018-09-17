namespace Legion.Localization
{
    public delegate void LanguageChangedEventHandler(string language);

    public interface ILanguageProvider
    {
        string Language { get; }
        event LanguageChangedEventHandler LanguageChanged;
    }
}