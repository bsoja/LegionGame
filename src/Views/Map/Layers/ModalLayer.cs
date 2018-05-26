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

        public ModalLayer(IGuiServices guiServices,
            IMapCityGuiFactory mapCityGuiFactory) : base(guiServices)
        {
            this.mapCityGuiFactory = mapCityGuiFactory;
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
    }
}