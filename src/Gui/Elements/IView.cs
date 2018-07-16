namespace Legion.Gui.Elements
{
    public interface IView
    {
        bool IsVisible { get; }

        void Initialize();
        void Update();
        void Draw();
    }
}