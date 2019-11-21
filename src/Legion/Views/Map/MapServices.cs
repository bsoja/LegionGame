using System;
using Gui.Elements;
using Legion.Model.Types;
using Legion.Views.Map.Layers;
using Microsoft.Xna.Framework;

namespace Legion.Views.Map
{
    public class MapServices : IMapServices
    {
        private readonly ModalLayer _modalLayer;

        public MapServices(ModalLayer modalLayer)
        {
            _modalLayer = modalLayer;
        }

        public bool IsRouteDrawing => DrawingRouteSource != null;

        public MapObject DrawingRouteSource { get; private set; }

        private Action<MapObject, Point> DrawingRouteEnded { get; set; }

        public void ShowModal(Window window)
        {
            _modalLayer.Window = window;
        }

        public void StartRouteDrawing(MapObject mapObject, Action<MapObject, Point> onDrawingEnded)
        {
            DrawingRouteSource = mapObject;
            DrawingRouteEnded = onDrawingEnded;
        }

        public void EndRouteDrawing(Point point)
        {
            DrawingRouteEnded?.Invoke(DrawingRouteSource, point);
            DrawingRouteSource = null;
        }
    }
}