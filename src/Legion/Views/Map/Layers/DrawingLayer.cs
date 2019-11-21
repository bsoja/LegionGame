using System.ComponentModel;
using Gui.Elements;
using Gui.Input;
using Gui.Services;
using Microsoft.Xna.Framework;

namespace Legion.Views.Map.Layers
{
    public class DrawingLayer : Layer
    {
        private readonly IMapServices _mapServices;
        private static readonly Color LineColor = Color.AntiqueWhite;

        public DrawingLayer(IGuiServices guiServices, IMapServices mapServices) : base(guiServices)
        {
            _mapServices = mapServices;
            Clicked += DrawingLayer_Clicked;
        }

        private void DrawingLayer_Clicked(HandledEventArgs args)
        {
            if (_mapServices.IsRouteDrawing)
            {
                args.Handled = true;
                var mousePos = InputManager.GetMousePostion(true);
                _mapServices.EndRouteDrawing(mousePos);
            }
        }

        public override void Draw()
        {
            if (_mapServices.IsRouteDrawing)
            {
                var mapObject = _mapServices.DrawingRouteSource;
                var mousePos = InputManager.GetMousePostion(true);

                GuiServices.BasicDrawer.DrawLine(LineColor, 
                    new Vector2(mapObject.X, mapObject.Y),
                    mousePos.ToVector2());
            }
        }
    }
}