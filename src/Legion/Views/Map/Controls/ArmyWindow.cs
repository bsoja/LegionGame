using System;
using System.ComponentModel;
using Gui.Elements;
using Gui.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Views.Map.Controls
{
    public class ArmyWindow : Window
    {
        const int DefaultWidth = 150;
        const int DefaultHeight = 100;

        protected Panel InnerPanel;
        protected Button OkButton;
        protected Button MoreButton;
        protected Label NameLabel;
        protected Label CountLabel;
        protected Label StrengthLabel;
        protected Label FoodLabel;
        protected Label SpeedLabel;
        protected Label ActionLabel;
        protected Label InfoLabel;
        protected Image image;

        public ArmyWindow(IGuiServices guiServices) : base(guiServices)
        {
            CreateElements();
        }

        public Texture2D Image
        {
            get => image.Data;
            set => image.Data = value;
        }

        public string NameText
        {
            get => NameLabel.Text;
            set => NameLabel.Text = value;
        }

        public string CountText
        {
            get => CountLabel.Text;
            set => CountLabel.Text = value;
        }

        public string StrengthText
        {
            get => StrengthLabel.Text;
            set => StrengthLabel.Text = value;
        }

        public string FoodText
        {
            get => FoodLabel.Text;
            set => FoodLabel.Text = value;
        }

        public string SpeedText
        {
            get => SpeedLabel.Text;
            set => SpeedLabel.Text = value;
        }

        public string ActionText
        {
            get => ActionLabel.Text;
            set => ActionLabel.Text = value;
        }

        public string InfoText
        {
            get => InfoLabel.Text;
            set => InfoLabel.Text = value;
        }

        public string ButtonMoreText
        {
            get => MoreButton.Text;
            set => MoreButton.Text = value;
        }

        public string ButtonOkText
        {
            get => OkButton.Text;
            set => OkButton.Text = value;
        }

        public event Action<HandledEventArgs> OkClicked
        {
            add => OkButton.Clicked += value;
            remove => OkButton.Clicked -= value;
        }

        public event Action<HandledEventArgs> MoreClicked
        {
            add => MoreButton.Clicked += value;
            remove => MoreButton.Clicked -= value;
        }

        private void CreateElements()
        {
            InnerPanel = new Panel(GuiServices);
            OkButton = new BrownButton(GuiServices, "") { Center = true };
            MoreButton = new BrownButton(GuiServices, "") { Center = true };
            NameLabel = new Label(GuiServices);
            CountLabel = new Label(GuiServices);
            StrengthLabel = new Label(GuiServices);
            FoodLabel = new Label(GuiServices);
            SpeedLabel = new Label(GuiServices);
            ActionLabel = new Label(GuiServices);
            InfoLabel = new Label(GuiServices);
            image = new Image(GuiServices);

            Elements.Add(InnerPanel);
            Elements.Add(OkButton);
            Elements.Add(MoreButton);
            Elements.Add(NameLabel);
            Elements.Add(CountLabel);
            Elements.Add(StrengthLabel);
            Elements.Add(FoodLabel);
            Elements.Add(SpeedLabel);
            Elements.Add(ActionLabel);
            Elements.Add(InfoLabel);
            Elements.Add(image);

            UpdateBounds();
        }

        private void UpdateBounds()
        {
            var width = DefaultWidth;
            var height = DefaultHeight;
            var x = (GuiServices.GameBounds.Width / 2) - (width / 2);
            var y = (GuiServices.GameBounds.Height / 2) - (height / 2);
            Bounds = new Rectangle(x, y, width, height);

            InnerPanel.Bounds = new Rectangle(Bounds.X + 4, Bounds.Y + 4, 142, 74);
            MoreButton.Bounds = new Rectangle(Bounds.X + 4, Bounds.Y + 80, 52, 15);
            OkButton.Bounds = new Rectangle(Bounds.X + 106, Bounds.Y + 80, 40, 15);

            NameLabel.Bounds = new Rectangle(Bounds.X + 50, Bounds.Y + 10, 10, 10);
            CountLabel.Bounds = new Rectangle(Bounds.X + 50, Bounds.Y + 20, 10, 10);
            StrengthLabel.Bounds = new Rectangle(Bounds.X + 50, Bounds.Y + 30, 10, 10);
            FoodLabel.Bounds = new Rectangle(Bounds.X + 50, Bounds.Y + 40, 10, 10);
            SpeedLabel.Bounds = new Rectangle(Bounds.X + 50, Bounds.Y + 50, 10, 10);
            ActionLabel.Bounds = new Rectangle(Bounds.X + 12, Bounds.Y + 60, 10, 10);
            InfoLabel.Bounds = new Rectangle(Bounds.X + 25, Bounds.Y + 60, 10, 10);
            image.Bounds = new Rectangle(Bounds.X + 8, Bounds.Y + 8, 1, 1);
        }
    }
}