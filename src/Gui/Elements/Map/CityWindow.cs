using System;
using System.Collections.Generic;
using System.ComponentModel;
using Legion.Gui.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Gui.Elements.Map
{
    public class CityWindow : Window
    {
        protected const int DefaultWidth = 150;
        protected const int DefaultHeight = 100;

        protected Panel innerPanel;
        protected Button okButton;
        protected Button moreButton;
        protected Label nameLabel;
        protected Label countLabel;
        protected Label taxLabel;
        protected Label moraleLabel;
        protected Label infoLabel;
        protected Image image;

        private List<string> buildingsTextLines = new List<string>();

        public CityWindow(IGuiServices guiServices) : base(guiServices)
        {
            CreateElements();
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
            set
            {
                infoLabel.Text = value;
                UpdateOkButtonBounds();
                UpdateMoreButtonVisibility();
            }
        }

        public Texture2D Image
        {
            get { return image.Data; }
            set { image.Data = value; }
        }

        private List<string> buildings;
        public List<string> Buildings
        {
            get { return buildings; }
            set
            {
                buildings = value;
                UpdateBuildingNames();
            }
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
            taxLabel = new Label(GuiServices);
            moraleLabel = new Label(GuiServices);
            infoLabel = new Label(GuiServices);
            image = new Image(GuiServices);

            Elements.Add(innerPanel);
            Elements.Add(okButton);
            Elements.Add(moreButton);
            Elements.Add(nameLabel);
            Elements.Add(countLabel);
            Elements.Add(taxLabel);
            Elements.Add(moraleLabel);
            Elements.Add(infoLabel);
            Elements.Add(image);

            UpdateBounds();
            UpdateMoreButtonVisibility();
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
            nameLabel.Bounds = new Rectangle(Bounds.X + 50, Bounds.Y + 10, 10, 10);
            countLabel.Bounds = new Rectangle(Bounds.X + 50, Bounds.Y + 20, 10, 10);
            taxLabel.Bounds = new Rectangle(Bounds.X + 50, Bounds.Y + 30, 10, 10);
            moraleLabel.Bounds = new Rectangle(Bounds.X + 50, Bounds.Y + 40, 10, 10);
            infoLabel.Bounds = new Rectangle(Bounds.X + 50, Bounds.Y + 55, 10, 10);
            image.Bounds = new Rectangle(Bounds.X + 8, Bounds.Y + 8, 1, 1);

            UpdateOkButtonBounds();
        }

        private void UpdateOkButtonBounds()
        {
            var okX = !string.IsNullOrEmpty(InfoText) ? 55 : 106;
            okButton.Bounds = new Rectangle(Bounds.X + okX, Bounds.Y + 80, 40, 15);
        }

        private void UpdateMoreButtonVisibility()
        {
            moreButton.IsVisible = string.IsNullOrEmpty(InfoText);
        }

        private void UpdateBuildingNames()
        {
            if (Buildings == null) return;

            var idx = 0;
            buildingsTextLines = new List<string> { "" };
            foreach (var name in Buildings)
            {
                var text = buildingsTextLines[idx] + " " + name;
                var width = GuiServices.BasicDrawer.MeasureText(text).X + 8;
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

        public override void Draw()
        {
            base.Draw();
            DrawBuildingNames();
        }

        private void DrawBuildingNames()
        {
            var pos = 52;
            foreach (var textLine in buildingsTextLines)
            {
                GuiServices.BasicDrawer.DrawText(Color.Black, Bounds.X + 8, Bounds.Y + pos, textLine);
                pos += 10;
            }
        }
    }
}