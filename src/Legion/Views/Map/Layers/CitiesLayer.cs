using System.Collections.Generic;
using System.ComponentModel;
using Gui.Elements;
using Gui.Input;
using Gui.Services;
using Legion.Controllers.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Views.Map.Layers
{
    public class CitiesLayer : Layer
    {
        private List<Texture2D> _cityImages;
        private readonly IMapController _mapController;
        private readonly ModalLayer _modalLayer;

        public CitiesLayer(IGuiServices guiServices,
            IMapController mapController,
            ModalLayer modalLayer) : base(guiServices)
        {
            _mapController = mapController;
            _modalLayer = modalLayer;

            Clicked += CitiesLayer_Clicked;
        }

        public override void Initialize()
        {
            _cityImages = GuiServices.ImagesStore.GetImages("city.users");
        }

        private void CitiesLayer_Clicked(HandledEventArgs obj)
        {
            var mousePosition = InputManager.GetMousePostion(true);

            foreach (var city in _mapController.Cities)
            {
                var id = city.IsBigCity ? 1 : 0;
                var cityBounds = new Rectangle(city.X, city.Y, _cityImages[id].Width, _cityImages[id].Height);
                if (cityBounds.Contains(mousePosition))
                {
                    _modalLayer.ShowCityWindow(city);
                    obj.Handled = true;
                }
            }
        }

        public override void Draw()
        {
            foreach (var city in _mapController.Cities)
            {
                var id = 0;
                if (city.Owner != null)
                {
                    id = city.Owner.Id * 2;
                }
                if (city.IsBigCity) id++;
                var cityImage = _cityImages[id];

                var cityX = city.X - cityImage.Width / 2;
                var cityY = city.Y - cityImage.Height / 2;

                GuiServices.BasicDrawer.DrawImage(cityImage, cityX, cityY);
            }

            base.Draw();
        }

    }
}