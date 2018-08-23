using System.Collections.Generic;
using Gui.Elements;
using Gui.Services;
using Legion.Views.Menu.Layers;

namespace Legion.Views.Menu
{
    public class MenuView : View
    {
        private readonly IEnumerable<Layer> _layers;

        public MenuView(IGuiServices guiServices,
            MenuLayer menuLayer) : base(guiServices)
        {
            _layers = new List<Layer> { menuLayer };
        }

        protected override IEnumerable<Layer> Layers => _layers;
    }
}