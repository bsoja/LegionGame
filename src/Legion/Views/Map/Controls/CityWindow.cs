using System;
using System.Collections.Generic;
using System.ComponentModel;
using Gui.Elements;
using Gui.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Views.Map.Controls
{
    public class CityWindow : Window
    {
        protected const int DefaultWidth = 150;
        protected const int DefaultHeight = 100;

        protected Panel InnerPanel;
        protected Button OkButton;
        protected Button MoreButton;
        protected Label NameLabel;
        protected Label CountLabel;
        protected Label TaxLabel;
        protected Label MoraleLabel;
        protected Label InfoLabel;
        protected Image image;

        private List<string> _buildingsTextLines = new List<string>();

        public CityWindow(IGuiServices guiServices) : base(guiServices)
        {
            CreateElements();
        }

        public string NameText
        {
            get { return NameLabel.Text; }
            set { NameLabel.Text = value; }
        }

        public string CountText
        {
            get { return CountLabel.Text; }
            set { CountLabel.Text = value; }
        }

        public string TaxText
        {
            get { return TaxLabel.Text; }
            set { TaxLabel.Text = value; }
        }

        public string MoraleText
        {
            get { return MoraleLabel.Text; }
            set { MoraleLabel.Text = value; }
        }

        public string InfoText
        {
            get { return InfoLabel.Text; }
            set
            {
                InfoLabel.Text = value;
                UpdateOkButtonBounds();
                UpdateMoreButtonVisibility();
            }
        }

        public Texture2D Image
        {
            get { return image.Data; }
            set { image.Data = value; }
        }

        private List<string> _buildings;
        public List<string> Buildings
        {
            get { return _buildings; }
            set
            {
                _buildings = value;
                UpdateBuildingNames();
            }
        }

        public string ButtonMoreText
        {
            get { return MoreButton.Text; }
            set { MoreButton.Text = value; }
        }

        public string ButtonOkText
        {
            get { return OkButton.Text; }
            set { OkButton.Text = value; }
        }

        public event Action<HandledEventArgs> OkClicked
        {
            add { OkButton.Clicked += value; }
            remove { OkButton.Clicked -= value; }
        }

        public event Action<HandledEventArgs> MoreClicked
        {
            add { MoreButton.Clicked += value; }
            remove { MoreButton.Clicked -= value; }
        }

        private void CreateElements()
        {
            InnerPanel = new Panel(GuiServices);
            OkButton = new BrownButton(GuiServices, "") { Center = true };
            MoreButton = new BrownButton(GuiServices, "") { Center = true };
            NameLabel = new Label(GuiServices);
            CountLabel = new Label(GuiServices);
            TaxLabel = new Label(GuiServices);
            MoraleLabel = new Label(GuiServices);
            InfoLabel = new Label(GuiServices);
            image = new Image(GuiServices);

            Elements.Add(InnerPanel);
            Elements.Add(OkButton);
            Elements.Add(MoreButton);
            Elements.Add(NameLabel);
            Elements.Add(CountLabel);
            Elements.Add(TaxLabel);
            Elements.Add(MoraleLabel);
            Elements.Add(InfoLabel);
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

            InnerPanel.Bounds = new Rectangle(Bounds.X + 4, Bounds.Y + 4, 142, 74);
            MoreButton.Bounds = new Rectangle(Bounds.X + 4, Bounds.Y + 80, 52, 15);
            NameLabel.Bounds = new Rectangle(Bounds.X + 50, Bounds.Y + 10, 10, 10);
            CountLabel.Bounds = new Rectangle(Bounds.X + 50, Bounds.Y + 20, 10, 10);
            TaxLabel.Bounds = new Rectangle(Bounds.X + 50, Bounds.Y + 30, 10, 10);
            MoraleLabel.Bounds = new Rectangle(Bounds.X + 50, Bounds.Y + 40, 10, 10);
            InfoLabel.Bounds = new Rectangle(Bounds.X + 50, Bounds.Y + 55, 10, 10);
            image.Bounds = new Rectangle(Bounds.X + 8, Bounds.Y + 8, 1, 1);

            UpdateOkButtonBounds();
        }

        private void UpdateOkButtonBounds()
        {
            var okX = !string.IsNullOrEmpty(InfoText) ? 55 : 106;
            OkButton.Bounds = new Rectangle(Bounds.X + okX, Bounds.Y + 80, 40, 15);
        }

        private void UpdateMoreButtonVisibility()
        {
            MoreButton.IsVisible = string.IsNullOrEmpty(InfoText);
        }

        private void UpdateBuildingNames()
        {
            if (Buildings == null) return;

            var idx = 0;
            _buildingsTextLines = new List<string> { "" };
            foreach (var name in Buildings)
            {
                var text = _buildingsTextLines[idx] + " " + name;
                var width = GuiServices.BasicDrawer.MeasureText(text).X + 8;
                if (width < InnerPanel.Bounds.Width)
                {
                    _buildingsTextLines[idx] = text;
                }
                else
                {
                    _buildingsTextLines.Add(name);
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
            foreach (var textLine in _buildingsTextLines)
            {
                GuiServices.BasicDrawer.DrawText(Color.Black, Bounds.X + 8, Bounds.Y + pos, textLine);
                pos += 10;
            }
        }
    }
}