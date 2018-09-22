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

        protected Panel innerPanel;
        protected Button okButton;
        protected Button moreButton;
        protected Label nameLabel;
        protected Label countLabel;
        protected Label strengthLabel;
        protected Label foodLabel;
        protected Label speedLabel;
        protected Label actionLabel;
        protected Label infoLabel;
        protected Image image;

        public ArmyWindow(IGuiServices guiServices) : base(guiServices)
        {
            CreateElements();
        }

        public Texture2D Image
        {
            get { return image.Data; }
            set { image.Data = value; }
        }

        public string NameText
        {
            get { return nameLabel.Text; }
            set { nameLabel.Text = value; }
        }

        public string CountText
        {
            get { return countLabel.Text; }
            set { countLabel.Text = value; }
        }

        public string StrengthText
        {
            get { return strengthLabel.Text; }
            set { strengthLabel.Text = value; }
        }

        public string FoodText
        {
            get { return foodLabel.Text; }
            set { foodLabel.Text = value; }
        }

        public string SpeedText
        {
            get { return speedLabel.Text; }
            set { speedLabel.Text = value; }
        }

        public string ActionText
        {
            get { return actionLabel.Text; }
            set { actionLabel.Text = value; }
        }

        public string InfoText
        {
            get { return infoLabel.Text; }
            set { infoLabel.Text = value; }
        }

        public string ButtonMoreText
        {
            get { return moreButton.Text; }
            set { moreButton.Text = value; }
        }

        public string ButtonOkText
        {
            get { return okButton.Text; }
            set { okButton.Text = value; }
        }

        public event Action<HandledEventArgs> OkClicked
        {
            add { okButton.Clicked += value; }
            remove { okButton.Clicked -= value; }
        }

        public event Action<HandledEventArgs> MoreClicked
        {
            add { moreButton.Clicked += value; }
            remove { moreButton.Clicked -= value; }
        }

        private void CreateElements()
        {
            innerPanel = new Panel(GuiServices);
            okButton = new BrownButton(GuiServices, "") { Center = true };
            moreButton = new BrownButton(GuiServices, "") { Center = true };
            nameLabel = new Label(GuiServices);
            countLabel = new Label(GuiServices);
            strengthLabel = new Label(GuiServices);
            foodLabel = new Label(GuiServices);
            speedLabel = new Label(GuiServices);
            actionLabel = new Label(GuiServices);
            infoLabel = new Label(GuiServices);
            image = new Image(GuiServices);

            Elements.Add(innerPanel);
            Elements.Add(okButton);
            Elements.Add(moreButton);
            Elements.Add(nameLabel);
            Elements.Add(countLabel);
            Elements.Add(strengthLabel);
            Elements.Add(foodLabel);
            Elements.Add(speedLabel);
            Elements.Add(actionLabel);
            Elements.Add(infoLabel);
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

            innerPanel.Bounds = new Rectangle(Bounds.X + 4, Bounds.Y + 4, 142, 74);
            moreButton.Bounds = new Rectangle(Bounds.X + 4, Bounds.Y + 80, 52, 15);
            okButton.Bounds = new Rectangle(Bounds.X + 106, Bounds.Y + 80, 40, 15);

            nameLabel.Bounds = new Rectangle(Bounds.X + 50, Bounds.Y + 10, 10, 10);
            countLabel.Bounds = new Rectangle(Bounds.X + 50, Bounds.Y + 20, 10, 10);
            strengthLabel.Bounds = new Rectangle(Bounds.X + 50, Bounds.Y + 30, 10, 10);
            foodLabel.Bounds = new Rectangle(Bounds.X + 50, Bounds.Y + 40, 10, 10);
            speedLabel.Bounds = new Rectangle(Bounds.X + 50, Bounds.Y + 50, 10, 10);
            actionLabel.Bounds = new Rectangle(Bounds.X + 12, Bounds.Y + 60, 10, 10);
            infoLabel.Bounds = new Rectangle(Bounds.X + 25, Bounds.Y + 60, 10, 10);
            image.Bounds = new Rectangle(Bounds.X + 8, Bounds.Y + 8, 1, 1);
        }
    }
}