using System.Collections.Generic;
using System.Linq;
using Legion.Gui;
using Legion.Gui.Services;
using Legion.Input;
using Microsoft.Xna.Framework;

namespace Legion.Gui.Elements
{
    public class View
    {
        protected Layer blockingLayer;
        private readonly IGuiServices guiServices;

        public View(IGuiServices guiServices)
        {
            this.guiServices = guiServices;
        }

        public bool IsVisible { get; set; }
        public object Context { get; private set; }

        protected IEnumerable<Layer> Layers { get; private set; }

        protected void SetLayers(IEnumerable<Layer> layers)
        {
            Layers = layers;
            foreach (var layer in Layers)
            {
                layer.Parent = this;
                layer.IsEnabled = true;
                layer.IsVisible = true;
            }
        }

        public void Initialize()
        {
            foreach (var layer in Layers)
            {
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

        public void Show(object context)
        {
            Context = context;
            IsVisible = true;
        }

        public void Hide()
        {
            IsVisible = false;
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