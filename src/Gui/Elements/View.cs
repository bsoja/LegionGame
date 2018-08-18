using System.Collections.Generic;
using System.Linq;
using Legion.Gui.Services;
using Legion.Input;

namespace Legion.Gui.Elements
{
    public abstract class View
    {
        private readonly IGuiServices guiServices;
        private bool isVisible;
        private Layer blockingLayer;

        public View(IGuiServices guiServices)
        {
            this.guiServices = guiServices;
        }

        protected abstract IEnumerable<Layer> Layers { get; }

        public bool IsVisible
        {
            get { return isVisible; }
            set
            {
                var isChanged = isVisible != value;
                isVisible = value;
                if (isChanged)
                {
                    if (isVisible)
                    {
                        OnShowInternal();
                    }
                    else
                    {
                        OnHideInternal();
                    }
                }
            }
        }

        public object Context { get; set; }

        public virtual void Initialize() { }
        public virtual void Update() { }
        public virtual void Draw() { }
        protected virtual void OnShow() { }
        protected virtual void OnHide() { }

        internal void InitializeInternal()
        {
            Initialize();

            foreach (var layer in Layers)
            {
                layer.Parent = this;
                layer.IsEnabled = true;
                layer.IsVisible = true;

                layer.InitializeInternal();
            }
        }

        internal void UpdateInternal()
        {
            if (!IsVisible) { return; }

            Update();

            IEnumerable<Layer> updateables;

            if (blockingLayer != null)
            {
                updateables = new List<Layer>() { blockingLayer };
            }
            else
            {
                updateables = Layers.Where(la => la.IsEnabled);
            }

            InputManager.Update();

            foreach (var layer in updateables.Reverse())
            {
                if (layer.UpdateInputInternal())
                {
                    break;
                }
            }

            foreach (var layer in updateables)
            {
                layer.UpdateInternal();
            }
        }

        internal void DrawInternal()
        {
            if (!IsVisible) { return; }

            Draw();

            var drawables = Layers.Where(la => la.IsVisible);
            foreach (var layer in drawables)
            {
                layer.DrawInternal();
            }
        }

        internal void OnShowInternal()
        {
            OnShow();

            foreach (var layer in Layers)
            {
                layer.OnShow();
            }
        }

        internal void OnHideInternal()
        {
            OnHide();

            foreach (var layer in Layers)
            {
                layer.OnHide();
            }
        }

        internal void BlockLayers(Layer layer)
        {
            blockingLayer = layer;
        }

        internal void UnblockLayers()
        {
            blockingLayer = null;
        }
    }
}