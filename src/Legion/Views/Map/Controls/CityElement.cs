using Gui.Elements;
using Gui.Services;
using Legion.Model.Types;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Views.Map.Controls
{
    public class CityElement : SelectableElement
    {
        private readonly City _city;

        public CityElement(IGuiServices guiServices, City city) : base(guiServices)
        {
            _city = city;
        }

        public override void Update()
        {
            var cityImage = GetCityImage();
            var cityX = _city.X - cityImage.Width / 2;
            var cityY = _city.Y - cityImage.Height / 2;
            Bounds = new Rectangle(cityX, cityY, cityImage.Width, cityImage.Height);

            base.Update();
        }

        public override void Draw()
        {
            var cityImage = GetCityImage();

            //if (IsMouseOver)
            //{
            //    GuiServices.BasicDrawer.DrawRectangle(Color.AntiqueWhite, Bounds);
            //}

            GuiServices.BasicDrawer.DrawImage(cityImage, Bounds.X, Bounds.Y);
        }

        private Texture2D GetCityImage()
        {
            var cityImages = GuiServices.ImagesStore.GetImages("city.users");

            var id = 0;
            if (_city.Owner != null)
            {
                id = _city.Owner.Id * 2;
            }
            if (_city.IsBigCity) id++;
            var cityImage = cityImages[id];
            return cityImage;
        }
    }
}