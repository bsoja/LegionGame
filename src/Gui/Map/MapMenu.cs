using System;
using Microsoft.Xna.Framework;

namespace Legion.Gui.Map
{
    public class MapMenu : GuiElement
    {
        const int DefaultButtonWidth = 29;
        const int DefaultButtonHeight = 14;

        private readonly Rectangle gameBounds;
        private Button startButton;
        private Button optionsButton;

        public MapMenu(IBasicDrawer basicDrawer, Rectangle gameBounds) : base(basicDrawer)
        {
            this.gameBounds = gameBounds;
            Initialize();
        }

        public event Action<EventArgs> StartClicked;
        public event Action<EventArgs> OptionsClicked;

        private void Initialize()
        {
            startButton = new Button(BasicDrawer);
            startButton.Text = "Start";
            startButton.Clicked += (args) => StartClicked?.Invoke(args);
            startButton.Bounds = new Rectangle(gameBounds.Width - 35, gameBounds.Height - 36, DefaultButtonWidth, DefaultButtonHeight);

            optionsButton = new Button(BasicDrawer);
            optionsButton.Text = "Opcje";
            optionsButton.Clicked += (args) => OptionsClicked?.Invoke(args);
            optionsButton.Bounds = new Rectangle(gameBounds.Width - 35, gameBounds.Height - 21, DefaultButtonWidth, DefaultButtonHeight);

            startButton.Center = optionsButton.Center = true;

            startButton.FillColor = optionsButton.FillColor = Colors.MapMenuBackgroundColor;
            startButton.TextColor = optionsButton.TextColor = Colors.TextLightColor;
        }

        public override void Update()
        {
            startButton.Update();
            optionsButton.Update();
        }

        public override void Draw()
        {
            BasicDrawer.DrawBorder(Color.Red, gameBounds.Width - 37, gameBounds.Height - 38, 32, 32);
            startButton.Draw();
            optionsButton.Draw();
        }
    }
}