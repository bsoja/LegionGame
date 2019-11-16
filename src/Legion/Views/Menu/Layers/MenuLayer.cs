using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using Gui.Elements;
using Gui.Input;
using Gui.Services;
using Legion.Archive;
using Legion.Model;
using Legion.Views.Menu.Controls;
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

        private LoadGameWindow loadGameWindow;

        private Texture2D background;
        private Texture2D sword;
        private readonly IViewSwitcher viewSwitcher;
        private readonly IGameArchive _gameArchive;

        public MenuLayer(IGuiServices guiServices, IViewSwitcher viewSwitcher, IGameArchive gameArchive) : base(guiServices)
        {
            this.viewSwitcher = viewSwitcher;
            _gameArchive = gameArchive;
        }

        public override void Initialize()
        {
            background = GuiServices.ImagesStore.GetImage("mainMenu");
            sword = GuiServices.ImagesStore.GetImage("mainMenuSword");

            Clicked += MenuLayer_Clicked;
        }

        private void MenuLayer_Clicked(System.ComponentModel.HandledEventArgs obj)
        {
            if (loadGameWindow == null)
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
                else
                {
                    loadGameWindow = new LoadGameWindow(GuiServices);
                    loadGameWindow.ButtonClicked += (args, name) =>
                    {
                        //TODO: keep archives path in common place
                        _gameArchive.LoadGame(Path.Combine("data", "archive", name));
                        viewSwitcher.OpenMap(null);
                    };
                    loadGameWindow.ExitClicked += args =>
                    {
                        RemoveElement(loadGameWindow);
                        loadGameWindow = null;
                        args.Handled = true;
                    };
                    AddElement(loadGameWindow);
                }
            }
        }

        public override void Draw()
        {
            base.Draw();
            GuiServices.BasicDrawer.DrawImage(background, 0, 0);

            if (loadGameWindow == null)
            {
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
}