using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Legion.Gui.Map
{
    public abstract class OrdersWindowBase : Window
    {
        protected const int ButtonWidth = 72;
        protected const int ButtonHeight = 15;
        protected const int Padding = 4;
        protected const int ButtonSpacing = 3;

        private readonly Rectangle gameBounds;

        public OrdersWindowBase(IBasicDrawer basicDrawer, Rectangle gameBounds) : base(basicDrawer)
        {
            this.gameBounds = gameBounds;
            Initialize();
        }

        protected Button ExitButton
        {
            get { return Buttons.LastOrDefault(); }
        }

        public event Action<EventArgs> ExitClicked
        {
            add
            {
                ExitButton.Clicked += value;
            }
            remove
            {
                ExitButton.Clicked -= value;
            }
        }

        protected abstract List<string> ButtonNames { get; }

        private List<Button> Buttons { get; set; }

        private void Initialize()
        {
            var buttonsCount = ButtonNames.Count + 1;

            var width = Padding + ButtonWidth + Padding;
            var height = Padding + (ButtonHeight * buttonsCount) + (ButtonSpacing * buttonsCount - ButtonSpacing) + Padding;

            var x = (gameBounds.Width / 2) - (width / 2);
            var y = (gameBounds.Height / 2) - (height / 2);
            Bounds = new Rectangle(x, y, width, height);

            var btnNo = 0;

            Buttons = new List<Button>();
            foreach (var btnName in ButtonNames)
            {
                Buttons.Add(CreateButton(btnNo++, btnName));
            }
            Buttons.Add(CreateButton(btnNo++, "Exit"));
        }

        private Button CreateButton(int btnNo, string text)
        {
            var x = Bounds.X + Padding;
            var y = Bounds.Y + (Padding + (btnNo * ButtonHeight) + (btnNo * ButtonSpacing));

            var button = new BrownButton(BasicDrawer);
            button.Bounds = new Rectangle(x, y, ButtonWidth, ButtonHeight);

            button.Text = text;

            return button;
        }

        public override void Update()
        {
            base.Update();

            foreach (var button in Buttons)
            {
                button.Update();
            }
        }

        public override void Draw()
        {
            base.Draw();

            foreach (var button in Buttons)
            {
                button.Draw();
            }
        }
    }
}