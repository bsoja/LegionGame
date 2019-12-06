using System.ComponentModel;
using System.Linq;
using Gui.Elements;
using Gui.Input;
using Gui.Services;
using Legion.Localization;
using Legion.Model.Types;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Views.Common.Controls
{
    public class EquipmentWindow: Window
    {
        private const int Margin = 5;
        private const int MiddleColMargin = 120;
        private const int RightColMargin = 235;
        private const int BottomMargin = 100;

        private readonly ITexts _texts;
        private readonly Texture2D _backgroundImage;
        private readonly Texture2D _manImage;

        private BrownButton _prevButton;
        private BrownButton _nextButton;

        public EquipmentWindow(IGuiServices guiServices, ITexts texts) : base(guiServices)
        {
            _texts = texts;
            _backgroundImage = GuiServices.ImagesStore.GetImage("equipment.background");
            _manImage = GuiServices.ImagesStore.GetImage("equipment.man");

            CreateNavigationButtons();
        }

        protected override bool OnMouseUp(MouseButton button, Point position)
        {
            if (button == MouseButton.Right)
            {
                Closing?.Invoke(new HandledEventArgs());
            }
            return base.OnMouseUp(button, position);
        }

        private Character CurrentCharacter { get; set; }

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

        private void CreateNavigationButtons()
        {
            // TODO: somehow current font displays '<' as '>' (WTF?)
            _prevButton = new BrownButton(GuiServices, ">");
            _prevButton.Center = true;
            _prevButton.Clicked += args =>
            {
                args.Handled = true;
                var curIdx = Army.Characters.IndexOf(CurrentCharacter);
                curIdx--;
                if (curIdx < 0)
                {
                    curIdx = Army.Characters.Count - 1;
                }
                CurrentCharacter = Army.Characters[curIdx];
            };
            AddElement(_prevButton);

            // TODO: somehow current font displays '<' as '>' (WTF?)
            _nextButton = new BrownButton(GuiServices, "<");
            _nextButton.Center = true;
            _nextButton.Clicked += args =>
            {
                args.Handled = true;
                var curIdx = Army.Characters.IndexOf(CurrentCharacter);
                curIdx++;
                if (curIdx >= Army.Characters.Count)
                {
                    curIdx = 0;
                }
                CurrentCharacter = Army.Characters[curIdx];
            };
            AddElement(_nextButton);
        }

        public override void Update()
        {
            //320x150
            Bounds = new Rectangle(
                GuiServices.GameBounds.Width / 2 - 320 / 2,
                GuiServices.GameBounds.Height / 2 - 150 / 2,
                320,
                150);

            int bottom = Bounds.Y + BottomMargin;

            _prevButton.Bounds = new Rectangle(Bounds.X + RightColMargin, bottom + 15, 30, 15);
            _nextButton.Bounds = new Rectangle(Bounds.X + RightColMargin + 45, bottom + 15, 30, 15);
        }

        public override void Draw()
        {
            // window background
            for (var i = 0; i < 3; i++)
            {
                GuiServices.BasicDrawer.DrawImage(_backgroundImage, Bounds.X, Bounds.Y + i * 50);
            }

            DrawMan();
            DrawBackpack();
            DrawGround();
            DrawItemsInfoBox();
            DrawCharacterInfo();

            GuiServices.BasicDrawer.DrawBorder(Color.Black, Bounds);
        }

        private void DrawMan()
        {
            // Man image and used items
            GuiServices.BasicDrawer.DrawRectangle(Color.Black, Bounds.X + 5, Bounds.Y + 5, 105, 125);
            GuiServices.BasicDrawer.DrawImage(_manImage, Bounds.X + 19, Bounds.Y + 10);

            // head
            GuiServices.BasicDrawer.DrawBorder(Color.SandyBrown, Bounds.X + 47, Bounds.Y + 8, 20, 20);
            if (CurrentCharacter.Equipment.Head != null)
            {
                var img = GuiServices.ImagesStore.GetImageByRealName(CurrentCharacter.Equipment.Head.Type.Img);
                GuiServices.BasicDrawer.DrawImage(img, Bounds.X + 49, Bounds.Y + 10);
            }

            // torse
            GuiServices.BasicDrawer.DrawRectangle(Color.Black, Bounds.X + 47, Bounds.Y + 44, 20, 20);
            GuiServices.BasicDrawer.DrawBorder(Color.SandyBrown, Bounds.X + 47, Bounds.Y + 44, 20, 20);
            if (CurrentCharacter.Equipment.Torse != null)
            {
                var img = GuiServices.ImagesStore.GetImageByRealName(CurrentCharacter.Equipment.Torse.Type.Img);
                GuiServices.BasicDrawer.DrawImage(img, Bounds.X + 49, Bounds.Y + 46);
            }

            // feets
            GuiServices.BasicDrawer.DrawRectangle(Color.Black, Bounds.X + 47, Bounds.Y + 108, 20, 20);
            GuiServices.BasicDrawer.DrawBorder(Color.SandyBrown, Bounds.X + 47, Bounds.Y + 108, 20, 20);
            if (CurrentCharacter.Equipment.Feets != null)
            {
                var img = GuiServices.ImagesStore.GetImageByRealName(CurrentCharacter.Equipment.Feets.Type.Img);
                GuiServices.BasicDrawer.DrawImage(img, Bounds.X + 49, Bounds.Y + 110);
            }

            // left hand
            GuiServices.BasicDrawer.DrawRectangle(Color.Black, Bounds.X + 7, Bounds.Y + 58, 20, 20);
            GuiServices.BasicDrawer.DrawBorder(Color.SandyBrown, Bounds.X + 7, Bounds.Y + 58, 20, 20);
            if (CurrentCharacter.Equipment.LeftHand != null)
            {
                var img = GuiServices.ImagesStore.GetImageByRealName(CurrentCharacter.Equipment.LeftHand.Type.Img);
                GuiServices.BasicDrawer.DrawImage(img, Bounds.X + 9, Bounds.Y + 60);
            }

            // right hand
            GuiServices.BasicDrawer.DrawRectangle(Color.Black, Bounds.X + 87, Bounds.Y + 58, 20, 20);
            GuiServices.BasicDrawer.DrawBorder(Color.SandyBrown, Bounds.X + 87, Bounds.Y + 58, 20, 20);
            if (CurrentCharacter.Equipment.RightHand != null)
            {
                var img = GuiServices.ImagesStore.GetImageByRealName(CurrentCharacter.Equipment.RightHand.Type.Img);
                GuiServices.BasicDrawer.DrawImage(img, Bounds.X + 89, Bounds.Y + 60);
            }
        }

        private void DrawBackpack()
        {
            int top = Bounds.Y + Margin;
            int bottom = Bounds.Y + BottomMargin;
            int left = Bounds.X + MiddleColMargin;

            GuiServices.BasicDrawer.DrawBorder(Color.Black, left, top, 105, 55);

            // Backpack
            for (var I = 0; I <= 3; I++)
            {
                GuiServices.BasicDrawer.DrawRectangle(Color.Black, 5 + left + (I * 25), top + 5, 20, 20);
                GuiServices.BasicDrawer.DrawBorder(Color.SandyBrown, 5 + left + (I * 25), top + 5, 20, 20);

                GuiServices.BasicDrawer.DrawRectangle(Color.Black, 5 + left + (I * 25), top + 30, 20, 20);
                GuiServices.BasicDrawer.DrawBorder(Color.SandyBrown, 5 + left + (I * 25), top + 30, 20, 20);

                GuiServices.BasicDrawer.DrawRectangle(Color.Black, 5 + left + (I * 25), bottom + 5, 20, 20);
                GuiServices.BasicDrawer.DrawBorder(Color.SandyBrown, 5 + left + (I * 25), bottom + 5, 20, 20);

                var itemTop = I < CurrentCharacter.Equipment.Backpack.Length
                    ? CurrentCharacter.Equipment.Backpack[I]
                    : null;

                var itemBottom = I + 4 < CurrentCharacter.Equipment.Backpack.Length
                    ? CurrentCharacter.Equipment.Backpack[I + 4]
                    : null;

                if (itemTop != null)
                {
                    var img = GuiServices.ImagesStore.GetImageByRealName(itemTop.Type.Img);
                    GuiServices.BasicDrawer.DrawImage(img, left + 7 + (I * 25), top + 7);
                }

                if (itemBottom != null)
                {
                    var img = GuiServices.ImagesStore.GetImageByRealName(itemBottom.Type.Img);
                    GuiServices.BasicDrawer.DrawImage(img, left + 7 + (I * 25), top + 32);
                }
            }

            var item = CurrentCharacter.Equipment.Backpack.FirstOrDefault(it=>it != null);
            if (item != null)
            {
                var itemType = _texts.Get(item.Type.Type.ToString());
                var itemName = _texts.Get(item.Type.Name);

                GuiServices.BasicDrawer.DrawRectangle(Color.Black, left + 6, Bounds.Y+71, 98-6, 88-71);
                GuiServices.BasicDrawer.DrawText(Color.AntiqueWhite, left + 10, Bounds.Y + 72, itemType);
                GuiServices.BasicDrawer.DrawText(Color.AntiqueWhite, left + 72, Bounds.Y + 72, "W: " + item.Type.Weight);
                GuiServices.BasicDrawer.DrawText(Color.AntiqueWhite, left + 10, Bounds.Y + 81, itemName);
            }
        }

        private void DrawGround()
        {
            int bottom = Bounds.Y + BottomMargin;
            int left = Bounds.X + MiddleColMargin;

            GuiServices.BasicDrawer.DrawBorder(Color.Black, left, bottom, 105, 30);

            //TODO: GLEBA!!
            //B3 = GLEBA(SEK, I)
            //If B3> 0
            //BB3 = BRON(B3, B_BOB) + BROBY
            //Paste Bob X2 + 7 + (I * 25),Y2 + 7,BB3 + GOBY
        }

        private void DrawItemsInfoBox()
        {
            int left = Bounds.X + MiddleColMargin;
            GuiServices.BasicDrawer.DrawBorder(Color.Orange, left + 5, Bounds.Y + 70, 95, 20);
            //TODO: complete drawing
        }

        private void DrawCharacterInfo()
        {
            int top = Bounds.Y + Margin;

            GuiServices.BasicDrawer.DrawBorder(Color.Black, Bounds.X + RightColMargin, top, 75, 100);
        }
    }
}
