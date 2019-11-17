using System;
using System.ComponentModel;
using Gui.Input;
using Gui.Services;
using Microsoft.Xna.Framework;

namespace Gui.Elements
{
    public class ClickableElement : DrawableElement
    {
        private bool _wasDown;

        public ClickableElement(IGuiServices guiServices) : base(guiServices) { }

        public event Action<HandledEventArgs> Clicked;
        public event Action<HandledEventArgs> MouseDown;

        protected virtual bool OnMouseDown(MouseButton button, Point position)
        {
            var args = new HandledEventArgs();

            if (!_wasDown)
            {
                _wasDown = true;
                MouseDown?.Invoke(args);
            }

            return args.Handled;
        }

        protected virtual bool OnMouseUp(MouseButton button, Point position)
        {
            var args = new HandledEventArgs();

            if (_wasDown)
            {
                _wasDown = false;
                Clicked?.Invoke(args);
            }

            return args.Handled;
        }

        private void GetMouseButtonState(MouseButton button, out bool isDown, out bool isUp)
        {
            var prevState = InputManager.GetIsMouseButtonDown(button, false);
            var currState = InputManager.GetIsMouseButtonDown(button, true);

            isDown = (!prevState && currState);
            isUp = (prevState && !currState);
        }

        internal virtual bool UpdateInputInternal()
        {
            var handled = false;
            var position = InputManager.GetMousePostion(true);

            var isMouseInside = Bounds.Contains(position);

            GetMouseButtonState(MouseButton.Left, out bool isLeftDown, out bool isLeftUp);
            GetMouseButtonState(MouseButton.Right, out bool isRightDown, out bool isRightUp);

            if (isLeftDown && isMouseInside) handled = OnMouseDown(MouseButton.Left, position);
            if (isRightDown && isMouseInside) handled = OnMouseDown(MouseButton.Right, position);
            if (isLeftUp) handled = OnMouseUp(MouseButton.Left, position);
            if (isRightUp) handled = OnMouseUp(MouseButton.Right, position);

            return handled || UpdateInput();
        }

        public virtual bool UpdateInput() { return false; }
    }
}