using System;
using System.Collections.Generic;
using System.ComponentModel;
using Gui.Services;
using Legion.Localization;
using Legion.Model;

namespace Legion.Views.Map.Controls
{
    public class GameOptionsWindow : ButtonsListWindow
    {
        protected const int OverrideButtonWidth = 120;

        public GameOptionsWindow(
            IGuiServices guiServices,
            ITexts texts,
            IPlayersRepository playersRepository,
            ILegionInfo legionInfo) : base(guiServices)
        {
            ButtonWidth = OverrideButtonWidth;

            var day = legionInfo.CurrentDay;
            var money = playersRepository.UserPlayer.Money;

            var dict = new Dictionary<string, Action<HandledEventArgs>>
            {
                {
                    texts.Get("mapOptions.title", day, money), args => args.Handled = true
                },
                {
                    texts.Get("mapOptions.loadGame"), args =>
                    {
                        LoadGameClicked?.Invoke(args);
                        Closing?.Invoke(args);
                    }
                },
                {
                    texts.Get("mapOptions.saveGame"), args =>
                    {
                        SaveGameClicked?.Invoke(args);
                        Closing?.Invoke(args);
                    }
                },
                {
                    texts.Get("mapOptions.statistics"), args =>
                    {
                        StatisticsClicked?.Invoke(args);
                        Closing?.Invoke(args);
                    }
                },
                {
                    texts.Get("mapOptions.options"), args =>
                    {
                        OptionsClicked?.Invoke(args);
                        Closing?.Invoke(args);
                    }
                },
                {
                    texts.Get("mapOptions.endGame"), args =>
                    {
                        EndGameClicked?.Invoke(args);
                        Closing?.Invoke(args);
                    }
                },
                {
                    texts.Get("mapOptions.exit"), args =>
                    {
                        ExitClicked?.Invoke(args);
                        Closing?.Invoke(args);
                    }
                }
            };

            ButtonNames = dict;
        }

        public event Action<HandledEventArgs> LoadGameClicked;

        public event Action<HandledEventArgs> SaveGameClicked;

        public event Action<HandledEventArgs> StatisticsClicked;

        public event Action<HandledEventArgs> OptionsClicked;

        public event Action<HandledEventArgs> EndGameClicked;

        public event Action<HandledEventArgs> ExitClicked;
    }
}