using Gui.Elements;
using Gui.Services;
using Legion.Controllers.Map;
using Legion.Views.Map.Controls;

namespace Legion.Views.Map.Layers
{
    public class CitiesLayer : Layer
    {
        private readonly IMapController _mapController;
        private readonly ModalLayer _modalLayer;

        public CitiesLayer(IGuiServices guiServices,
            IMapController mapController,
            ModalLayer modalLayer) : base(guiServices)
        {
            _mapController = mapController;
            _modalLayer = modalLayer;
        }

        public override void OnShow()
        {
            base.OnShow();
            
            ClearElements();

            foreach (var city in _mapController.Cities)
            {
                var element = new CityElement(GuiServices, city);
                element.Clicked += args =>
                {
                    _modalLayer.ShowCityWindow(city);
                    args.Handled = true;
                };
                AddElement(element);
            }
        }
    }
}