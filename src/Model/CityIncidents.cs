using System;
using System.Collections.Generic;
using Legion.Model.Helpers;
using Legion.Model.Repositories;
using Legion.Model.Types;
using Legion.View.Map;

namespace Legion.Model
{
    public class CityIncidents : ICityIncidents
    {
        private static readonly Random Rand = new Random();

        private readonly IStateController stateController;
        private readonly IArmiesRepository armiesRepository;
        private readonly ICharactersRepository charactersRepository;
        private readonly IDefinitionsRepository definitionsRepository;
        private readonly IArmiesHelper armiesHelper;
        private readonly IMapMessagesService mapMessagesService;

        public CityIncidents(IStateController stateController,
            IArmiesRepository armiesRepository,
            ICharactersRepository charactersRepository,
            IDefinitionsRepository definitionsRepository,
            IArmiesHelper armiesHelper,
            IMapMessagesService mapMessagesService)
        {
            this.stateController = stateController;
            this.armiesRepository = armiesRepository;
            this.charactersRepository = charactersRepository;
            this.definitionsRepository = definitionsRepository;
            this.armiesHelper = armiesHelper;
            this.mapMessagesService = mapMessagesService;
        }

        public void Plague(City city)
        {
            var type = Rand.Next(4);

            if (type == 0)
            {
                city.Population -= city.Population / 4;
                if (city.Population < 50) city.Population = 50;
                for (var i = 2; i <= 20; i++)
                {
                    if (Rand.Next(2) == 1)
                    {
                        city.Population = 0;
                    }
                }

                var fireMessage = new MapMessage();
                fireMessage.Type = MapMessageType.FireBurnsPeopleAndCity;
                fireMessage.MapObjects = new List<MapObject> { city };
                mapMessagesService.ShowMessage(fireMessage);
            }
            else if (type == 1)
            {
                city.Population -= city.Population / 2;
                if (city.Population < 50) city.Population = 50;

                var epidemyMessage = new MapMessage();
                epidemyMessage.Type = MapMessageType.EpidemyInsideCity;
                epidemyMessage.MapObjects = new List<MapObject> { city };
                mapMessagesService.ShowMessage(epidemyMessage);
            }
            else if (type == 2)
            {
                city.Food = 0;

                var ratsMessage = new MapMessage();
                ratsMessage.Type = MapMessageType.AllFoodsEatenByRats;
                ratsMessage.MapObjects = new List<MapObject> { city };
                mapMessagesService.ShowMessage(ratsMessage);
            }
        }

        public void Riot(City city)
        {
            var userArmy = armiesHelper.FindUserArmyInCity(city);
            if (userArmy == null)
            {
                city.Owner = null;
                city.Morale = 30;
                //TODO: //CENTER[MIASTA(M, 0, M_X), MIASTA(M, 0, M_Y), 1]
                var riotMessage = new MapMessage();
                riotMessage.Type = MapMessageType.RiotInTheCity;
                riotMessage.MapObjects = new List<MapObject> { city };
                mapMessagesService.ShowMessage(riotMessage);
                return;
            }

            //TODO: CENTER[MIASTA(M, 0, M_X), MIASTA(M, 0, M_Y), 1]

            // there is user army in city and can fight with rebels
            var villagersCount = 2 + Rand.Next(3);
            var count = (city.Population / 70) + 1;
            if (count > 10) count = 10;
            count -= villagersCount;

            var rebelArmy = armiesRepository.CreateTempArmy(count);
            //'wieśniacy wśród buntowników 
            for (var i = 0; i <= villagersCount; i++)
            {
                // TODO: check if 9 is villager
                var villager = charactersRepository.CreateCharacter(definitionsRepository.Characters.Find(c => c.Id == 10));
                rebelArmy.Characters.Add(villager);
            }

            //TODO: BITWA[_ATAK,40,1,1,0,1,1,1,TEREN,M]
            var battleContext = new TerrainActionContext();
            battleContext.UserArmy = userArmy;
            battleContext.EnemyArmy = rebelArmy;
            battleContext.Type = TerrainActionType.Battle;
            battleContext.ActionAfter = () =>
            {
                city.Population -= city.Population / 4;

                if (rebelArmy.IsKilled)
                {
                    city.Morale = 50;
                    city.Craziness = Rand.Next(4) + 5;
                }
                else
                {
                    var successMessage = new MapMessage();
                    successMessage.Type = MapMessageType.RiotInTheCitySuccess;
                    successMessage.MapObjects = new List<MapObject> { city };
                    mapMessagesService.ShowMessage(successMessage);
                }
            };

            var defenceMessage = new MapMessage();
            defenceMessage.Type = MapMessageType.RiotInTheCityWithDefence;
            defenceMessage.MapObjects = new List<MapObject> { city, userArmy };
            defenceMessage.OnClose = () =>
            {
                stateController.EnterTerrainAction(battleContext);
            };
            mapMessagesService.ShowMessage(defenceMessage);
        }
    }
}