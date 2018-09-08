using System;
using Gui.Elements;
using Gui.Services;
using Legion.Gui.Map;
using Legion.Model.Types;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Views.Map.Layers
{
    public class ModalLayer : Layer
    {
        private readonly IMapCityGuiFactory mapCityGuiFactory;
        private readonly IMapArmyGuiFactory mapArmyGuiFactory;

        public ModalLayer(IGuiServices guiServices,
            IMapCityGuiFactory mapCityGuiFactory,
            IMapArmyGuiFactory mapArmyGuiFactory) : base(guiServices)
        {
            this.mapCityGuiFactory = mapCityGuiFactory;
            this.mapArmyGuiFactory = mapArmyGuiFactory;
        }

        public void Show(string title, string text, Texture2D image, Action onClose)
        {
            var messageWindow = new MessageWindow(GuiServices);
            messageWindow.TargetName = title;
            messageWindow.Text = text;
            messageWindow.Image = image;
            messageWindow.Clicked += (args) =>
            {
                onClose?.Invoke();
                RemoveElement(messageWindow);
                Parent.UnblockLayers();
                args.Handled = true;
            };

            AddElement(messageWindow);
            Parent.BlockLayers(this);
        }

        public void ShowCityWindow(City city)
        {
            var cityWindow = mapCityGuiFactory.CreateCityWindow(city);
            AddElement(cityWindow);
            Parent.BlockLayers(this);
            cityWindow.OkClicked += (args) =>
            {
                RemoveElement(cityWindow);
                Parent.UnblockLayers();
                args.Handled = true;
            };

            if (city.Owner != null && city.Owner.IsUserControlled)
            {
                cityWindow.MoreClicked += (args) =>
                {
                    RemoveElement(cityWindow);
                    args.Handled = true;

                    var ordersWindow = mapCityGuiFactory.CreateCityOrdersWindow(city);
                    AddElement(ordersWindow);
                    ordersWindow.ExitClicked += (exitArgs) =>
                    {
                        RemoveElement(ordersWindow);
                        Parent.UnblockLayers();
                        args.Handled = true;
                    };
                };
            }
            else
            {
                // cityWindow.MoreClicked += (args) => HandleBuyInformation(city);
            }
        }

        public void ShowArmyWindow(Army army)
        {
            var armyWindow = mapArmyGuiFactory.CreateArmyWindow(army);
            AddElement(armyWindow);
            Parent.BlockLayers(this);
            armyWindow.OkClicked += (args) =>
            {
                RemoveElement(armyWindow);
                Parent.UnblockLayers();
                args.Handled = true;
            };

            if (army.Owner.IsUserControlled)
            {
                armyWindow.MoreClicked += (args) =>
                {
                    RemoveElement(armyWindow);
                    args.Handled = true;

                    var ordersWindow = mapArmyGuiFactory.CreateArmyOrdersWindow(army);
                    AddElement(ordersWindow);
                    ordersWindow.ExitClicked += (exitArgs) =>
                    {
                        RemoveElement(ordersWindow);
                        Parent.UnblockLayers();
                        exitArgs.Handled = true;
                    };
                };
            }
            else if (army.DaysToGetInfo > 0 && army.DaysToGetInfo < 100)
            {
                //armyWindow.MoreClicked += (args) => HandleBuyInformation(army);
            }
        }
    }
}