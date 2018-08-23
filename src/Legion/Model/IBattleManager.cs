using Legion.Model.Types;

namespace Legion.Model
{
    public interface IBattleManager
    {
        void AttackOnArmy(Army army, Army targetArmy);
        void AttackOnCity(Army army, City city);
    }
}