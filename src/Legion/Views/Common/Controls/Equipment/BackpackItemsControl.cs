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

                itemContainer.Clicked += args =>
                {
                    ItemClicked?.Invoke(itemContainer, args);
                };
            }
        }

        public Point Position
        {
            get => Bounds.Location;
            set => Bounds = new Rectangle(value.X, value.Y, 80, 120);
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

        public event Action<ItemContainer, HandledEventArgs> ItemClicked;

        public override void Update()
        {
            for (var i = 0; i < 4; i++)
            {
                _backpackContainers[i].Position = new Point(Bounds.X + 5 + i * 25, Bounds.Y + 5);
                _backpackContainers[i + 4].Position = new Point(Bounds.X + 5 + i * 25, Bounds.Y + 30);
            }
        }
    }
}