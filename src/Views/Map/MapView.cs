using System.Collections.Generic;
using Legion.Gui.Elements;
using Legion.Gui.Services;
using Legion.Views.Map.Layers;

namespace Legion.Views.Map
{
    public class MapView : View
    {
        public MapView(IGuiServices guiServices,
            MapLayer mapLayer,
            CitiesLayer citiesLayer,
            ArmiesLayer armiesLayer,
            MapGuiLayer mapGuiLayer,
            MessagesLayer messagesLayer) : base(guiServices)
        {
            SetLayers(new List<Layer> { mapLayer, citiesLayer, armiesLayer, mapGuiLayer, messagesLayer });
        }
    }
}