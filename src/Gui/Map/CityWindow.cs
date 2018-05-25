using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Gui.Map
{
    public class CityWindow : Window
    {
        protected const int DefaultWidth = 150;
        protected const int DefaultHeight = 100;

        private readonly Rectangle gameBounds;

        protected Panel innerPanel;
        protected Button okButton;
        protected Button moreButton;
        protected Label nameLabel;
        protected Label countLabel;
        protected Label taxLabel;
        protected Label moraleLabel;
        protected Label infoLabel;

        private List<string> buildingsTextLines = new List<string>();

        public CityWindow(IBasicDrawer basicDrawer, Rectangle gameBounds) : base(basicDrawer)
        {
            this.gameBounds = gameBounds;

            innerPanel = new Panel(basicDrawer);
            okButton = new BrownButton(basicDrawer) { Center = true };
            moreButton = new BrownButton(basicDrawer) { Center = true };
            nameLabel = new Label(basicDrawer);
            countLabel = new Label(basicDrawer);
            taxLabel = new Label(basicDrawer);
            moraleLabel = new Label(basicDrawer);
            infoLabel = new Label(basicDrawer);

            Initialize();
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
        public string TaxText
        {
            get { return taxLabel.Text; }
            set { taxLabel.Text = value; }
        }
        public string MoraleText
        {
            get { return moraleLabel.Text; }
            set { moraleLabel.Text = value; }
        }
        public string InfoText
        {
            get { return infoLabel.Text; }
            set { infoLabel.Text = value; }
        }

        public List<string> Buildings { get; set; }

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

        public event Action<EventArgs> OkClicked
        {
            add
            {
                okButton.Clicked += value;
            }
            remove
            {
                okButton.Clicked -= value;
            }
        }
        public event Action<EventArgs> MoreClicked
        {
            add
            {
                moreButton.Clicked += value;
            }
            remove
            {
                moreButton.Clicked -= value;
            }
        }

        void Initialize()
        {
            var width = DefaultWidth;
            var height = DefaultHeight;

            var x = (gameBounds.Width / 2) - (width / 2);
            var y = (gameBounds.Height / 2) - (height / 2);

            Bounds = new Rectangle(x, y, width, height);

            innerPanel.Bounds = new Rectangle(Bounds.X + 4, Bounds.Y + 4, 142, 74);
            moreButton.Bounds = new Rectangle(Bounds.X + 4, Bounds.Y + 80, 52, 15);
            UpdateOkButton();

            nameLabel.Bounds = new Rectangle(Bounds.X + 50, Bounds.Y + 10, 10, 10);
            countLabel.Bounds = new Rectangle(Bounds.X + 50, Bounds.Y + 20, 10, 10);
            taxLabel.Bounds = new Rectangle(Bounds.X + 50, Bounds.Y + 30, 10, 10);
            moraleLabel.Bounds = new Rectangle(Bounds.X + 50, Bounds.Y + 40, 10, 10);
            infoLabel.Bounds = new Rectangle(Bounds.X + 50, Bounds.Y + 55, 10, 10);
        }

        void UpdateOkButton()
        {
            var okX = string.IsNullOrEmpty(InfoText) ? 55 : 106;
            okButton.Bounds = new Rectangle(Bounds.X + okX, Bounds.Y + 80, 40, 15);
        }

        void UpdateBuildingNames()
        {
            if (Buildings == null) return;

            var idx = 0;
            buildingsTextLines = new List<string> { "" };
            foreach (var name in Buildings)
            {
                var text = buildingsTextLines[idx] + " " + name;
                var width = BasicDrawer.MeasureText(text).X + 8;
                if (width < innerPanel.Bounds.Width)
                {
                    buildingsTextLines[idx] = text;
                }
                else
                {
                    buildingsTextLines.Add(name);
                    idx++;
                }
            }
        }

        public override void Update()
        {
            base.Update();

            UpdateOkButton();

            moreButton.Update();
            okButton.Update();

            UpdateBuildingNames();
        }

        public override void Draw()
        {
            base.Draw();

            innerPanel.Draw();
            if (!string.IsNullOrEmpty(InfoText))
            {
                moreButton.Draw();
            }
            okButton.Draw();

            if (Image != null)
            {
                BasicDrawer.DrawImage(Image, Bounds.X + 8, Bounds.Y + 8);
            }

            nameLabel.Draw();
            countLabel.Draw();
            taxLabel.Draw();
            moraleLabel.Draw();
            infoLabel.Draw();

            var pos = 52;
            foreach (var textLine in buildingsTextLines)
            {
                BasicDrawer.DrawText(Color.Black, Bounds.X + 8, Bounds.Y + pos, textLine);
                pos += 10;
            }

        }
    }
}