using System;
using Gui.Elements;
using Legion.Model.Types;
using Microsoft.Xna.Framework;

namespace Legion.Views.Map
{
    public interface IMapServices
    {
        void ShowModal(Window window);

        bool IsRouteDrawing { get; }

        MapObject DrawingRouteSource { get; }

        void StartRouteDrawing(MapObject mapObject, Action<MapObject, Point> onDrawingEnded);

        void EndRouteDrawing(Point point);
    }
}