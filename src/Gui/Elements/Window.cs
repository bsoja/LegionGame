using System;
using System.ComponentModel;
using Gui.Services;

namespace Gui.Elements
{
    public class Window : ContainerElement
    {
        public Window(IGuiServices guiServices) : base(guiServices) { }

        public override void Draw()
        {
            GuiServices.BasicDrawer.DrawRectangle(Colors.WindowBackgroundColor, Bounds);
            GuiServices.BasicDrawer.DrawBorder(Colors.WindowBorderColor, Bounds);
        }

        public Action<HandledEventArgs> Closing;
    }
}