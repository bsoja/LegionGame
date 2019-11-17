using System;
using System.ComponentModel;
using Gui.Input;
using Gui.Services;

namespace Gui.Elements
{
    public class SelectableElement : ClickableElement
    {
        public SelectableElement(IGuiServices guiServices) : base(guiServices)
        {
            Clicked += args => IsMouseOver = false;
        }
        
        public event Action<HandledEventArgs> MouseEnter;
        public event Action<HandledEventArgs> MouseLeave;

        public bool IsMouseOver { get; private set; }

        protected virtual bool OnMouseEnter()
        {
            IsMouseOver = true;

            var args = new HandledEventArgs();
            MouseEnter?.Invoke(args);
            return args.Handled;
        }

        protected virtual bool OnMouseLeave()
        {
            IsMouseOver = false;

            var args = new HandledEventArgs();
            MouseLeave?.Invoke(args);
            return args.Handled;
        }

        internal override bool UpdateInputInternal()
        {
            var handled = false;
            var previousPosition = InputManager.GetMousePostion(false);
            var currentPosition = InputManager.GetMousePostion(true);

            var wasMouseInside = Bounds.Contains(previousPosition);
            var isMouseInside = Bounds.Contains(currentPosition);

            if (!wasMouseInside && isMouseInside)
            {
                handled = OnMouseEnter();
            }
            else if (wasMouseInside && !isMouseInside)
            {
                handled = OnMouseLeave();
            }

            return handled || base.UpdateInputInternal();
        }
    }
}