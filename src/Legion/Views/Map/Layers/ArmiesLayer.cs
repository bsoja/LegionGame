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
        private readonly IMapController _mapController;
        private readonly ModalLayer _modalLayer;
        private List<Texture2D> _armyImages;
        private Army _currentArmy;

        public ArmiesLayer(IGuiServices guiServices,
            IMapController mapController,
            ModalLayer modalLayer) : base(guiServices)
        {
            _mapController = mapController;
            _modalLayer = modalLayer;

            Clicked += ArmiesLayer_Clicked;
        }

        public override void Initialize()
        {
            _armyImages = GuiServices.ImagesStore.GetImages("army.users");
        }

        private void ArmiesLayer_Clicked(HandledEventArgs obj)
        {
            var mousePosition = InputManager.GetMousePostion(true);

            foreach (var army in _mapController.Armies)
            {
                var armyBounds = new Rectangle(army.X, army.Y, _armyImages[0].Width, _armyImages[0].Height);
                if (armyBounds.Contains(mousePosition))
                {
                    _modalLayer.ShowArmyWindow(army);
                    obj.Handled = true;
                }
            }
        }

        public override void Update()
        {
            base.Update();

            if (_mapController.IsProcessingTurn)
            {
                if (_currentArmy != null && _currentArmy.IsMoving)
                {
                    ProcessArmyMovement(_currentArmy);
                }
                else
                {
                    _currentArmy = _mapController.ProcessTurnForNextArmy();
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
                _mapController.OnMoveEnded(army);
            }
        }

        public override void Draw()
        {
            base.Draw();

            foreach (var army in _mapController.Armies)
            {
                if (army.Owner != null)
                {
                    var armyImage = _armyImages[army.Owner.Id - 1];
                    GuiServices.BasicDrawer.DrawImage(armyImage, army.X, army.Y);
                }
            }
        }
    }
}