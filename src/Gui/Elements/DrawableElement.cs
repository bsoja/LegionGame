using Legion.Gui.Services;
using Microsoft.Xna.Framework;

namespace Legion.Gui.Elements
{
    public class DrawableElement
    {
        private readonly IGuiServices guiServices;

        public DrawableElement(IGuiServices guiServices)
        {
            this.guiServices = guiServices;
        }

        protected IGuiServices GuiServices
        {
            get { return guiServices; }
        }

        public Rectangle Bounds { get; set; }
        public bool IsVisible { get; set; }
        public bool IsEnabled { get; set; }

        public virtual bool UpdateInput() { return false; }
        public virtual void Update() { }
        public virtual void Draw() { }
    }
}