using System.Collections.Generic;
using Legion.Model.Types;

namespace Legion.Controllers
{
    public interface IMapController
    {
        List<City> Cities { get; }
        List<Army> Armies { get; }
    }
}