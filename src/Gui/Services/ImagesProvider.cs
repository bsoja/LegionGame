using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gui.Services
{
    public class ImagesProvider : IImagesProvider
    {
        private readonly Dictionary<ImageType, List<Texture2D>> dict;

        public ImagesProvider()
        {
            dict = new Dictionary<ImageType, List<Texture2D>>();
        }

        private void Add(Game game, ImageType type, params string[] names)
        {
            var list = new List<Texture2D>();
            foreach (var name in names)
            {
                list.Add(game.Content.Load<Texture2D>(name));
            }
            dict.Add(type, list);
        }

        public void LoadContent(Game game)
        {
            Add(game, ImageType.Map, "mapa2");
            Add(game, ImageType.MainMenu, "kam.pic");

            Add(game, ImageType.CityEmptySmall, "mapa.7");
            Add(game, ImageType.CityEmptyBig, "mapa.8");
            Add(game, ImageType.CityUserSmall, "mapa.9");
            Add(game, ImageType.CityUserBig, "mapa.10");
            Add(game, ImageType.CityPlayer2Small, "mapa.11");
            Add(game, ImageType.CityPlayer2Big, "mapa.12");
            Add(game, ImageType.CityPlayer3Small, "mapa.13");
            Add(game, ImageType.CityPlayer3Big, "mapa.14");
            Add(game, ImageType.CityPlayer4Small, "mapa.15");
            Add(game, ImageType.CityPlayer4Big, "mapa.16");

            Add(game, ImageType.CityWindow1, "mapa.19");
            Add(game, ImageType.CityWindow2, "mapa.20");
            Add(game, ImageType.CityWindow3, "mapa.21");
            Add(game, ImageType.CityWindow4, "mapa.22");

            Add(game, ImageType.ArmyUser, "mapa.2");
            Add(game, ImageType.ArmyPlayer2, "mapa.3");
            Add(game, ImageType.ArmyPlayer3, "mapa.4");
            Add(game, ImageType.ArmyPlayer4, "mapa.5");
            Add(game, ImageType.ArmyChaos, "mapa.6");

            Add(game, ImageType.ArmyWindowUser, "mapa.23");
            Add(game, ImageType.ArmyWindowPlayer2, "mapa.24");
            Add(game, ImageType.ArmyWindowPlayer3, "mapa.25");
            Add(game, ImageType.ArmyWindowPlayer4, "mapa.26");
            Add(game, ImageType.ArmyWindowChaos, "mapa.27");

            Add(game, ImageType.EpidemyInTheCity, "mapa.28");
            Add(game, ImageType.RatsInTheCity, "mapa.29");
            Add(game, ImageType.FireInTheCity, "mapa.31");
            Add(game, ImageType.ChaosWarriorsBurnedCity, "mapa.31");

            Add(game, ImageType.SceneForest, Enumerable.Range(0, 12).Select(i => "scen-las." + i).ToArray());
        }

        public Texture2D GetImage(ImageType type)
        {
            return dict[type][0];
        }

        public List<Texture2D> GetImages(ImageType type)
        {
            return dict[type];
        }

    }
}