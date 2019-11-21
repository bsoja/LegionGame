using System;
using Gui.Elements;
using Gui.Services;
using Legion.Controllers.Map;
using Legion.Model.Types;
using Legion.Views.Map.Controls;

namespace Legion.Views.Map.Layers
{
    public class ArmiesLayer : Layer
    {
        private readonly IMapServices _mapServices;
        private readonly IMapController _mapController;
        private readonly IMapArmyGuiFactory _armyGuiFactory;
        private Army _currentArmy;

        public ArmiesLayer(
            IGuiServices guiServices,
            IMapServices mapServices,
            IMapController mapController,
            IMapArmyGuiFactory armyGuiFactory) : base(guiServices)
        {
            _mapServices = mapServices;
            _mapController = mapController;
            _armyGuiFactory = armyGuiFactory;
        }

        public override void OnShow()
        {
            base.OnShow();

            ClearElements();

            foreach (var army in _mapController.Armies)
            {
                var element = new ArmyElement(GuiServices, army);
                element.Clicked += args =>
                {
                    var armyWindow = _armyGuiFactory.CreateArmyWindow(army);
                    _mapServices.ShowModal(armyWindow);
                    args.Handled = true;
                };
                AddElement(element);
            }
        }

        public override void Update()
        {
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
    }
}