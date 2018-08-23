using Gui;
using Gui.Services;

namespace Gui.Elements
{
    public class Layer : ContainerElement
    {
        public Layer(IGuiServices guiServices) : base(guiServices) { }

        public View Parent { get; set; }
        
        public virtual void OnShow() { }
        public virtual void OnHide() { }
    }
}