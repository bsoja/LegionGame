using System;
using Gui.Services;
using Legion.Model;
using Microsoft.Xna.Framework;

namespace Legion.Gui
{
    public interface ILegionGuiServices : IGuiServices
    {
        IViewSwitcher ViewSwitcher { get; }
    }
}