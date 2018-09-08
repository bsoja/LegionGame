using System;
using Gui.Elements;
using Gui.Services;
using Legion.Gui.Map;
using Legion.Model;
using Legion.Model.Types;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Views.Map.Layers
{
    public class ModalLayer : Layer
    {
        private readonly IMapCityGuiFactory mapCityGuiFactory;
        private readonly IMapArmyGuiFactory mapArmyGuiFactory;
        private readonly IPlayersRepository playersRepository;

        public ModalLayer(IGuiServices guiServices,
            IMapCityGuiFactory mapCityGuiFactory,
            IMapArmyGuiFactory mapArmyGuiFactory,
            IPlayersRepository playersRepository) : base(guiServices)
        {
            this.mapCityGuiFactory = mapCityGuiFactory;
            this.mapArmyGuiFactory = mapArmyGuiFactory;
            this.playersRepository = playersRepository;
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
                cityWindow.MoreClicked += (args) =>
                {
                    RemoveElement(cityWindow);
                    args.Handled = true;

                    HandleBuyInformation(city);
                };
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
                armyWindow.MoreClicked += (args) =>
                {
                    RemoveElement(armyWindow);
                    args.Handled = true;

                    HandleBuyInformation(army);
                };
            }
        }

        public void HandleBuyInformation(MapObject target)
        {
            var window = new BuyInformationWindow(GuiServices);
            AddElement(window);
            window.CancelClicked += (args) =>
            {
                RemoveElement(window);
                Parent.UnblockLayers();
                args.Handled = true;
            };
            window.OkClicked += (args) =>
            {
                var user = playersRepository.UserPlayer;
                if (user.Money - window.Price >= 0 && window.Price > 100)
                {
                    if (target is Army) ((Army) target).DaysToGetInfo = window.Days;
                    if (target is City) ((City) target).DaysToGetInfo = window.Days;
                    user.Money -= window.Price;
                }

                RemoveElement(window);
                Parent.UnblockLayers();
                args.Handled = true;
            };
        }
    }
}