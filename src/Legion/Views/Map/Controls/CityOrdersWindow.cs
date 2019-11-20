using System;
using System.Collections.Generic;
using System.ComponentModel;
using Gui.Services;
using Legion.Localization;

namespace Legion.Views.Map.Controls
{
    public class CityOrdersWindow : ButtonsListWindow
    {
        public CityOrdersWindow(IGuiServices guiServices, ITexts texts) : base(guiServices)
        {
            //TODO: provide translations for all items here
            ButtonNames = new Dictionary<string, Action<HandledEventArgs>>
            {
                {"Podatki", args => TaxesClicked?.Invoke(args)},
                {"Nowy Legion", args => NewLegionClicked?.Invoke(args)},
                {"Rozbudowa", args => BuildClicked?.Invoke(args)},
                {"Budowa Murow", args => WallsBuildClicked?.Invoke(args)},
                {texts.Get("exit"), args => ExitClicked?.Invoke(args)}
            };
        }

        public event Action<HandledEventArgs> TaxesClicked;

        public event Action<HandledEventArgs> NewLegionClicked;

        public event Action<HandledEventArgs> BuildClicked;

        public event Action<HandledEventArgs> WallsBuildClicked;

        public event Action<HandledEventArgs> ExitClicked;
    }
}