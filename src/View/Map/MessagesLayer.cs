using System;
using Microsoft.Xna.Framework;

namespace Legion.View.Map
{
    public class MessagesLayer : Layer
    {
        private string title;
        private string text;
        private Action onClose;

        public MessagesLayer(Game game) : base(game) { }

        public void Show(string title, string text, Action onClose)
        {
            this.title = title;
            this.text = text;
            this.onClose = onClose;

            Parent.BlockLayers(this);
        }

        public void Close()
        {
            onClose?.Invoke();

            Parent.UnblockLayers();
        }

        public override void Update(GameTime gameTime)
        {
            //TODO update message window
        }

        public override void Draw(GameTime gameTime)
        {
            //TODO draw message window

        }
    }
}