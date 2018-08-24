using Legion.Model.Types;

namespace Legion.Model
{
    public interface ICityIncidents
    {
        void Plague(City city);
        void Riot(City city);
    }
}