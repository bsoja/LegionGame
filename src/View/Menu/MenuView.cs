using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.View.Menu
{
    public class MenuView : View
    {
        private readonly ILayersProvider layersProvider;

        public MenuView(Game game, ILayersProvider layersProvider):
            base(game, layersProvider.GetLayers<MenuView>())
            {
                this.layersProvider = layersProvider;
            }

    }
}