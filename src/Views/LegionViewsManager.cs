using System.Collections.Generic;
using Legion.Gui.Elements;
using Legion.Gui.Services;
using Legion.Views.Map;
using Legion.Views.Menu;
using Legion.Views.Terrain;

namespace Legion.Views
{
    public class LegionViewsManager : ViewsManager, ILegionViewsManager
    {
        private readonly List<View> views;

        public LegionViewsManager(MenuView menuView, MapView mapView, TerrainView terrainView)
        {
            Menu = menuView;
            Map = mapView;
            Terrain = terrainView;

            views = new List<View> { menuView, mapView, terrainView };
        }

        protected override List<View> Views { get { return views; } }

        public View Menu { get; private set; }
        public View Map { get; private set; }
        public View Terrain { get; private set; }
    }
}