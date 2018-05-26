using System;
using System.Collections.Generic;
using Legion.Gui.Elements;
using Legion.Gui.Services;
using Legion.Input;
using Legion.Views;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Legion
{
    public class LegionGame : Game, IGuiServices, IViewsProvider
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
            InputManager.ScaleMatrix = scaleMatrix;
            gameBounds = new Rectangle(0, 0, WorldWidth, WorldHeight);

            Content.RootDirectory = "Assets/bin";
        }

        public IBasicDrawer BasicDrawer { get { return basicDrawer; } }
        public IImagesProvider ImagesProvider { get { return imagesProvider; } }
        public Rectangle GameBounds { get { return gameBounds; } }

        public View Menu { get; private set; }
        public View Map { get; private set; }
        public View Terrain { get; private set; }
        private IEnumerable<View> views;
        public event Action Loaded;

        public void SetViews(View menu, View map, View terrain)
        {
            Menu = menu;
            Map = map;
            Terrain = terrain;
            views = new List<View> { menu, map, terrain };
        }

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

            //NOTE: views are initalized here because it needs imagesProvider content loaded before this
            foreach (var view in views)
            {
                view.Initialize();
            }

            Loaded?.Invoke();
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

            foreach (var view in views)
            {
                if (view.IsVisible) { view.Update(); }
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(sortMode: SpriteSortMode.Deferred, transformMatrix: scaleMatrix);
            base.Draw(gameTime);

            foreach (var view in views)
            {
                if (view.IsVisible) { view.Draw(); }
            }

            spriteBatch.End();
        }

    }
}