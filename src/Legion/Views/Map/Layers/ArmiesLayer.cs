using System;
using System.Collections.Generic;
using Gui.Elements;
using Gui.Input;
using Gui.Services;
using Legion.Controllers;
using Legion.Model;
using Legion.Model.Types;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Views.Map.Layers
{
    public class ArmiesLayer : Layer
    {
        private readonly IArmiesTurnProcessor armiesTurnProcessor;
        private readonly IMapController mapController;
        private readonly ModalLayer modalLayer;
        private List<Texture2D> armyImages;
        private Army currentArmy;

        public ArmiesLayer(IGuiServices guiServices,
            IArmiesTurnProcessor armiesTurnProcessor,
            IMapController mapController,
            ModalLayer modalLayer) : base(guiServices)
        {
            this.armiesTurnProcessor = armiesTurnProcessor;
            this.mapController = mapController;
            this.modalLayer = modalLayer;
        }

        public override void Initialize()
        {
            armyImages = GuiServices.ImagesStore.GetImages("army.users");
        }

        private Rectangle GetArmyBounds(Army army)
        {
            var imgWidth = (int) (armyImages[0].Width);
            var imgHeight = (int) (armyImages[0].Height);
            var armyBounds = new Rectangle(army.X, army.Y, imgWidth, imgHeight);
            return armyBounds;
        }

        private Army GetClickedArmy()
        {
            var wasMouseDown = InputManager.GetIsMouseButtonDown(MouseButton.Left, false);
            var isMouseDown = InputManager.GetIsMouseButtonDown(MouseButton.Left, true);
            var prevMousePosition = InputManager.GetMousePostion(false);
            var currMousePosition = InputManager.GetMousePostion(true);

            if (!wasMouseDown && isMouseDown)
            {
                foreach (var army in mapController.Armies)
                {
                    var cityBounds = GetArmyBounds(army);
                    if (cityBounds.Contains(prevMousePosition) && cityBounds.Contains(currMousePosition))
                    {
                        return army;
                    }
                }
            }

            return null;
        }

        public override bool UpdateInput()
        {
            var army = GetClickedArmy();
            if (army != null)
            {
                modalLayer.ShowArmyWindow(army);
                return true;
            }

            return base.UpdateInput();
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
                    var armyImage = armyImages[army.Owner.Id - 1];
                    GuiServices.BasicDrawer.DrawImage(armyImage, army.X, army.Y);
                }
            }
        }
    }
}