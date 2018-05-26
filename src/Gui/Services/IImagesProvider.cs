using Microsoft.Xna.Framework.Graphics;

namespace Legion.Gui.Services
{
    public interface IImagesProvider
    {
        Texture2D GetImage(ImageType type);
    }
}