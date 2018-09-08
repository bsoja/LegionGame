using Legion.Model.Types;

namespace Legion.Controllers
{
    public class TerrainController : ITerrainController
    {
        public bool IsPaused { get; set; }        
        public Army EnemyArmy { get; set; }
        public Army UserArmy { get; set; }
    }
}