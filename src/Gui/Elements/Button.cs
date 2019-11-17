using Gui.Input;
using Gui.Services;
using Microsoft.Xna.Framework;

namespace Gui.Elements
{
    public class Button : Panel
    {
        protected Label Label;

        public Button(IGuiServices guiServices, string text) : base(guiServices)
        {
            Label = new Label(guiServices) { IsVerticalCenter = true };
            Text = text;
        }

        public bool Center { get; set; }

        public string Text
        {
            get => Label.Text;
            set => Label.Text = value;
        }

        public Color TextColor
        {
            get => Label.TextColor;
            set => Label.TextColor = value;
        }

        protected override bool OnMouseDown(MouseButton button, Point position)
        {
            if (button == MouseButton.Left)
            {
                Invert = true;
            }

            return base.OnMouseDown(button, position);
        }

        protected override bool OnMouseUp(MouseButton button, Point position)
        {
            if (button == MouseButton.Left)
            {
                Invert = false;
            }

            return base.OnMouseUp(button, position);
        }

        public override void Update()
        {
            base.Update();

            int x = Center ? (Bounds.X + Bounds.Width / 2) : (Bounds.X + 4);
            int y = Bounds.Y + Bounds.Height / 2;

            Label.Bounds = new Rectangle(x, y, 1, 1);
            Label.IsHorizontalCenter = Center;
        }

        public override void Draw()
        {
            base.Draw();
            Label.Draw();
        }
    }
}