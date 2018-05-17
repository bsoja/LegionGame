namespace Legion.Gui
{
    public class BrownButton : Button
    {
        public BrownButton(IBasicDrawer basicDrawer) : base(basicDrawer)
        {
            FillColor = Colors.PanelBrownFillColor;
            DarkColor = Colors.PanelBrownDarkColor;
            LightColor = Colors.PanelBrownLightColor;
            TextColor = Colors.TextLightColor;
        }

        public BrownButton(IBasicDrawer basicDrawer, string text) : this(basicDrawer)
        {
            Text = text;
        }
    }
}