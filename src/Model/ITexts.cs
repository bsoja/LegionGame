namespace Legion.Model
{
    public interface ITexts
    {
        string Get(string key, params object[] args);
    }
}