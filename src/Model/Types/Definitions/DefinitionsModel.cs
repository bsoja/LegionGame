using System.Collections.Generic;

namespace Legion.Model.Types.Definitions
{
    public class DefinitionsModel
    {
        public List<BuildingDefinition> Buildings { get; set; }
        public List<RaceDefinition> Races { get; set; }
        public List<CreatureDefinition> Creatures { get; set; }
        public List<ItemDefinition> Items { get; set; }
    }
}