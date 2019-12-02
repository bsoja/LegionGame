using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Gui.Services
{
    public interface IImagesStore
    {
        List<string> GetNames();

        Texture2D GetImage(string type);

        Texture2D GetImageByRealName(string name);

        List<Texture2D> GetImages(string type);
    }
}