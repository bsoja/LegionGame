using Legion.Gui.Elements;
using Legion.Gui.Services;

namespace Legion.Views
{
    public interface ILegionViewsManager : IViewsManager
    {
        View Menu { get; }
        View Map { get; }
        View Terrain { get; }
    }
}