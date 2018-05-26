using Legion.Gui.Elements.Map;
using Legion.Model.Types;

namespace Legion.Views.Map
{
    public interface IMapCityGuiFactory
    {
        CityWindow CreateCityWindow(City city);
    }
}