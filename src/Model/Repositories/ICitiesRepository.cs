using System.Collections.Generic;
using Legion.Model.Types;

namespace Legion.Model.Repositories
{
    public interface ICitiesRepository
    {
        List<City> Cities { get;  }
    }
}