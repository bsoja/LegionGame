using Microsoft.Xna.Framework.Graphics;

namespace Legion.Gui
{
    public interface IImagesProvider
    {
        Texture2D GetImage(ImageType type);
    }
}