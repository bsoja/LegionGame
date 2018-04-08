namespace Legion.Model.Types.Definitions
{
    public abstract class CharacterDefinition
    {
		public int Id { get; set; }
        public string Name { get; set; }
		public int Energy { get; set; }
		public int Strength { get; set; }
		public int Speed { get; set; }
        public string Bob { get; set; }
    }
}