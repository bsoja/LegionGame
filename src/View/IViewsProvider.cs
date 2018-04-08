namespace Legion.View
{
    public interface IViewsProvider
    {
        View Menu { get; }
        View Map { get; }
        View Terrain { get; }
    }
}