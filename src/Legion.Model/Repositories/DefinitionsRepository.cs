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
        private DefinitionsModel _model;

        public DefinitionsRepository()
        {
            Load();
        }

        private void Load()
        {
            var modelJson = File.ReadAllText(FilePath);

            _model = JsonConvert.DeserializeObject<DefinitionsModel>(modelJson);
            if (_model == null)
            {
                throw new Exception("Unable to load main game model");
            }
        }

        public List<BuildingDefinition> Buildings
        {
            get { return _model.Buildings; }
        }

        public List<ItemDefinition> Items
        {
            get { return _model.Items; }
        }

        public List<CreatureDefinition> Creatures
        {
            get { return _model.Creatures; }
        }

        public List<RaceDefinition> Races
        {
            get { return _model.Races; }
        }
    }
}