using System;
using Legion.Gui.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Legion.View.Map.Layers
{
    public class MessagesLayer : Layer<MapView>
    {
        private string title;
        private string text;
        private Texture2D image;
        private Action onClose;
        private MessageWindow messageWindow;

        public MessagesLayer(Game game) : base(game) { }

        public void Show(string title, string text, Texture2D image, Action onClose)
        {
            this.title = title;
            this.text = text;
            this.image = image;
            this.onClose = onClose;

            messageWindow = new MessageWindow(BasicDrawer, GameBounds);
            messageWindow.TargetName = title;
            messageWindow.Text = text;
            messageWindow.Image = image;
            messageWindow.Clicked += OnMessageClicked;

            Parent.BlockLayers(this);
        }

        public void Close()
        {
            onClose?.Invoke();
            Parent.UnblockLayers();
            messageWindow.Clicked -= OnMessageClicked;
            messageWindow = null;
        }

        private void OnMessageClicked(Gui.EventArgs args)
        {
            args.Handled = true;
            Close();
        }

        public override bool UpdateInput()
        {
            if (messageWindow != null)
            {
                return messageWindow.UpdateInput();
            }
            return false;
        }

        public override void Update(GameTime gameTime)
        {
            messageWindow?.Update();
        }

        public override void Draw(GameTime gameTime)
        {
            messageWindow?.Draw();
        }
    }
}