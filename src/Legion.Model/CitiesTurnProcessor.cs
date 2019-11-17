using System.Linq;
using Legion.Model.Repositories;
using Legion.Model.Types;
using Legion.Utils;

namespace Legion.Model
{
    public class CitiesTurnProcessor : ICitiesTurnProcessor
    {
        private readonly ICitiesRepository _citiesRepository;
        private readonly IArmiesRepository _armiesRepository;
        private readonly ICityIncidents _cityIncidents;

        private int _currentTurnCityIdx = -1;

        public CitiesTurnProcessor(ICitiesRepository citiesRepository,
            IArmiesRepository armiesRepository,
            ICityIncidents cityIncidents)
        {
            _citiesRepository = citiesRepository;
            _armiesRepository = armiesRepository;
            _cityIncidents = cityIncidents;
        }

        public bool IsProcessingTurn => _currentTurnCityIdx >= 0;

        public void NextTurn()
        {
            for (var i = ++_currentTurnCityIdx; i < _citiesRepository.Cities.Count; i++)
            {
                _currentTurnCityIdx = i;
                var city = _citiesRepository.Cities[i];
                ProcessTurn(city);
            }
            _currentTurnCityIdx = -1;
        }

        private void ProcessTurn(City city)
        {
            if (city.DaysToGetInfo < 25 && city.DaysToGetInfo > 0) city.DaysToGetInfo--;
            if (city.DaysToSetNewRecruiters > 0) city.DaysToSetNewRecruiters--;

            if (GlobalUtils.Rand(50) == 1 && city.Population > 800)
            {
                _cityIncidents.Plague(city);
            }

            if (GlobalUtils.Rand(5) == 1)
            {
                //TODO: Add MIASTA(M,1,M_MORALE),Rnd(2)-1,0 To 25
                //' V = V + A
                //' V<BASE Then V = TOP
                //' V> TOP Then V = BASE
                var x = city.Craziness + GlobalUtils.Rand(2) - 1;
                if (x < 0) x = 25;
                if (x > 25) x = 0;
                city.Craziness = x;
            }

            ProcessTaxes(city);
            ProcessGranaries(city);
            ProcessPopulation(city);
            ProcessRecruiting(city);
        }

        private void ProcessTaxes(City city)
        {
            if (city.Owner != null)
            {
                city.Owner.Money += city.Tax * city.Population / 25;
            }
        }

        private void ProcessGranaries(City city)
        {
            // obsługa spichlerzy
            //TODO: check if 9 is the Granary
            var granaries = city.Buildings.Where(b => b.Type.Name == "granary");
            if (granaries.Count() > 0)
            {
                var spi = granaries.Count() * 200;
                //If SPI>0 : Add MIASTA(M,1,M_LUDZIE),LUDZIE/15,MIASTA(M,1,M_LUDZIE) To SPI*200 : End If 
                var currentFood = city.Food;
                currentFood += city.Population / 15;
                if (currentFood < city.Population) city.Food = spi;
                if (currentFood > spi) city.Food = currentFood; //?
            }
        }

        private void ProcessPopulation(City city)
        {
            if (city.Owner != null)
            {
                if (city.Owner.IsUserControlled)
                {
                    var population = city.Population + (city.Craziness - city.Tax);
                    var morale = city.Morale + (city.Craziness - city.Tax);

                    if (morale > 150) morale = 150;
                    if (population < 30) population = 30;
                    city.Population = population;
                    city.Morale = morale;

                    if (morale <= 0)
                    {
                        _cityIncidents.Riot(city);
                    }
                }
                else
                {
                    city.Population += GlobalUtils.Rand(10) - 2;
                }
            }
        }

        private void ProcessRecruiting(City city)
        {
            // NOTE: some old game saves have cities which belongs to owner with id == zero
            if (city.Owner != null && !city.Owner.IsUserControlled && city.Owner.Id > 0)
            {
                if (city.Owner.Money > 10000 &&GlobalUtils.Rand(3) == 1 && city.DaysToSetNewRecruiters == 0)
                {
                    // TODO: set upper limit for player's legion count // For I=20 To 39
                    city.Owner.Money -= 10000;
                    city.DaysToSetNewRecruiters = 20 + GlobalUtils.Rand(10);
                    var army = _armiesRepository.CreateArmy(city.Owner, 10);
                    army.X = city.X;
                    army.Y = city.Y;
                }
            }
        }
    }
}