using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Legion.Model;
using Legion.Model.Repositories;
using Legion.Model.Types;

namespace Legion
{
    public interface IGameArchive
    {
        void LoadGame(string path);
    }

    public class GameArchive : IGameArchive
    {
        private readonly IBytesHelper helper;
        private readonly IArmiesRepository armiesRepository;
        private readonly ICitiesRepository citiesRepository;
        private readonly IPlayersRepository playersRepository;
        private readonly IDefinitionsRepository definitionsRepository;

        public GameArchive(IBytesHelper helper,
            IArmiesRepository armiesRepository,
            ICitiesRepository citiesRepository,
            IPlayersRepository playersRepository,
            IDefinitionsRepository definitionsRepository)
        {
            this.helper = helper;
            this.armiesRepository = armiesRepository;
            this.citiesRepository = citiesRepository;
            this.playersRepository = playersRepository;
            this.definitionsRepository = definitionsRepository;
        }

        public void LoadGame(string path)
        {
            var bytes = File.ReadAllBytes(path);
            var pos = 0;

            var archiveName = Encoding.Default.GetString(bytes, pos, 20);
            pos += 20;

            var players = new List<Player>();
            for (var id = 0; id <= 4; id++)
            {
                var player = new Player();
                player.Id = id;
                players.Add(player);
            }

            // Load armies and theirs characters data
            var armies = LoadArmies(bytes, ref pos, players);

            // TODO: Load conflicts info between players
            // 'wojna(5,5)
            pos += 36;

            // Load players info
            LoadPlayers(bytes, ref pos, players);

            // Load armies and theirs characters names
            LoadArmiesNames(bytes, ref pos, armies);

            // Load player names
            LoadPlayerNames(bytes, ref pos, players);

            // TODO: Load preferences
            //'prefs(10) 
            pos += 11;

            // Load cities info
            var cities = LoadCities(bytes, ref pos, players);

            // Load cities names
            LoadCitiesNames(bytes, ref pos, cities);

            // 44535 / 0xADF7

            var currentDay = helper.ReadInt16(bytes, pos);
            pos += 2;
            var currentPower = helper.ReadInt16(bytes, pos);
            pos += 2;

            // TODO: adventures:
            /*
            'przygody(3,10)
            For I=0 To 3
                For J=0 To 10
                    DAT=Deek(MEM)
                    PRZYGODY(I,J)=DAT
                    Add MEM,2
                Next J
            Next I
            'im_przygody$(3) 
            For I=0 To 3
                Gosub _READ_STRING
                IM_PRZYGODY$(I)=DAT$
            Next I
             */

            UpdateTargets(armies, cities);
            UpdateRepositories(armies, cities, players);
        }

        private void UpdateRepositories(List<Army> armies, List<City> cities, List<Player> players)
        {
            armiesRepository.Armies.Clear();
            citiesRepository.Cities.Clear();
            playersRepository.Players.Clear();

            armiesRepository.Armies.AddRange(armies);
            citiesRepository.Cities.AddRange(cities);
            playersRepository.Players.AddRange(players);
            playersRepository.UserPlayer = players[0];
            playersRepository.ChaosPlayer = players[players.Count - 1];
        }

        private List<Army> LoadArmies(byte[] bytes, ref int pos, List<Player> players)
        {
            var armies = new List<Army>();

            // Load Armies and theirs characters
            for (var id = 0; id <= 40; id++)
            {
                var army = new Army();
                army.Id = id;
                army.X = helper.ReadInt16(bytes, pos + 2);
                army.Y = helper.ReadInt16(bytes, pos + 4);
                army.Owner = players[helper.ReadInt16(bytes, pos + 52)];
                army.DaysToGetInfo = helper.ReadInt16(bytes, pos + 60);
                army.Food = helper.ReadInt16(bytes, pos + 24);
                //TODO: later update target object by providing correct reference to existing object
                army.Target = new MapObject()
                {
                    X = helper.ReadInt16(bytes, pos + 10),
                    Y = helper.ReadInt16(bytes, pos + 12)
                };
                army.CurrentAction = (ArmyActions) helper.ReadInt16(bytes, pos + 14);

                pos += 62;

                for (var ch = 1; ch <= 10; ch++)
                {
                    // TODO: handle these properties:
                    // TKLAT=11 : TGLOWA=13 : TKORP=14 : TNOGI=15 : TLEWA=16 : TPRAWA=17 : TPLECAK=18 : TRASA=28 : TWAGA=29 
                    var character = new Character();
                    character.Id = ch;
                    character.EnergyMax = helper.ReadInt16(bytes, pos);
                    character.X = helper.ReadInt16(bytes, pos + 2);
                    character.Y = helper.ReadInt16(bytes, pos + 4);
                    character.Strength = helper.ReadInt16(bytes, pos + 6);
                    character.Speed = helper.ReadInt16(bytes, pos + 8);
                    character.SpeedMax = helper.ReadInt16(bytes, pos + 24);
                    character.TargetX = helper.ReadInt16(bytes, pos + 10);
                    character.TargetY = helper.ReadInt16(bytes, pos + 12);
                    character.CurrentAction = (CharacterActionType) helper.ReadInt16(bytes, pos + 14);
                    character.Energy = helper.ReadInt16(bytes, pos + 16);
                    character.Resistance = helper.ReadInt16(bytes, pos + 18);
                    character.Magic = helper.ReadInt16(bytes, pos + 52);
                    character.MagicMax = helper.ReadInt16(bytes, pos + 60);
                    character.Experience = helper.ReadInt16(bytes, pos + 54);

                    var characterType = helper.ReadInt16(bytes, pos + 56);
                    character.Type = definitionsRepository.Races[characterType];

                    if (character.Energy > 0 && character.EnergyMax > 0)
                    {
                        army.Characters.Add(character);
                    }

                    pos += 62; // 31 properties each have 2 bytes (index start at 0)
                }

                if (army.Characters.Count > 0)
                {
                    armies.Add(army);
                }
            }

            return armies;
        }

