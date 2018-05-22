using Legion.Gui;
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
        BasicDrawer basicDrawer;
        ImagesProvider imagesProvider;

        public LegionGame()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = WorldWidth;
            graphics.PreferredBackBufferHeight = WorldHeight;

            Content.RootDirectory = "Assets/bin";
        }

        public SpriteBatch SpriteBatch { get { return spriteBatch; } }
        public IBasicDrawer BasicDrawer { get { return basicDrawer; } }
        public IImagesProvider ImagesProvider { get { return imagesProvider; } }

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            basicDrawer = new BasicDrawer(spriteBatch);
            imagesProvider = new ImagesProvider();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            IsMouseVisible = true;
            basicDrawer.LoadContent(this);
            imagesProvider.LoadContent(this);
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