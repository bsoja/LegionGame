using Gui.Elements;
using Gui.Services;
using Legion.Model.Types;
using Microsoft.Xna.Framework;

namespace Legion.Views.Map.Controls
{
    public class PlayerChartElement : ContainerElement
    {
        private readonly Label _playerLabel;
        private readonly Player _player;
        private int _length = 4;

        public PlayerChartElement(
            IGuiServices guiServices,
            Player player) : base(guiServices)
        {
            _player = player;
            _playerLabel = new Label(GuiServices);
            Elements.Add(_playerLabel);
        }

        public override void Update()
        {
            _playerLabel.Text = _player.Name;
            _playerLabel.Bounds = new Rectangle(Bounds.X + 8, Bounds.Y + 4, 10, 10);

            _length = _player.Power / 250;
            if (_length > 100) _length = 100;
            if (_length < 4) _length = 4;
        }

        public override void Draw()
        {
            var x = Bounds.X + 50;
            var y = Bounds.Y;// - 8;
            var width = _length;
            var height = 15;
            GuiServices.BasicDrawer.DrawRectangle(Color.Brown, x, y, width, height);
        }
    }
}