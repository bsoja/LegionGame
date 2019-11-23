namespace Legion.Model.Types
{
    public abstract class MapObject
    {
        public int Id { get; set; }

        public abstract MapObjectType Type { get; }

        public Player Owner { get; set; }

        public string Name { get; set; }

        public int X { get; set; }

        public int Y { get; set; }
    }
}