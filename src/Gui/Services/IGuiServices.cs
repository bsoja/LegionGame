using System;
using Gui.Services;
using Microsoft.Xna.Framework;

namespace Gui.Services
{
    public interface IGuiServices
    {
        IBasicDrawer BasicDrawer { get; }
        IImagesProvider ImagesProvider { get; }
        
        Rectangle GameBounds { get; }

        //NOTE: occurs when everything is loaded
        event Action GameLoaded;
    }
}