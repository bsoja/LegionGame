using System;
using Microsoft.Xna.Framework;

namespace Legion.Gui.Map
{
    public class MapMenu : GuiElement
    {
        const int DefaultButtonWidth = 58;
        const int DefaultButtonHeight = 28;

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
            startButton.Bounds = new Rectangle(gameBounds.Width - 70, gameBounds.Height - 72, DefaultButtonWidth, DefaultButtonHeight);

            optionsButton = new Button(BasicDrawer);
            optionsButton.Text = "Opcje";
            optionsButton.Clicked += (args) => OptionsClicked?.Invoke(args);
            optionsButton.Bounds = new Rectangle(gameBounds.Width - 70, gameBounds.Height - 42, DefaultButtonWidth, DefaultButtonHeight);

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
            BasicDrawer.DrawBorder(Color.Red, gameBounds.Width - 74, gameBounds.Height - 76, 65, 65);
            startButton.Draw();
            optionsButton.Draw();
        }
    }
}