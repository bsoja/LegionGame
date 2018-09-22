using System.Collections.Generic;
using System.Linq;
using Gui.Services;
using Legion.Localization;
using Legion.Model;
using Legion.Model.Types;
using Legion.Model.Types.Definitions;
using Legion.Views.Map.Controls;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Views.Map
{
    public class MapCityGuiFactory : IMapCityGuiFactory
    {
        private readonly IGuiServices guiServices;
        private readonly ILegionConfig legionConfig;
        private readonly ITexts texts;
        private List<Texture2D> cityWindowImages;

        public MapCityGuiFactory(IGuiServices guiServices,
            ILegionConfig legionConfig,
            ITexts texts)
        {
            this.guiServices = guiServices;
            this.legionConfig = legionConfig;
            this.texts = texts;

            guiServices.GameLoaded += () => LoadImages();
        }

        private void LoadImages()
        {
            cityWindowImages = guiServices.ImagesStore.GetImages("city.windows");
        }

        public CityOrdersWindow CreateCityOrdersWindow(City city)
        {
            var window = new CityOrdersWindow(guiServices);
            return window;
        }

        public CityWindow CreateCityWindow(City city)
        {
            var window = new CityWindow(guiServices);
            var hasData = false;
            var infoText = "";
            var daysText = "";

            window.Image = cityWindowImages[city.WallType];

            window.ButtonOkText = texts.Get("ok");
            if (city.Owner != null && city.Owner.IsUserControlled)
            {
                window.ButtonMoreText = texts.Get("commands");
                hasData = true;
            }
            else
            {
                window.ButtonMoreText = texts.Get("interview");
                if (city.DaysToGetInfo > 25)
                {
                    hasData = false;
                    infoText = texts.Get("noInformation");
                }
                else
                {
                    infoText = city.DaysToGetInfo > 1 ?
                        texts.Get("informationsInXDays", city.DaysToGetInfo) :
                        texts.Get("informationsInOneDay");
                    hasData = false;
                }
                if (city.DaysToGetInfo == 0)
                {
                    infoText = "";
                    hasData = true;
                }
            }

            if (city.Population > 700)
            {
                window.NameText = texts.Get("city") + " " + city.Name;
            }
            else
            {
                window.NameText = texts.Get("village") + " " + city.Name;
            }

            if (!hasData && !legionConfig.GoDmOdE)
            {
                window.InfoText = infoText;
            }
            else
            {
                window.CountText = texts.Get("peopleCount", city.Population);
                window.TaxText = texts.Get("tax") + ": " + city.Tax;

                var morale2 = city.Morale / 20;
                if (morale2 > 4) morale2 = 4;
                //TODO: handle morale texts better way
                var moraleTexts = new []
                {
                    texts.Get("rebelious"),
                    texts.Get("discontented"),
                    texts.Get("serf"),
                    texts.Get("loyal"),
                    texts.Get("fanatics")
                };
                //Text OKX + 50,OKY + 45,"Morale :" + GUL$(MORALE2)
                window.MoraleText = texts.Get("morale") + ": " + moraleTexts[morale2];

                window.Buildings = new List<string>();
                foreach (var name in city.Buildings.Where(b => b.Type.Type == BuildingType.Shop).Select(b => b.Type.Name))
                {
                    if (!window.Buildings.Contains(name))
                    {
                        window.Buildings.Add(name);
                    }
                }
            }

            return window;
        }
    }
}