using Legion.Model.Types;
using Legion.Views.Map.Controls;

namespace Legion.Views.Map
{
    public interface IMapCityGuiFactory
    {
        CityWindow CreateCityWindow(City city);
        CityOrdersWindow CreateCityOrdersWindow(City city);
    }
}