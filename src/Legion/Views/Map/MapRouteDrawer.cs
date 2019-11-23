using System;
using Legion.Model.Types;
using Microsoft.Xna.Framework;

namespace Legion.Views.Map
{
    public class MapRouteDrawer : IMapRouteDrawer
    {
        public bool IsRouteDrawingForAny => IsRouteDrawingForPoint || IsRouteDrawingForMapObject;

        public bool IsRouteDrawingForPoint { get; private set; }

        public bool IsRouteDrawingForMapObject { get; private set; }

        public MapObject DrawingRouteSource { get; private set; }

        private Action<MapObject, Point> DrawingRouteForPointEnded { get; set; }

        private Action<MapObject, MapObject> DrawingRouteForMapObjectEnded { get; set; }


        public void StartRouteDrawingForPoint(MapObject mapObject, Action<MapObject, Point> onDrawingEnded)
        {
            DrawingRouteSource = mapObject;
            DrawingRouteForPointEnded = onDrawingEnded;
            IsRouteDrawingForPoint = true;
            IsRouteDrawingForMapObject = false;
        }

        public void StartRouteDrawingForMapObject(MapObject mapObject, Action<MapObject, MapObject> onDrawingEnded)
        {
            DrawingRouteSource = mapObject;
            DrawingRouteForMapObjectEnded = onDrawingEnded;
            IsRouteDrawingForPoint = false;
            IsRouteDrawingForMapObject = true;
        }

        public void EndRouteDrawingForPoint(Point point)
        {
            DrawingRouteForPointEnded?.Invoke(DrawingRouteSource, point);
            DrawingRouteSource = null;
            IsRouteDrawingForPoint = false;
        }

        public void EndRouteDrawingForMapObject(MapObject mapObject)
        {
            DrawingRouteForMapObjectEnded?.Invoke(DrawingRouteSource, mapObject);
            DrawingRouteSource = null;
            IsRouteDrawingForMapObject = false;
        }
    }
}