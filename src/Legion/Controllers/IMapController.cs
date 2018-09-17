using System.Collections.Generic;
using Legion.Model.Types;

namespace Legion.Controllers
{
    public interface IMapController
    {
        List<City> Cities { get; }
        List<Army> Armies { get; }
        bool IsProcessingTurn { get; }

        void NextTurn();
        Army ProcessTurnForNextArmy();
        void OnMoveEnded(Army army);
    }
}