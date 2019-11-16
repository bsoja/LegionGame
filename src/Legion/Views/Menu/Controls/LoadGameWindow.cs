using System.Collections.Generic;
using System.IO;
using System.Linq;
using Gui.Services;
using Legion.Views.Map.Controls;

namespace Legion.Views.Menu.Controls
{
    public class LoadGameWindow : OrdersWindowBase
    {
        public LoadGameWindow(IGuiServices guiServices) : base(guiServices)
        {
        }

        protected override List<string> ButtonNames
        {
            get
            {
                //TODO: keep archives path in common place
                //TODO: sort out this line:
                var archives = Directory.EnumerateFiles(Path.Combine("data", "archive")).Take(10).Select(Path.GetFileName).ToList();
                return archives;
            }
        }
    }
}
