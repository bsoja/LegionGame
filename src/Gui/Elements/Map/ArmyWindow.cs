using System;
using System.ComponentModel;
using Legion.Gui.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Gui.Elements.Map
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

        public ArmyWindow(IGuiServices guiServices) : base(guiServices)
        {
            innerPanel = new Panel(guiServices);
            okButton = new BrownButton(guiServices, "") { Center = true };
            moreButton = new BrownButton(guiServices, "") { Center = true };
            nameLabel = new Label(guiServices);
            countLabel = new Label(guiServices);
            strengthLabel = new Label(guiServices);
            foodLabel = new Label(guiServices);
            speedLabel = new Label(guiServices);
            actionLabel = new Label(guiServices);
            infoLabel = new Label(guiServices);

            CreateElements();
        }

        public Texture2D Image { get; set; }

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
        }

        public override bool UpdateInput()
        {
            var handled = okButton.UpdateInput() || moreButton.UpdateInput();
            if (!handled)
            {
                handled = base.UpdateInput();
            }
            return handled;
        }

        public override void Update()
        {
            base.Update();

            moreButton.Update();
            okButton.Update();
        }

        public override void Draw()
        {
            base.Draw();

            innerPanel.Draw();
            moreButton.Draw();
            okButton.Draw();

            if (Image != null)
            {
                GuiServices.BasicDrawer.DrawImage(Image, Bounds.X + 8, Bounds.Y + 8);
            }

            nameLabel.Draw();
            countLabel.Draw();
            strengthLabel.Draw();
            foodLabel.Draw();
            speedLabel.Draw();
            actionLabel.Draw();
            infoLabel.Draw();
        }
    }
}