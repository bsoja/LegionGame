using Gui.Services;

namespace Gui.Elements
{
    public class BrownButton : Button
    {
        public BrownButton(IGuiServices guiServices, string text) : base(guiServices, text)
        {
            FillColor = Colors.PanelBrownFillColor;
            DarkColor = Colors.PanelBrownDarkColor;
            LightColor = Colors.PanelBrownLightColor;
            TextColor = Colors.TextLightColor;
        }
    }
}