using System.Collections.Generic;
using Gui.Services;

namespace Legion.Views.Map.Controls
{
    public class ArmyOrdersWindow : OrdersWindowBase
    {
        private bool _isTerrainActionButtonVisible;
        private bool _isRecruitButtonVisible;

        public ArmyOrdersWindow(IGuiServices guiServices,
            bool isTerrainActionButtonVisible,
            bool isRecruitButtonVisible) : base(guiServices)
        {
            _isTerrainActionButtonVisible = isTerrainActionButtonVisible;
            _isRecruitButtonVisible = isRecruitButtonVisible;
        }

        private List<string> _buttonNames;
        protected override List<string> ButtonNames
        {
            get
            {
                if (_buttonNames == null)
                {
                    _buttonNames = new List<string>
                    {
                    "Ruch",
                    "Szybki Ruch",
                    "Atak",
                    _isRecruitButtonVisible ? "Rekrutacja" : "Polowanie",
                    "Oboz",
                    "Ekwipunek"
                    };
                    if (_isTerrainActionButtonVisible)
                    {
                        _buttonNames.Add("Akcja w terenie");
                    }
                }
                return _buttonNames;
            }
        }

        public override void Draw()
        {
            base.Draw();

            //TODO: selected action marker 
            /*
               If TRYB>0
                  Text OKX+65,OKY-4+18*TRYB,"@"
               End If 
               If TRYB=0
                  Text OKX+65,OKY-4+18*5,"@"
               End If 
            */
        }
    }
}