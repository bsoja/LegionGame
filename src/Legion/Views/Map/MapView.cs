using System.Collections.Generic;
using Gui.Elements;
using Gui.Services;
using Legion.Views.Map.Layers;

namespace Legion.Views.Map
{
    public class MapView : View
    {
        public MapView(IGuiServices guiServices,
            MapBackgroundLayer mapLayer,
            CitiesLayer citiesLayer,
            ArmiesLayer armiesLayer,
            MapGuiLayer mapGuiLayer,
            DrawingLayer drawingLayer,
            ModalLayer messagesLayer) : base(guiServices)
        {
            Layers = new List<MapLayer> {mapLayer, citiesLayer, armiesLayer, mapGuiLayer, drawingLayer, messagesLayer};
        }

        protected override IEnumerable<Layer> Layers { get; }


        
    }
}