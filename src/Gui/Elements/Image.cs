using Gui.Services;
using Microsoft.Xna.Framework.Graphics;

namespace Gui.Elements
{
    public class Image : DrawableElement
    {
        public Image(IGuiServices guiServices) : base(guiServices)
        {
        }

        public Texture2D Data { get; set; }

        public override void Draw()
        {
            if (Data != null)
            {
                GuiServices.BasicDrawer.DrawImage(Data, Bounds.X, Bounds.Y);
            }
        }
    }
}