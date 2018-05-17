using System;
using System.Collections.Generic;
using Legion.Model.Helpers;
using Legion.Model.Repositories;
using Legion.Model.Types;
using Legion.View.Map;

namespace Legion.Model
{
    public class BattleManager : IBattleManager
    {
        private static readonly Random Rand = new Random();

        private readonly IArmiesRepository armiesRepository;
        private readonly IPlayersRepository playersRepository;
        private readonly IArmiesHelper armiesHelper;
        private readonly ICitiesHelper citiesHelper;
        private readonly IMapMessagesService mapMessagesService;
        private readonly IStateController stateController;

        public BattleManager(IArmiesRepository armiesRepository,
            IPlayersRepository playersRepository,
            IArmiesHelper armiesHelper,
            ICitiesHelper citiesHelper,
            IMapMessagesService mapMessagesService,
            IStateController stateController)
        {
            this.playersRepository = playersRepository;
            this.armiesRepository = armiesRepository;
            this.armiesHelper = armiesHelper;
            this.citiesHelper = citiesHelper;
            this.mapMessagesService = mapMessagesService;
            this.stateController = stateController;
        }

        public void AttackOnArmy(Army army, Army targetArmy)
        {
            if (!army.Owner.IsUserControlled && !targetArmy.Owner.IsUserControlled)
            {
                SimulatedBattle(army, targetArmy);
                return;
            }
            else
            {
                if (army.Owner.IsUserControlled)
                {
                    /*
					   CENTER[X1,Y1,1]
					   MESSAGE[A,"Rozpoczynamy atak na "+A$,0,0]
					   ILEDNI=Rnd(30)+10
					   WOJNA(PL,PL2)=ILEDNI
					   WOJNA(PL2,PL)=ILEDNI
					   ARMIA(B,0,TMAGMA)=0
					   BITWA[A,B,LOAX,LOAY,LTRYB,LOAX2,LOAY2,LTRYB,TEREN,MT]
					*/
                }
                else
                {
                    /*
					   CENTER[X1,Y1,1]
					   MESSAGE[A,"zaatakował nasz "+A$+" ",0,0]
					   BITWA[B,A,LOAX2,LOAY2,LTRYB,LOAX,LOAY,LTRYB,TEREN,MT]
					   ARMIA(A,0,TMAGMA)=0
					*/
                }
                /*
					CENTER[X1,Y1,0]
					If ARMIA(B,0,TE)=0 : MESSAGE2[B,"został rozbity ",33,0,0] : End If 
					If ARMIA(A,0,TE)=0 : MESSAGE2[A,"został rozbity ",33,0,0] : End If 
				*/

                return;
            }
        }

        public void AttackOnCity(Army army, City city)
        {
            //var wall = 0;

            //if (city.WallType == 0 || army.Owner.IsChaosControlled)
            //{
            //	wall = city.Id;
            //}
            //else
            //{
            //	wall = -city.WallType - 1;
            //}

            Army cityArmy = null;

            if (city.Owner == playersRepository.UserPlayer)
            {
                cityArmy = armiesHelper.FindUserArmyInCity(city);
            }
            else
            {
                var defendersCount = (city.Population / 70) + 1;
                if (defendersCount > 10) defendersCount = 10;

                cityArmy = armiesRepository.CreateTempArmy(defendersCount);
            }

            if (!army.Owner.IsUserControlled && (city.Owner != null && !city.Owner.IsUserControlled))
            {
                SimulatedBattle(army, cityArmy);
                AfterAttackOnCity(army, city, cityArmy);
            }
            else
            {
                if (cityArmy != null)
                {
                    //TODO: CENTER[X1,Y1,1]

                    var battleContext = new TerrainActionContext();
                    battleContext.Type = TerrainActionType.Battle;
                    battleContext.ActionAfter = () => AfterAttackOnCity(army, city, cityArmy);

                    if (cityArmy.Owner == playersRepository.UserPlayer)
                    {
                        battleContext.UserArmy = cityArmy;
                        battleContext.EnemyArmy = army;

                        var message = new MapMessage();
                        message.Type = MapMessageType.EnemyAttacksUserCity;
                        message.MapObjects = new List<MapObject> { city, army };
                        mapMessagesService.ShowMessage(message);
                    }
                    if (army.Owner == playersRepository.UserPlayer)
                    {
                        battleContext.UserArmy = army;
                        battleContext.EnemyArmy = cityArmy;

                        var days = Rand.Next(30) + 10;
                        army.Owner.UpdateWar(city.Owner, days);
                        if (city.Owner != null) { city.Owner.UpdateWar(army.Owner, days); }

                        var message = new MapMessage();
                        message.Type = MapMessageType.UserAttackCity;
                        message.MapObjects = new List<MapObject> { city, army };
                        mapMessagesService.ShowMessage(message);
                    }

                    stateController.EnterTerrainAction(battleContext);
                }
            }
        }

