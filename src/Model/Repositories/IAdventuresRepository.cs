using System.Collections.Generic;
using Legion.Model.Types;

namespace Legion.Model.Repositories
{
    public interface IAdventuresRepository
    {
        List<Adventure> Adventures { get; }
        Adventure Create(int id, int level);
    }
}