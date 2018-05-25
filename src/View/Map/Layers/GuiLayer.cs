using Legion.Gui;
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
            mapMenu.StartClicked += OnStartClicked;
        }

        private void OnStartClicked(EventArgs args)
        {
            args.Handled = true;
            Parent.MapController.NextTurn();
        }

        public override bool UpdateInput()
        {
            var handled = mapMenu.UpdateInput();
            return handled;
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