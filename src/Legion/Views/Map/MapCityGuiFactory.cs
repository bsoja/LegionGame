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
        private readonly IGuiServices _guiServices;
        private readonly ILegionConfig _legionConfig;
        private readonly ITexts _texts;
        private List<Texture2D> _cityWindowImages;

        public MapCityGuiFactory(IGuiServices guiServices,
            ILegionConfig legionConfig,
            ITexts texts)
        {
            _guiServices = guiServices;
            _legionConfig = legionConfig;
            _texts = texts;

            guiServices.GameLoaded += () => LoadImages();
        }

        private void LoadImages()
        {
            _cityWindowImages = _guiServices.ImagesStore.GetImages("city.windows");
        }

        public CityOrdersWindow CreateCityOrdersWindow(City city)
        {
            var window = new CityOrdersWindow(_guiServices);
            return window;
        }

        public CityWindow CreateCityWindow(City city)
        {
            var window = new CityWindow(_guiServices);
            var hasData = false;
            var infoText = "";
            var daysText = "";

            window.Image = _cityWindowImages[city.WallType];

            window.ButtonOkText = _texts.Get("ok");
            if (city.Owner != null && city.Owner.IsUserControlled)
            {
                window.ButtonMoreText = _texts.Get("commands");
                hasData = true;
            }
            else
            {
                window.ButtonMoreText = _texts.Get("interview");
                if (city.DaysToGetInfo > 25)
                {
                    hasData = false;
                    infoText = _texts.Get("noInformation");
                }
                else
                {
                    infoText = city.DaysToGetInfo > 1 ?
                        _texts.Get("informationsInXDays", city.DaysToGetInfo) :
                        _texts.Get("informationsInOneDay");
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
                window.NameText = _texts.Get("city") + " " + city.Name;
            }
            else
            {
                window.NameText = _texts.Get("village") + " " + city.Name;
            }

            if (!hasData && !_legionConfig.GoDmOdE)
            {
                window.InfoText = infoText;
            }
            else
            {
                window.CountText = _texts.Get("peopleCount", city.Population);
                window.TaxText = _texts.Get("tax") + ": " + city.Tax;

                var morale2 = city.Morale / 20;
                if (morale2 > 4) morale2 = 4;
                //TODO: handle morale texts better way
                var moraleTexts = new []
                {
                    _texts.Get("rebelious"),
                    _texts.Get("discontented"),
                    _texts.Get("serf"),
                    _texts.Get("loyal"),
                    _texts.Get("fanatics")
                };
                //Text OKX + 50,OKY + 45,"Morale :" + GUL$(MORALE2)
                window.MoraleText = _texts.Get("morale") + ": " + moraleTexts[morale2];

                var buildings = new List<string>();
                foreach (var name in city.Buildings.Where(b => b.Type.Type == BuildingType.Shop).Select(b => b.Type.Name))
                {
                    if (!buildings.Contains(name))
                    {
                        buildings.Add(name);
                    }
                }
                window.Buildings = buildings;
            }

            return window;
        }
    }
}