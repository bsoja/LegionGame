using Legion.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Legion.View.Menu.Layers
{
    public class MenuLayer : Layer
    {
        private Texture2D background;
        private readonly IStateController stateController;

        public MenuLayer(Game game, IStateController stateController) : base(game)
        {
            this.stateController = stateController;
        }

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
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                stateController.EnterMap();
                return true;
            }
            return false;
        }
    }
}