using System.Collections.Generic;
using Gui.Elements;
using Gui.Services;
using Legion.Views.Map;
using Legion.Views.Menu;
using Legion.Views.Terrain;

namespace Legion.Views
{
    public class LegionViewsManager : ViewsManager, ILegionViewsManager
    {
        public LegionViewsManager(MenuView menuView, MapView mapView, TerrainView terrainView)
        {
            Menu = menuView;
            Map = mapView;
            Terrain = terrainView;

            Views = new List<View> { menuView, mapView, terrainView };
        }

        protected override List<View> Views { get; set; }

        public View Menu { get; private set; }
        public View Map { get; private set; }
        public View Terrain { get; private set; }
    }
}