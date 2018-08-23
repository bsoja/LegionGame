using System.Collections.Generic;
using System.Linq;
using Gui.Services;

namespace Gui.Elements
{
    public class ContainerElement : ClickableElement
    {
        public ContainerElement(IGuiServices guiServices) : base(guiServices)
        {
            Elements = new List<DrawableElement>();
        }

        protected List<DrawableElement> Elements { get; private set; }

        internal override bool UpdateInputInternal()
        {
            foreach (var elem in ((IEnumerable<DrawableElement>) Elements).Reverse())
            {
                if (elem is ClickableElement && elem.IsEnabled && elem.IsVisible)
                {
                    var handled = ((ClickableElement) elem).UpdateInputInternal();
                    if (handled) return true;
                }
            }
            return base.UpdateInputInternal();
        }

        internal override void UpdateInternal()
        {
            base.UpdateInternal();

            foreach (var elem in Elements)
            {
                if (elem.IsVisible) elem.UpdateInternal();
            }
        }

        internal override void DrawInternal()
        {
            base.DrawInternal();

            foreach (var elem in Elements)
            {
                if (elem.IsVisible) elem.DrawInternal();
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