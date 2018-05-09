using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Legion.View.Map.Layers
{
    public class MapGuiLayer : Layer<MapView>
    {
        public MapGuiLayer(Game game) : base(game)
        { }

        public override bool UpdateInput()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                Parent.MapController.NextTurn();
                return true;
            }
            return false;
        }
    }
}