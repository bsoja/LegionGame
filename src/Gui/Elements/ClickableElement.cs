using System;
using System.ComponentModel;
using Legion.Gui.Services;
using Legion.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Gui.Elements
{
    public class ClickableElement : DrawableElement
    {
        private bool wasDown;

        public ClickableElement(IGuiServices guiServices) : base(guiServices) { }

        public event Action<HandledEventArgs> Clicked;
        public event Action<HandledEventArgs> MouseDown;

        protected virtual bool OnMouseDown(MouseButton button, Point position)
        {
            var args = new HandledEventArgs();

            if (!wasDown)
            {
                wasDown = true;
                MouseDown?.Invoke(args);
            }

            return args.Handled;
        }

        protected virtual bool OnMouseUp(MouseButton button, Point position)
        {
            var args = new HandledEventArgs();

            if (wasDown)
            {
                wasDown = false;
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

        public override bool UpdateInput()
        {
            var handled = false;
            var position = InputManager.GetMousePostion(true);

            var isMouseInside = Bounds.Contains(position);

            GetMouseButtonState(MouseButton.Left, out bool isLeftDown, out bool isLeftUp);
            GetMouseButtonState(MouseButton.Left, out bool isRightDown, out bool isRightUp);

            if (isLeftDown && isMouseInside) handled = OnMouseDown(MouseButton.Left, position);
            if (isRightDown && isMouseInside) handled = OnMouseDown(MouseButton.Right, position);
            if (isLeftUp) handled = OnMouseUp(MouseButton.Left, position);
            if (isRightUp) handled = OnMouseUp(MouseButton.Right, position);

            return handled;
        }
    }
}