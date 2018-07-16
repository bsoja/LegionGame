using Legion.Gui.Elements;
using Legion.Gui.Services;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Legion.Views.Menu.Layers
{
    public class MenuLayer : Layer
    {
        private Texture2D background;

        public MenuLayer(IGuiServices guiServices) : base(guiServices)
        {
        }

        public override void Initialize()
        {
            background = GuiServices.ImagesProvider.GetImage(ImageType.MainMenu);
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
                GuiServices.ViewSwitcher.OpenMap(null);
                return true;
            }
            return false;
        }
    }
}