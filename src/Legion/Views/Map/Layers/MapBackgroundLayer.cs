using Gui.Elements;
using Gui.Services;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Views.Map.Layers
{
    public class MapBackgroundLayer : MapLayer
    {
        private Texture2D _background;

        public MapBackgroundLayer(IGuiServices guiServices) : base(guiServices) { }

        public override void Initialize()
        {
            _background = GuiServices.ImagesStore.GetImage("map");
        }

        public override void Draw()
        {
            base.Draw();
            GuiServices.BasicDrawer.DrawImage(_background, 0, 0);
        }
    }
}