using Microsoft.Xna.Framework;

namespace Legion.Gui
{
    public class Label : GuiElement
    {
        public Label(IBasicDrawer basicDrawer) : base(basicDrawer)
        {
            Text = "";
            TextColor = Colors.TextDarkColor;
        }

        public bool IsHorizontalCenter { get; set; }

        public bool IsVerticalCenter { get; set; }

        public string Text { get; set; }

        public Color TextColor { get; set; }

        public override void Draw()
        {
            base.Draw();

            int x = IsHorizontalCenter ? (Bounds.X + Bounds.Width / 2) : Bounds.X;
            int y = IsVerticalCenter ? (Bounds.Y + Bounds.Height / 2) : Bounds.Y;

            BasicDrawer.DrawText(TextColor, x, y, Text, IsHorizontalCenter, IsVerticalCenter);
        }
    }
}