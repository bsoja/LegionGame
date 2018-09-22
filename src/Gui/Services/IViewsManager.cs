using Gui.Elements;

namespace Gui.Services
{
    public interface IViewsManager
    {
        View CurrentView { get; set; }
        void Initialize();
        void Update();
        void Draw();
    }
}