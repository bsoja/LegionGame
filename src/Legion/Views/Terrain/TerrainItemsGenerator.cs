using System;
using System.Collections.Generic;
using Legion.Model.Repositories;
using Legion.Model.Types.Definitions;
using Legion.Utils;

namespace Legion.Views.Terrain
{
    public class TerrainItemsGenerator
    {
        private readonly IDefinitionsRepository _definitionsRepository;

        public TerrainItemsGenerator(IDefinitionsRepository definitionsRepository)
        {
            _definitionsRepository = definitionsRepository;
        }

        public List<TerrainItem> Generate(TerrainType terrainType)
        {
            // TODO: support all types
            return GenerateForest();
        }

        public List<TerrainItem> GenerateForest()
        {
            var items = new List<TerrainItem>();

            for (var i = 1; i <= GlobalUtils.Rand(12) + 1; i++)
            {
                var item = new TerrainItem();
                item.X = GlobalUtils.Rand(47);
                item.Y = GlobalUtils.Rand(3);
                var r = GlobalUtils.Rand(10);
                if (r < 5) item.Type = GetItem("bayLeafHerb"); //co = 37;
                else if (r == 5) item.Type = GetItem("spinachHerb"); //co = 36;
                else if (r == 6) item.Type = GetItem("spinachHerb"); //co = 36;
                else if (r == 7) item.Type = GetItem("sterydiusHerb"); //co = 32;
                else if (r == 8) item.Type = GetItem("sterydiusHerb"); //co = 32;
                else if (r == 9) item.Type = GetItem("commonArrows"); //co = 39; // TODO: arrows, really?
                else if (r == 10) item.Type = null; //co = 0;
                // GLEBA(X,Y)=CO
                items.Add(item);
            }

            return items;
        }

        private ItemDefinition GetItem(string name)
        {
            return _definitionsRepository.Items.Find(i => string.Equals(i.Name, name, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}