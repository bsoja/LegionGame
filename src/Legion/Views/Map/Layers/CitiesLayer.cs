using Gui.Elements;
using Gui.Services;
using Gui.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.ComponentModel;
using Legion.Controllers.Map;

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

            Clicked += CitiesLayer_Clicked;
        }

        public override void Initialize()
        {
            cityImages = GuiServices.ImagesStore.GetImages("city.users");
        }

        private void CitiesLayer_Clicked(HandledEventArgs obj)
        {
            var mousePosition = InputManager.GetMousePostion(true);

            foreach (var city in mapController.Cities)
            {
                var id = city.IsBigCity ? 1 : 0;
                var cityBounds = new Rectangle(city.X, city.Y, cityImages[id].Width, cityImages[id].Height);
                if (cityBounds.Contains(mousePosition))
                {
                    modalLayer.ShowCityWindow(city);
                    obj.Handled = true;
                }
            }
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