using System;
using System.ComponentModel;
using Gui.Elements;
using Gui.Services;
using Microsoft.Xna.Framework;

namespace Legion.Views.Map.Controls
{
    public class MapMenu : ContainerElement
    {
        const int DefaultButtonWidth = 29;
        const int DefaultButtonHeight = 14;

        private Button _startButton;
        private Button _optionsButton;

        public MapMenu(IGuiServices guiServices) : base(guiServices)
        {
            CreateElements();
        }

        public event Action<HandledEventArgs> StartClicked;
        public event Action<HandledEventArgs> OptionsClicked;

        private void CreateElements()
        {
            _startButton = new Button(GuiServices, "Start");
            _startButton.Clicked += args => StartClicked?.Invoke(args);
            _startButton.Bounds = new Rectangle(GuiServices.GameBounds.Width - 35, GuiServices.GameBounds.Height - 36, DefaultButtonWidth, DefaultButtonHeight);

            _optionsButton = new Button(GuiServices, "Opcje");
            _optionsButton.Clicked += args => OptionsClicked?.Invoke(args);
            _optionsButton.Bounds = new Rectangle(GuiServices.GameBounds.Width - 35, GuiServices.GameBounds.Height - 21, DefaultButtonWidth, DefaultButtonHeight);

            _startButton.Center = _optionsButton.Center = true;

            _startButton.FillColor = _optionsButton.FillColor = Colors.MapMenuBackgroundColor;
            _startButton.TextColor = _optionsButton.TextColor = Colors.TextLightColor;

            Elements.Add(_startButton);
            Elements.Add(_optionsButton);
        }

        public override void Draw()
        {
            GuiServices.BasicDrawer.DrawBorder(Color.Red,
                GuiServices.GameBounds.Width - 37,
                GuiServices.GameBounds.Height - 38, 32, 32);
        }
    }
}