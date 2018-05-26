using System;
using Microsoft.Xna.Framework;

namespace Legion.Gui.Services
{
    public interface IGuiServices
    {
        IBasicDrawer BasicDrawer { get; }
        IImagesProvider ImagesProvider { get; }
        Rectangle GameBounds { get; }

        //NOTE: occurs when everything is loaded
        event Action Loaded;
    }
}