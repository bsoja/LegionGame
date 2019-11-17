using System;
using Gui.Input;
using Gui.Services;
using Legion.Model;
using Legion.Views;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Legion
{
    public class LegionGame : Game, IGuiServices, IViewSwitcher
    {
        const float Scale = 1.5f;
        const int WorldWidth = 640;
        const int WorldHeight = 512;
        const float ScreenWidth = WorldWidth * Scale;
        const float ScreenHeight = WorldHeight * Scale;
        private readonly Matrix _scaleMatrix;

        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        BasicDrawer _basicDrawer;
        ImagesStore _imagesStore;
        Rectangle _gameBounds;

        public LegionGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = (int) ScreenWidth;
            _graphics.PreferredBackBufferHeight = (int) ScreenHeight;

            _scaleMatrix = Matrix.CreateScale(Scale);
            InputManager.ScaleMatrix = _scaleMatrix;
            _gameBounds = new Rectangle(0, 0, WorldWidth, WorldHeight);

            Content.RootDirectory = "Assets/bin";
        }

        public IBasicDrawer BasicDrawer => _basicDrawer;
        public IImagesStore ImagesStore => _imagesStore;
        public IViewSwitcher ViewSwitcher => this;
        public Rectangle GameBounds => _gameBounds;
        public ILegionViewsManager ViewsManager { get; set; }

        public event Action GameLoaded;

        protected override void Initialize()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _basicDrawer = new BasicDrawer(_spriteBatch);
            _imagesStore = new ImagesStore();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            IsMouseVisible = true;
            _basicDrawer.LoadContent(this);
            _imagesStore.LoadContent(this);

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
            _spriteBatch.Begin(sortMode: SpriteSortMode.Deferred, transformMatrix: _scaleMatrix);
            base.Draw(gameTime);
            ViewsManager.Draw();

            _spriteBatch.End();
        }

        public void OpenMenu()
        {
            ViewsManager.CurrentView = ViewsManager.Menu;
        }

        public void OpenMap(TerrainActionContext context)
        {
            ViewsManager.CurrentView = ViewsManager.Map;
            context?.ActionAfter?.Invoke();
        }

        public void OpenTerrain(TerrainActionContext context)
        {
            ViewsManager.Terrain.Context = context;
            ViewsManager.CurrentView = ViewsManager.Terrain;
        }
    }
}