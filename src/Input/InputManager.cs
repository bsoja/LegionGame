using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Legion.Input
{
    //TODO: Handle input in better way
    public static class InputManager
    {
        public static Matrix ScaleMatrix;
        // Store current and previous states for comparison. 
        private static MouseState previousMouseState;
        private static MouseState currentMouseState;

        // Some keyboard states for later use.
        private static KeyboardState previousKeyboardState;
        private static KeyboardState currentKeyboardState;

        // Update the states so that they contain the right data.
        public static void Update()
        {
            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();

            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
        }

        public static Rectangle GetMouseBounds(bool currentState)
        {
            var pos = GetMousePostion(currentState);
            // Return a 1x1 squre representing the mouse click's bounding box.
            return new Rectangle(pos.X, pos.Y, 1, 1);
        }

        public static Point GetMousePostion(bool currentState)
        {
            var position = currentState ? currentMouseState.Position : previousMouseState.Position;
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
                        return currentMouseState.LeftButton == ButtonState.Released;
                    case MouseButton.Middle:
                        return currentMouseState.MiddleButton == ButtonState.Released;
                    case MouseButton.Right:
                        return currentMouseState.RightButton == ButtonState.Released;
                }
            else
                switch (btn)
                {
                    case MouseButton.Left:
                        return previousMouseState.LeftButton == ButtonState.Released;
                    case MouseButton.Middle:
                        return previousMouseState.MiddleButton == ButtonState.Released;
                    case MouseButton.Right:
                        return previousMouseState.RightButton == ButtonState.Released;
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
            return currentKeyboardState.IsKeyDown(key);
        }

        public static bool GetIsKeyUp(Keys key)
        {
            return currentKeyboardState.IsKeyUp(key);
        }
    }
}