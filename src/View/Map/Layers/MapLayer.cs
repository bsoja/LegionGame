using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.View.Map.Layers
{
    public class MapLayer : Layer<MapView>
    {
        private Texture2D background;
        
        public MapLayer(Game game) : base(game) { }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            SpriteBatch.Draw(background, new Vector2(0, 0), null, Color.White, 0, new Vector2(), 1, SpriteEffects.None, 0);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            background = Game.Content.Load<Texture2D>("mapa2");
        }
    }
}
