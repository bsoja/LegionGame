using System.Collections.Generic;
using Legion.Gui.Elements;
using Legion.Gui.Services;
using Legion.Views.Menu.Layers;

namespace Legion.Views.Menu
{
    public class MenuView : View
    {
        public MenuView(IGuiServices guiServices,
            MenuLayer menuLayer) : base(guiServices)
        {
            SetLayers(new List<Layer> { menuLayer });
        }
    }
}