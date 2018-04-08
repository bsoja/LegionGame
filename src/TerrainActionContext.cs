using System;

namespace Legion
{
    public class TerrainActionContext
    {
        public Action ActionAfter { get; set; } = () => { };
    }
}