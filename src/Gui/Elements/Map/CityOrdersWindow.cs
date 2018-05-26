using System.Collections.Generic;
using Legion.Gui.Services;

namespace Legion.Gui.Elements.Map
{
    public class CityOrdersWindow : OrdersWindowBase
    {
        public CityOrdersWindow(IGuiServices guiServices) : base(guiServices) { }

        private List<string> buttonNames;

        protected override List<string> ButtonNames
        {
            get
            {
                if (buttonNames == null)
                {
                    buttonNames = new List<string>
                    {
                    "Podatki",
                    "Nowy Legion",
                    "Rozbudowa",
                    "Budowa Murow"
                    };
                }
                return buttonNames;
            }
        }
    }
}