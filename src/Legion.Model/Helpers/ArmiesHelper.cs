using System;
using System.Linq;
using Legion.Model.Repositories;
using Legion.Model.Types;

namespace Legion.Model.Helpers
{
    public class ArmiesHelper : IArmiesHelper
    {
        private readonly ICitiesRepository _citiesRepository;
        private readonly IArmiesRepository _armiesRepository;
        private readonly IAdventuresRepository _adventuresRepository;

        public ArmiesHelper(ICitiesRepository citiesRepository,
            IArmiesRepository armiesRepository,
            IAdventuresRepository adventuresRepository)
        {
            _citiesRepository = citiesRepository;
            _armiesRepository = armiesRepository;
            _adventuresRepository = adventuresRepository;
        }

        public Army FindUserArmyInCity(City city)
        {
            //TODO: 
            var userArmies = _armiesRepository.Armies.Where(a => a.Owner != null && a.Owner.IsUserControlled);
            {
                foreach (var army in userArmies)
                {
                    // TODO: check range to check with original or check by city sprite width/height
                    var diffX = Math.Abs(army.X - city.X);
                    var diffY = Math.Abs(army.Y - city.Y);
                    if (diffX <= 8 && diffY <= 8)
                    {
                        return army;
                    }
                }
            }
            return null;
        }

        public City IsArmyInTheCity(Army army)
        {
            foreach (var city in _citiesRepository.Cities)
            {
                // TODO: check range to check with original or check by city sprite width/height
                if ((army.X >= city.X && army.X <= city.X + 8) && (army.Y >= city.Y && army.Y <= city.Y + 8))
                {
                    return city;
                }
            }
            return null;
        }

        public Adventure IsArmyInTheAdventure(Army army)
        {
            foreach (var adv in _adventuresRepository.Adventures)
            {
                // TODO: check range to check with original or check by city sprite width/height
                if ((army.X >= adv.X && army.X <= adv.X + 8) && (army.Y >= adv.Y && army.Y <= adv.Y + 8))
                {
                    return adv;
                }
            }
            return null;
        }
    }
}