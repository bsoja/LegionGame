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
            dict.Add(TextType.FireBurnsPeopleAndCity, "Plomienie strawily wielu \nmieszkancow \ni ich domostwa.");
            dict.Add(TextType.EpidemyInsideCity, "Epidemia zarazy kosi \nswe smiertelne zniwo ! ");
            dict.Add(TextType.AllFoodsEatenByRats, "Szczury pozarly caly \nzapas zboza \nw spichlerzach.");
            dict.Add(TextType.RiotInTheCity, "W miescie wybuchl bunt!");
            
        }

        public string GetText(TextType text)
        {
            return dict[text];
        }
    }
}