namespace Legion.Localization
{
    public class LanguageProvider : ILanguageProvider
    {
        const string DefaultLanguage = "en-us";
        private string _language = DefaultLanguage;

        public string Language
        {
            get { return _language; }
            set
            {
                _language = value;
                LanguageChanged?.Invoke(_language);
            }
        }

        public event LanguageChangedEventHandler LanguageChanged;
    }
}