        private void AfterAttackOnCity(Army army, City city, Army cityArmy)
        {
            city.Population -= city.Population / 4;
            if (city.Population < 20) city.Population = 20;

            if (cityArmy == null || cityArmy.IsKilled)
            {
                if (army.Owner.IsChaosControlled)
                {
                    city.Owner = null;
                    city.Population -= city.Population / 2;
                    if (city.Population < 20) city.Population = 20;
                    for (var i = 2; i <= 10; i++)
                    {
                        if (Rand.Next(3) == 1) city.Population = 0;
                    }

                    var burnedCityMessage = new MapMessage();
                    burnedCityMessage.Type = MapMessageType.ChaosWarriorsBurnsCity;
                    burnedCityMessage.MapObjects = new List<MapObject> { city };
                    mapMessagesService.ShowMessage(burnedCityMessage);
                }
                else
                {
                    var cityOwner = city.Owner;
                    city.Owner = army.Owner;

                    if (cityOwner == playersRepository.UserPlayer ||
                        army.Owner == playersRepository.UserPlayer)
                    {
                        var capturedCityMessage = new MapMessage();
                        capturedCityMessage.MapObjects = new List<MapObject> { city };

                        if (army.Owner == playersRepository.UserPlayer)
                        {
                            citiesHelper.UpdatePriceModificators(city);
                            capturedCityMessage.Type = MapMessageType.UserCapturedCity;
                        }
                        else
                        {
                            capturedCityMessage.Type = MapMessageType.EnemyCapturedUserCity;
                        }

                        mapMessagesService.ShowMessage(capturedCityMessage);
                    }
                }
            }
            else
            {
                if (army.IsTracked || army.Owner == playersRepository.UserPlayer)
                {
                    //TODO: CENTER[X1, Y1, 1]
                    var failedMessage = new MapMessage();
                    failedMessage.Type = MapMessageType.UserArmyFailedToCaptureCity;
                    failedMessage.MapObjects = new List<MapObject> { army };
                    mapMessagesService.ShowMessage(failedMessage);
                }
            }
        }

        public void SimulatedBattle(Army a, Army b)
        {
            // //TODO: temporary things:
            // actionsManager.NextAction = new ActionInfo
            // {
            //     UserArmy = a,
            //     EnemyArmy = b,
            //     Type = ActionType.Battle
            // };
            // return;

            Army winner;
            Army loser;

            var s1 = a.Strength + Rand.Next(100);
            var s2 = b.Strength + Rand.Next(100);
            var s3 = 0;

            var ds = s1 - s2;
            if (ds >= 0)
            {
                winner = a;
                loser = b;
            }
            else
            {
                winner = b;
                loser = a;
            }
            s3 = s2 / 15;

            armiesRepository.KillArmy(loser);

            foreach (var character in winner.Characters)
            {
                character.Energy -= s3;
                if (character.Energy < 0)
                {
                    character.Energy = 0;
                }
            }

            if (loser.IsTracked)
            {
                //TODO: MESSAGE2[LOSER," został rozbity.",33,0,0]
            }
        }

        public void Battle(Army a, Army b)
        {
            /*
            Procedure BITWA[A,B,X1,Y1,T1,X2,Y2,T2,SCENERIA,WIES]
   ARM=A : WRG=B
   PL2=ARMIA(B,0,TMAG)
   Sprite Off 2
   SETUP["","Bitwa",""]
   If ARMIA(B,0,TMAG)=5
      For I=1 To 16
         Del Bob POTWORY+1
      Next I
      _LOAD[KAT$+"dane/potwory/szkielet","dane:potwory/szkielet","Dane",1]
      _LOAD[KAT$+"dane/potwory/szkielet.snd","dane:potwory/szkielet.snd","Dane",9]
   End If 
   RYSUJ_SCENERIE[SCENERIA,WIES]
   AGRESJA=ARMIA(B,0,TKORP)
   For I=1 To 10 : ARMIA(WRG,I,TKORP)=AGRESJA : Next I
   USTAW_WOJSKO[A,X1,Y1,T1]
   USTAW_WOJSKO[B,X2,Y2,T2]
   MAIN_ACTION
   If TESTING Then Pop Proc
   SETUP0
   VISUAL_OBJECTS
   Sprite 2,SPX,SPY,1
   
End Proc*/
        }
    }
}