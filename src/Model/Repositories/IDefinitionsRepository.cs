using System.Collections.Generic;
using Legion.Model.Types.Definitions;

namespace Legion.Model.Repositories
{
    public interface IDefinitionsRepository
    {
        List<BuildingDefinition> Buildings { get; }
        List<ItemDefinition> Items { get; }
        List<CharacterDefinition> Creatures { get; }
        List<CharacterDefinition> Races { get; }
    }
}