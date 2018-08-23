using Legion.Gui.Map;
using Legion.Model.Types;

namespace Legion.Views.Map
{
    public interface IMapCityGuiFactory
    {
        CityWindow CreateCityWindow(City city);
    }
}