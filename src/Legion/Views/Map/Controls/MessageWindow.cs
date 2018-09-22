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

        protected Panel innerPanel;
        protected Label textLabel;
        protected Label targetLabel;

        public MessageWindow(IGuiServices guiServices) : base(guiServices)
        {
            innerPanel = new Panel(guiServices);
            textLabel = new Label(guiServices);
            targetLabel = new Label(guiServices);

            CreateElements();
        }

        public Texture2D Image { get; set; }

        public string Text
        {
            get { return textLabel.Text; }
            set { textLabel.Text = value; }
        }

        public string TargetName
        {
            get { return targetLabel.Text; }
            set { targetLabel.Text = value; }
        }

        private void CreateElements()
        {
            var width = DefaultWidth;
            var height = DefaultHeight;

            var x = (GuiServices.GameBounds.Width / 2) - (width / 2);
            var y = (GuiServices.GameBounds.Height / 2) - (height / 2);

            Bounds = new Rectangle(x, y, width, height);
            innerPanel.Bounds = new Rectangle(x + 4, y + 4, width - 7, height - 6);

            targetLabel.Bounds = new Rectangle(x + 10, y + 80, 10, 10);
            textLabel.Bounds = new Rectangle(x + 12, y + 90, 10, 10);
        }

        public override void Draw()
        {
            GuiServices.BasicDrawer.DrawBorder(Colors.WindowBorderColor, Bounds);
            innerPanel.Draw();
            GuiServices.BasicDrawer.DrawImage(Image, Bounds.X + 8, Bounds.Y + 8);
            textLabel.Draw();
            targetLabel.Draw();
        }
    }
}