using System.Collections.Generic;
using Legion.Gui.Elements;
using Legion.Gui.Services;

namespace Legion.Views.Terrain
{
    public class TerrainView : View
    {
        public TerrainView(IGuiServices guiServices) : base(guiServices)
        {
            SetLayers(new List<Layer>());
        }
    }
}