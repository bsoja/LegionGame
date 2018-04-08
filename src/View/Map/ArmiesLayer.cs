using Legion.Controllers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.View.Map
{
    public class ArmiesLayer : Layer
    {
        private Texture2D[] armyImages;
        private readonly IMapController mapController;

        public ArmiesLayer(Game game, IMapController mapController) : base(game)
        {
            this.mapController = mapController;
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

        public override void Draw(GameTime gameTime)
        {
            foreach (var army in mapController.Armies)
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