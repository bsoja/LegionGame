using System.Collections.Generic;
using Legion.View.Map;
using Legion.View.Menu;
using Legion.View.Terrain;
using Microsoft.Xna.Framework;

namespace Legion.View
{
    public class ViewsProvider : IViewsProvider
    {
        public ViewsProvider(Game game, MenuView menu, MapView map, TerrainView terrain)
        {
            Menu = menu;
            Map = map;
            Terrain = terrain;

            game.Components.Add(Menu);
            game.Components.Add(Map);
            game.Components.Add(Terrain);
        }

        public View Menu { get; private set; }

        public View Map { get; private set; }

        public View Terrain { get; private set; }
    }
}