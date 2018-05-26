using Legion.Gui.Elements;

namespace Legion.Views
{
    public interface IViewsProvider
    {
        View Menu { get; }
        View Map { get; }
        View Terrain { get; }
    }
}