using Microsoft.Xna.Framework;

namespace Legion.Gui.Elements
{
    public static class Colors
    {
		public readonly static Color WindowBorderColor = new Color (0x00, 0xBB, 0xFF);
        public readonly static Color WindowBackgroundColor = new Color (PanelBrownDarkColor, 0x55);

		public readonly static Color TextDarkColor = new Color (0x22, 0x11, 0x00);
        public readonly static Color TextLightColor = new Color (0xCC, 0xCC, 0xCC);

        public readonly static Color MapMenuBackgroundColor = new Color (0x88, 0x88, 0x88);

		public readonly static Color PanelFillColor = new Color (0xAA, 0xAA, 0xAA);
		public readonly static Color PanelLightColor = new Color (PanelFillColor.R + 0x22, PanelFillColor.G + 0x22, PanelFillColor.B + 0x22);
		public readonly static Color PanelDarkColor = new Color (0x33, 0x22, 0x11);

        public readonly static Color PanelBrownFillColor = new Color (0x77, 0x66, 0x55);
		public readonly static Color PanelBrownLightColor = new Color (PanelBrownFillColor.R + 0x22, PanelBrownFillColor.G + 0x22, PanelBrownFillColor.B + 0x22);
		public readonly static Color PanelBrownDarkColor = new Color (0x33, 0x22, 0x11);
    }
}