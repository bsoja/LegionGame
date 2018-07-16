using Legion.Gui.Elements.Map;
using Legion.Gui.Services;
using Legion.Model;
using Legion.Model.Types;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Views.Map
{
    public class MapArmyGuiFactory : IMapArmyGuiFactory
    {
        private readonly IGuiServices guiServices;
        private readonly ILegionConfig legionConfig;
        private readonly ITexts texts;
        private Texture2D[] armyWindowImages;

        public MapArmyGuiFactory(IGuiServices guiServices,
            ILegionConfig legionConfig,
            ITexts texts)
        {
            this.guiServices = guiServices;
            this.legionConfig = legionConfig;
            this.texts = texts;

            guiServices.GameLoaded += () => LoadImages();
        }

        private void LoadImages()
        {
            armyWindowImages = new []
            {
                null,
                guiServices.ImagesProvider.GetImage(ImageType.ArmyWindowUser),
                guiServices.ImagesProvider.GetImage(ImageType.ArmyWindowPlayer2),
                guiServices.ImagesProvider.GetImage(ImageType.ArmyWindowPlayer3),
                guiServices.ImagesProvider.GetImage(ImageType.ArmyWindowPlayer4),
                guiServices.ImagesProvider.GetImage(ImageType.ArmyWindowChaos),
            };
        }

        public ArmyWindow CreateArmyWindow(Army army)
        {
            var window = new ArmyWindow(guiServices);
            var hasData = false;
            var infoText = "";

            window.NameText = army.Name;
            window.Image = armyWindowImages[army.Owner.Id];

            window.ButtonOkText = texts.Get("ok");
            if (army.Owner.IsUserControlled)
            {
                window.ButtonMoreText = texts.Get("commands");
                hasData = true;
            }
            else
            {
                window.ButtonMoreText = texts.Get("interview");
                if (army.DaysToGetInfo > 28 && army.DaysToGetInfo < 100)
                {
                    hasData = false;
                    infoText = texts.Get("noInformation");
                }
                else
                {
                    infoText = army.DaysToGetInfo > 1 ?
                        texts.Get("informationsInXDays", army.DaysToGetInfo) :
                        texts.Get("informationsInOneDay");
                    hasData = false;
                }
                if (army.DaysToGetInfo == 0 || army.DaysToGetInfo == 100)
                {
                    hasData = true;
                    window.ButtonMoreText = texts.Get("trace");
                }
            }

            if (!hasData && !legionConfig.GoDmOdE)
            {
                window.InfoText = infoText;
            }
            else
            {
                var count = army.Characters.Count;
                window.CountText = count == 1 ?
                    texts.Get("oneWarrior") :
                    texts.Get("xWarriors", count);

                int foodCount = army.Food / army.Characters.Count;
                if (foodCount > 1) window.FoodText = texts.Get("foodForXDays", foodCount);
                else if (foodCount == 1) window.FoodText = texts.Get("foodForOneDay");
                else window.FoodText = texts.Get("noMoreFood");

                window.StrengthText = texts.Get("strength") + army.Strength;
                window.SpeedText = texts.Get("speed") + army.Speed;

                window.ActionText = "";
                switch (army.CurrentAction)
                {
                    case ArmyActions.Camping:
                        window.ActionText = texts.Get("camping");
                        /* TODO:
                         If TEREN>69
                            RO$=RO$+" w "+MIASTA$(TEREN-70)
                         End If 
                         */
                        break;
                    case ArmyActions.Move:
                    case ArmyActions.FastMove:
                        window.ActionText = texts.Get("moving");
                        break;
                    case ArmyActions.Attack:
                        window.ActionText = texts.Get("attacking", "");
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
                        window.ActionText = texts.Get("hunting");
                        break;
                }
            }

            return window;
        }
    }
}