using System.Collections.Generic;
using Legion.Model.Helpers;
using Legion.Model.Repositories;
using Legion.Model.Types;
using Legion.Utils;

namespace Legion.Model
{
    public class BattleManager : IBattleManager
    {
        private readonly IArmiesRepository _armiesRepository;
        private readonly IPlayersRepository _playersRepository;
        private readonly IArmiesHelper _armiesHelper;
        private readonly ICitiesHelper _citiesHelper;
        private readonly IMessagesService _messagesService;
        private readonly IViewSwitcher _viewSwitcher;

        public BattleManager(IArmiesRepository armiesRepository,
            IPlayersRepository playersRepository,
            IArmiesHelper armiesHelper,
            ICitiesHelper citiesHelper,
            IMessagesService messagesService,
            IViewSwitcher viewSwitcher)
        {
            _playersRepository = playersRepository;
            _armiesRepository = armiesRepository;
            _armiesHelper = armiesHelper;
            _citiesHelper = citiesHelper;
            _messagesService = messagesService;
            _viewSwitcher = viewSwitcher;
        }

        public void AttackOnArmy(Army army, Army targetArmy)
        {
            if (!army.Owner.IsUserControlled && !targetArmy.Owner.IsUserControlled)
            {
                SimulatedBattle(army, targetArmy);
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
                /*
					CENTER[X1,Y1,0]
					If ARMIA(B,0,TE)=0 : MESSAGE2[B,"został rozbity ",33,0,0] : End If 
					If ARMIA(A,0,TE)=0 : MESSAGE2[A,"został rozbity ",33,0,0] : End If 
				*/
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

            if (city.Owner == _playersRepository.UserPlayer)
            {
                cityArmy = _armiesHelper.FindUserArmyInCity(city);
            }
            else
            {
                var defendersCount = (city.Population / 70) + 1;
                if (defendersCount > 10) defendersCount = 10;

                cityArmy = _armiesRepository.CreateTempArmy(defendersCount);
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

                    if (cityArmy.Owner == _playersRepository.UserPlayer)
                    {
                        battleContext.UserArmy = cityArmy;
                        battleContext.EnemyArmy = army;

                        var message = new Message();
                        message.Type = MessageType.EnemyAttacksUserCity;
                        message.MapObjects = new List<MapObject> { city, army };
                        _messagesService.ShowMessage(message);
                    }
                    if (army.Owner == _playersRepository.UserPlayer)
                    {
                        battleContext.UserArmy = army;
                        battleContext.EnemyArmy = cityArmy;

                        var days = GlobalUtils.Rand(30) + 10;
                        army.Owner.UpdateWar(city.Owner, days);
                        if (city.Owner != null) { city.Owner.UpdateWar(army.Owner, days); }

                        var message = new Message();
                        message.Type = MessageType.UserAttackCity;
                        message.MapObjects = new List<MapObject> { city, army };
                        _messagesService.ShowMessage(message);
                    }
                    
                    _viewSwitcher.OpenTerrain(battleContext);
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
                        if (GlobalUtils.Rand(3) == 1) city.Population = 0;
                    }

                    var burnedCityMessage = new Message();
                    burnedCityMessage.Type = MessageType.ChaosWarriorsBurnedCity;
                    burnedCityMessage.MapObjects = new List<MapObject> { city };
                    _messagesService.ShowMessage(burnedCityMessage);
                }
                else
                {
                    var cityOwner = city.Owner;
                    city.Owner = army.Owner;

                    if (cityOwner == _playersRepository.UserPlayer ||
                        army.Owner == _playersRepository.UserPlayer)
                    {
                        var capturedCityMessage = new Message();
                        capturedCityMessage.MapObjects = new List<MapObject> { city };

                        if (army.Owner == _playersRepository.UserPlayer)
                        {
                            _citiesHelper.UpdatePriceModificators(city);
                            capturedCityMessage.Type = MessageType.UserCapturedCity;
                        }
                        else
                        {
                            capturedCityMessage.Type = MessageType.EnemyCapturedUserCity;
                        }

                        _messagesService.ShowMessage(capturedCityMessage);
                    }
                }
            }
            else
            {
                if (army.IsTracked || army.Owner == _playersRepository.UserPlayer)
                {
                    //TODO: CENTER[X1, Y1, 1]
                    var failedMessage = new Message();
                    failedMessage.Type = MessageType.UserArmyFailedToCaptureCity;
                    failedMessage.MapObjects = new List<MapObject> { army };
                    _messagesService.ShowMessage(failedMessage);
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

            var s1 = a.Strength + GlobalUtils.Rand(100);
            var s2 = b.Strength + GlobalUtils.Rand(100);
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

            _armiesRepository.KillArmy(loser);

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