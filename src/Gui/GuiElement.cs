using System;
using Legion.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Gui
{
    public class GuiElement
    {
        private bool wasDown;
        private readonly IBasicDrawer basicDrawer;

        public GuiElement(IBasicDrawer basicDrawer)
        {
            this.basicDrawer = basicDrawer;
        }

        public Rectangle Bounds { get; set; }

        protected IBasicDrawer BasicDrawer
        {
            get { return basicDrawer; }
        }

        public event Action<EventArgs> Clicked;
        public event Action<EventArgs> MouseDown;

        protected virtual bool OnMouseDown(MouseButton button, Point position)
        {
            var args = new EventArgs();

            if (!wasDown)
            {
                wasDown = true;
                MouseDown?.Invoke(args);
            }

            return args.Handled;
        }

        protected virtual bool OnMouseUp(MouseButton button, Point position)
        {
            var args = new EventArgs();

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

        public virtual bool UpdateInput()
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

        public virtual void Update() { }

        public virtual void Draw() { }
    }
}