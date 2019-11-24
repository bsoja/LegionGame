using System.ComponentModel;
using System.IO;
using Gui.Elements;
using Gui.Input;
using Gui.Services;
using Legion.Archive;
using Legion.Localization;
using Legion.Model;
using Legion.Views.Common;
using Legion.Views.Common.Controls;
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

        private LoadGameWindow _loadGameWindow;

        private Texture2D _background;
        private Texture2D _sword;
        private readonly IViewSwitcher _viewSwitcher;
        private readonly ITexts _texts;
        private readonly ICommonGuiFactory _commonGuiFactory;

        public MenuLayer(IGuiServices guiServices, 
            IViewSwitcher viewSwitcher,
            ITexts texts,
            ICommonGuiFactory commonGuiFactory) : base(guiServices)
        {
            _viewSwitcher = viewSwitcher;
            _texts = texts;
            _commonGuiFactory = commonGuiFactory;
        }

        public override void Initialize()
        {
            _background = GuiServices.ImagesStore.GetImage("mainMenu");
            _sword = GuiServices.ImagesStore.GetImage("mainMenuSword");

            Clicked += MenuLayer_Clicked;
        }

        private void MenuLayer_Clicked(HandledEventArgs obj)
        {
            if (_loadGameWindow == null)
            {
                var position = InputManager.GetMousePostion(true);
                if (position.Y < TopBoundary)
                {
                    _viewSwitcher.OpenMap(null);
                }
                else if (position.Y > BottomBoundary)
                {
                    // TODO: terminate game
                }
                else
                {
                    _loadGameWindow = _commonGuiFactory.CreateLoadGameWindow(args =>
                    {
                        RemoveElement(_loadGameWindow);
                        _loadGameWindow = null;
                        args.Handled = true;
                    });
                    AddElement(_loadGameWindow);
                }
            }
        }

        public override void Draw()
        {
            base.Draw();
            GuiServices.BasicDrawer.DrawImage(_background, 0, 0);

            if (_loadGameWindow == null)
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
                GuiServices.BasicDrawer.DrawImage(_sword, SwordLeft, swordY);
            }
        }
    }
}