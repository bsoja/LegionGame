using System.Collections.Generic;
using Legion.Model.Types.Definitions;

namespace Legion.Model
{
    public interface IDefinitionsLoader
    {
        List<CreatureDefinition> ReadCreatures();
        List<RaceDefinition> ReadRaces();
        List<BuildingDefinition> ReadBuildings();
    }
}