using Gui.Elements;
using Gui.Input;
using Gui.Services;
using Legion.Model;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Views.Menu.Layers
{
    public class MenuLayer : Layer
    {
        private const int TopBoundary = 235;
        private const int BottomBoundary = 280;
        private const int SwordLeft = 80;
        private const int SwordTop = 190;
        private const int SwordMiddle = TopBoundary;
        private const int SwordBottom = 275;

        private Texture2D background;
        private Texture2D sword;
        private readonly IViewSwitcher viewSwitcher;

        public MenuLayer(IGuiServices guiServices, IViewSwitcher viewSwitcher) : base(guiServices)
        {
            this.viewSwitcher = viewSwitcher;
        }

        public override void Initialize()
        {
            background = GuiServices.ImagesStore.GetImage("mainMenu");
            sword = GuiServices.ImagesStore.GetImage("mainMenuSword");

            Clicked += MenuLayer_Clicked;
        }

        private void MenuLayer_Clicked(System.ComponentModel.HandledEventArgs obj)
        {
            var position = InputManager.GetMousePostion(true);
            if (position.Y < TopBoundary)
            {
                viewSwitcher.OpenMap(null);
            }
            else if (position.Y > BottomBoundary)
            {
                // TODO: terminate game
            }
            // TODO: load game
        }

        public override void Draw()
        {
            base.Draw();
            GuiServices.BasicDrawer.DrawImage(background, 0, 0);
            var swordY = SwordMiddle;
            var position = InputManager.GetMousePostion(true);
            if (position.Y < TopBoundary)
            {
                swordY = SwordTop;
            }
            else if (position.Y > BottomBoundary)
            {
                swordY = SwordBottom;
            }
            GuiServices.BasicDrawer.DrawImage(sword, SwordLeft, swordY);
        }
        
    }
}