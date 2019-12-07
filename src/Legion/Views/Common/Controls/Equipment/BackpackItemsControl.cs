using System;
using System.ComponentModel;
using Gui.Elements;
using Gui.Services;
using Legion.Model.Types;
using Microsoft.Xna.Framework;

namespace Legion.Views.Common.Controls.Equipment
{
    public class BackpackItemsControl : ContainerElement
    {
        private readonly ItemContainer[] _backpackContainers;

        public BackpackItemsControl(IGuiServices guiServices) : base(guiServices)
        {
            _backpackContainers = new ItemContainer[8];
            for (var i = 0; i < 8; i++)
            {
                var itemContainer = new ItemContainer(GuiServices);
                _backpackContainers[i] = itemContainer;
                AddElement(itemContainer);
                var itemSlot = (ItemSlotType)(i + (int)ItemSlotType.Backpack1);
                itemContainer.Clicked += args =>
                {
                    ItemClicked?.Invoke(itemSlot, args);
                };
            }
        }

        public Point Position
        {
            get => Bounds.Location;
            set => Bounds = new Rectangle(value.X, value.Y, 105, 55);
        }

        private Character _character;
        public Character Character
        {
            get => _character;
            set
            {
                _character = value;
                for (var i = 0; i < 8; i++)
                {
                    _backpackContainers[i].Item = _character.Equipment.Backpack[i];
                }
            }
        }

        public event Action<ItemSlotType, HandledEventArgs> ItemClicked;

        public ItemContainer GetItemContainer(ItemSlotType slotType)
        {
            var slotNr = slotType - ItemSlotType.Backpack1;
            if (slotNr < 0 || slotNr >= 8)
            {
                return null;
            }
            return _backpackContainers[slotNr];
        }

        public override void Update()
        {
            for (var i = 0; i < 4; i++)
            {
                _backpackContainers[i].Position = new Point(Bounds.X + 5 + i * 25, Bounds.Y + 5);
                _backpackContainers[i + 4].Position = new Point(Bounds.X + 5 + i * 25, Bounds.Y + 30);
            }
        }

        public override void Draw()
        {
            GuiServices.BasicDrawer.DrawBorder(Color.Black, Bounds);
        }
    }
}