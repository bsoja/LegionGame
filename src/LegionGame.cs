using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

/*
LegionGame(Game)

- MenuView
- TerrainView
- MapView
-- MapWindow
--- Map
---- MapObjects (Army, City, Adventure)
--- MapMenu
---- Border
---- Start Button
---- Options Button
-- Modal Dialogs (Messages, Informations Windows (City/Army/Adventure Info Window), Options Window)



StateController - controls which View currently should be used


View : DrawableComponent
-> Content : Panel
-> Windows : Stack<Window>

Panel : GuiElement
-> Childrens : List<GuiElement>
-> Bounds : Rect
 */

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

        public IStateController StateController { get; set; }
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