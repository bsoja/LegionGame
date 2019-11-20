using System;
using System.Collections.Generic;
using System.ComponentModel;
using Gui.Services;
using Legion.Localization;

namespace Legion.Views.Map.Controls
{
    public class ArmyOrdersWindow : ButtonsListWindow
    {
        public ArmyOrdersWindow(IGuiServices guiServices,
            ITexts texts,
            bool isTerrainActionButtonVisible,
            bool isRecruitButtonVisible) : base(guiServices)
        {
            var dict = new Dictionary<string, Action<HandledEventArgs>>
            {
                {texts.Get("move"), args => MoveClicked?.Invoke(args)},
                {texts.Get("fastMove"), args => FastMoveClicked?.Invoke(args)},
                {texts.Get("attack"), args => AttackClicked?.Invoke(args)}
            };
            if (isRecruitButtonVisible)
            {
                dict.Add(texts.Get("recruit"), args => RecruitClicked?.Invoke(args));
            }
            else
            {
                dict.Add(texts.Get("hunt"), args => HuntClicked?.Invoke(args));
            }
            dict.Add(texts.Get("camp"), args => CampClicked?.Invoke(args));
            dict.Add(texts.Get("equipment"), args => EquipmentClicked?.Invoke(args));
            if (isTerrainActionButtonVisible)
            {
                dict.Add(texts.Get("action"), args => ActionClicked?.Invoke(args));
            }
            dict.Add(texts.Get("exit"), args => ExitClicked?.Invoke(args));

            ButtonNames = dict;
        }

        public event Action<HandledEventArgs> MoveClicked;

        public event Action<HandledEventArgs> FastMoveClicked;

        public event Action<HandledEventArgs> AttackClicked;

        public event Action<HandledEventArgs> RecruitClicked;

        public event Action<HandledEventArgs> HuntClicked;

        public event Action<HandledEventArgs> CampClicked;

        public event Action<HandledEventArgs> EquipmentClicked;

        public event Action<HandledEventArgs> ActionClicked;

        public event Action<HandledEventArgs> ExitClicked;

        public override void Draw()
        {
            base.Draw();

            //TODO: selected action marker 
            /*
               If TRYB>0
                  Text OKX+65,OKY-4+18*TRYB,"@"
               End If 
               If TRYB=0
                  Text OKX+65,OKY-4+18*5,"@"
               End If 
            */
        }
    }
}