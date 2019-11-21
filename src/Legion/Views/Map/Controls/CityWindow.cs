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
        protected List<Label> BuildingLabels;
        protected Image image;

        public CityWindow(IGuiServices guiServices) : base(guiServices)
        {
            CreateElements();
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

        public string TaxText
        {
            get => TaxLabel.Text;
            set => TaxLabel.Text = value;
        }

        public string MoraleText
        {
            get => MoraleLabel.Text;
            set => MoraleLabel.Text = value;
        }

        public string InfoText
        {
            get => InfoLabel.Text;
            set
            {
                InfoLabel.Text = value;
                UpdateOkButtonBounds();
                UpdateMoreButtonVisibility();
            }
        }

        public Texture2D Image
        {
            get => image.Data;
            set => image.Data = value;
        }

        private List<string> _buildings;
        public List<string> Buildings
        {
            get => _buildings;
            set
            {
                _buildings = value;
                UpdateBuildingNames();
            }
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
            OkButton.Clicked += args => Closing?.Invoke(args);

            MoreButton = new BrownButton(GuiServices, "") { Center = true };
            MoreButton.Clicked += args => Closing?.Invoke(args);

            NameLabel = new Label(GuiServices);
            CountLabel = new Label(GuiServices);
            TaxLabel = new Label(GuiServices);
            MoraleLabel = new Label(GuiServices);
            InfoLabel = new Label(GuiServices);
            image = new Image(GuiServices);
            BuildingLabels = new List<Label>();

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
            var buildingsTextLines = new List<string> { "" };
            foreach (var name in Buildings)
            {
                var text = buildingsTextLines[idx] + " " + name;
                var width = GuiServices.BasicDrawer.MeasureText(text).X + 8;
                if (width < InnerPanel.Bounds.Width)
                {
                    buildingsTextLines[idx] = text;
                }
                else
                {
                    buildingsTextLines.Add(name);
                    idx++;
                }
            }

            foreach (var label in BuildingLabels)
            {
                RemoveElement(label);
            }
            BuildingLabels.Clear();

            var pos = 52;
            foreach (var line in buildingsTextLines)
            {
                var lineLabel = new Label(GuiServices)
                {
                    TextColor = Color.Black,
                    Bounds = new Rectangle(Bounds.X + 8, Bounds.Y + pos, 0, 0),
                    Text = line
                };
                BuildingLabels.Add(lineLabel);
                AddElement(lineLabel);
                pos += 10;
            }
        }
        
    }
}