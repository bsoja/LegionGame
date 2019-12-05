using System.Linq;
using Gui.Elements;
using Gui.Services;
using Legion.Model.Types;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Views.Common.Controls
{
    public class EquipmentWindow: Window
    {
        private const int TopMargin = 5;
        private const int MiddleLeftMargin = 120;
        private const int BottomMargin = 100;

        private readonly Texture2D _backgroundImage;
        private readonly Texture2D _manImage;

        private BrownButton _prevButton;
        private BrownButton _nextButton;

        public EquipmentWindow(IGuiServices guiServices) : base(guiServices)
        {
            _backgroundImage = GuiServices.ImagesStore.GetImage("equipment.background");
            _manImage = GuiServices.ImagesStore.GetImage("equipment.man");

            CreateNavigationButtons();
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
            Bounds = new Rectangle(0,
                GuiServices.GameBounds.Height / 2,
                GuiServices.GameBounds.Width,
                GuiServices.GameBounds.Height);

            int bottom = Bounds.Y + BottomMargin;

            _prevButton.Bounds = new Rectangle(235, bottom + 15, 30, 15);
            _nextButton.Bounds = new Rectangle(280, bottom + 15, 30, 15);
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
            int top = Bounds.Y + TopMargin;
            int bottom = Bounds.Y + BottomMargin;

            GuiServices.BasicDrawer.DrawBorder(Color.Black, MiddleLeftMargin, top, 105, 55);

            // Backpack
            for (var I = 0; I <= 3; I++)
            {
                GuiServices.BasicDrawer.DrawRectangle(Color.Black, 5 + MiddleLeftMargin + (I * 25), top + 5, 20, 20);
                GuiServices.BasicDrawer.DrawBorder(Color.SandyBrown, 5 + MiddleLeftMargin + (I * 25), top + 5, 20, 20);

                GuiServices.BasicDrawer.DrawRectangle(Color.Black, 5 + MiddleLeftMargin + (I * 25), top + 30, 20, 20);
                GuiServices.BasicDrawer.DrawBorder(Color.SandyBrown, 5 + MiddleLeftMargin + (I * 25), top + 30, 20, 20);

                GuiServices.BasicDrawer.DrawRectangle(Color.Black, 5 + MiddleLeftMargin + (I * 25), bottom + 5, 20, 20);
                GuiServices.BasicDrawer.DrawBorder(Color.SandyBrown, 5 + MiddleLeftMargin + (I * 25), bottom + 5, 20, 20);

                var itemTop = I < CurrentCharacter.Equipment.Backpack.Length
                    ? CurrentCharacter.Equipment.Backpack[I]
                    : null;

                var itemBottom = I + 4 < CurrentCharacter.Equipment.Backpack.Length
                    ? CurrentCharacter.Equipment.Backpack[I + 4]
                    : null;

                if (itemTop != null)
                {
                    var img = GuiServices.ImagesStore.GetImageByRealName(itemTop.Type.Img);
                    GuiServices.BasicDrawer.DrawImage(img, MiddleLeftMargin + 7 + (I * 25), top + 7);
                }

                if (itemBottom != null)
                {
                    var img = GuiServices.ImagesStore.GetImageByRealName(itemBottom.Type.Img);
                    GuiServices.BasicDrawer.DrawImage(img, MiddleLeftMargin + 7 + (I * 25), top + 32);
                }
            }
        }

        private void DrawGround()
        {
            int bottom = Bounds.Y + BottomMargin;

            GuiServices.BasicDrawer.DrawBorder(Color.Black, MiddleLeftMargin, bottom, 105, 30);

            //TODO: GLEBA!!
            //B3 = GLEBA(SEK, I)
            //If B3> 0
            //BB3 = BRON(B3, B_BOB) + BROBY
            //Paste Bob X2 + 7 + (I * 25),Y2 + 7,BB3 + GOBY
        }

        private void DrawItemsInfoBox()
        {
            GuiServices.BasicDrawer.DrawBorder(Color.Orange, MiddleLeftMargin + 5, Bounds.Y + 70, 95, 20);
            //TODO: complete drawing
        }

        private void DrawCharacterInfo()
        {
            int top = Bounds.Y + TopMargin;

            GuiServices.BasicDrawer.DrawBorder(Color.Black, 235, top, 75, 100);
        }
    }
}
