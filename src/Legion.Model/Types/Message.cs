using System;
using System.Collections.Generic;

namespace Legion.Model.Types
{
    public class Message
    {
        public MessageType Type { get; set; }
        public List<MapObject> MapObjects { get; set; }
        public Action OnClose { get; set; }
    }
}