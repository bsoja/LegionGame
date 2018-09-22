using System.Collections.Generic;
using Gui.Elements;

namespace Gui.Services
{
    public abstract class ViewsManager : IViewsManager
    {
        protected abstract List<View> Views { get; set; }

        private View currentView;
        public View CurrentView
        {
            get { return currentView; }
            set
            {
                if (currentView != value)
                {
                    foreach (var view in Views)
                    {
                        view.IsVisible = false;
                    }
                    currentView = value;
                    currentView.IsVisible = true;
                }
            }
        }

        public void Initialize()
        {
            foreach (var view in Views)
            {
                view.InitializeInternal();
            }
        }

        public void Update()
        {
            CurrentView.UpdateInternal();

            // foreach (var view in Views)
            // {
            //     if (view.IsVisible) { view.UpdateInternal(); }
            // }
        }

        public void Draw()
        {
            CurrentView.DrawInternal();

            // foreach (var view in Views)
            // {
            //     if (view.IsVisible) { view.DrawInternal(); }
            // }
        }
    }
}