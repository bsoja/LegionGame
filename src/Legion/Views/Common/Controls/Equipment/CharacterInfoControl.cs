using Gui.Elements;
using Gui.Services;
using Legion.Localization;
using Legion.Model.Types;
using Microsoft.Xna.Framework;

namespace Legion.Views.Common.Controls.Equipment
{
    public class CharacterInfoControl : ContainerElement
    {
        private readonly ITexts _texts;

        public CharacterInfoControl(IGuiServices guiServices, ITexts texts) : base(guiServices)
        {
            _texts = texts;
        }

        public Point Position
        {
            get => Bounds.Location;
            set => Bounds = new Rectangle(value.X, value.Y, 75, 100);
        }

        public Character Character { get; set; }

        public override void Draw()
        {
            GuiServices.BasicDrawer.DrawRectangle(Color.Black, Bounds);

            var left = Bounds.X + 2;
            var top = Bounds.Y + 5;
            var weight = Character.Weight;

            GuiServices.BasicDrawer.DrawText(Color.AntiqueWhite, left, top, Character.Name);
            GuiServices.BasicDrawer.DrawText(Color.AntiqueWhite, left, top + 10, Character.Type.Name);
            GuiServices.BasicDrawer.DrawText(Color.AntiqueWhite, left, top + 20, "Energia:");
            GuiServices.BasicDrawer.DrawText(Color.AntiqueWhite, left, top + 30, "Sila:");
            GuiServices.BasicDrawer.DrawText(Color.AntiqueWhite, left, top + 40, "Szybkosc:");
            GuiServices.BasicDrawer.DrawText(Color.AntiqueWhite, left, top + 50, "Odpornosc:");
            GuiServices.BasicDrawer.DrawText(Color.AntiqueWhite, left, top + 60, "Magia:");
            GuiServices.BasicDrawer.DrawText(weight > Character.EnergyMax ? Color.Red : Color.AntiqueWhite,
                left, top + 70, "Obciazenie:");
            GuiServices.BasicDrawer.DrawText(Color.AntiqueWhite, left, top + 80, "Doswiadczenie:");

            GuiServices.BasicDrawer.DrawText(Color.AntiqueWhite, Bounds.X + 35, top + 20,
                Character.Energy + "/" + Character.EnergyMax);
            GuiServices.BasicDrawer.DrawText(Color.AntiqueWhite, Bounds.X + 55, top + 30, Character.Strength.ToString());
            GuiServices.BasicDrawer.DrawText(Color.AntiqueWhite, Bounds.X + 55, top + 40, Character.Speed.ToString());
            GuiServices.BasicDrawer.DrawText(Color.AntiqueWhite, Bounds.X + 55, top + 50, Character.Resistance.ToString());
            GuiServices.BasicDrawer.DrawText(Color.AntiqueWhite, Bounds.X + 35, top + 60,
                Character.Magic + "/" + Character.MagicMax);
            GuiServices.BasicDrawer.DrawText(Color.AntiqueWhite, Bounds.X + 55, top + 70, weight.ToString());
            GuiServices.BasicDrawer.DrawText(Color.AntiqueWhite, Bounds.X + 60, top + 80, Character.Experience.ToString());
        }
    }
}