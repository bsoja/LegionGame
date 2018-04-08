using Legion.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.View.Menu
{
    public class MenuLayer : Layer
    {
        private Texture2D background;

        public MenuLayer(Game game) : base(game) { }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            SpriteBatch.Draw(background, new Vector2(0, 0), null, Color.White, 0, new Vector2(), 1, SpriteEffects.None, 0);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            background = Game.Content.Load<Texture2D>("kam.pic");
        }

        public override bool UpdateInput()
        {
            if (Microsoft.Xna.Framework.Input.Keyboard.GetState().
                IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Enter))
            {
                ((LegionGame) Game).StateController.EnterMap();
                return true;
            }
            return false;
        }
    }
}