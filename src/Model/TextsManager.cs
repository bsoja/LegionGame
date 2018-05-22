using System.Collections.Generic;

namespace Legion.Model
{
    public class TextsManager : ITextsManager
    {
        private readonly ILegionConfig legionConfig;
        private Dictionary<TextType, string> dict;

        public TextsManager(ILegionConfig legionConfig)
        {
            this.legionConfig = legionConfig;

            legionConfig.LanguageChanged += Load;
            Load(legionConfig.Language);
        }

        private void Load(string language)
        {
            dict = new Dictionary<TextType, string>();

            //TODO: load texts from file/db based on selected language
            dict.Add(TextType.FireBurnsPeopleAndCity, "Plomienie strawily wielu miaszkancow i ich domostwa.");
            dict.Add(TextType.EpidemyInsideCity, "Epidemia zarazy kosi swe smiertelne zniwo!");
            dict.Add(TextType.AllFoodsEatenByRats, "Szczury pozarly caly zapas zboza w spichlerzach.");
        }

        public string GetText(TextType text)
        {
            return dict[text];
        }
    }
}