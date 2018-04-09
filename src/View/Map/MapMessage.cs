using System;
using System.Collections.Generic;
using Legion.Model.Types;

namespace Legion.View.Map
{
    public class MapMessage
    {
        public MapMessageType Type { get; set; }
        public List<MapObject> MapObjects { get; set; }
        public Action OnClose { get; set; }
    }
}