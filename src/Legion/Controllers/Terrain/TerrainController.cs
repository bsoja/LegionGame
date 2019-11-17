using Legion.Model;
using Legion.Model.Types;

namespace Legion.Controllers.Terrain
{
    public class TerrainController : ITerrainController
    {
        private readonly ILegionConfig _legionConfig;

        public TerrainController(ILegionConfig legionConfig)
        {
            _legionConfig = legionConfig;
        }

        public bool IsPaused { get; set; }
        public Army EnemyArmy { get; set; }
        public Army UserArmy { get; set; }
    }
}