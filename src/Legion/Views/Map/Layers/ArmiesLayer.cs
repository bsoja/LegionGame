using System;
using System.Collections.Generic;
using System.ComponentModel;
using Gui.Elements;
using Gui.Input;
using Gui.Services;
using Legion.Controllers.Map;
using Legion.Model.Types;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Views.Map.Layers
{
    public class ArmiesLayer : Layer
    {
        private readonly IMapController mapController;
        private readonly ModalLayer modalLayer;
        private List<Texture2D> armyImages;
        private Army currentArmy;

        public ArmiesLayer(IGuiServices guiServices,
            IMapController mapController,
            ModalLayer modalLayer) : base(guiServices)
        {
            this.mapController = mapController;
            this.modalLayer = modalLayer;

            Clicked += ArmiesLayer_Clicked;
        }

        public override void Initialize()
        {
            armyImages = GuiServices.ImagesStore.GetImages("army.users");
        }

        private void ArmiesLayer_Clicked(HandledEventArgs obj)
        {
            var mousePosition = InputManager.GetMousePostion(true);

            foreach (var army in mapController.Armies)
            {
                var armyBounds = new Rectangle(army.X, army.Y, armyImages[0].Width, armyImages[0].Height);
                if (armyBounds.Contains(mousePosition))
                {
                    modalLayer.ShowArmyWindow(army);
                    obj.Handled = true;
                }
            }
        }

        public override void Update()
        {
            base.Update();

            if (mapController.IsProcessingTurn)
            {
                if (currentArmy != null && currentArmy.IsMoving)
                {
                    ProcessArmyMovement(currentArmy);
                }
                else
                {
                    currentArmy = mapController.ProcessTurnForNextArmy();
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
                mapController.OnMoveEnded(army);
            }
        }

        public override void Draw()
        {
            base.Draw();

            foreach (var army in mapController.Armies)
            {
                if (army.Owner != null)
                {
                    var armyImage = armyImages[army.Owner.Id - 1];
                    GuiServices.BasicDrawer.DrawImage(armyImage, army.X, army.Y);
                }
            }
        }
    }
}