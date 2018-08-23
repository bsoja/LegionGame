using System.Collections.Generic;
using Gui.Services;
using Legion.Gui.Elements.Map;

namespace Legion.Gui.Map
{
    public class ArmyOrdersWindow : OrdersWindowBase
    {
        private bool isTerrainActionButtonVisible;
        private bool isRecruitButtonVisible;

        public ArmyOrdersWindow(ILegionGuiServices guiServices,
            bool isTerrainActionButtonVisible,
            bool isRecruitButtonVisible) : base(guiServices)
        {
            this.isTerrainActionButtonVisible = isTerrainActionButtonVisible;
            this.isRecruitButtonVisible = isRecruitButtonVisible;
        }

        private List<string> buttonNames;
        protected override List<string> ButtonNames
        {
            get
            {
                if (buttonNames == null)
                {
                    buttonNames = new List<string>
                    {
                    "Ruch",
                    "Szybki Ruch",
                    "Atak",
                    isRecruitButtonVisible ? "Rekrutacja" : "Polowanie",
                    "Oboz",
                    "Ekwipunek"
                    };
                    if (isTerrainActionButtonVisible)
                    {
                        buttonNames.Add("Akcja w terenie");
                    }
                }
                return buttonNames;
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