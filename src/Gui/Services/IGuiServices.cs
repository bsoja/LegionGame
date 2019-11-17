using System;
using Microsoft.Xna.Framework;

namespace Gui.Services
{
    public interface IGuiServices
    {
        IBasicDrawer BasicDrawer { get; }
        IImagesStore ImagesStore { get; }
        
        Rectangle GameBounds { get; }

        //NOTE: occurs when everything is loaded
        event Action GameLoaded;
    }
}