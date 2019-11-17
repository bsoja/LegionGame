using System.ComponentModel;
using Gui.Elements;
using Gui.Services;
using Legion.Controllers.Map;
using Legion.Views.Map.Controls;

namespace Legion.Views.Map.Layers
{
    public class MapGuiLayer : Layer
    {
        private readonly IMapController _mapController;
        private MapMenu _mapMenu;

        public MapGuiLayer(IGuiServices guiServices,
            IMapController mapController) : base(guiServices)
        {
            _mapController = mapController;
        }

        public override void Initialize()
        {
            _mapMenu = new MapMenu(GuiServices);
            _mapMenu.StartClicked += OnStartClicked;

            AddElement(_mapMenu);
        }

        private void OnStartClicked(HandledEventArgs args)
        {
            args.Handled = true;
            _mapController.NextTurn();
        }
    }
}