using System;
using System.Collections.Generic;
using Legion.Model.Helpers;
using Legion.Model.Repositories;
using Legion.Model.Types;

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
        private readonly IMessagesService messagesService;

        public CityIncidents(IStateController stateController,
            IArmiesRepository armiesRepository,
            ICharactersRepository charactersRepository,
            IDefinitionsRepository definitionsRepository,
            IArmiesHelper armiesHelper,
            IMessagesService messagesService)
        {
            this.stateController = stateController;
            this.armiesRepository = armiesRepository;
            this.charactersRepository = charactersRepository;
            this.definitionsRepository = definitionsRepository;
            this.armiesHelper = armiesHelper;
            this.messagesService = messagesService;
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

                var fireMessage = new Message();
                fireMessage.Type = TextType.FireBurnsPeopleAndCity;
                fireMessage.MapObjects = new List<MapObject> { city };
                messagesService.ShowMessage(fireMessage);
            }
            else if (type == 1)
            {
                city.Population -= city.Population / 2;
                if (city.Population < 50) city.Population = 50;

                var epidemyMessage = new Message();
                epidemyMessage.Type = TextType.EpidemyInsideCity;
                epidemyMessage.MapObjects = new List<MapObject> { city };
                messagesService.ShowMessage(epidemyMessage);
            }
            else if (type == 2)
            {
                city.Food = 0;

                var ratsMessage = new Message();
                ratsMessage.Type = TextType.AllFoodsEatenByRats;
                ratsMessage.MapObjects = new List<MapObject> { city };
                messagesService.ShowMessage(ratsMessage);
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
                var riotMessage = new Message();
                riotMessage.Type = TextType.RiotInTheCity;
                riotMessage.MapObjects = new List<MapObject> { city };
                messagesService.ShowMessage(riotMessage);
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
                var villager = charactersRepository.CreateCharacter(definitionsRepository.Races.Find(c => c.Id == 10));
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
                    var successMessage = new Message();
                    successMessage.Type = TextType.RiotInTheCitySuccess;
                    successMessage.MapObjects = new List<MapObject> { city };
                    messagesService.ShowMessage(successMessage);
                }
            };

            var defenceMessage = new Message();
            defenceMessage.Type = TextType.RiotInTheCityWithDefence;
            defenceMessage.MapObjects = new List<MapObject> { city, userArmy };
            defenceMessage.OnClose = () =>
            {
                stateController.EnterTerrainAction(battleContext);
            };
            messagesService.ShowMessage(defenceMessage);
        }
    }
}