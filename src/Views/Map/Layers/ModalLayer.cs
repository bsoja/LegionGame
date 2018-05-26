using System;
using Legion.Gui.Elements;
using Legion.Gui.Elements.Map;
using Legion.Gui.Services;
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

            // if (city.Owner != null && city.Owner.IsUserControlled)
            // {
            //     ((CityWindow) activeWindow).MoreClicked += () =>
            //     {
            //         activeWindow = mapUiFactory.CreateCityOrdersWindow(city);
            //         ((CityOrdersWindow) activeWindow).ExitClicked += () => activeWindow = null;
            //     };
            // }
            // else
            // {
            //     ((CityWindow) activeWindow).MoreClicked += () => HandleBuyInformation(city);
            // }
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

            // if (army.Owner.IsUserControlled)
            // {
            //     ((ArmyWindow) activeWindow).MoreClicked += () =>
            //     {
            //         activeWindow = mapUiFactory.CreateArmyOrdersWindow(army);
            //         ((ArmyOrdersWindow) activeWindow).ExitClicked += () => activeWindow = null;
            //     };
            // }
            // else if (army.DaysToGetInfo > 0 && army.DaysToGetInfo < 100)
            // {
            //     ((ArmyWindow) activeWindow).MoreClicked += () => HandleBuyInformation(army);
            // }
        }
    }
}