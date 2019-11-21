using Legion.Model.Types;
using Legion.Views.Map.Controls;

namespace Legion.Views.Map
{
    public interface ICommonMapGuiFactory
    {
        BuyInformationWindow CreateBuyInformationWindow(MapObject target);
    }
}