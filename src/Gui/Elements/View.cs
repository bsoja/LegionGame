using System.Collections.Generic;
using System.Linq;
using Legion.Gui.Services;
using Legion.Input;

namespace Legion.Gui.Elements
{
    public abstract class View : IView
    {
        private readonly IGuiServices guiServices;

        protected Layer blockingLayer;
        protected abstract IEnumerable<Layer> Layers { get; }
        
        public View(IGuiServices guiServices)
        {
            this.guiServices = guiServices;
        }

        public bool IsVisible { get; set; }

        public void Initialize()
        {
            foreach (var layer in Layers)
            {
                layer.Parent = this;
                layer.IsEnabled = true;
                layer.IsVisible = true;

                layer.Initialize();
            }
        }

        public void Update()
        {
            if (!IsVisible) { return; }

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
                if (layer.UpdateInput())
                {
                    break;
                }
            }

            foreach (var layer in updateables)
            {
                layer.Update();
            }
        }

        public void Draw()
        {
            if (!IsVisible) { return; }

            var drawables = Layers.Where(la => la.IsVisible);
            foreach (var layer in drawables)
            {
                layer.Draw();
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