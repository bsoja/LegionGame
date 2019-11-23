using System;
using Legion.Model.Types;
using Microsoft.Xna.Framework;

namespace Legion.Views.Map
{
    public interface IMapRouteDrawer
    {
        bool IsRouteDrawingForAny { get; }

        bool IsRouteDrawingForPoint { get; }

        bool IsRouteDrawingForMapObject { get; }

        MapObject DrawingRouteSource { get; }

        void StartRouteDrawingForPoint(MapObject mapObject, Action<MapObject, Point> onDrawingEnded);

        void StartRouteDrawingForMapObject(MapObject mapObject, Action<MapObject, MapObject> onDrawingEnded);

        void EndRouteDrawingForPoint(Point point);

        void EndRouteDrawingForMapObject(MapObject mapObject);
    }
}