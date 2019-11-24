using System;
using System.ComponentModel;
using System.IO;
using Gui.Services;
using Legion.Archive;
using Legion.Localization;
using Legion.Model;
using Legion.Views.Common.Controls;

namespace Legion.Views.Common
{
    public class CommonGuiFactory : ICommonGuiFactory
    {
        private readonly IGuiServices _guiServices;
        private readonly ITexts _texts;
        private readonly IGameArchive _gameArchive;
        private readonly IViewSwitcher _viewSwitcher;

        public CommonGuiFactory(
            IGuiServices guiServices, 
            ITexts texts,
            IGameArchive gameArchive,
            IViewSwitcher viewSwitcher)
        {
            _guiServices = guiServices;
            _texts = texts;
            _gameArchive = gameArchive;
            _viewSwitcher = viewSwitcher;
        }

        public LoadGameWindow CreateLoadGameWindow(Action<HandledEventArgs> onExit)
        {
            var window = new LoadGameWindow(_guiServices, _texts);
            window.ArchiveNameClicked += (args, name) =>
            {
                _viewSwitcher.OpenMenu();
                //TODO: keep archives path in common place
                _gameArchive.LoadGame(Path.Combine("data", "archive", name));
                _viewSwitcher.OpenMap(null);
            };
            if (onExit != null)
            {
                window.ExitClicked += onExit;
            }

            return window;
        }
    }
}
