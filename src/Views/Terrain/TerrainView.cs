using System.Collections.Generic;
using Legion.Gui.Elements;
using Legion.Gui.Services;

namespace Legion.Views.Terrain
{
    public class TerrainView : View
    {
        private readonly IEnumerable<Layer> _layers;

        public TerrainView(IGuiServices guiServices) : base(guiServices)
        {
            _layers = new List<Layer>();
        }

        protected override IEnumerable<Layer> Layers => _layers;
    }
}