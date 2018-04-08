using System;
using Legion.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Gui
{

    public class EventArgs
    {
        public bool Handled { get; set; }
    }

    public class GuiElement
    {
        private bool wasDown;

        public GuiElement Parent { get; set; }
        public Rectangle Bounds { get; set; }

        public event Action<EventArgs> Clicked;
        public event Action<EventArgs> MouseDown;

        protected virtual void OnMouseDown(MouseButton button, Point position)
        {
            var args = new EventArgs();

            if (!wasDown)
            {
                wasDown = true;
                MouseDown?.Invoke(args);
            }

            if (!args.Handled)
            {
                Parent?.OnMouseDown(button, position);
            }
        }

        protected virtual void OnMouseUp(MouseButton button, Point position)
        {
            var args = new EventArgs();

            if (wasDown)
            {
                wasDown = false;
                Clicked?.Invoke(args);
            }

            if (!args.Handled)
            {
                Parent?.OnMouseUp(button, position);
            }
        }

        private void GetMouseButtonState(MouseButton button, out bool isDown, out bool isUp)
        {
            var prevState = InputManager.GetIsMouseButtonDown(button, false);
            var currState = InputManager.GetIsMouseButtonDown(button, true);

            isDown = (!prevState && currState);
            isUp = (prevState && !currState);
        }

        public virtual void Update()
        {
            var position = InputManager.GetMousePostion(true);

            var isMouseInside = Bounds.Contains(position);

            GetMouseButtonState(MouseButton.Left, out bool isLeftDown, out bool isLeftUp);
            GetMouseButtonState(MouseButton.Left, out bool isRightDown, out bool isRightUp);

            if (isLeftDown && isMouseInside) OnMouseDown(MouseButton.Left, position);
            if (isRightDown && isMouseInside) OnMouseDown(MouseButton.Right, position);
            if (isLeftUp) OnMouseUp(MouseButton.Left, position);
            if (isRightUp) OnMouseUp(MouseButton.Right, position);
        }

        public virtual void Draw(SpriteBatch spriteBatch) { }
    }
}