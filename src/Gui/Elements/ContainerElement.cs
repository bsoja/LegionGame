using System.Collections.Generic;
using System.Linq;
using Legion.Gui.Services;

namespace Legion.Gui.Elements
{
    public class ContainerElement : ClickableElement
    {
        public ContainerElement(IGuiServices guiServices) : base(guiServices)
        {
            Elements = new List<DrawableElement>();
        }

        protected List<DrawableElement> Elements { get; private set; }

        public override bool UpdateInput()
        {
            foreach (var elem in ((IEnumerable<DrawableElement>) Elements).Reverse())
            {
                var handled = elem.UpdateInput();
                if (handled) return true;
            }
            return base.UpdateInput();
        }

        public override void Update()
        {
            foreach (var elem in Elements)
            {
                elem.Update();
            }
        }

        public override void Draw()
        {
            foreach (var elem in Elements)
            {
                elem.Draw();
            }
        }

        public void AddElement(DrawableElement element)
        {
            Elements.Add(element);
        }

        public void RemoveElement(DrawableElement element)
        {
            Elements.Remove(element);
        }
    }
}