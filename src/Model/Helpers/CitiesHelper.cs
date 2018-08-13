using System;
using Legion.Model.Repositories;
using Legion.Model.Types;
using Legion.Utils;

namespace Legion.Model.Helpers
{
    public class CitiesHelper : ICitiesHelper
    {
        private readonly IDefinitionsRepository definitionsRepository;

        public CitiesHelper(IDefinitionsRepository definitionsRepository)
        {
            this.definitionsRepository = definitionsRepository;
        }

        public void UpdatePriceModificators(City city)
        {
            city.PriceModificators.Clear();
            var mod = (city.Owner != null && city.Owner.IsUserControlled) ? 20 : 50;

            // Price modificators for each item in that city
            foreach (var item in definitionsRepository.Items)
            {
                city.PriceModificators.Add(item.Name, GlobalUtils.Rand(mod));
            }
        }
    }
}