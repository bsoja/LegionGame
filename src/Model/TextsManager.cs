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

            dict.Add(TextType.Ok, "Ok");
            dict.Add(TextType.Orders, "Rozkazy");
            dict.Add(TextType.Interview, "Wywiad");
            dict.Add(TextType.NoInformation, "Brak informacji");
            dict.Add(TextType.Day, " dzien.");
            dict.Add(TextType.Days, " dni.");
            dict.Add(TextType.InformationIn, "Informacje za ");
            dict.Add(TextType.City, "Miasto : ");
            dict.Add(TextType.Settlement, "Osada  : ");
            dict.Add(TextType.People, " mieszkancow");
            dict.Add(TextType.Tax, "Podatek : ");
            dict.Add(TextType.Morale, "Morale :");
            dict.Add(TextType.Rebelious, "zbuntowani");
            dict.Add(TextType.Dissatisfied, "niezadowoleni");
            dict.Add(TextType.Lieges, "poddani");
            dict.Add(TextType.Loyal, "lojalni");
            dict.Add(TextType.Fanatics, "fanatycy");

            dict.Add(TextType.Spy, "sledzenie");
            dict.Add(TextType.OneWarrior, "1 wojownik");
            dict.Add(TextType.Warriors, "wojownikow");
            dict.Add(TextType.FoodFor, "zywnosc na ");
            dict.Add(TextType.FoodForOneDay, "zywnosc na 1 dzien");
            dict.Add(TextType.NoFood, "Brak zywnosci !");
            dict.Add(TextType.Strength, "Sila      : ");
            dict.Add(TextType.Speed, "Szybkosc  : ");
            dict.Add(TextType.Camping, "Oddzial obozuje");
            dict.Add(TextType.Moving, "Odzial w ruchu");
            dict.Add(TextType.Attacking, "Atakujemy ");
            dict.Add(TextType.Hunting, "Tropimy zwierzyne");
        }

        public string Get(TextType text)
        {
            return dict[text];
        }
    }
}