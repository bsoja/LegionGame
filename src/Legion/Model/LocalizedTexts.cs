using System.Collections.Generic;

namespace Legion.Model
{
    public class LocalizedTexts
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<TextPair> Texts { get; set; }
    }
}