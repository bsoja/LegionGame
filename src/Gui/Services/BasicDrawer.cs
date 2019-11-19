using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gui.Services
{
    public class BasicDrawer : IBasicDrawer
    {
        private readonly SpriteBatch _spriteBatch;
        private Texture2D _pixel; //base for the line texture
        private SpriteFont _defenderFont;

        public BasicDrawer(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
        }

        public void LoadContent(Game game)
        {
            // create 1x1 texture for line drawing
            _pixel = new Texture2D(game.GraphicsDevice, 1, 1);
            _pixel.SetData(new[] { Color.White }); // fill the texture with white

            _defenderFont = game.Content.Load<SpriteFont>("defender");
        }

        private void DrawLine(Color color, Vector2 start, Vector2 end, int thickness)
        {
            Vector2 edge = end - start;
            // calculate angle to rotate line
            float angle = (float) Math.Atan2(edge.Y, edge.X);

            _spriteBatch.Draw(_pixel,
                new Rectangle( // rectangle defines shape of line and position of start of line
                    (int) start.X,
                    (int) start.Y,
                    (int) edge.Length(), //sb will strech the texture to fill this rectangle
                    thickness), //width of line, change this to make thicker line
                null,
                color, //colour of line
                angle, //angle of line (calulated above)
                new Vector2(0, 0), // point in line about which to rotate
                SpriteEffects.None,
                0);
        }

        public void DrawLine(Color color, Vector2 start, Vector2 end)
        {
            DrawLine(color, start, end, 1); //(int)currentScale);
        }

        private void DrawBorder(Color color, int x, int y, int width, int height, int thickness)
        {
            DrawLine(color, new Vector2(x, y), new Vector2(x + width, y), thickness);
            DrawLine(color, new Vector2(x + width, y), new Vector2(x + width, y + height), thickness);
            DrawLine(color, new Vector2(x + width, y + height), new Vector2(x, y + height), thickness);
            DrawLine(color, new Vector2(x, y + height), new Vector2(x, y), thickness);
        }

        public void DrawBorder(Color color, int x, int y, int width, int height)
        {
            DrawBorder(color, x, y, width, height, 1); //(int)currentScale);
        }

        public void DrawBorder(Color color, Rectangle rectangle)
        {
            DrawBorder(color, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, 1); //(int)currentScale);
        }

        public void DrawRectangle(Color color, Rectangle rectangle)
        {
            _spriteBatch.Draw(_pixel, rectangle, null, color, .0f, new Vector2(0, 0), SpriteEffects.None, 0);
        }

        public void DrawRectangle(Color color, int x, int y, int width, int height)
        {
            DrawRectangle(color, new Rectangle(x, y, width, height));
        }

        public void DrawText(Color color, int x, int y, string text,
            bool centerHorizontally = false,
            bool centerVertically = false)
        {
            var vect = new Vector2();
            var vectCenter = _defenderFont.MeasureString(text) / 2;

            if (centerHorizontally)
            {
                vect.X = vectCenter.X;
            }
            if (centerVertically)
            {
                vect.Y = vectCenter.Y;
            }

            _spriteBatch.DrawString(_defenderFont, text, new Vector2(x, y), color, 0f, vect, .5f, SpriteEffects.None, 0f);
        }

        public Vector2 MeasureText(string text)
        {
            return _defenderFont.MeasureString(text) / 2; // somehow measure gives too big size
        }

        public void DrawImage(Texture2D image, float x, float y)
        {
            _spriteBatch.Draw(image, new Vector2(x, y), null, Color.White, 0f, new Vector2(), 1f, SpriteEffects.None, 0f);
        }
    }
}