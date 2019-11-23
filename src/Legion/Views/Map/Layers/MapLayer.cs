using Gui.Elements;
using Gui.Services;

namespace Legion.Views.Map.Layers
{
    public abstract class MapLayer : Layer
    {
        protected MapLayer(IGuiServices guiServices) : base(guiServices)
        {
        }

        public MapView MapView => (MapView) Parent;
    }
}