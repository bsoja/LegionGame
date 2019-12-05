using System.Collections.Generic;

namespace Legion.Model.Types
{
    public class CharacterEquipment
    {
        public CharacterEquipment()
        {
            Backpack = new Item[8];
        }

        public Item Head { get; set; }

        public Item Torse { get; set; }

        public Item LeftHand { get; set; }

        public Item RightHand { get; set; }

        public Item Feets { get; set; }

        public Item[] Backpack { get; set; }
        
    }
}