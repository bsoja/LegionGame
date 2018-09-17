namespace Legion.Localization
{
    public interface ITexts
    {
        string Get(string key, params object[] args);
    }
}