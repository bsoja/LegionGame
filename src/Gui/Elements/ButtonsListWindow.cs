using System;
using System.Collections.Generic;
using System.ComponentModel;
using Gui.Services;
using Microsoft.Xna.Framework;

namespace Gui.Elements
{
    public class ButtonsListWindow : Window
    {
        protected const int ButtonWidth = 72;
        protected const int ButtonHeight = 15;
        protected const int Padding = 4;
        protected const int ButtonSpacing = 3;

        public ButtonsListWindow(IGuiServices guiServices) : base(guiServices)
        {
        }

        public event Action<HandledEventArgs, string> ButtonClicked;

        private List<string> _buttonNames;

        public List<string> ButtonNames
        {
            get => _buttonNames;
            set
            {
                _buttonNames = value;
                CreateElements();
            }
        }

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
                var button = CreateButton(btnNo++, btnName);
                button.Clicked += args => ButtonClicked?.Invoke(args, btnName);
                Elements.Add(button);
            }
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