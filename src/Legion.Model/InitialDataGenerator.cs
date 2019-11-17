using System.Collections.Generic;
using System.Linq;
using Legion.Model.Helpers;
using Legion.Model.Repositories;
using Legion.Model.Types;
using Legion.Utils;

namespace Legion.Model
{
    public class InitialDataGenerator : IInitialDataGenerator
    {
        private readonly ILegionConfig _legionConfig;
        private readonly IDefinitionsRepository _definitionsRepository;
        private readonly IArmiesRepository _armiesRepository;
        private readonly IPlayersRepository _playersRepository;
        private readonly ICitiesRepository _citiesRepository;
        private readonly ICitiesHelper _citiesHelper;

        public InitialDataGenerator(ILegionConfig legionConfig,
            IDefinitionsRepository definitionsRepository,
            IArmiesRepository armiesRepository,
            IPlayersRepository playersRepository,
            ICitiesRepository citiesRepository,
            ICitiesHelper citiesHelper)
        {
            _legionConfig = legionConfig;
            _definitionsRepository = definitionsRepository;
            _armiesRepository = armiesRepository;
            _playersRepository = playersRepository;
            _citiesRepository = citiesRepository;
            _citiesHelper = citiesHelper;
        }

        public void Generate()
        {
            GeneratePlayers();
            GenerateCities();
            GenerateArmies();
        }

        private void GeneratePlayers()
        {
            //TODO: currently generate random player names for now, should be provided by user on new game
            for (var i = 1; i <= _legionConfig.PlayersCount; i++)
            {
                _playersRepository.Players.Add(new Player { Id = i, Money = 5000, Name = NamesGenerator.Generate() });
            }

            _playersRepository.UserPlayer = _playersRepository.Players[1];
            _playersRepository.ChaosPlayer = _playersRepository.Players[_playersRepository.Players.Count - 1];
        }

        private void GenerateArmies()
        {
            for (var i = 1; i < _playersRepository.Players.Count - 1; i++)
            {
                var owner = _playersRepository.Players[i];

                var xg = GlobalUtils.Rand(_legionConfig.WorldWidth - 200) + 100;
                var yg = GlobalUtils.Rand(_legionConfig.WorldHeight - 200) + 100;

                for (var k = 0; k <= 2; k++)
                {
                    var army = _armiesRepository.CreateArmy(owner, 10);
                    army.X = xg + GlobalUtils.Rand(200) - 100;
                    army.Y = yg + GlobalUtils.Rand(200) - 100;
                }
            }

            var ownArmy = _armiesRepository.CreateArmy(_playersRepository.UserPlayer, 5);
            ownArmy.X = GlobalUtils.Rand(_legionConfig.WorldWidth) + 20;
            ownArmy.Y = GlobalUtils.Rand(_legionConfig.WorldHeight) + 10;
            ownArmy.Food = 100;
        }

        private City GenerateCity(Player owner)
        {
            var city = new City();
            city.Name = NamesGenerator.Generate();

            do
            {
                //city.X = GlobalUtils.Rand(config.WorldWidth - 50) + 20; // X=Rnd(590)+20
                //city.Y = GlobalUtils.Rand(config.WorldHeight - 52) + 20; // Y=Rnd(460)+20

                city.X = GlobalUtils.Rand(_legionConfig.WorldWidth);
                city.Y = GlobalUtils.Rand(_legionConfig.WorldHeight);
            } while (!IsCityPositionAvailable(city.X, city.Y));

            city.Population = GlobalUtils.Rand(900) + 10;
            city.Owner = owner;
            city.BobId = 8 + (city.Owner != null ? city.Owner.Id : 0) * 2;
            if (city.Population > 700)
            {
                city.BobId++;
                city.WallType = GlobalUtils.Rand(2) + 1;
            }
            else
            {
                city.WallType = GlobalUtils.Rand(1);
            }

            city.Tax = GlobalUtils.Rand(25);
            city.Morale = GlobalUtils.Rand(100);
            //TEREN[X+4,Y+4]
            //city.TerrainType = terrainManager.GetTerrain(city.X + 4, city.Y + 4);
            //if (city.TerrainType == 7) city.TerrainType = 1;

            city.X += 8;
            city.Y += 8;
            city.Craziness = GlobalUtils.Rand(10) + 5;
            city.DaysToGetInfo = 30;

            _citiesHelper.UpdatePriceModificators(city);

            var buildings = GenerateBuildings();
            city.Buildings = buildings;

            return city;
        }

        private void GenerateCities()
        {
            for (var i = 0; i < _legionConfig.MaxCitiesCount; i++)
            {
                Player owner = null;

                // TODO: magic numbers
                if (i == 43 || i == 44) owner = _playersRepository.Players.FirstOrDefault(p => p.Id == 2);
                else if (i == 45 || i == 46) owner = _playersRepository.Players.FirstOrDefault(p => p.Id == 3);
                else if (i == 47 || i == 48) owner = _playersRepository.Players.FirstOrDefault(p => p.Id == 4);

                var city = GenerateCity(owner);
                _citiesRepository.Cities.Add(city);
            }
        }

        private bool IsCityPositionAvailable(int x, int y)
        {
            foreach (var city in _citiesRepository.Cities)
            {
                if ((city.X + 60 >= x && city.X - 60 <= x) && (city.Y + 60 >= y && city.Y - 60 <= y))
                {
                    return false;
                }
            }
            //Paste Bob X,Y,B1
            //Set Zone 70+I,X-20,Y-20 To X+30,Y+30
            //// OR:
            // If Zone(X,Y)=0 and Zone(X+8,Y+8)=0 and Zone(X+4,Y+4)=0
            return true;
        }

        private List<Building> GenerateBuildings()
        {
            var buildings = new List<Building>();
            var x = 50;
            var y = 50;

            for (var i = 0; i < _legionConfig.MaxCityBuildingsCount; i++)
            {
                x += GlobalUtils.Rand(50);
                if (x > 580)
                {
                    x = 50;
                    y = 130 + GlobalUtils.Rand(30);
                }

                var building = GenerateBuilding(x, y);
                buildings.Add(building);

                x += building.Type.Width;
            }

            return buildings;
        }

        private Building GenerateBuilding(int x, int y)
        {
            var building = new Building();
            var type = _definitionsRepository.Buildings[GlobalUtils.Rand(_definitionsRepository.Buildings.Count-1)];
            building.Type = type;

            building.X = x;
            building.Y = y;

            return building;
        }
    }

}