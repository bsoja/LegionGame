using Legion.Controllers;
using Gui.Elements;
using Gui.Services;
using Gui.Input;
using Legion.Model.Types;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Legion.Views.Map.Layers
{
    public class CitiesLayer : Layer
    {
        private List<Texture2D> cityImages;
        private readonly IMapController mapController;
        private readonly ModalLayer modalLayer;

        public CitiesLayer(IGuiServices guiServices,
            IMapController mapController,
            ModalLayer modalLayer) : base(guiServices)
        {
            this.mapController = mapController;
            this.modalLayer = modalLayer;
        }

        public override void Initialize()
        {
            cityImages = GuiServices.ImagesStore.GetImages("city.users");
        }

        private Rectangle GetCityBounds(City city)
        {
            var id = city.IsBigCity ? 1 : 0;
            var imgWidth = (int) (cityImages[id].Width);
            var imgHeight = (int) (cityImages[id].Height);
            var cityBounds = new Rectangle(city.X, city.Y, imgWidth, imgHeight);
            return cityBounds;
        }

        private City GetClickedCity()
        {
            var wasMouseDown = InputManager.GetIsMouseButtonDown(MouseButton.Left, false);
            var isMouseDown = InputManager.GetIsMouseButtonDown(MouseButton.Left, true);
            var prevMousePosition = InputManager.GetMousePostion(false);
            var currMousePosition = InputManager.GetMousePostion(true);

            if (!wasMouseDown && isMouseDown)
            {
                foreach (var city in mapController.Cities)
                {
                    var cityBounds = GetCityBounds(city);
                    if (cityBounds.Contains(prevMousePosition) && cityBounds.Contains(currMousePosition))
                    {
                        return city;
                    }
                }
            }

            return null;
        }

        public override bool UpdateInput()
        {
            var city = GetClickedCity();
            if (city != null)
            {
                modalLayer.ShowCityWindow(city);
                return true;
            }

            return base.UpdateInput();
        }

        public override void Draw()
        {
            foreach (var city in mapController.Cities)
            {
                var id = 0;
                if (city.Owner != null)
                {
                    id = city.Owner.Id * 2;
                }
                if (city.IsBigCity) id++;
                var cityImage = cityImages[id];

                var cityX = city.X - cityImage.Width / 2;
                var cityY = city.Y - cityImage.Height / 2;

                GuiServices.BasicDrawer.DrawImage(cityImage, cityX, cityY);
            }

            base.Draw();
        }

    }
}