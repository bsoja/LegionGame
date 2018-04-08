using System.Collections.Generic;
using Legion.Model.Types;
using Legion.Model.Types.Definitions;

namespace Legion.Model.Repositories
{
    public interface IArmiesRepository
    {
        List<Army> Armies { get; }
        Army CreateArmy(Player owner, int charactersCount, CharacterDefinition charactersType = null);
        Army CreateTempArmy(int charactersCount, CharacterDefinition charactersType = null);
        void KillArmy(Army army);
    }
}