using System.Collections.Generic;

namespace Legion.View
{
    public interface ILayersProvider
    {
        List<Layer> GetLayers<T>() where T : View;
    }
}