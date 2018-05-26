using System;
using Legion.Controllers;
using Legion.Gui.Elements;
using Legion.Gui.Services;
using Legion.Model;
using Legion.Model.Types;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Views.Map.Layers
{
    public class ArmiesLayer : Layer
    {
        private readonly IArmiesTurnProcessor armiesTurnProcessor;
        private readonly IMapController mapController;
        private Texture2D[] armyImages;
        private Army currentArmy;

        public ArmiesLayer(IGuiServices guiServices,
            IArmiesTurnProcessor armiesTurnProcessor,
            IMapController mapController) : base(guiServices)
        {
            this.armiesTurnProcessor = armiesTurnProcessor;
            this.mapController = mapController;
        }

        public override void Initialize()
        {
            armyImages = new []
            {
                null,
                GuiServices.ImagesProvider.GetImage(ImageType.ArmyUser),
                GuiServices.ImagesProvider.GetImage(ImageType.ArmyPlayer2),
                GuiServices.ImagesProvider.GetImage(ImageType.ArmyPlayer3),
                GuiServices.ImagesProvider.GetImage(ImageType.ArmyPlayer4),
                GuiServices.ImagesProvider.GetImage(ImageType.ArmyChaos),
            };
        }

        public override void Update()
        {
            base.Update();

            if (armiesTurnProcessor.IsProcessingTurn)
            {
                if (currentArmy != null && currentArmy.IsMoving)
                {
                    ProcessArmyMovement(currentArmy);
                }
                else
                {
                    currentArmy = armiesTurnProcessor.ProcessTurnForNextArmy();
                }
            }
        }

        void ProcessArmyMovement(Army army)
        {
            var dx = army.TurnTargetX - army.X;
            var dy = army.TurnTargetY - army.Y;

            var mx = 0;
            var my = 0;

            if (dx < 0) mx = -1;
            if (dx > 0) mx = 1;

            if (dy < 0) my = -1;
            if (dy > 0) my = 1;

            army.X += mx;
            army.Y += my;

            if (Math.Abs(dx) < 1 && Math.Abs(dy) < 1)
            {
                army.X = army.TurnTargetX;
                army.Y = army.TurnTargetY;
                armiesTurnProcessor.OnMoveEnded(army);
            }
        }

        public override void Draw()
        {
            base.Draw();

            foreach (var army in mapController.Armies)
            {
                if (army.Owner != null)
                {
                    var armyImage = armyImages[army.Owner.Id];
                    GuiServices.BasicDrawer.DrawImage(armyImage, army.X, army.Y);
                }
            }
        }
    }
}