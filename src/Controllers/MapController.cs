using System;
using System.Collections.Generic;
using Legion.Model;
using Legion.Model.Repositories;
using Legion.Model.Types;

namespace Legion.Controllers
{
    public class MapController : IMapController
    {
        private static readonly Random Rand = new Random();

        private readonly ICitiesRepository citiesRepository;
        private readonly IArmiesRepository armiesRepository;
        private readonly ICitiesTurnProcessor citiesTurnProcessor;
        private readonly IArmiesTurnProcessor armiesTurnProcessor;

        public MapController(ICitiesRepository citiesRepository,
            IArmiesRepository armiesRepository,
            ICitiesTurnProcessor citiesTurnProcessor,
            IArmiesTurnProcessor armiesTurnProcessor)
        {
            this.citiesRepository = citiesRepository;
            this.armiesRepository = armiesRepository;
            this.citiesTurnProcessor = citiesTurnProcessor;
            this.armiesTurnProcessor = armiesTurnProcessor;
        }

        public List<City> Cities
        {
            get { return citiesRepository.Cities; }
        }

        public List<Army> Armies
        {
            get { return armiesRepository.Armies; }
        }

        public void NextTurn()
        {
            if (!citiesTurnProcessor.IsProcessingTurn && !armiesTurnProcessor.IsProcessingTurn)
            {
                citiesTurnProcessor.NextTurn();
                armiesTurnProcessor.NextTurn();
            }
        }

    }
}