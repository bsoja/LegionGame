using System.ComponentModel;
using Legion.Controllers;
using Gui.Elements;
using Legion.Gui.Elements.Map;
using Gui.Services;

namespace Legion.Views.Map.Layers
{
    public class MapGuiLayer : Layer
    {
        private readonly IMapController mapController;
        private MapMenu mapMenu;

        public MapGuiLayer(IGuiServices guiServices,
            IMapController mapController) : base(guiServices)
        {
            this.mapController = mapController;
        }

        public override void Initialize()
        {
            mapMenu = new MapMenu(GuiServices);
            mapMenu.StartClicked += OnStartClicked;

            AddElement(mapMenu);
        }

        private void OnStartClicked(HandledEventArgs args)
        {
            args.Handled = true;
            mapController.NextTurn();
        }
    }
}