using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Legion.Gui.Services;
using Microsoft.Xna.Framework;

namespace Legion.Gui.Elements.Map
{
    public abstract class OrdersWindowBase : Window
    {
        protected const int ButtonWidth = 72;
        protected const int ButtonHeight = 15;
        protected const int Padding = 4;
        protected const int ButtonSpacing = 3;

        public OrdersWindowBase(IGuiServices guiServices) : base(guiServices)
        {
            CreateElements();
        }

        protected Button ExitButton { get; private set; }

        public event Action<HandledEventArgs> ExitClicked
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

        private void CreateElements()
        {
            var buttonsCount = ButtonNames.Count + 1;

            var width = Padding + ButtonWidth + Padding;
            var height = Padding + (ButtonHeight * buttonsCount) + (ButtonSpacing * buttonsCount - ButtonSpacing) + Padding;

            var x = (GuiServices.GameBounds.Width / 2) - (width / 2);
            var y = (GuiServices.GameBounds.Height / 2) - (height / 2);
            Bounds = new Rectangle(x, y, width, height);

            var btnNo = 0;

            foreach (var btnName in ButtonNames)
            {
                Elements.Add(CreateButton(btnNo++, btnName));
            }
            ExitButton = CreateButton(btnNo++, "Exit");
            Elements.Add(ExitButton);
        }

        private Button CreateButton(int btnNo, string text)
        {
            var x = Bounds.X + Padding;
            var y = Bounds.Y + (Padding + (btnNo * ButtonHeight) + (btnNo * ButtonSpacing));

            var button = new BrownButton(GuiServices, text);
            button.Bounds = new Rectangle(x, y, ButtonWidth, ButtonHeight);

            return button;
        }
    }
}