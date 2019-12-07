using Gui.Elements;
using Gui.Services;
using Legion.Model.Types;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Views.Common.Controls.Equipment
{
    public class ItemContainer : ClickableElement
    {
        private const int ItemMargin = 2;
        private const int DefaultWidth = 20;
        private const int DefaultHeight = 20;

        private Texture2D _itemImage;

        public ItemContainer(IGuiServices guiServices) : base(guiServices)
        {
            IsItemVisible = true;
        }

        public bool IsTransparent { get; set; }

        public bool IsItemVisible { get; set; }

        public Point Position
        {
            get => Bounds.Location;
            set => Bounds = new Rectangle(value.X, value.Y, DefaultWidth, DefaultHeight);
        }

        private Item _item;
        public Item Item
        {
            get => _item;
            set
            {
                _item = value;
                _itemImage = _item != null ? GuiServices.ImagesStore.GetImageByRealName(_item.Type.Img) : null;
            }
        }

        public override void Draw()
        {
            if (!IsTransparent)
            {
                GuiServices.BasicDrawer.DrawRectangle(Color.Black, Bounds);
            }
            GuiServices.BasicDrawer.DrawBorder(Colors.ItemContainerBorderColor, Bounds);

            if (_itemImage != null && IsItemVisible)
            {
                GuiServices.BasicDrawer.DrawImage(_itemImage, Bounds.X + ItemMargin, Bounds.Y + ItemMargin);
            }
        }
    }
}