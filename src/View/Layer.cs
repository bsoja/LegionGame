using System.Collections.Generic;
using System.Linq;
using Legion.Gui;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.View
{
    public class Layer<T> : Layer where T : View
    {
        public Layer(Game game) : base(game) { }
        public new T Parent
        {
            get { return (T) base.Parent; }
            set { base.Parent = value; }
        }
    }

    public class Layer : DrawableGameComponent
    {
        public Layer(Game game) : base(game)
        {
            GuiElements = new List<GuiElement>();
        }

        public View Parent { get; set; }

        protected List<GuiElement> GuiElements { get; private set; }

        public SpriteBatch SpriteBatch
        {
            get { return Parent?.SpriteBatch; }
        }

        public IBasicDrawer BasicDrawer
        {
            get { return Parent?.BasicDrawer; }
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public virtual bool UpdateInput()
        {
            foreach (var elem in ((IEnumerable<GuiElement>) GuiElements).Reverse())
            {
                var handled = elem.UpdateInput();
                if (handled) return true;
            }
            return false;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            foreach (var elem in GuiElements)
            {
                elem.Update();
            }
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            foreach (var elem in GuiElements)
            {
                elem.Draw();
            }
        }

        public void AddElement(GuiElement element)
        {
            GuiElements.Add(element);
        }

        public void RemoveElement(GuiElement element)
        {
            GuiElements.Remove(element);
        }
    }
}