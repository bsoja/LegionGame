using Legion.Model.Types;
using Legion.Views.Map.Controls;

namespace Legion.Views.Map
{
    public interface IMapArmyGuiFactory
    {
        ArmyWindow CreateArmyWindow(Army army);
        ArmyOrdersWindow CreateArmyOrdersWindow(Army army);
    }
}