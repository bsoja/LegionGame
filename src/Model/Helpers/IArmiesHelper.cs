using Legion.Model.Types;

namespace Legion.Model.Helpers
{
    public interface IArmiesHelper
    {
        Army FindUserArmyInCity(City city);
        City IsArmyInTheCity(Army army);
        Adventure IsArmyInTheAdventure(Army army);
    }
}