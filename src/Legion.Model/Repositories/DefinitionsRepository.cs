using System;
using System.Collections.Generic;
using System.IO;
using Legion.Model.Types.Definitions;
using Newtonsoft.Json;

namespace Legion.Model.Repositories
{
    public class DefinitionsRepository : IDefinitionsRepository
    {
        private static readonly string FilePath = Path.Combine("data", "model.json");
        private DefinitionsModel model;

        public DefinitionsRepository()
        {
            Load();
        }

        private void Load()
        {
            var modelJson = File.ReadAllText(FilePath);

            model = JsonConvert.DeserializeObject<DefinitionsModel>(modelJson);
            if (model == null)
            {
                throw new Exception("Unable to load main game model");
            }
        }

        public List<BuildingDefinition> Buildings
        {
            get { return model.Buildings; }
        }

        public List<ItemDefinition> Items
        {
            get { return model.Items; }
        }

        public List<CreatureDefinition> Creatures
        {
            get { return model.Creatures; }
        }

        public List<RaceDefinition> Races
        {
            get { return model.Races; }
        }
    }
}