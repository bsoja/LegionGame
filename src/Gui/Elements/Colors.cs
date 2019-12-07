using Microsoft.Xna.Framework;

namespace Gui.Elements
{
    public static class Colors
    {
		public static readonly Color WindowBorderColor = new Color (0x00, 0xBB, 0xFF);
        public static readonly Color WindowBackgroundColor = new Color (PanelBrownDarkColor, 0x55);

		public static readonly Color TextDarkColor = new Color (0x22, 0x11, 0x00);
        public static readonly Color TextLightColor = new Color (0xCC, 0xCC, 0xCC);

        public static readonly Color MapMenuBackgroundColor = new Color (0x88, 0x88, 0x88);

		public static readonly Color PanelFillColor = new Color (0xAA, 0xAA, 0xAA);
		public static readonly Color PanelLightColor = new Color (PanelFillColor.R + 0x22, PanelFillColor.G + 0x22, PanelFillColor.B + 0x22);
		public static readonly Color PanelDarkColor = new Color (0x33, 0x22, 0x11);

        public static readonly Color PanelBrownFillColor = new Color (0x77, 0x66, 0x55);
		public static readonly Color PanelBrownLightColor = new Color (PanelBrownFillColor.R + 0x22, PanelBrownFillColor.G + 0x22, PanelBrownFillColor.B + 0x22);
		public static readonly Color PanelBrownDarkColor = new Color (0x33, 0x22, 0x11);

		public static readonly Color ItemContainerBorderColor = new Color (0xBB, 0x99, 0x66);
    }
}