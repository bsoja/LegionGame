using Gui.Elements;
using Gui.Services;
using Legion.Model.Types;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Views.Map.Controls
{
    public class ArmyElement : SelectableElement
    {
        private readonly Army _army;
        private readonly Texture2D _image;

        public ArmyElement(IGuiServices guiServices, Army army) : base(guiServices)
        {
            _army = army;

            var armyImages = GuiServices.ImagesStore.GetImages("army.users");
            _image = armyImages[_army.Owner.Id - 1];
        }

        public Army Army => _army;

        public override void Update()
        {
            Bounds = new Rectangle(_army.X, _army.Y, _image.Width, _image.Height);
        }

        public override void Draw()
        {
            if (_army.Owner != null)
            {
                var armyImages = GuiServices.ImagesStore.GetImages("army.users");
                var armyImage = armyImages[_army.Owner.Id - 1];

                //if (IsMouseOver)
                //{
                //    GuiServices.BasicDrawer.DrawRectangle(Color.AntiqueWhite, Bounds);
                //}

                GuiServices.BasicDrawer.DrawImage(armyImage, _army.X, _army.Y);
            }
        }
    }
}