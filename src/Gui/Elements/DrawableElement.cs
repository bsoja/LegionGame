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
        public bool IsVisible { get; set; } = true;
        public bool IsEnabled { get; set; } = true;

        internal virtual void InitializeInternal()
        {
            Initialize();
        }

        internal virtual void UpdateInternal()
        {
            Update();
        }

        internal virtual void DrawInternal()
        {
            Draw();
        }

        public virtual void Initialize() { }
        public virtual void Update() { }
        public virtual void Draw() { }
    }
}