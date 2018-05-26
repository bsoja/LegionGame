using Legion.Gui.Services;

namespace Legion.Gui.Elements
{
    public class Window : ClickableElement
    {
        public Window(IGuiServices guiServices) : base(guiServices) { }

        public override void Draw()
        {
            base.Draw();
            GuiServices.BasicDrawer.DrawRectangle(Colors.WindowBackgroundColor, Bounds);
            GuiServices.BasicDrawer.DrawBorder(Colors.WindowBorderColor, Bounds);
        }
    }
}