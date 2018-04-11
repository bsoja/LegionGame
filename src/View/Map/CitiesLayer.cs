using Legion.Controllers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.View.Map
{
    public class CitiesLayer : Layer<MapView>
    {
        private Texture2D[] cityImages;

        public CitiesLayer(Game game) : base(game)
        {
        }

        protected override void LoadContent()
        {
            var citySmallEmpty = Game.Content.Load<Texture2D>("mapa.7");
            var cityBigEmpty = Game.Content.Load<Texture2D>("mapa.8");
            var citySmallUser = Game.Content.Load<Texture2D>("mapa.9");
            var cityBigUser = Game.Content.Load<Texture2D>("mapa.10");
            var citySmallPlayer2 = Game.Content.Load<Texture2D>("mapa.11");
            var cityBigPlayer2 = Game.Content.Load<Texture2D>("mapa.12");
            var citySmallPlayer3 = Game.Content.Load<Texture2D>("mapa.13");
            var cityBigPlayer3 = Game.Content.Load<Texture2D>("mapa.14");
            var citySmallPlayer4 = Game.Content.Load<Texture2D>("mapa.15");
            var cityBigPlayer4 = Game.Content.Load<Texture2D>("mapa.16");

            cityImages = new []
            {
                citySmallEmpty,
                cityBigEmpty,
                citySmallUser,
                cityBigUser,
                citySmallPlayer2,
                cityBigPlayer2,
                citySmallPlayer3,
                cityBigPlayer3,
                citySmallPlayer4,
                cityBigPlayer4
            };
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (var city in Parent.MapController.Cities)
            {
                var id = 0;
                if (city.Owner != null)
                {
                    id = city.Owner.Id * 2;
                }
                if (city.IsBigCity) id++;
                var cityImage = cityImages[id];

                var cityX = city.X - cityImage.Width / 2;
                var cityY = city.Y - cityImage.Height / 2;

                SpriteBatch.Draw(cityImage, new Vector2(cityX, cityY), null, Color.White, 0, new Vector2(), 1, SpriteEffects.None, 0);
            }
        }
    }
}