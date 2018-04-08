using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.View
{
    public class Layer : DrawableGameComponent
    {
        public Layer(Game game) : base(game) { }

        public View Parent { get; set; }

        protected SpriteBatch SpriteBatch
        {
            get { return Parent?.SpriteBatch; }
        }

        // returns if input was handled or not
        public virtual bool UpdateInput()
        {
            return false;
        }
    }
}