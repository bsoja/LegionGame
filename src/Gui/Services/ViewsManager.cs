using System.Collections.Generic;
using Legion.Gui.Elements;

namespace Legion.Gui.Services
{
    public abstract class ViewsManager : IViewsManager
    {
        protected abstract List<View> Views { get; }

        public void Initialize()
        {
            foreach (var view in Views)
            {
                view.InitializeInternal();
            }
        }

        public void Update()
        {
            foreach (var view in Views)
            {
                if (view.IsVisible) { view.UpdateInternal(); }
            }
        }

        public void Draw()
        {
            foreach (var view in Views)
            {
                if (view.IsVisible) { view.DrawInternal(); }
            }
        }
    }
}