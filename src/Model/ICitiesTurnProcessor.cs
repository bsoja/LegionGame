namespace Legion.Model
{
    public interface ICitiesTurnProcessor
    {
        bool IsProcessingTurn { get; }
        void NextTurn();
    }
}