using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Legion.Model.Types.Definitions;
using Newtonsoft.Json;

namespace Legion.Model.Repositories
{
    public class DefinitionsRepository : IDefinitionsRepository
    {
        private static readonly string FilePath = Path.Combine("data", "model.json");
        private static readonly string OldModelMappingFilePath = Path.Combine("data", "old.model.mapping.json");
        private DefinitionsModel _model;
        private OldModelMappings _mappings;

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
                throw new Exception("Unable to load main game model!");
            }

            var mappingsJson = File.ReadAllText(OldModelMappingFilePath);
            _mappings = JsonConvert.DeserializeObject<OldModelMappings>(mappingsJson);
            if (_mappings == null)
            {
                throw new Exception("Unable to load main game model mappings!");
            }
        }

        public List<BuildingDefinition> Buildings => _model.Buildings;

        public List<ItemDefinition> Items => _model.Items;

        public List<CreatureDefinition> Creatures => _model.Creatures;

        public List<RaceDefinition> Races => _model.Races;

        public ItemDefinition GetItemByOldIndex(int index)
        {
            var mapping = _mappings.Items.FirstOrDefault(m => m.Index == index);
            if (mapping != null)
            {
                var item = Items.FirstOrDefault(i => i.Name.Equals(mapping.Name));
                return item;
            }
            return null;
        }
    }
}