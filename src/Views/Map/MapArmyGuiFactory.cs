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
        private readonly ITextsManager texts;
        private Texture2D[] armyWindowImages;

        public MapArmyGuiFactory(IGuiServices guiServices,
            ILegionConfig legionConfig,
            ITextsManager textsManager)
        {
            this.guiServices = guiServices;
            this.legionConfig = legionConfig;
            this.texts = textsManager;

            guiServices.Loaded += () => LoadImages();
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
            var daysText = "";

            window.NameText = army.Name;
            window.Image = armyWindowImages[army.Owner.Id];

            window.ButtonOkText = texts.Get(TextType.Ok);
            if (army.Owner.IsUserControlled)
            {
                window.ButtonMoreText = texts.Get(TextType.Orders);
                hasData = true;
            }
            else
            {
                window.ButtonMoreText = texts.Get(TextType.Interview);
                if (army.DaysToGetInfo > 28 && army.DaysToGetInfo < 100)
                {
                    hasData = false;
                    infoText = texts.Get(TextType.NoInformation);
                }
                else
                {
                    if (army.DaysToGetInfo > 1)
                    {
                        daysText = texts.Get(TextType.Days);
                    }
                    else
                    {
                        daysText = texts.Get(TextType.Day);
                    }
                    hasData = false;
                    infoText = texts.Get(TextType.InformationIn) + army.DaysToGetInfo + daysText;
                }
                if (army.DaysToGetInfo == 0 || army.DaysToGetInfo == 100)
                {
                    hasData = true;
                    window.ButtonMoreText = texts.Get(TextType.Spy);
                }
            }

            if (!hasData && !legionConfig.GoDmOdE)
            {
                window.InfoText = infoText;
            }
            else
            {
                var count = army.Characters.Count;
                window.CountText = count == 1 ? texts.Get(TextType.OneWarrior) : count + texts.Get(TextType.Warriors);

                int foodCount = army.Food / army.Characters.Count;
                window.FoodText = texts.Get(TextType.FoodFor) + foodCount + texts.Get(TextType.Days);
                if (foodCount == 1) window.FoodText = texts.Get(TextType.FoodForOneDay);
                if (foodCount <= 0) window.FoodText = texts.Get(TextType.NoFood);

                window.StrengthText = texts.Get(TextType.Strength) + army.Strength;
                window.SpeedText = texts.Get(TextType.Speed) + army.Speed;

                window.ActionText = "";
                switch (army.CurrentAction)
                {
                    case ArmyActions.Camping:
                        window.ActionText = texts.Get(TextType.Camping);
                        /* TODO:
                         If TEREN>69
                            RO$=RO$+" w "+MIASTA$(TEREN-70)
                         End If 
                         */
                        break;
                    case ArmyActions.Move:
                    case ArmyActions.FastMove:
                        window.ActionText = texts.Get(TextType.Moving);
                        break;
                    case ArmyActions.Attack:
                        window.ActionText = texts.Get(TextType.Attacking);
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
                        window.ActionText = texts.Get(TextType.Hunting);
                        break;
                }
            }

            return window;
        }
    }
}