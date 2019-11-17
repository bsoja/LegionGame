using Gui.Elements;
using Gui.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Views.Map.Controls
{
    public class MessageWindow : ClickableElement
    {
        protected const int DefaultWidth = 112;
        protected const int DefaultHeight = 120;

        protected Panel InnerPanel;
        protected Label TextLabel;
        protected Label TargetLabel;

        public MessageWindow(IGuiServices guiServices) : base(guiServices)
        {
            InnerPanel = new Panel(guiServices);
            TextLabel = new Label(guiServices);
            TargetLabel = new Label(guiServices);

            CreateElements();
        }

        public Texture2D Image { get; set; }

        public string Text
        {
            get => TextLabel.Text;
            set => TextLabel.Text = value;
        }

        public string TargetName
        {
            get => TargetLabel.Text;
            set => TargetLabel.Text = value;
        }

        private void CreateElements()
        {
            var width = DefaultWidth;
            var height = DefaultHeight;

            var x = (GuiServices.GameBounds.Width / 2) - (width / 2);
            var y = (GuiServices.GameBounds.Height / 2) - (height / 2);

            Bounds = new Rectangle(x, y, width, height);
            InnerPanel.Bounds = new Rectangle(x + 4, y + 4, width - 7, height - 6);

            TargetLabel.Bounds = new Rectangle(x + 10, y + 80, 10, 10);
            TextLabel.Bounds = new Rectangle(x + 12, y + 90, 10, 10);
        }

        public override void Draw()
        {
            GuiServices.BasicDrawer.DrawBorder(Colors.WindowBorderColor, Bounds);
            InnerPanel.Draw();
            GuiServices.BasicDrawer.DrawImage(Image, Bounds.X + 8, Bounds.Y + 8);
            TextLabel.Draw();
            TargetLabel.Draw();
        }
    }
}