using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Legion.View.Terrain
{
    public class TerrainView : View
    {
        public TerrainView(Game game) : base(game, new List<Layer>()) { }
    }
}