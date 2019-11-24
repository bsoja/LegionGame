using System;
using System.ComponentModel;
using Legion.Views.Common.Controls;

namespace Legion.Views.Common
{
    public interface ICommonGuiFactory
    {
        LoadGameWindow CreateLoadGameWindow(Action<HandledEventArgs> onExit);
    }
}