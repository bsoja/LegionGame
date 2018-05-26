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

        public BuyInformationWindow(IGuiServices guiServices) : base(guiServices)
        {
            innerPanel = new Panel(guiServices);
            pricePanel = new Panel(guiServices);
            upButton = new BrownButton(guiServices, "+"); //TODO: up arrow
            downButton = new BrownButton(guiServices, "-"); //TODO: down arrow
            okButton = new BrownButton(guiServices, "Ok");
            cancelButton = new BrownButton(guiServices, "Odwolac");
            priceLabel = new Label(guiServices)
            {
                IsHorizontalCenter = true,
                IsVerticalCenter = true
            };
            label1 = new Label(guiServices) { IsVerticalCenter = true };
            label2 = new Label(guiServices) { IsVerticalCenter = true };

            Initialize();
        }

        public Texture2D Image { get; set; }

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

        private void Initialize()
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

            pricePanel.Bounds = new Rectangle(Bounds.X + 112, Bounds.Y + 24, 40, 15);
            priceLabel.Bounds = pricePanel.Bounds;

            cancelButton.Bounds = new Rectangle(Bounds.X + 112, Bounds.Y + 61, 40, 15);
            okButton.Bounds = new Rectangle(Bounds.X + 112, Bounds.Y + 81, 40, 15);

            cancelButton.Center = okButton.Center = upButton.Center = downButton.Center = true;

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

        public override void Update()
        {
            base.Update();

            UpdatePrice();

            upButton.Update();
            downButton.Update();
            okButton.Update();
            cancelButton.Update();
        }

        public override void Draw()
        {
            base.Draw();

            innerPanel.Draw();
            pricePanel.Draw();
            upButton.Draw();
            downButton.Draw();
            okButton.Draw();
            cancelButton.Draw();
            priceLabel.Draw();
            label1.Draw();
            label2.Draw();

            if (Image != null)
            {
                GuiServices.BasicDrawer.DrawImage(Image, Bounds.X + 8, Bounds.Y + 8);
            }
        }
    }
}