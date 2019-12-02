using System.Collections.Generic;

namespace Legion.Model.Types
{
    public class CharacterEquipment
    {
        public CharacterEquipment()
        {
            Backpack = new List<Item>();
        }

        public Item Head { get; set; }

        public Item Torse { get; set; }

        public Item LeftHand { get; set; }

        public Item RightHand { get; set; }

        public Item Feets { get; set; }

        public List<Item> Backpack { get; set; }
        
    }
}