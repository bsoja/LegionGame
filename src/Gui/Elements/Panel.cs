using Legion.Gui.Services;
using Microsoft.Xna.Framework;

namespace Legion.Gui.Elements
{
    public class Panel : ClickableElement
    {
        public Panel(IGuiServices guiServices) : base(guiServices)
        { }

        public bool Invert { get; set; }

        public Color FillColor { get; set; } = Colors.PanelFillColor;
        public Color DarkColor { get; set; } = Colors.PanelDarkColor;
        public Color LightColor { get; set; } = Colors.PanelLightColor;

        public override void Draw()
        {
            GuiServices.BasicDrawer.DrawRectangle(FillColor, Bounds);

            var x = Bounds.X;
            var y = Bounds.Y;
            var width = Bounds.Width;
            var height = Bounds.Height;

            var firstColor = Invert ? DarkColor : LightColor;
            var secondColor = Invert ? LightColor : DarkColor;

            GuiServices.BasicDrawer.DrawLine(firstColor, new Vector2(x, y + height), new Vector2(x, y));
            GuiServices.BasicDrawer.DrawLine(firstColor, new Vector2(x, y), new Vector2(x + width, y));

            GuiServices.BasicDrawer.DrawLine(secondColor, new Vector2(x + width, y), new Vector2(x + width, y + height));
            GuiServices.BasicDrawer.DrawLine(secondColor, new Vector2(x + width, y + height), new Vector2(x, y + height));
        }
    }
}