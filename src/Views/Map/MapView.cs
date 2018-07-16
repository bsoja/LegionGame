using System.Collections.Generic;
using Legion.Gui.Elements;
using Legion.Gui.Services;
using Legion.Views.Map.Layers;

namespace Legion.Views.Map
{
    public class MapView : View
    {
        private readonly IEnumerable<Layer> _layers;

        public MapView(IGuiServices guiServices,
            MapLayer mapLayer,
            CitiesLayer citiesLayer,
            ArmiesLayer armiesLayer,
            MapGuiLayer mapGuiLayer,
            ModalLayer messagesLayer) : base(guiServices)
        {
            _layers = new List<Layer> { mapLayer, citiesLayer, armiesLayer, mapGuiLayer, messagesLayer };
        }

        protected override IEnumerable<Layer> Layers => _layers;
    }
}