using Gui.Elements;
using Gui.Services;
using Legion.Model.Types;
using Microsoft.Xna.Framework;

namespace Legion.Views.Common.Controls.Equipment
{
    public class GroundItemsControl : ContainerElement
    {
        private readonly ItemContainer[] _groundContainers;

        public GroundItemsControl(IGuiServices guiServices) : base(guiServices)
        {
            _groundContainers = new ItemContainer[4];
            for (var i = 0; i < 4; i++)
            {
                _groundContainers[i] = new ItemContainer(GuiServices);
                AddElement(_groundContainers[i]);
            }
        }

        public Point Position
        {
            get => Bounds.Location;
            set => Bounds = new Rectangle(value.X, value.Y, 80, 120);
        }

        private Character _character;
        public Character Character
        {
            get => _character;
            set
            {
                //TODO: handle ground items
                _character = value;
                for (var i = 0; i < 4; i++)
                {
                    _groundContainers[i].Item = null;//_character.Equipment.Backpack[i];
                }
            }
        }

        public override void Update()
        {
            for (var i = 0; i < 4; i++)
            {
                _groundContainers[i].Position = new Point(Bounds.X + 5 + i * 25, Bounds.Y + 5);
            }
        }

        public override void Draw()
        {
            GuiServices.BasicDrawer.DrawBorder(Color.Black, Bounds.X, Bounds.Y, 105, 30);

            //TODO: GLEBA!!
            //B3 = GLEBA(SEK, I)
            //If B3> 0
            //BB3 = BRON(B3, B_BOB) + BROBY
            //Paste Bob X2 + 7 + (I * 25),Y2 + 7,BB3 + GOBY
        }
    }
}