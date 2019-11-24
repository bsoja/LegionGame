using System;
using System.ComponentModel;
using Gui.Elements;
using Gui.Services;
using Legion.Localization;
using Microsoft.Xna.Framework;

namespace Legion.Views.Map.Controls
{
    public class GameStatisticsWindow : Window
    {
        protected const int DefaultWidth = 160;
        protected const int DefaultHeight = 120;

        private readonly ITexts _texts;

        protected Panel InnerPanel;
        protected Button OkButton;
        protected Button ChartsButton;
        protected Label Label1;
        protected Label Label2;
        protected Label Label3;
        protected Label Label4;
        protected Label Label5;
        protected Label Label6;

        public GameStatisticsWindow(
            IGuiServices guiServices,
            ITexts texts) : base(guiServices)
        {
            _texts = texts;
            CreateElements();
        }

        public event Action<HandledEventArgs> OkClicked
        {
            add => OkButton.Clicked += value;
            remove => OkButton.Clicked -= value;
        }

        public event Action<HandledEventArgs> ChartsClicked
        {
            add => ChartsButton.Clicked += value;
            remove => ChartsButton.Clicked -= value;
        }

        private void CreateElements()
        {
            InnerPanel = new Panel(GuiServices);

            OkButton = new BrownButton(GuiServices, _texts.Get("gameStatistics.ok")) { Center = true };
            OkButton.Clicked += args => Closing?.Invoke(args);

            ChartsButton = new BrownButton(GuiServices, _texts.Get("gameStatistics.charts")) { Center = true };
            ChartsButton.Clicked += args => Closing?.Invoke(args);

            Label1 = new Label(GuiServices){ Text = "Raport na dzien: 142"};
            Label2 = new Label(GuiServices) { Text = "W twoim wladaniu : " };
            Label3 = new Label(GuiServices) { Text = "13 legiony, 51 wojownikow" };
            Label4 = new Label(GuiServices) { Text = "19 miast, 13311 mieszkancow" };
            Label5 = new Label(GuiServices) { Text = "Dzienny dochod : 2914 " };
            Label6 = new Label(GuiServices) { Text = "W skarbcu: 146394" };

            Elements.Add(InnerPanel);
            Elements.Add(OkButton);
            Elements.Add(ChartsButton);
            Elements.Add(Label1);
            Elements.Add(Label2);
            Elements.Add(Label3);
            Elements.Add(Label4);
            Elements.Add(Label5);
            Elements.Add(Label6);

            UpdateBounds();
        }

        private void UpdateBounds()
        {
            var width = DefaultWidth;
            var height = DefaultHeight;
            var x = (GuiServices.GameBounds.Width / 2) - (width / 2);
            var y = (GuiServices.GameBounds.Height / 2) - (height / 2);
            Bounds = new Rectangle(x, y, width, height);

            InnerPanel.Bounds = new Rectangle(Bounds.X + 4, Bounds.Y + 4, 152, 92);
            ChartsButton.Bounds = new Rectangle(Bounds.X + 4, Bounds.Y + 100, 40, 15);
            OkButton.Bounds = new Rectangle(Bounds.X + 116, Bounds.Y + 100, 40, 15);

            Label1.Bounds = new Rectangle(Bounds.X + 8, Bounds.Y + 16, 10, 10);
            Label2.Bounds = new Rectangle(Bounds.X + 8, Bounds.Y + 26, 10, 10);
            Label3.Bounds = new Rectangle(Bounds.X + 8, Bounds.Y + 44, 10, 10);
            Label4.Bounds = new Rectangle(Bounds.X + 8, Bounds.Y + 54, 10, 10);
            Label5.Bounds = new Rectangle(Bounds.X + 8, Bounds.Y + 74, 10, 10);
            Label6.Bounds = new Rectangle(Bounds.X + 8, Bounds.Y + 84, 10, 10);
        }
    }
}