        private void LoadPlayers(byte[] bytes, ref int pos, List<Player> players)
        {
            for (var id = 0; id <= 4; id++)
            {
                var player = players[id];
                player.Money = helper.ReadInt32(bytes, pos);
                player.Power = helper.ReadInt32(bytes, pos + 4);
                player.Unknown = helper.ReadInt32(bytes, pos + 8);

                pos += 16;
            }
        }

        private void LoadArmiesNames(byte[] bytes, ref int pos, List<Army> armies)
        {
            for (var id = 0; id <= 40; id++)
            {
                Army army = null;
                var armyName = helper.ReadText(bytes, pos);
                pos += armyName.Length + 1;
                if (!string.IsNullOrEmpty(armyName))
                {
                    army = armies.FirstOrDefault(a => a.Id == id);
                    army.Name = armyName;
                }

                for (var chid = 1; chid <= 10; chid++)
                {
                    var characterName = helper.ReadText(bytes, pos);
                    pos += characterName.Length + 1;
                    if (army != null && !string.IsNullOrEmpty(characterName))
                    {
                        var character = army.Characters.FirstOrDefault(ch => ch.Id == chid);
                        if (character != null)
                        {
                            character.Name = characterName;
                        }
                    }
                }
            }
        }

        private void LoadPlayerNames(byte[] bytes, ref int pos, List<Player> players)
        {
            for (var i = 0; i <= 4; i++)
            {
                var playerName = helper.ReadText(bytes, pos);
                pos += playerName.Length + 1;
                players[i].Name = playerName;
            }
        }

        private List<City> LoadCities(byte[] bytes, ref int pos, List<Player> players)
        {
            var cities = new List<City>();
            // Load cities info
            for (var id = 0; id <= 50; id++)
            {
                var city = new City();
                city.Id = id;
                city.WallType = helper.ReadInt16(bytes, pos);
                city.X = helper.ReadInt16(bytes, pos + 2);
                city.Y = helper.ReadInt16(bytes, pos + 4);
                city.Population = helper.ReadInt16(bytes, pos + 6);
                city.Tax = helper.ReadInt16(bytes, pos + 8);
                city.Owner = players[helper.ReadInt16(bytes, pos + 10)];
                city.Morale = helper.ReadInt16(bytes, pos + 12);
                pos += 14;
                city.DaysToGetInfo = helper.ReadInt16(bytes, pos + 4);
                city.Food = helper.ReadInt16(bytes, pos + 6);
                city.DaysToSetNewRecruiters = helper.ReadInt16(bytes, pos + 8);
                city.Craziness = helper.ReadInt16(bytes, pos + 12);
                pos += 14;

                for (var bid = 2; bid <= 20; bid++)
                {
                    //0, 1 are city info, rest are buildings
                    var building = new Building();
                    building.X = helper.ReadInt16(bytes, pos + 2);
                    building.Y = helper.ReadInt16(bytes, pos + 4);
                    var buildingType = helper.ReadInt16(bytes, pos + 6);
                    //TODO: check if building type is correct
                    if (buildingType > 0 && building.X > 0 && building.Y > 0)
                    {
                        building.Type = definitionsRepository.Buildings[buildingType - 1];
                        city.Buildings.Add(building);
                    }

                    pos += 14;
                }

                //TODO: price modificators for items:
                /*
                    For J=1 To 19
                        MIASTA(I,J,M_MUR)=Rnd(WAHANIA)
                    Next J
                */

                cities.Add(city);
            }
            return cities;
        }

        private void LoadCitiesNames(byte[] bytes, ref int pos, List<City> cities)
        {
            for (var id = 0; id <= 50; id++)
            {
                var name = helper.ReadText(bytes, pos);
                pos += name.Length + 1;
                if (!string.IsNullOrEmpty(name))
                {
                    var city = cities.FirstOrDefault(c => c.Id == id);
                    city.Name = name;
                }
            }
        }

        private void UpdateTargets(List<Army> armies, List<City> cities /*, List<Adventure> adventures */ )
        {
            foreach (var army in armies)
            {
                switch (army.CurrentAction)
                {
                    case ArmyActions.Camping:
                    case ArmyActions.Hunting:
                        army.Target = null;
                        break;
                    case ArmyActions.Move:
                    case ArmyActions.FastMove:
                        army.TargetType = ArmyTargetType.Position;
                        break;
                    case ArmyActions.Attack:
                        var targetId = army.Target.Y;
                        var isCityAttack = army.Target.X > 0;
                        if (isCityAttack)
                        {
                            army.Target = cities.FirstOrDefault(c => c.Id == targetId);
                            army.TargetType = ArmyTargetType.City;
                        }
                        else
                        {
                            army.Target = armies.FirstOrDefault(a => a.Id == targetId);
                            army.TargetType = ArmyTargetType.Army;
                        }
                        break;
                }
            }
        }
    }
}