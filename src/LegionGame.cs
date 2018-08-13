using System;
using System.Collections.Generic;
using Legion.Gui.Elements;
using Legion.Gui.Services;
using Legion.Input;
using Legion.Model;
using Legion.Views;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Legion
{
    public class LegionGame : Game, IGuiServices, IViewSwitcher
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
        public IViewSwitcher ViewSwitcher { get { return this; } }
        public Rectangle GameBounds { get { return gameBounds; } }
        public ILegionViewsManager ViewsManager { get; set; }

        public event Action GameLoaded;

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
            ViewsManager.Initialize();

            GameLoaded?.Invoke();
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
            ViewsManager.Update();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(sortMode: SpriteSortMode.Deferred, transformMatrix: scaleMatrix);
            base.Draw(gameTime);
            ViewsManager.Draw();

            spriteBatch.End();
        }

        public void OpenMenu()
        {
			ViewsManager.Menu.IsVisible = true;
            ViewsManager.Terrain.IsVisible = false;
            ViewsManager.Map.IsVisible = false;
        }

        public void OpenMap(TerrainActionContext context)
        {
            ViewsManager.Menu.IsVisible = false;
            ViewsManager.Terrain.IsVisible = false;
            ViewsManager.Map.IsVisible = true;

            context?.ActionAfter?.Invoke();
        }

        public void OpenTerrain(TerrainActionContext context)
        {
            ViewsManager.Terrain.Context = context;

            ViewsManager.Menu.IsVisible = false;
            ViewsManager.Terrain.IsVisible = true;
            ViewsManager.Map.IsVisible = false;
        }
    }
}