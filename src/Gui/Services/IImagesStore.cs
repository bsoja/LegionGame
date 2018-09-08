using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Gui.Services
{
    public interface IImagesStore
    {
        Texture2D GetImage(string type);
        List<Texture2D> GetImages(string type);
    }
}