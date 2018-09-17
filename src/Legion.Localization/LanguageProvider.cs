namespace Legion.Localization
{
    public class LanguageProvider : ILanguageProvider
    {
        const string DefaultLanguage = "en-us";
        private string language = DefaultLanguage;

        public string Language
        {
            get { return language; }
            set
            {
                language = value;
                LanguageChanged?.Invoke(language);
            }
        }

        public event LanguageChangedEventHandler LanguageChanged;
    }
}