using System;
using System.ComponentModel;
using Legion.Gui.Elements;
using Legion.Gui.Elements.Map;
using Legion.Gui.Services;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Views.Map.Layers
{
    public class MessagesLayer : Layer
    {
        private string title;
        private string text;
        private Texture2D image;
        private Action onClose;
        private MessageWindow messageWindow;

        public MessagesLayer(IGuiServices guiServices) : base(guiServices) { }

        public void Show(string title, string text, Texture2D image, Action onClose)
        {
            this.title = title;
            this.text = text;
            this.image = image;
            this.onClose = onClose;

            messageWindow = new MessageWindow(GuiServices);
            messageWindow.TargetName = title;
            messageWindow.Text = text;
            messageWindow.Image = image;
            messageWindow.Clicked += OnMessageClicked;

            AddElement(messageWindow);

            Parent.BlockLayers(this);
        }

        public void Close()
        {
            onClose?.Invoke();
            RemoveElement(messageWindow);
            Parent.UnblockLayers();
            messageWindow.Clicked -= OnMessageClicked;
            messageWindow = null;
        }

        private void OnMessageClicked(HandledEventArgs args)
        {
            args.Handled = true;
            Close();
        }
    }
}