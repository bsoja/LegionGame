using System.Collections.Generic;
using Legion.Model;
using Legion.Model.Repositories;
using Legion.Model.Types;

namespace Legion.Controllers.Map
{
    public class MapController : IMapController
    {
        private readonly ICitiesRepository _citiesRepository;
        private readonly IArmiesRepository _armiesRepository;
        private readonly ICitiesTurnProcessor _citiesTurnProcessor;
        private readonly IArmiesTurnProcessor _armiesTurnProcessor;

        public MapController(ICitiesRepository citiesRepository,
            IArmiesRepository armiesRepository,
            ICitiesTurnProcessor citiesTurnProcessor,
            IArmiesTurnProcessor armiesTurnProcessor)
        {
            _citiesRepository = citiesRepository;
            _armiesRepository = armiesRepository;
            _citiesTurnProcessor = citiesTurnProcessor;
            _armiesTurnProcessor = armiesTurnProcessor;
        }

        public List<City> Cities => _citiesRepository.Cities;

        public List<Army> Armies => _armiesRepository.Armies;

        public bool IsProcessingTurn => _armiesTurnProcessor.IsProcessingTurn;

        public void NextTurn()
        {
            if (!_citiesTurnProcessor.IsProcessingTurn && !_armiesTurnProcessor.IsProcessingTurn)
            {
                _citiesTurnProcessor.NextTurn();
                _armiesTurnProcessor.NextTurn();
            }
        }

        public Army ProcessTurnForNextArmy()
        {
            return _armiesTurnProcessor.ProcessTurnForNextArmy();
        }

        public void OnMoveEnded(Army army)
        {
            _armiesTurnProcessor.OnMoveEnded(army);
        }

    }
}