using System.Drawing;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Views.Terrain
{
    public class TerrainPart
    {
        public TerrainPart(Texture2D image, int x, int y, Rectangle bounds = new Rectangle())
        {
            this.Image = image;
            this.X = x;
            this.Y = y;
            this.Bounds = bounds;
        }

        public Texture2D Image { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Rectangle Bounds { get; set; }
    }
}