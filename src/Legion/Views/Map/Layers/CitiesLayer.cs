using Gui.Elements;
using Gui.Services;
using Legion.Controllers.Map;
using Legion.Views.Map.Controls;

namespace Legion.Views.Map.Layers
{
    public class CitiesLayer : Layer
    {
        private readonly IMapServices _mapServices;
        private readonly IMapController _mapController;
        private readonly IMapCityGuiFactory _cityGuiFactory;

        public CitiesLayer(
            IGuiServices guiServices,
            IMapServices mapServices,
            IMapController mapController,
            IMapCityGuiFactory cityGuiFactory) : base(guiServices)
        {
            _mapServices = mapServices;
            _mapController = mapController;
            _cityGuiFactory = cityGuiFactory;
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
                    var cityWindow = _cityGuiFactory.CreateCityWindow(city);
                    _mapServices.ShowModal(cityWindow);
                    args.Handled = true;
                };
                AddElement(element);
            }
        }
    }
}