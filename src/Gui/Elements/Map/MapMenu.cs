using System;
using System.ComponentModel;
using Legion.Gui.Services;
using Microsoft.Xna.Framework;

namespace Legion.Gui.Elements.Map
{
    public class MapMenu : ContainerElement
    {
        const int DefaultButtonWidth = 29;
        const int DefaultButtonHeight = 14;

        private Button startButton;
        private Button optionsButton;

        public MapMenu(IGuiServices guiServices) : base(guiServices)
        {
            CreateElements();
        }

        public event Action<HandledEventArgs> StartClicked;
        public event Action<HandledEventArgs> OptionsClicked;

        private void CreateElements()
        {
            startButton = new Button(GuiServices, "Start");
            startButton.Clicked += (args) => StartClicked?.Invoke(args);
            startButton.Bounds = new Rectangle(GuiServices.GameBounds.Width - 35, GuiServices.GameBounds.Height - 36, DefaultButtonWidth, DefaultButtonHeight);

            optionsButton = new Button(GuiServices, "Opcje");
            optionsButton.Clicked += (args) => OptionsClicked?.Invoke(args);
            optionsButton.Bounds = new Rectangle(GuiServices.GameBounds.Width - 35, GuiServices.GameBounds.Height - 21, DefaultButtonWidth, DefaultButtonHeight);

            startButton.Center = optionsButton.Center = true;

            startButton.FillColor = optionsButton.FillColor = Colors.MapMenuBackgroundColor;
            startButton.TextColor = optionsButton.TextColor = Colors.TextLightColor;

            Elements.Add(startButton);
            Elements.Add(optionsButton);
        }

        public override void Draw()
        {
            GuiServices.BasicDrawer.DrawBorder(Color.Red,
                GuiServices.GameBounds.Width - 37,
                GuiServices.GameBounds.Height - 38, 32, 32);
        }
    }
}