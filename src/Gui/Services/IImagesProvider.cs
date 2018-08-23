using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Gui.Services
{
    public interface IImagesProvider
    {
        Texture2D GetImage(ImageType type);
        List<Texture2D> GetImages(ImageType type);
    }
}