using Legion.Gui.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Legion.View.Map.Layers
{
    public class MapGuiLayer : Layer<MapView>
    {
        private MapMenu mapMenu;

        public MapGuiLayer(Game game) : base(game)
        { 

        }

        public override void Initialize()
        {
            base.Initialize();
            mapMenu = new MapMenu(BasicDrawer, GameBounds);
        }

        public override bool UpdateInput()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                Parent.MapController.NextTurn();
                return true;
            }
            return false;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            mapMenu.Update();
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            mapMenu.Draw();
        }
    }
}