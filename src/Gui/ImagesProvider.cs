using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Gui
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
            dict.Add(ImageType.EpidemyInsideCity, game.Content.Load<Texture2D>("mapa.28"));
            dict.Add(ImageType.AllFoodsEatenByRats, game.Content.Load<Texture2D>("mapa.29"));
            dict.Add(ImageType.FireBurnsPeopleAndCity, game.Content.Load<Texture2D>("mapa.31"));
        }

        public Texture2D GetImage(ImageType type)
        {
            return dict[type];
        }

    }
}