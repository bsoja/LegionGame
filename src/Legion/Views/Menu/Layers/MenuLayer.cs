using Gui.Elements;
using Gui.Services;
using Legion.Model;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Legion.Views.Menu.Layers
{
    public class MenuLayer : Layer
    {
        private Texture2D background;
        private readonly IViewSwitcher viewSwitcher;

        public MenuLayer(IGuiServices guiServices, IViewSwitcher viewSwitcher) : base(guiServices)
        {
            this.viewSwitcher = viewSwitcher;
        }

        public override void Initialize()
        {
            background = GuiServices.ImagesStore.GetImage("mainMenu");
        }

        public override void Draw()
        {
            base.Draw();
            GuiServices.BasicDrawer.DrawImage(background, 0, 0);
        }

        public override bool UpdateInput()
        {
            base.UpdateInput();
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                viewSwitcher.OpenMap(null);
                return true;
            }
            return false;
        }
    }
}