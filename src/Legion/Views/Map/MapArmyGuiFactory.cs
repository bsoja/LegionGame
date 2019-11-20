using System.Collections.Generic;
using Gui.Services;
using Legion.Localization;
using Legion.Model;
using Legion.Model.Types;
using Legion.Views.Map.Controls;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Views.Map
{
    public class MapArmyGuiFactory : IMapArmyGuiFactory
    {
        private readonly IGuiServices _guiServices;
        private readonly ILegionConfig _legionConfig;
        private readonly ITexts _texts;
        private List<Texture2D> _armyWindowImages;

        public MapArmyGuiFactory(IGuiServices guiServices,
            ILegionConfig legionConfig,
            ITexts texts)
        {
            _guiServices = guiServices;
            _legionConfig = legionConfig;
            _texts = texts;

            guiServices.GameLoaded += LoadImages;
        }

        private void LoadImages()
        {
            _armyWindowImages = _guiServices.ImagesStore.GetImages("army.windowUsers");
        }

        public ArmyWindow CreateArmyWindow(Army army)
        {
            var window = new ArmyWindow(_guiServices);
            var hasData = false;
            var infoText = "";

            window.NameText = army.Name;
            window.Image = _armyWindowImages[army.Owner.Id - 1];

            window.ButtonOkText = _texts.Get("ok");
            if (army.Owner.IsUserControlled)
            {
                window.ButtonMoreText = _texts.Get("commands");
                hasData = true;
            }
            else
            {
                window.ButtonMoreText = _texts.Get("interview");
                if (army.DaysToGetInfo > 28 && army.DaysToGetInfo < 100)
                {
                    hasData = false;
                    infoText = _texts.Get("noInformation");
                }
                else
                {
                    infoText = army.DaysToGetInfo > 1 ?
                        _texts.Get("informationsInXDays", army.DaysToGetInfo) :
                        _texts.Get("informationsInOneDay");
                    hasData = false;
                }
                if (army.DaysToGetInfo == 0 || army.DaysToGetInfo == 100)
                {
                    hasData = true;
                    window.ButtonMoreText = _texts.Get("trace");
                }
            }

            if (!hasData && !_legionConfig.GoDmOdE)
            {
                window.InfoText = infoText;
            }
            else
            {
                var count = army.Characters.Count;
                window.CountText = count == 1 ?
                    _texts.Get("oneWarrior") :
                    _texts.Get("xWarriors", count);

                int foodCount = army.Food / army.Characters.Count;
                if (foodCount > 1) window.FoodText = _texts.Get("foodForXDays", foodCount);
                else if (foodCount == 1) window.FoodText = _texts.Get("foodForOneDay");
                else window.FoodText = _texts.Get("noMoreFood");

                window.StrengthText = _texts.Get("strength") + ": " + army.Strength;
                window.SpeedText = _texts.Get("speed") + ": " + army.Speed;

                window.ActionText = "";
                switch (army.CurrentAction)
                {
                    case ArmyActions.Camping:
                        window.ActionText = _texts.Get("camping");
                        /* TODO:
                         If TEREN>69
                            RO$=RO$+" w "+MIASTA$(TEREN-70)
                         End If 
                         */
                        break;
                    case ArmyActions.Move:
                    case ArmyActions.FastMove:
                        window.ActionText = _texts.Get("moving");
                        break;
                    case ArmyActions.Attack:
                        window.ActionText = _texts.Get("attacking", "");
                        /* TODO:
                         If CELY=0
                            R2$=ARMIA$(CELX,0)
                         Else 
                            R2$=MIASTA$(CELX)
                         End If 
                         RO$="Atakujemy "+R2$
                        */
                        break;
                    case ArmyActions.Hunting:
                        window.ActionText = _texts.Get("hunting");
                        break;
                }
            }

            return window;
        }

        public ArmyOrdersWindow CreateArmyOrdersWindow(Army army)
        {
            //TODO: provide correct informations to the constructor instaead of 2x false
            var window = new ArmyOrdersWindow(_guiServices, _texts, false, false);
            return window;
        }
        
    }
}