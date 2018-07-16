using System.Collections.Generic;
using Legion.Gui.Elements;
using Legion.Views.Map;
using Legion.Views.Menu;
using Legion.Views.Terrain;

namespace Legion.Views
{
    public class ViewsManager : IViewsManager
    {
        private readonly List<IView> _views;

        public View Menu { get; private set; }
        public View Map { get; private set; }
        public View Terrain { get; private set; }

        public ViewsManager(MenuView menuView, MapView mapView, TerrainView terrainView)
        {
            Menu = menuView;
            Map = mapView;
            Terrain = terrainView;

            _views = new List<IView> { menuView, mapView, terrainView };
        }

        public void Initialize()
        {
            foreach (var view in _views)
            {
                view.Initialize();
            }
        }

        public void Update()
        {
            foreach (var view in _views)
            {
                if (view.IsVisible) { view.Update(); }
            }
        }

        public void Draw()
        {
            foreach (var view in _views)
            {
                if (view.IsVisible) { view.Draw(); }
            }
        }
    }
}