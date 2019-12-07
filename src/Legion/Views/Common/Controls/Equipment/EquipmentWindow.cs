using System.ComponentModel;
using System.Linq;
using Gui.Elements;
using Gui.Input;
using Gui.Services;
using Legion.Localization;
using Legion.Model.Types;
using Legion.Model.Types.Definitions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Views.Common.Controls.Equipment
{
    public class EquipmentWindow: Window
    {
        private const int WindowWidth = 320;
        private const int WindowHeight = 150;
        private const int Margin = 5;
        private const int MiddleColMargin = 120;
        private const int RightColMargin = 235;
        private const int BottomMargin = 100;
        
        private readonly Texture2D _backgroundImage;
        
        private readonly BodyItemsControl _bodyItemsControl;
        private readonly BackpackItemsControl _backpackItemsControl;
        private readonly GroundItemsControl _groundItemsControl;
        private readonly NavigationButtonsControl _navigationButtonsControl;
        private readonly ItemsInfoControl _itemsInfoControl;
        private readonly CharacterInfoControl _characterInfoControl;

        private Image _dragImage;
        private Item _dragItem;

        public EquipmentWindow(IGuiServices guiServices, ITexts texts) : base(guiServices)
        {
            _backgroundImage = GuiServices.ImagesStore.GetImage("equipment.background");

            _bodyItemsControl = new BodyItemsControl(GuiServices);
            _backpackItemsControl = new BackpackItemsControl(GuiServices);
            _groundItemsControl = new GroundItemsControl(GuiServices);
            _navigationButtonsControl = new NavigationButtonsControl(GuiServices);
            _itemsInfoControl = new ItemsInfoControl(GuiServices, texts);
            _characterInfoControl = new CharacterInfoControl(GuiServices, texts);
            _dragImage = new Image(GuiServices);

            AddElement(_bodyItemsControl);
            AddElement(_backpackItemsControl);
            AddElement(_groundItemsControl);
            AddElement(_navigationButtonsControl);
            AddElement(_itemsInfoControl);
            AddElement(_characterInfoControl);
            AddElement(_dragImage);

            _navigationButtonsControl.PrevClicked += OnPrevClicked;
            _navigationButtonsControl.NextClicked += OnNextClicked;
            _backpackItemsControl.ItemClicked += OnBackpackItemClicked;
            _bodyItemsControl.ItemClicked += OnBodyItemClicked;
        }

        private Army _army;
        public Army Army
        {
            get => _army;
            set
            {
                _army = value;

                CurrentCharacter = _army.Characters.First();
            }
        }

        private Character _currentCharacter;

        private Character CurrentCharacter
        {
            get => _currentCharacter;
            set
            {
                _currentCharacter = value;
                _bodyItemsControl.Character = CurrentCharacter;
                _backpackItemsControl.Character = CurrentCharacter;
                _groundItemsControl.Character = CurrentCharacter;
                _characterInfoControl.Character = CurrentCharacter;
            }
        }

        private void OnPrevClicked(HandledEventArgs args)
        {
            args.Handled = true;
            var curIdx = Army.Characters.IndexOf(CurrentCharacter);
            curIdx--;
            if (curIdx < 0)
            {
                curIdx = Army.Characters.Count - 1;
            }
            CurrentCharacter = Army.Characters[curIdx];
        }

        private void OnNextClicked(HandledEventArgs args)
        {
            args.Handled = true;
            var curIdx = Army.Characters.IndexOf(CurrentCharacter);
            curIdx++;
            if (curIdx >= Army.Characters.Count)
            {
                curIdx = 0;
            }
            CurrentCharacter = Army.Characters[curIdx];
        }

        private void OnBackpackItemClicked(ItemSlotType slotType, HandledEventArgs args)
        {
            var itemContainer = _backpackItemsControl.GetItemContainer(slotType);
            _itemsInfoControl.Item = itemContainer.Item;

            if (_dragItem == null)
            {
                if (itemContainer.Item != null)
                {
                    _dragItem = itemContainer.Item;
                    _dragImage.Data = itemContainer.Image;
                    itemContainer.Item = null;
                    CurrentCharacter.Equipment.Backpack[slotType - ItemSlotType.Backpack1] = null;
                }
            }
            else
            {
                CurrentCharacter.Equipment.Backpack[slotType - ItemSlotType.Backpack1] = _dragItem;
                _dragItem = itemContainer.Item;
                _dragImage.Data = itemContainer.Image;
            }
            CurrentCharacter = CurrentCharacter;
        }

        private void OnBodyItemClicked(ItemSlotType slotType, HandledEventArgs args)
        {
            var itemContainer = _bodyItemsControl.GetItemContainer(slotType);
            _itemsInfoControl.Item = itemContainer.Item;

            if (_dragItem == null)
            {
                if (itemContainer.Item != null)
                {
                    _dragItem = itemContainer.Item;
                    _dragImage.Data = itemContainer.Image;
                    itemContainer.Item = null;
                    switch (slotType)
                    {
                        case ItemSlotType.Head: CurrentCharacter.Equipment.Head = null; break;
                        case ItemSlotType.Torse: CurrentCharacter.Equipment.Torse = null; break;
                        case ItemSlotType.Feets: CurrentCharacter.Equipment.Feets = null; break;
                        case ItemSlotType.LeftHand: CurrentCharacter.Equipment.LeftHand = null; break;
                        case ItemSlotType.RightHand: CurrentCharacter.Equipment.RightHand = null; break;
                    }
                }
            }
            else
            {
                switch (slotType)
                {
                    case ItemSlotType.Head:
                        if (_dragItem.Type.Target == ItemTarget.Head)
                        {
                            CurrentCharacter.Equipment.Head = _dragItem;
                            _dragItem = itemContainer.Item;
                            _dragImage.Data = itemContainer.Image;
                        }
                        break;
                    case ItemSlotType.Torse:
                        if (_dragItem.Type.Target == ItemTarget.Torse)
                        {
                            CurrentCharacter.Equipment.Torse = _dragItem;
                            _dragItem = itemContainer.Item;
                            _dragImage.Data = itemContainer.Image;
                        }
                        break;
                    case ItemSlotType.Feets:
                        if (_dragItem.Type.Target == ItemTarget.Feets)
                        {
                            CurrentCharacter.Equipment.Feets = _dragItem;
                            _dragItem = itemContainer.Item;
                            _dragImage.Data = itemContainer.Image;
                        }
                        break;
                    case ItemSlotType.LeftHand:
                        if (_dragItem.Type.Target == ItemTarget.Hands)
                        {
                            CurrentCharacter.Equipment.LeftHand = _dragItem;
                            _dragItem = itemContainer.Item;
                            _dragImage.Data = itemContainer.Image;
                        }
                        break;
                    case ItemSlotType.RightHand:
                        if (_dragItem.Type.Target == ItemTarget.Hands)
                        {
                            CurrentCharacter.Equipment.RightHand = _dragItem;
                            _dragItem = itemContainer.Item;
                            _dragImage.Data = itemContainer.Image;
                        }
                        break;
                }
            }
            CurrentCharacter = CurrentCharacter;
        }

        protected override bool OnMouseUp(MouseButton button, Point position)
        {
            if (button == MouseButton.Right)
            {
                Closing?.Invoke(new HandledEventArgs());
            }
            return base.OnMouseUp(button, position);
        }

        public override void Update()
        {
            Bounds = new Rectangle(
                GuiServices.GameBounds.Width / 2 - WindowWidth / 2,
                GuiServices.GameBounds.Height / 2 - WindowHeight / 2,
                WindowWidth,
                WindowHeight);
            
            int top = Bounds.Y + Margin;
            int bottom = Bounds.Y + BottomMargin;
            int left = Bounds.X + MiddleColMargin;

            _bodyItemsControl.Position = Bounds.Location;
            _backpackItemsControl.Position = new Point(left, top);
            _groundItemsControl.Position = new Point(left, bottom);
            _navigationButtonsControl.Position = new Point(Bounds.X + RightColMargin, bottom);
            _itemsInfoControl.Position = new Point(left, Bounds.Y);
            _characterInfoControl.Position = new Point(Bounds.X + RightColMargin, top);

            var pos = InputManager.GetMousePostion(true);
            _dragImage.Bounds= new Rectangle(pos, Point.Zero);
        }

        public override void Draw()
        {
            //GuiServices.BasicDrawer.DrawRectangle(
            //    Colors.WindowBackgroundColor,
            //    Bounds.X - 5,
            //    Bounds.Y - 5,
            //    Bounds.Width + 10,
            //    Bounds.Height + 10);
            GuiServices.BasicDrawer.DrawBorder(
                Color.Black,
                Bounds.X - 5,
                Bounds.Y - 5,
                Bounds.Width + 10,
                Bounds.Height + 10);

            // window background
            for (var i = 0; i < 3; i++)
            {
                GuiServices.BasicDrawer.DrawImage(_backgroundImage, Bounds.X, Bounds.Y + i * 50);
            }

            GuiServices.BasicDrawer.DrawBorder(Color.Black, Bounds);
        }
    }
}
