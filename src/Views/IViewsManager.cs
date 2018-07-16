using Legion.Gui.Elements;

namespace Legion.Views
{
    public interface IViewsManager
    {
        View Menu { get; }
        View Map { get; }
        View Terrain { get; }
        
        void Initialize();
        void Update();
        void Draw();
    }
}