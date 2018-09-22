using System.ComponentModel;
using Gui.Elements;
using Gui.Services;
using Legion.Views.Map.Controls;
using Legion.Controllers.Map;

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