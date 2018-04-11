using Legion.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Legion
{
    public class LegionGame : Game
    {
        const int WorldWidth = 800;
        const int WorldHeight = 640;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public LegionGame()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = WorldWidth;
            graphics.PreferredBackBufferHeight = WorldHeight;

            Content.RootDirectory = "Assets/bin";
        }

        public SpriteBatch SpriteBatch { get { return spriteBatch; } }

        protected override void Initialize()
        {
            base.Initialize();

            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void LoadContent()
        {
            IsMouseVisible = true;
        }

        protected override void UnloadContent() { }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.Deferred);
            base.Draw(gameTime);
            spriteBatch.End();
        }

    }
}