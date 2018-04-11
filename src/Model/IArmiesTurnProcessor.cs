namespace Legion.Model
{
    public interface IArmiesTurnProcessor
    {
        bool IsProcessingTurn { get; }
        void ProcessTurn();
    }
}