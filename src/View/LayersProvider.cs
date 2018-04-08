using System.Collections.Generic;
using Legion.View.Map;
using Legion.View.Menu;
using Legion.View.Terrain;

namespace Legion.View
{
    public class LayersProvider : ILayersProvider
    {
        private List<Layer> mapLayers;
        private List<Layer> menuLayers;
        private List<Layer> terrainLayers;

        public LayersProvider(
            // Map layers
            MapLayer mapLayer,
            CitiesLayer citiesLayer,
            ArmiesLayer armiesLayer,
            MapGuiLayer guiLayer,
            MessagesLayer messagesLayer,
            // Menu layers:
            MenuLayer menuLayer
            // Terrain layers:
        )
        {
            mapLayers = new List<Layer>
            {
                mapLayer,
                citiesLayer,
                armiesLayer,
                guiLayer,
                messagesLayer
            };

            menuLayers = new List<Layer>
            {
                menuLayer
            };

            terrainLayers = new List<Layer> { };
        }
        public List<Layer> GetLayers<T>() where T : View
        {
            var type = typeof(T);
            if (type == typeof(MapView))
            {
                return mapLayers;
            }
            else if (type == typeof(MenuView))
            {
                return menuLayers;
            }
            else if (type == typeof(TerrainView))
            {
                return terrainLayers;
            }
            else
            {
                throw new System.Exception("Layers not found for View.");
            }
        }
    }
}