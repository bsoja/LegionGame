using Legion.Controllers;
using Legion.Gui.Elements;
using Legion.Gui.Services;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Views.Map.Layers
{
    public class CitiesLayer : Layer
    {
        private Texture2D[] cityImages;
        private readonly IMapController mapController;

        public CitiesLayer(IGuiServices guiServices, IMapController mapController) : base(guiServices)
        {
            this.mapController = mapController;
        }

        public override void Initialize()
        {
            cityImages = new []
            {
                GuiServices.ImagesProvider.GetImage(ImageType.CityEmptySmall),
                GuiServices.ImagesProvider.GetImage(ImageType.CityEmptyBig),
                GuiServices.ImagesProvider.GetImage(ImageType.CityUserSmall),
                GuiServices.ImagesProvider.GetImage(ImageType.CityUserBig),
                GuiServices.ImagesProvider.GetImage(ImageType.CityPlayer2Small),
                GuiServices.ImagesProvider.GetImage(ImageType.CityPlayer2Big),
                GuiServices.ImagesProvider.GetImage(ImageType.CityPlayer3Small),
                GuiServices.ImagesProvider.GetImage(ImageType.CityPlayer3Big),
                GuiServices.ImagesProvider.GetImage(ImageType.CityPlayer4Small),
                GuiServices.ImagesProvider.GetImage(ImageType.CityPlayer4Big),
            };
        }

        public override void Draw()
        {
            base.Draw();

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
        }
    }
}