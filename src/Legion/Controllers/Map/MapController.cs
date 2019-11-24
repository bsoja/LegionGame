using System.Collections.Generic;
using Legion.Model;
using Legion.Model.Repositories;
using Legion.Model.Types;

namespace Legion.Controllers.Map
{
    public class MapController : IMapController
    {
        private readonly ILegionInfo _legionInfo;
        private readonly ICitiesRepository _citiesRepository;
        private readonly IArmiesRepository _armiesRepository;
        private readonly ICitiesTurnProcessor _citiesTurnProcessor;
        private readonly IArmiesTurnProcessor _armiesTurnProcessor;

        public MapController(
            ILegionInfo legionInfo,
            ICitiesRepository citiesRepository,
            IArmiesRepository armiesRepository,
            ICitiesTurnProcessor citiesTurnProcessor,
            IArmiesTurnProcessor armiesTurnProcessor)
        {
            _legionInfo = legionInfo;
            _citiesRepository = citiesRepository;
            _armiesRepository = armiesRepository;
            _citiesTurnProcessor = citiesTurnProcessor;
            _armiesTurnProcessor = armiesTurnProcessor;
        }

        public List<City> Cities => _citiesRepository.Cities;

        public List<Army> Armies => _armiesRepository.Armies;

        public bool IsProcessingTurn => _armiesTurnProcessor.IsProcessingTurn;

        public void NextTurn()
        {
            if (!_citiesTurnProcessor.IsProcessingTurn && !_armiesTurnProcessor.IsProcessingTurn)
            {
                _legionInfo.CurrentDay++;
                // BUSY_ANIM
                /* TODO:
                   'wygaszanie konfliktów zbrojnych przez NATO
                   For I=0 To 5
                      For J=0 To 5
                         Add WOJNA(I,J),-1,0 To WOJNA(I,J)
                      Next 
                   Next 
                   'wszczynanie du?ych wojen
                   SR=0
                   For PL=1 To 4 : OBLICZ_POWER[PL] : SR=SR+Param : Next 
                   POWER=(GRACZE(1,2)/900)+7 : If POWER>99 : POWER=99 : End If 
                   SR=SR/4
                   '   Pen 21 : Print At(1,0);"power:",POWER,GRACZE(1,2),SR 
                   OLDSI=0
                   For I=1 To 4
                      SI=GRACZE(I,2)
                      '      Pen GRACZE(I,3)+1 : Print At(1,I);SI
                      If SI>SR+((40*SR)/100) and SI>OLDSI
                         OLDSI=SI
                         '         Print At(10,I);"lider:"
                         For J=2 To 4 : WOJNA(J,I)=Rnd(15)+10 : Next 
                      End If 
                   Next I
                 */

                _citiesTurnProcessor.NextTurn();
                _armiesTurnProcessor.NextTurn();
            }
        }

        public Army ProcessTurnForNextArmy()
        {
            return _armiesTurnProcessor.ProcessTurnForNextArmy();
        }

        public void OnMoveEnded(Army army)
        {
            _armiesTurnProcessor.OnMoveEnded(army);
        }

    }
}