namespace Legion.Model.Types
{
    public class MapObject
    {
        public int Id { get; set; }
        public Player Owner { get; set; }
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}