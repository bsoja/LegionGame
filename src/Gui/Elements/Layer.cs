using Legion.Gui;
using Legion.Gui.Services;

namespace Legion.Gui.Elements
{
    public class Layer : ContainerElement
    {
        public Layer(IGuiServices guiServices) : base(guiServices) { }

        public View Parent { get; set; }
        
        public virtual void OnShow() { }
        public virtual void OnHide() { }
    }
}