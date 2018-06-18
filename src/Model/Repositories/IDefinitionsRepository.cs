using System.Collections.Generic;
using Legion.Model.Types.Definitions;

namespace Legion.Model.Repositories
{
    public interface IDefinitionsRepository
    {
        List<BuildingDefinition> Buildings { get; }
        List<ItemDefinition> Items { get; }
        List<CreatureDefinition> Creatures { get; }
        List<RaceDefinition> Races { get; }
    }
}