using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Gui.Input
{
    //TODO: Handle input in better way
    public static class InputManager
    {
        public static Matrix ScaleMatrix;
        // Store current and previous states for comparison. 
        private static MouseState _previousMouseState;
        private static MouseState _currentMouseState;

        // Some keyboard states for later use.
        private static KeyboardState _previousKeyboardState;
        private static KeyboardState _currentKeyboardState;

        // Update the states so that they contain the right data.
        public static void Update()
        {
            _previousMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();

            _previousKeyboardState = _currentKeyboardState;
            _currentKeyboardState = Keyboard.GetState();
        }

        public static Rectangle GetMouseBounds(bool currentState)
        {
            var pos = GetMousePostion(currentState);
            // Return a 1x1 squre representing the mouse click's bounding box.
            return new Rectangle(pos.X, pos.Y, 1, 1);
        }

        public static Point GetMousePostion(bool currentState)
        {
            var position = currentState ? _currentMouseState.Position : _previousMouseState.Position;
            var vect = new Vector2(position.X, position.Y);
            Vector2 worldPosition = Vector2.Transform(vect, Matrix.Invert(ScaleMatrix));
            return new Point((int)worldPosition.X, (int)worldPosition.Y);
        }

        public static bool GetIsMouseButtonUp(MouseButton btn, bool currentState)
        {
            // Simply returns whether the button state is released or not.

            if (currentState)
                switch (btn)
                {
                    case MouseButton.Left:
                        return _currentMouseState.LeftButton == ButtonState.Released;
                    case MouseButton.Middle:
                        return _currentMouseState.MiddleButton == ButtonState.Released;
                    case MouseButton.Right:
                        return _currentMouseState.RightButton == ButtonState.Released;
                }
            else
                switch (btn)
                {
                    case MouseButton.Left:
                        return _previousMouseState.LeftButton == ButtonState.Released;
                    case MouseButton.Middle:
                        return _previousMouseState.MiddleButton == ButtonState.Released;
                    case MouseButton.Right:
                        return _previousMouseState.RightButton == ButtonState.Released;
                }

            return false;
        }

        public static bool GetIsMouseButtonDown(MouseButton btn, bool currentState)
        {
            // This will just call the method above and negate.
            return !GetIsMouseButtonUp(btn, currentState);
        }

        // TODO: Keyboard input stuff goes here.

        public static bool GetIsKeyDown(Keys key)
        {
            return _currentKeyboardState.IsKeyDown(key);
        }

        public static bool GetIsKeyUp(Keys key)
        {
            return _currentKeyboardState.IsKeyUp(key);
        }
    }
}