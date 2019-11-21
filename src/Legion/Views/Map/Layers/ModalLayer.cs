using System;
using System.ComponentModel;
using Gui.Elements;
using Gui.Services;
using Legion.Views.Map.Controls;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Views.Map.Layers
{
    public class ModalLayer : Layer
    {
        public ModalLayer(IGuiServices guiServices) : base(guiServices)
        {
        }

        private Window _window;

        public Window Window
        {
            get => _window;
            set
            {
                if (_window != null)
                {
                    _window.Closing -= OnWindowClosing;
                    RemoveElement(_window);
                    Parent.UnblockLayers();
                }

                _window = value;

                if (_window != null)
                {
                    AddElement(_window);
                    _window.Closing += OnWindowClosing;
                    Parent.BlockLayers(this);
                }
            }
        }

        private void OnWindowClosing(HandledEventArgs args)
        {
            args.Handled = true;
            Window = null;
        }

        public void ShowMessage(string title, string text, Texture2D image, Action onClose)
        {
            var messageWindow = new MessageWindow(GuiServices)
            {
                TargetName = title,
                Text = text,
                Image = image
            };
            Window = messageWindow;
        }

    }
}