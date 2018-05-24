using Legion.Gui;
using Legion.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Legion
{
    public class LegionGame : Game
    {
        const float scale = 1.5f;
        const int WorldWidth = 640;
        const int WorldHeight = 512;
        const float ScreenWidth = WorldWidth * scale;
        const float ScreenHeight = WorldHeight * scale;
        private readonly Matrix scaleMatrix;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        BasicDrawer basicDrawer;
        ImagesProvider imagesProvider;
        Rectangle gameBounds;

        public LegionGame()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = (int) ScreenWidth;
            graphics.PreferredBackBufferHeight = (int) ScreenHeight;

            scaleMatrix = Matrix.CreateScale(scale);
            gameBounds = new Rectangle(0, 0, WorldWidth, WorldHeight);

            Content.RootDirectory = "Assets/bin";
        }

        public SpriteBatch SpriteBatch { get { return spriteBatch; } }
        public IBasicDrawer BasicDrawer { get { return basicDrawer; } }
        public IImagesProvider ImagesProvider { get { return imagesProvider; } }
        public Rectangle GameBounds { get { return gameBounds; } }

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

            spriteBatch.Begin(sortMode: SpriteSortMode.Deferred, transformMatrix: scaleMatrix);
            base.Draw(gameTime);
            spriteBatch.End();
        }

    }
}