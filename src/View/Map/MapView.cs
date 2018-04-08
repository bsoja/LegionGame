using System;
using Legion.Controllers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.View.Map
{
    public class MapView : View
    {
        private readonly ILayersProvider layersProvider;
        private readonly IMapController mapController;

        public MapView(Game game, ILayersProvider layersProvider, IMapController mapController):
            base(game, layersProvider.GetLayers<MapView>())
            {
                this.layersProvider = layersProvider;
                this.mapController = mapController;
            }

        protected override void LoadContent()
        {
            base.LoadContent();
        }
    }
}