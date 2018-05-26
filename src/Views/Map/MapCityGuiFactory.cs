using System.Collections.Generic;
using System.Linq;
using Legion.Gui.Elements.Map;
using Legion.Gui.Services;
using Legion.Model;
using Legion.Model.Types;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Views.Map
{
    public class MapCityGuiFactory : IMapCityGuiFactory
    {
        private readonly IGuiServices guiServices;
        private readonly ILegionConfig legionConfig;
        private readonly ITextsManager textsManager;
        private Texture2D[] cityWindowImages;

        public MapCityGuiFactory(IGuiServices guiServices,
            ILegionConfig legionConfig,
            ITextsManager textsManager)
        {
            this.guiServices = guiServices;
            this.legionConfig = legionConfig;
            this.textsManager = textsManager;

            guiServices.Loaded += () => LoadImages();
        }

        private void LoadImages()
        {
            cityWindowImages = new []
            {
                guiServices.ImagesProvider.GetImage(ImageType.CityWindow1),
                guiServices.ImagesProvider.GetImage(ImageType.CityWindow2),
                guiServices.ImagesProvider.GetImage(ImageType.CityWindow3),
                guiServices.ImagesProvider.GetImage(ImageType.CityWindow4),
            };
        }

        public CityWindow CreateCityWindow(City city)
        {
            var window = new CityWindow(guiServices);
            var hasData = false;
            var infoText = "";
            var daysText = "";

            window.Image = cityWindowImages[city.WallType];

            window.ButtonOkText = textsManager.Get(TextType.Ok);
            if (city.Owner != null && city.Owner.IsUserControlled)
            {
                window.ButtonMoreText = textsManager.Get(TextType.Orders);
                hasData = true;
            }
            else
            {
                window.ButtonMoreText = textsManager.Get(TextType.Interview);
                if (city.DaysToGetInfo > 25)
                {
                    hasData = false;
                    infoText = textsManager.Get(TextType.NoInformation);
                }
                else
                {
                    if (city.DaysToGetInfo == 1)
                    {
                        daysText = textsManager.Get(TextType.Day);
                    }
                    else
                    {
                        daysText = textsManager.Get(TextType.Days);
                    }
                    hasData = false;
                    infoText = textsManager.Get(TextType.InformationIn) + city.DaysToGetInfo + daysText;
                }
                if (city.DaysToGetInfo == 0)
                {
                    infoText = "";
                    hasData = true;
                }
            }

            if (city.Population > 700)
            {
                window.NameText = textsManager.Get(TextType.City) + city.Name;
            }
            else
            {
                window.NameText = textsManager.Get(TextType.Settlement) + city.Name;
            }

            if (!hasData && !legionConfig.GoDmOdE)
            {
                window.InfoText = infoText;
            }
            else
            {
                window.CountText = city.Population + textsManager.Get(TextType.People);
                window.TaxText = textsManager.Get(TextType.Tax) + city.Tax;

                var morale2 = city.Morale / 20;
                if (morale2 > 4) morale2 = 4;
                //TODO: handle morale texts better way
                var moraleTexts = new []
                {
                    textsManager.Get(TextType.Rebelious),
                    textsManager.Get(TextType.Dissatisfied),
                    textsManager.Get(TextType.Lieges),
                    textsManager.Get(TextType.Loyal),
                    textsManager.Get(TextType.Fanatics)
                };
                //Text OKX + 50,OKY + 45,"Morale :" + GUL$(MORALE2)
                window.MoraleText = textsManager.Get(TextType.Morale) + moraleTexts[morale2];

                window.Buildings = new List<string>();
                foreach (var name in city.Buildings.Where(b => b.Type.Id > 3).Select(b => b.Type.Name))
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