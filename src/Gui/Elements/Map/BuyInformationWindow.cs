using System;
using System.ComponentModel;
using Legion.Gui.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Gui.Elements.Map
{
    public class BuyInformationWindow : Window
    {
        private const int DefaultWidth = 156;
        private const int DefaultHeight = 100;

        protected Panel innerPanel;
        protected Panel pricePanel;
        protected Button upButton;
        protected Button downButton;
        protected Button okButton;
        protected Button cancelButton;
        protected Label priceLabel;
        protected Label label1;
        protected Label label2;
        protected Image image;

        public BuyInformationWindow(IGuiServices guiServices) : base(guiServices)
        {
            CreateElements();
        }

        public Texture2D Image
        {
            get { return image.Data; }
            set { image.Data = value; }
        }

        public string Text1
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        public string Text2
        {
            get { return label2.Text; }
            set { label2.Text = value; }
        }

        public int Price { get; set; }

        public int Days { get; set; } = 22;

        public event Action<HandledEventArgs> OkClicked
        {
            add { okButton.Clicked += value; }
            remove { okButton.Clicked -= value; }
        }

        public event Action<HandledEventArgs> CancelClicked
        {
            add { cancelButton.Clicked += value; }
            remove { cancelButton.Clicked -= value; }
        }

        private void CreateElements()
        {
            innerPanel = new Panel(GuiServices);
            pricePanel = new Panel(GuiServices);
            upButton = new BrownButton(GuiServices, "+"); //TODO: up arrow
            downButton = new BrownButton(GuiServices, "-"); //TODO: down arrow
            okButton = new BrownButton(GuiServices, "Ok"); // TODO: use translated texts here
            cancelButton = new BrownButton(GuiServices, "Odwolac"); // TODO: use translated texts here
            priceLabel = new Label(GuiServices)
            {
                IsHorizontalCenter = true,
                IsVerticalCenter = true
            };
            label1 = new Label(GuiServices) { IsVerticalCenter = true };
            label2 = new Label(GuiServices) { IsVerticalCenter = true };
            image = new Image(GuiServices);

            Elements.Add(innerPanel);
            Elements.Add(priceLabel);
            Elements.Add(upButton);
            Elements.Add(downButton);
            Elements.Add(okButton);
            Elements.Add(cancelButton);
            Elements.Add(priceLabel);
            Elements.Add(label1);
            Elements.Add(label2);
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

            innerPanel.Bounds = new Rectangle(Bounds.X + 4, Bounds.Y + 4, 104, 92);
            upButton.Bounds = new Rectangle(Bounds.X + 112, Bounds.Y + 4, 18, 15);
            downButton.Bounds = new Rectangle(Bounds.X + 133, Bounds.Y + 4, 18, 15);
            label1.Bounds = new Rectangle(Bounds.X + 12, Bounds.Y + 70, 40, 15);
            label2.Bounds = new Rectangle(Bounds.X + 12, Bounds.Y + 80, 40, 15);
            image.Bounds = new Rectangle(Bounds.X + 8, Bounds.Y + 8, 1, 1);

            pricePanel.Bounds = new Rectangle(Bounds.X + 112, Bounds.Y + 24, 40, 15);
            priceLabel.Bounds = pricePanel.Bounds;

            okButton.Bounds = new Rectangle(Bounds.X + 112, Bounds.Y + 81, 40, 15);
            cancelButton.Bounds = new Rectangle(Bounds.X + 112, Bounds.Y + 61, 40, 15);

            cancelButton.Center = okButton.Center = upButton.Center = downButton.Center = true;
        }

        private void ConnectEvents()
        {
            upButton.Clicked += (args) => { ChangePrice(1); args.Handled = true; };
            downButton.Clicked += (args) => { ChangePrice(-1); args.Handled = true; };
        }

        void ChangePrice(int n)
        {
            Price += n * 50;
            if (Price > 1000) Price = 0;
            if (Price < 0) Price = 1000;

            Days += -n;
            if (Days > 22) Days = 2;
            if (Days < 2) Days = 22;

            priceLabel.Text = Price.ToString();

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
                Text1 = "Za " + Days.ToString() + " dni";
                Text2 = "bede cos wiedzial.";
            }
        }
    }
}