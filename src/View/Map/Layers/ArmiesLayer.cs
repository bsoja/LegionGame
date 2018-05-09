using System;
using Legion.Controllers;
using Legion.Model;
using Legion.Model.Types;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.View.Map.Layers
{
    public class ArmiesLayer : Layer<MapView>
    {
        private readonly IArmiesTurnProcessor armiesTurnProcessor;

        private Texture2D[] armyImages;
        private Army currentArmy;

        public ArmiesLayer(Game game,
            IArmiesTurnProcessor armiesTurnProcessor) : base(game)
        {
            this.armiesTurnProcessor = armiesTurnProcessor;
        }

        protected override void LoadContent()
        {
            var armyUser = Game.Content.Load<Texture2D>("mapa.2");
            var armyPlayer2 = Game.Content.Load<Texture2D>("mapa.3");
            var armyPlayer3 = Game.Content.Load<Texture2D>("mapa.4");
            var armyPlayer4 = Game.Content.Load<Texture2D>("mapa.5");
            var armyChaos = Game.Content.Load<Texture2D>("mapa.6");

            armyImages = new []
            {
                null,
                armyUser,
                armyPlayer2,
                armyPlayer3,
                armyPlayer4,
                armyChaos
            };
        }

        public override void Update(GameTime gameTime)
        {
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

        public override void Draw(GameTime gameTime)
        {
            foreach (var army in Parent.MapController.Armies)
            {
                if (army.Owner != null)
                {
                    var armyImage = armyImages[army.Owner.Id];
                    SpriteBatch.Draw(armyImage, new Vector2(army.X, army.Y), null, Color.White, 0, new Vector2(), 1, SpriteEffects.None, 0);
                }
            }
        }
    }
}