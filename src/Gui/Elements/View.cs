using System.Collections.Generic;
using System.Linq;
using Gui.Input;
using Gui.Services;

namespace Gui.Elements
{
    public abstract class View
    {
        private readonly IGuiServices _guiServices;
        private bool _isVisible;
        private Layer _blockingLayer;

        public View(IGuiServices guiServices)
        {
            _guiServices = guiServices;
        }

        protected abstract IEnumerable<Layer> Layers { get; }

        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                var isChanged = _isVisible != value;
                _isVisible = value;
                if (isChanged)
                {
                    if (_isVisible)
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

            if (_blockingLayer != null)
            {
                updateables = new List<Layer> { _blockingLayer };
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

        public void BlockLayers(Layer layer)
        {
            _blockingLayer = layer;
        }

        public void UnblockLayers()
        {
            _blockingLayer = null;
        }
    }
}