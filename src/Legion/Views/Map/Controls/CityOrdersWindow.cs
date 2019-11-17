using System.Collections.Generic;
using Gui.Services;

namespace Legion.Views.Map.Controls
{
    public class CityOrdersWindow : OrdersWindowBase
    {
        public CityOrdersWindow(IGuiServices guiServices) : base(guiServices) { }

        private List<string> _buttonNames;

        protected override List<string> ButtonNames
        {
            get
            {
                if (_buttonNames == null)
                {
                    _buttonNames = new List<string>
                    {
                    "Podatki",
                    "Nowy Legion",
                    "Rozbudowa",
                    "Budowa Murow"
                    };
                }
                return _buttonNames;
            }
        }
    }
}