using Legion.Model.Types;

namespace Legion.Model
{
    public interface IArmiesTurnProcessor
    {
        bool IsProcessingTurn { get; }
        void NextTurn();
        Army ProcessTurnForNextArmy();
        void OnMoveEnded(Army army);
    }
}