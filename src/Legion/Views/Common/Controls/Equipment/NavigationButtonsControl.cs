using System;
using System.ComponentModel;
using Gui.Elements;
using Gui.Services;
using Microsoft.Xna.Framework;

namespace Legion.Views.Common.Controls.Equipment
{
    public class NavigationButtonsControl : ContainerElement
    {
        private readonly BrownButton _prevButton;
        private readonly BrownButton _nextButton;

        public NavigationButtonsControl(IGuiServices guiServices) : base(guiServices)
        {
            // TODO: somehow current font displays '<' as '>' (WTF?)
            _prevButton = new BrownButton(GuiServices, ">");
            _prevButton.Center = true;
            AddElement(_prevButton);

            // TODO: somehow current font displays '<' as '>' (WTF?)
            _nextButton = new BrownButton(GuiServices, "<");
            _nextButton.Center = true;
            AddElement(_nextButton);
        }

        public event Action<HandledEventArgs> PrevClicked
        {
            add => _prevButton.Clicked += value;
            remove => _prevButton.Clicked -= value;
        }

        public event Action<HandledEventArgs> NextClicked
        {
            add => _nextButton.Clicked += value;
            remove => _nextButton.Clicked -= value;
        }

        public Point Position
        {
            get => Bounds.Location;
            set => Bounds = new Rectangle(value.X, value.Y, 80, 120);
        }

        public override void Update()
        {
            _prevButton.Bounds = new Rectangle(Bounds.X, Bounds.Y + 15, 30, 15);
            _nextButton.Bounds = new Rectangle(Bounds.X + 45, Bounds.Y + 15, 30, 15);
        }
    }
}