using System.ComponentModel;
using Gui.Input;
using Gui.Services;
using Microsoft.Xna.Framework;

namespace Legion.Views.Map.Layers
{
    public class DrawingLayer : MapLayer
    {
        private readonly IMapRouteDrawer _routeDrawer;
        private static readonly Color LineColor = Color.AntiqueWhite;

        public DrawingLayer(IGuiServices guiServices, IMapRouteDrawer routeDrawer) : base(guiServices)
        {
            _routeDrawer = routeDrawer;
            Clicked += DrawingLayer_Clicked;
        }

        private void DrawingLayer_Clicked(HandledEventArgs args)
        {
            if (_routeDrawer.IsRouteDrawingForPoint)
            {
                args.Handled = true;
                var mousePos = InputManager.GetMousePostion(true);
                _routeDrawer.EndRouteDrawingForPoint(mousePos);
            }
        }

        public override void Draw()
        {
            if (_routeDrawer.IsRouteDrawingForAny)
            {
                var mapObject = _routeDrawer.DrawingRouteSource;
                var mousePos = InputManager.GetMousePostion(true);

                GuiServices.BasicDrawer.DrawLine(LineColor, 
                    new Vector2(mapObject.X, mapObject.Y),
                    mousePos.ToVector2());
            }
        }
    }
}