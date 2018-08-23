using System;
using Legion.Model.Types;

namespace Legion.Model
{
    public class TerrainActionContext
    {
        public Army UserArmy { get; set; }
        public Army EnemyArmy { get; set; }
        public TerrainActionType Type { get; set; }
        public Action ActionAfter { get; set; } = () => { };
    }
}