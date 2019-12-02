using Legion.Utils;

namespace Legion.Model.Types.Definitions
{
    public abstract class CharacterDefinition
    {
        public string Name { get; set; }
        public int Energy { get; set; }
        public int Strength { get; set; }
        public int Speed { get; set; }
        public string Img { get; set; }
    }
}