using Legion.Model;
using Legion.Model.Types;

namespace Legion.Controllers.Terrain
{
    public class TerrainController : ITerrainController
    {
        private readonly ILegionConfig legionConfig;

        public TerrainController(ILegionConfig legionConfig)
        {
            this.legionConfig = legionConfig;
        }

        public bool IsPaused { get; set; }
        public Army EnemyArmy { get; set; }
        public Army UserArmy { get; set; }
    }
}