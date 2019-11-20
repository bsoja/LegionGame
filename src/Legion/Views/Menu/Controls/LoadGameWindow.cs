using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Gui.Services;
using Legion.Localization;
using Legion.Views.Map.Controls;

namespace Legion.Views.Menu.Controls
{
    public class LoadGameWindow : ButtonsListWindow
    {
        public LoadGameWindow(IGuiServices guiServices, ITexts texts) : base(guiServices)
        {
            //TODO: keep archives path in common place
            //TODO: sort out this line:
            var archives = Directory.EnumerateFiles(Path.Combine("data", "archive"))
                .Take(10)
                .Select(Path.GetFileName)
                .ToList();

            var dict = new Dictionary<string, Action<HandledEventArgs>>();
            foreach (var name in archives)
            {
                dict.Add(name, args => ArchiveNameClicked?.Invoke(args, name));
            }
            dict.Add(texts.Get("exit"), args => ExitClicked?.Invoke(args));
            ButtonNames = dict;
        }

        public event Action<HandledEventArgs, string> ArchiveNameClicked;

        public event Action<HandledEventArgs> ExitClicked;
    }
}
