using System;
using System.ComponentModel;
using Gui.Elements;
using Gui.Services;
using Legion.Model.Types;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Views.Common.Controls.Equipment
{
    public class BodyItemsControl : ContainerElement
    {
        private readonly Texture2D _manImage;

        private readonly ItemContainer _headContainer;
        private readonly ItemContainer _torseContainer;
        private readonly ItemContainer _feetsContainer;
        private readonly ItemContainer _leftHandContainer;
        private readonly ItemContainer _rightHandContainer;

        public BodyItemsControl(IGuiServices guiServices) : base(guiServices)
        {
            _manImage = GuiServices.ImagesStore.GetImage("equipment.man");

            _headContainer = new ItemContainer(GuiServices) { IsTransparent = true };
            _torseContainer = new ItemContainer(GuiServices);
            _feetsContainer = new ItemContainer(GuiServices);
            _leftHandContainer = new ItemContainer(GuiServices);
            _rightHandContainer = new ItemContainer(GuiServices);

            AddElement(_headContainer);
            AddElement(_torseContainer);
            AddElement(_feetsContainer);
            AddElement(_leftHandContainer);
            AddElement(_rightHandContainer);

            _headContainer.Clicked += args => ItemClicked?.Invoke(_headContainer, args);
            _torseContainer.Clicked += args => ItemClicked?.Invoke(_torseContainer, args);
            _feetsContainer.Clicked += args => ItemClicked?.Invoke(_feetsContainer, args);
            _leftHandContainer.Clicked += args => ItemClicked?.Invoke(_leftHandContainer, args);
            _rightHandContainer.Clicked += args => ItemClicked?.Invoke(_rightHandContainer, args);
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
                _headContainer.Item = _character.Equipment.Head;
                _torseContainer.Item = _character.Equipment.Torse;
                _feetsContainer.Item = _character.Equipment.Feets;
                _leftHandContainer.Item = _character.Equipment.LeftHand;
                _rightHandContainer.Item = _character.Equipment.RightHand;
            }
        }

        public event Action<ItemContainer, HandledEventArgs> ItemClicked;

        public override void Update()
        {
            _headContainer.Position = new Point(Bounds.X + 47, Bounds.Y + 8);
            _torseContainer.Position = new Point(Bounds.X + 47, Bounds.Y + 44);
            _feetsContainer.Position = new Point(Bounds.X + 47, Bounds.Y + 108);
            _leftHandContainer.Position = new Point(Bounds.X + 7, Bounds.Y + 58);
            _rightHandContainer.Position = new Point(Bounds.X + 87, Bounds.Y + 58);
        }

        public override void Draw()
        {
            GuiServices.BasicDrawer.DrawRectangle(Color.Black, Bounds.X + 5, Bounds.Y + 5, 105, 125);
            GuiServices.BasicDrawer.DrawImage(_manImage, Bounds.X + 19, Bounds.Y + 10);
        }
    }
}