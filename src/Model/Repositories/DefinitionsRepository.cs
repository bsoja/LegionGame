using System.Collections.Generic;
using Legion.Model.Types.Definitions;

namespace Legion.Model.Repositories
{
    public class DefinitionsRepository : IDefinitionsRepository
    {
        private readonly IDefinitionsLoader definitionsLoader;

        public DefinitionsRepository(IDefinitionsLoader definitionsLoader)
        {
            this.definitionsLoader = definitionsLoader;

            //TODO: temporary data

            Buildings = new List<BuildingDefinition>();
            Items = new List<ItemDefinition>();
            Creatures = new List<CharacterDefinition>();
            Races = new List<CharacterDefinition>();

            Items.Add(new ItemDefinition() { Id = 1 });

            var raceTypes = definitionsLoader.ReadRaces();
            var creatureTypes = definitionsLoader.ReadCreatures();
            var buildingTypes = definitionsLoader.ReadBuildings();

            Creatures.AddRange(creatureTypes);
            Races.AddRange(raceTypes);
            Buildings.AddRange(buildingTypes);
        }

        public List<BuildingDefinition> Buildings { get; private set; }
        public List<ItemDefinition> Items { get; private set; }
        public List<CharacterDefinition> Creatures { get; private set; }
        public List<CharacterDefinition> Races { get; private set; }
    }
}