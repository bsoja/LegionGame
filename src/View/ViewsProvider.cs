using System;
using System.Collections.Generic;
using System.Linq;
using Legion.View.Map;
using Legion.View.Menu;
using Legion.View.Terrain;
using Microsoft.Xna.Framework;

namespace Legion.View
{
    public class ViewsProvider : IViewsProvider
    {
        private readonly Game game;

        public ViewsProvider(Game game)
        {
            this.game = game;
        }

        private View GetView(Type viewType)
        {
            return (View) game.Components.First(component => component.GetType() == viewType);
        }

        public View Menu
        {
            get { return GetView(typeof(MenuView)); }
        }

        public View Map
        {
            get { return GetView(typeof(MapView)); }
        }

        public View Terrain
        {
            get { return GetView(typeof(TerrainView)); }
        }
    }
}