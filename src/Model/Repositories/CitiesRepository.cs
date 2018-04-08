using System.Collections.Generic;
using Legion.Model.Types;

namespace Legion.Model.Repositories
{
    public class CitiesRepository : ICitiesRepository
    {
        public CitiesRepository()
        {
            Cities = new List<City>();
        }
        
        public List<City> Cities { get; private set; }
    }
}