using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Gui.Services
{
    public class ImagesProvider : IImagesProvider
    {
        private readonly Dictionary<ImageType, Texture2D> dict;

        public ImagesProvider()
        {
            dict = new Dictionary<ImageType, Texture2D>();
        }

        public void LoadContent(Game game)
        {
            var Add = new Action<ImageType, string>((type, name) => dict.Add(type, game.Content.Load<Texture2D>(name)));

            Add(ImageType.Map, "mapa2");
            Add(ImageType.MainMenu, "kam.pic");

            Add(ImageType.CityEmptySmall, "mapa.7");
            Add(ImageType.CityEmptyBig, "mapa.8");
            Add(ImageType.CityUserSmall, "mapa.9");
            Add(ImageType.CityUserBig, "mapa.10");
            Add(ImageType.CityPlayer2Small, "mapa.11");
            Add(ImageType.CityPlayer2Big, "mapa.12");
            Add(ImageType.CityPlayer3Small, "mapa.13");
            Add(ImageType.CityPlayer3Big, "mapa.14");
            Add(ImageType.CityPlayer4Small, "mapa.15");
            Add(ImageType.CityPlayer4Big, "mapa.16");

            Add(ImageType.CityWindow1, "mapa.19");
            Add(ImageType.CityWindow2, "mapa.20");
            Add(ImageType.CityWindow3, "mapa.21");
            Add(ImageType.CityWindow4, "mapa.22");

            Add(ImageType.ArmyUser, "mapa.2");
            Add(ImageType.ArmyPlayer2, "mapa.3");
            Add(ImageType.ArmyPlayer3, "mapa.4");
            Add(ImageType.ArmyPlayer4, "mapa.5");
            Add(ImageType.ArmyChaos, "mapa.6");

            Add(ImageType.ArmyWindowUser, "mapa.23");
            Add(ImageType.ArmyWindowPlayer2, "mapa.24");
            Add(ImageType.ArmyWindowPlayer3, "mapa.25");
            Add(ImageType.ArmyWindowPlayer4, "mapa.26");
            Add(ImageType.ArmyWindowChaos, "mapa.27");

            Add(ImageType.EpidemyInTheCity, "mapa.28");
            Add(ImageType.RatsInTheCity, "mapa.29");
            Add(ImageType.FireInTheCity, "mapa.31");
            Add(ImageType.ChaosWarriorsBurnedCity, "mapa.31");
        }

        public Texture2D GetImage(ImageType type)
        {
            return dict[type];
        }

    }
}