using System;
using System.ComponentModel;
using Gui.Elements;
using Gui.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Views.Map.Controls
{
    public class BuyInformationWindow : Window
    {
        private const int DefaultWidth = 156;
        private const int DefaultHeight = 100;

        protected Panel InnerPanel;
        protected Panel PricePanel;
        protected Button UpButton;
        protected Button DownButton;
        protected Button OkButton;
        protected Button CancelButton;
        protected Label PriceLabel;
        protected Label Label1;
        protected Label Label2;
        protected Image image;

        public BuyInformationWindow(IGuiServices guiServices) : base(guiServices)
        {
            CreateElements();
        }

        public Texture2D Image
        {
            get => image.Data;
            set => image.Data = value;
        }

        public string Text1
        {
            get => Label1.Text;
            set => Label1.Text = value;
        }

        public string Text2
        {
            get => Label2.Text;
            set => Label2.Text = value;
        }

        public int Price { get; set; }

        public int Days { get; set; } = 22;

        public event Action<HandledEventArgs> OkClicked
        {
            add => OkButton.Clicked += value;
            remove => OkButton.Clicked -= value;
        }

        public event Action<HandledEventArgs> CancelClicked
        {
            add => CancelButton.Clicked += value;
            remove => CancelButton.Clicked -= value;
        }

        private void CreateElements()
        {
            InnerPanel = new Panel(GuiServices);
            PricePanel = new Panel(GuiServices);
            UpButton = new BrownButton(GuiServices, "+"); //TODO: up arrow
            DownButton = new BrownButton(GuiServices, "-"); //TODO: down arrow
            OkButton = new BrownButton(GuiServices, "Ok"); // TODO: use translated texts here
            CancelButton = new BrownButton(GuiServices, "Odwolac"); // TODO: use translated texts here
            PriceLabel = new Label(GuiServices)
            {
                IsHorizontalCenter = true,
                IsVerticalCenter = true
            };
            Label1 = new Label(GuiServices) { IsVerticalCenter = true };
            Label2 = new Label(GuiServices) { IsVerticalCenter = true };
            image = new Image(GuiServices);

            Elements.Add(InnerPanel);
            Elements.Add(PriceLabel);
            Elements.Add(UpButton);
            Elements.Add(DownButton);
            Elements.Add(OkButton);
            Elements.Add(CancelButton);
            Elements.Add(PriceLabel);
            Elements.Add(Label1);
            Elements.Add(Label2);
            Elements.Add(image);

            UpdateBounds();
            ConnectEvents();
        }

        private void UpdateBounds()
        {
            var width = DefaultWidth;
            var height = DefaultHeight;
            var x = (GuiServices.GameBounds.Width / 2) - (width / 2);
            var y = (GuiServices.GameBounds.Height / 2) - (height / 2);
            Bounds = new Rectangle(x, y, width, height);

            InnerPanel.Bounds = new Rectangle(Bounds.X + 4, Bounds.Y + 4, 104, 92);
            UpButton.Bounds = new Rectangle(Bounds.X + 112, Bounds.Y + 4, 18, 15);
            DownButton.Bounds = new Rectangle(Bounds.X + 133, Bounds.Y + 4, 18, 15);
            Label1.Bounds = new Rectangle(Bounds.X + 12, Bounds.Y + 70, 40, 15);
            Label2.Bounds = new Rectangle(Bounds.X + 12, Bounds.Y + 80, 40, 15);
            image.Bounds = new Rectangle(Bounds.X + 8, Bounds.Y + 8, 1, 1);

            PricePanel.Bounds = new Rectangle(Bounds.X + 112, Bounds.Y + 24, 40, 15);
            PriceLabel.Bounds = PricePanel.Bounds;

            OkButton.Bounds = new Rectangle(Bounds.X + 112, Bounds.Y + 81, 40, 15);
            CancelButton.Bounds = new Rectangle(Bounds.X + 112, Bounds.Y + 61, 40, 15);

            CancelButton.Center = OkButton.Center = UpButton.Center = DownButton.Center = true;
        }

        private void ConnectEvents()
        {
            UpButton.Clicked += args => { ChangePrice(1); args.Handled = true; };
            DownButton.Clicked += args => { ChangePrice(-1); args.Handled = true; };
        }

        void ChangePrice(int n)
        {
            Price += n * 50;
            if (Price > 1000) Price = 0;
            if (Price < 0) Price = 1000;

            Days += -n;
            if (Days > 22) Days = 2;
            if (Days < 2) Days = 22;

            PriceLabel.Text = Price.ToString();

            UpdatePrice();
        }

        private void UpdatePrice()
        {
            if (Price <= 100)
            {
                Text1 = "ladna mamy dzis ";
                Text2 = "pogode.";
                if (Price == 0)
                {
                    Text1 = "Za informacje trzeba";
                    Text2 = "zaplacic.";
                }
            }
            else
            {
                Text1 = "Za " + Days + " dni";
                Text2 = "bede cos wiedzial.";
            }
        }
    }
}