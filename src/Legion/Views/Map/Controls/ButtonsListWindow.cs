using System;
using System.Collections.Generic;
using System.ComponentModel;
using Gui.Elements;
using Gui.Services;
using Microsoft.Xna.Framework;

namespace Legion.Views.Map.Controls
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

        private Dictionary<string, Action<HandledEventArgs>> _buttonNames;

        public Dictionary<string, Action<HandledEventArgs>> ButtonNames
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
            var buttonsCount = ButtonNames.Count;// + 1;

            var width = Padding + ButtonWidth + Padding;
            var height = Padding + (ButtonHeight * buttonsCount) + (ButtonSpacing * buttonsCount - ButtonSpacing) + Padding;

            var x = (GuiServices.GameBounds.Width / 2) - (width / 2);
            var y = (GuiServices.GameBounds.Height / 2) - (height / 2);
            Bounds = new Rectangle(x, y, width, height);

            var btnNo = 0;

            foreach (var btnInfo in ButtonNames)
            {
                var button = CreateButton(btnNo++, btnInfo.Key);
                if (btnInfo.Value != null)
                {
                    button.Clicked += btnInfo.Value;
                }
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