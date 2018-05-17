namespace Legion.Gui
{
    public class Window : GuiElement
    {
        public Window(IBasicDrawer basicDrawer) : base(basicDrawer)
        { }

        public override void Draw()
        {
            base.Draw();
            BasicDrawer.DrawRectangle(Colors.WindowBackgroundColor, Bounds);
            BasicDrawer.DrawBorder(Colors.WindowBorderColor, Bounds);
        }
    }
}