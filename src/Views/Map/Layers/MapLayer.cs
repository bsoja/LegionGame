using Legion.Gui.Elements;
using Legion.Gui.Services;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Views.Map.Layers
{
    public class MapLayer : Layer
    {
        private Texture2D background;

        public MapLayer(IGuiServices guiServices) : base(guiServices) { }

        public override void Initialize()
        {
            background = GuiServices.ImagesProvider.GetImage(ImageType.Map);
        }

        public override void Draw()
        {
            base.Draw();
            GuiServices.BasicDrawer.DrawImage(background, 0, 0);
        }
    }
}