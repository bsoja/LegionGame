namespace Legion.Controllers
{
    public interface ICitiesTurnProcessor
    {
        bool IsProcessingTurn { get; }
        void ProcessTurn();
    }
}