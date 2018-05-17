using System;
using System.Collections.Generic;
using System.Linq;
using Legion.Gui;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.View
{
    public class View : DrawableGameComponent
    {
        protected List<Layer> layers;
        protected Layer blockingLayer;

        public View(Game game, List<Layer> layers) : base(game)
        {
            this.layers = layers;
            if (layers != null)
            {
                foreach (var layer in layers)
                {
                    layer.Parent = this;
                }
            }
        }

        public void Show(object context)
        {
            Context = context;
            Visible = true;
        }

        public void Hide()
        {
            Visible = false;
        }

        public object Context { get; private set; }

        public SpriteBatch SpriteBatch
        {
            get { return ((LegionGame) Game).SpriteBatch; }
        }

        public IBasicDrawer BasicDrawer
        {
            get { return ((LegionGame) Game).BasicDrawer; }
        }

        public override void Initialize()
        {
            base.Initialize();

            foreach (var layer in layers)
            {
                layer.Initialize();
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (!Visible) { return; }

            IEnumerable<Layer> updateables;

            if (blockingLayer != null)
            {
                updateables = new List<Layer>() { blockingLayer };
            }
            else
            {
                updateables = layers.Where(la => la.Enabled);
            }

            foreach (var layer in updateables.Reverse())
            {
                if (layer.UpdateInput())
                {
                    break;
                }
            }

            foreach (var layer in updateables)
            {
                layer.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            if (!Visible) { return; }

            var drawables = layers.Where(la => la.Visible);
            foreach (var layer in drawables)
            {
                layer.Draw(gameTime);
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