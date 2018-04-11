namespace Legion.Controllers
{
    public interface IArmiesTurnProcessor
    {
        bool IsProcessingTurn { get; }
        void ProcessTurn();
    }
}