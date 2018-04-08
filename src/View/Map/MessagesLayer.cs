using Microsoft.Xna.Framework;

namespace Legion.View.Map
{
    public class MessagesLayer : Layer
    {
        public MessagesLayer(Game game) : base(game) { }

        public void Show()
        {
            Parent.BlockLayers(this);
        }

        public void Close()
        {
            Parent.UnblockLayers();
        }
    }
}