using System;
using System.Collections.Generic;
using Legion.Controllers;
using Legion.Model.Types;
using Legion.View.Map;
using Legion.View.Map.Layers;

namespace Legion.View.Map
{
    public class MapMessagesService : IMapMessagesService
    {
        private readonly MessagesLayer messagesLayer;

        public MapMessagesService(MessagesLayer messagesLayer)
        {
            this.messagesLayer = messagesLayer;
        }

        public void ShowMessage(MapMessage mapMessage)
        {
            //TODO handle everything here
            messagesLayer.Show("title", mapMessage.Type.ToString(), mapMessage.OnClose);
        }
    }
}