using System;
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
        private static readonly Random Rand = new Random();
        private readonly ILegionConfig legionConfig;
        private readonly IDefinitionsRepository definitionsRepository;
        private readonly IArmiesRepository armiesRepository;
        private readonly IPlayersRepository playersRepository;
        private readonly ICitiesRepository citiesRepository;
        private readonly ICitiesHelper citiesHelper;

        public InitialDataGenerator(ILegionConfig legionConfig,
            IDefinitionsRepository definitionsRepository,
            IArmiesRepository armiesRepository,
            IPlayersRepository playersRepository,
            ICitiesRepository citiesRepository,
            ICitiesHelper citiesHelper)
        {
            this.legionConfig = legionConfig;
            this.definitionsRepository = definitionsRepository;
            this.armiesRepository = armiesRepository;
            this.playersRepository = playersRepository;
            this.citiesRepository = citiesRepository;
            this.citiesHelper = citiesHelper;
        }

        public void GenerateAll()
        {
            GeneratePlayers();
            GenerateCities();
            GenerateArmies();
        }

        private void GeneratePlayers()
        {
            //TODO: currently generate random player names for now, should be provided by user on new game
            for (var i = 1; i <= legionConfig.PlayersCount; i++)
            {
                playersRepository.Players.Add(new Player { Id = i, Money = 5000, Name = NamesGenerator.Generate() });
            }

            playersRepository.UserPlayer = playersRepository.Players[0];
            playersRepository.ChaosPlayer = playersRepository.Players[playersRepository.Players.Count - 1];
        }

        private void GenerateArmies()
        {
            for (var i = 1; i < playersRepository.Players.Count - 1; i++)
            {
                var owner = playersRepository.Players[i];

                var xg = Rand.Next(legionConfig.WorldWidth - 200) + 100;
                var yg = Rand.Next(legionConfig.WorldHeight - 200) + 100;

                for (var k = 0; k <= 2; k++)
                {
                    var army = armiesRepository.CreateArmy(owner, 10);
                    army.X = xg + Rand.Next(200) - 100;
                    army.Y = yg + Rand.Next(200) - 100;
                }
            }

            var ownArmy = armiesRepository.CreateArmy(playersRepository.UserPlayer, 5);
            ownArmy.X = Rand.Next(legionConfig.WorldWidth) + 20;
            ownArmy.Y = Rand.Next(legionConfig.WorldHeight) + 10;
            ownArmy.Food = 100;
        }

        private City GenerateCity(Player owner)
        {
            var city = new City();
            city.Name = NamesGenerator.Generate();

            do
            {
                //city.X = Rand.Next(config.WorldWidth - 50) + 20; // X=Rnd(590)+20
                //city.Y = Rand.Next(config.WorldHeight - 52) + 20; // Y=Rnd(460)+20

                city.X = Rand.Next(legionConfig.WorldWidth);
                city.Y = Rand.Next(legionConfig.WorldHeight);
            } while (!IsCityPositionAvailable(city.X, city.Y));

            city.Population = Rand.Next(900) + 10;
            city.Owner = owner;
            city.BobId = 8 + (city.Owner != null ? city.Owner.Id : 0) * 2;
            if (city.Population > 700)
            {
                city.BobId++;
                city.WallType = Rand.Next(3) + 1;
            }
            else
            {
                city.WallType = Rand.Next(2);
            }

            city.Tax = Rand.Next(25);
            city.Morale = Rand.Next(100);
            //TEREN[X+4,Y+4]
            //city.TerrainType = terrainManager.GetTerrain(city.X + 4, city.Y + 4);
            //if (city.TerrainType == 7) city.TerrainType = 1;

            city.X += 8;
            city.Y += 8;
            city.Craziness = Rand.Next(10) + 5;
            city.DaysToGetInfo = 30;

            citiesHelper.UpdatePriceModificators(city);

            var buildings = GenerateBuildings();
            city.Buildings = buildings;

            return city;
        }

        private void GenerateCities()
        {
            for (var i = 0; i < legionConfig.MaxCitiesCount; i++)
            {
                Player owner = null;

                // TODO: magic numbers
                if (i == 43 || i == 44) owner = playersRepository.Players.FirstOrDefault(p => p.Id == 2);
                else if (i == 45 || i == 46) owner = playersRepository.Players.FirstOrDefault(p => p.Id == 3);
                else if (i == 47 || i == 48) owner = playersRepository.Players.FirstOrDefault(p => p.Id == 4);

                var city = GenerateCity(owner);
                citiesRepository.Cities.Add(city);
            }
        }

        private bool IsCityPositionAvailable(int x, int y)
        {
            foreach (var city in citiesRepository.Cities)
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

            for (var i = 0; i < legionConfig.MaxCityBuildingsCount; i++)
            {
                x += Rand.Next(50);
                if (x > 580)
                {
                    x = 50;
                    y = 130 + Rand.Next(30);
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
            var type = definitionsRepository.Buildings[Rand.Next(definitionsRepository.Buildings.Count)];
            building.Type = type;

            building.X = x;
            building.Y = y;

            return building;
        }
    }

}