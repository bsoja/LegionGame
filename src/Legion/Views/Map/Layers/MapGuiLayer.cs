using System.ComponentModel;
using Gui.Services;
using Legion.Controllers.Map;
using Legion.Localization;
using Legion.Model;
using Legion.Views.Map.Controls;

namespace Legion.Views.Map.Layers
{
    public class MapGuiLayer : MapLayer
    {
        private readonly IMapController _mapController;
        private readonly ITexts _texts;
        private readonly IPlayersRepository _playersRepository;
        private readonly ILegionInfo _legionInfo;
        private readonly ModalLayer _modalLayer;
        private MapMenu _mapMenu;

        public MapGuiLayer(
            IGuiServices guiServices,
            IMapController mapController,
            ITexts texts,
            IPlayersRepository playersRepository,
            ILegionInfo legionInfo,
            ModalLayer modalLayer) : base(guiServices)
        {
            _mapController = mapController;
            _texts = texts;
            _playersRepository = playersRepository;
            _legionInfo = legionInfo;
            _modalLayer = modalLayer;
        }

        public override void Initialize()
        {
            _mapMenu = new MapMenu(GuiServices);
            _mapMenu.StartClicked += OnStartClicked;
            _mapMenu.OptionsClicked += OnOptionsClicked;

            AddElement(_mapMenu);
        }

        private void OnOptionsClicked(HandledEventArgs args)
        {
            args.Handled = true;
            var window = new GameOptionsWindow(GuiServices, _texts, _playersRepository, _legionInfo);
            _modalLayer.Window = window;
        }

        private void OnStartClicked(HandledEventArgs args)
        {
            args.Handled = true;
            _mapController.NextTurn();
        }
    }
}