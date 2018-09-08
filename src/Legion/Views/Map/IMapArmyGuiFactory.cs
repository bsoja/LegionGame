using Legion.Gui.Map;
using Legion.Model.Types;

namespace Legion.Views.Map
{
    public interface IMapArmyGuiFactory
    {
        ArmyWindow CreateArmyWindow(Army army);
        ArmyOrdersWindow CreateArmyOrdersWindow(Army army);
    }
}