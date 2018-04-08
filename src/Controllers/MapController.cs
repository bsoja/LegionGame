using System.Collections.Generic;
using Legion.Model.Repositories;
using Legion.Model.Types;

namespace Legion.Controllers
{
    public class MapController : IMapController
    {
        private readonly ICitiesRepository citiesRepository;
        private readonly IArmiesRepository armiesRepository;

        public MapController(ICitiesRepository citiesRepository, IArmiesRepository armiesRepository)
        {
            this.armiesRepository = armiesRepository;
            this.citiesRepository = citiesRepository;
        }

        public List<City> Cities
        {
            get
            {
                return citiesRepository.Cities;
            }
        }

        public List<Army> Armies
        {
            get { return armiesRepository.Armies; }
        }
    }
}