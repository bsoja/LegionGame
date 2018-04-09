using System;
using System.Collections.Generic;
using Legion.Controllers;
using Legion.Model.Types;

namespace Legion.View.Map
{
    public interface IMapMessagesService
    {
        void ShowMessage(MapMessage mapMessage);
    }
}