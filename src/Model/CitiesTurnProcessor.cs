using System;
using System.Linq;
using Legion.Model;
using Legion.Model.Repositories;
using Legion.Model.Types;

namespace Legion.Model
{
    public class CitiesTurnProcessor : ICitiesTurnProcessor
    {
        private static readonly Random Rand = new Random();

        private readonly ICitiesRepository citiesRepository;
        private readonly IArmiesRepository armiesRepository;
        private readonly ICityIncidents cityIncidents;

        private int currentTurnCityIdx = -1;

        public CitiesTurnProcessor(ICitiesRepository citiesRepository,
            IArmiesRepository armiesRepository,
            ICityIncidents cityIncidents)
        {
            this.citiesRepository = citiesRepository;
            this.armiesRepository = armiesRepository;
            this.cityIncidents = cityIncidents;
        }

        public bool IsProcessingTurn
        {
            get { return currentTurnCityIdx >= 0; }
        }

        public void NextTurn()
        {
            for (var i = ++currentTurnCityIdx; i < citiesRepository.Cities.Count; i++)
            {
                currentTurnCityIdx = i;
                var city = citiesRepository.Cities[i];
                ProcessTurn(city);
            }
            currentTurnCityIdx = -1;
        }

        private void ProcessTurn(City city)
        {
            if (city.DaysToGetInfo < 25 && city.DaysToGetInfo > 0) city.DaysToGetInfo--;
            if (city.DaysToSetNewRecruiters > 0) city.DaysToSetNewRecruiters--;

            if (Rand.Next(50) == 1 && city.Population > 800)
            {
                cityIncidents.Plague(city);
            }

            if (Rand.Next(5) == 1)
            {
                //TODO: Add MIASTA(M,1,M_MORALE),Rnd(2)-1,0 To 25
                //' V = V + A
                //' V<BASE Then V = TOP
                //' V> TOP Then V = BASE
                var x = city.Craziness + Rand.Next(2) - 1;
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
            var granaries = city.Buildings.Where(b => b.Type.Id == 9);
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
                        cityIncidents.Riot(city);
                    }
                }
                else
                {
                    city.Population += Rand.Next(10) - 2;
                }
            }
        }

        private void ProcessRecruiting(City city)
        {
            if (city.Owner != null && !city.Owner.IsUserControlled)
            {
                if (city.Owner.Money > 10000 && Rand.Next(3) == 1 && city.DaysToSetNewRecruiters == 0)
                {
                    // TODO: set upper limit for player's legion count // For I=20 To 39
                    city.Owner.Money -= 10000;
                    city.DaysToSetNewRecruiters = 20 + Rand.Next(10);
                    var army = armiesRepository.CreateArmy(city.Owner, 10);
                    army.X = city.X;
                    army.Y = city.Y;
                }
            }
        }
    }
}