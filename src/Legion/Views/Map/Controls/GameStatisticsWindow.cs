using System;
using System.ComponentModel;
using System.Linq;
using Gui.Elements;
using Gui.Services;
using Legion.Controllers.Map;
using Legion.Localization;
using Legion.Model;
using Microsoft.Xna.Framework;

namespace Legion.Views.Map.Controls
{
    public class GameStatisticsWindow : Window
    {
        protected const int DefaultWidth = 160;
        protected const int DefaultHeight = 120;

        private readonly ITexts _texts;
        private readonly ILegionInfo _legionInfo;
        private readonly IMapController _mapController;
        private readonly IPlayersRepository _playersRepository;

        protected Panel InnerPanel;
        protected Button OkButton;
        protected Button ChartsButton;
        protected Label Label1;
        protected Label Label2;
        protected Label Label3;
        protected Label Label4;
        protected Label Label5;
        protected Label Label6;

        public GameStatisticsWindow(
            IGuiServices guiServices,
            ITexts texts,
            ILegionInfo legionInfo,
            IMapController mapController,
            IPlayersRepository playersRepository) : base(guiServices)
        {
            _texts = texts;
            _legionInfo = legionInfo;
            _mapController = mapController;
            _playersRepository = playersRepository;

            CreateElements();
        }

        public event Action<HandledEventArgs> OkClicked
        {
            add => OkButton.Clicked += value;
            remove => OkButton.Clicked -= value;
        }

        public event Action<HandledEventArgs> ChartsClicked
        {
            add => ChartsButton.Clicked += value;
            remove => ChartsButton.Clicked -= value;
        }

        private void CreateElements()
        {
            InnerPanel = new Panel(GuiServices);

            OkButton = new BrownButton(GuiServices, _texts.Get("gameStatistics.ok")) { Center = true };
            OkButton.Clicked += args => Closing?.Invoke(args);

            ChartsButton = new BrownButton(GuiServices, _texts.Get("gameStatistics.charts")) { Center = true };
            ChartsButton.Clicked += args => Closing?.Invoke(args);

            Label1 = new Label(GuiServices) {Text = _texts.Get("gameStatistics.reportForDay", _legionInfo.CurrentDay)};
            Label2 = new Label(GuiServices) { Text = _texts.Get("gameStatistics.yourPossession") };
            
            var userArmies =
                _mapController.Armies.Where(a => !a.IsKilled && a.Owner != null && a.Owner.IsUserControlled);
            var userCharacters = userArmies.Sum(a => a.Characters.Count(c => c.Energy > 0));

            //TODO: handle words ends correctly, based on numbers
            Label3 = new Label(GuiServices)
            {
                Text = _texts.Get("gameStatistics.legionAndWarriorsCount", userArmies.Count(), userCharacters)
            };

            /*
             For A=0 To 19
              If ARMIA(A,0,TE)>0
                 Inc AM
                 For I=1 To 10
                    If ARMIA(A,I,TE)>0
                       Inc WOJ
                    End If 
                 Next I
              End If 
           Next A
           RES=AM mod 10
           KON$="" : KON2$="ów"
           If RES<=1 or RES>4 : KON$="ów" : End If 
           If RES>1 and RES<5 : KON$="y" : End If 
           If AM=1 : KON$="" : End If 
           If WOJ=1 : KON2$="" : End If 
           A$=Str$(AM)+" legion"+KON$+", "+Str$(WOJ)+" wojownik"+KON2$
             */

            var userCities = _mapController.Cities.Where(c => c.Owner != null && c.Owner.IsUserControlled);
            var userCitizens = userCities.Sum(uc => uc.Population);
            var dailyIncome = userCities.Sum(c => c.Tax * c.Population / 25);

            //TODO: handle words ends correctly, based on numbers
            Label4 = new Label(GuiServices)
            {
                Text = _texts.Get("gameStatistics.citiesAndCitizensCount", userCities.Count(), userCitizens)
            };
            Label5 = new Label(GuiServices) { Text = _texts.Get("gameStatistics.dailyIncome", dailyIncome) };

            /*
             For M=0 To 49
              If MIASTA(M,0,M_CZYJE)=1
                 Inc MS
                 Add LUDZIE,MIASTA(M,0,M_LUDZIE)
                 Add POD,MIASTA(M,0,M_PODATEK)*MIASTA(M,0,M_LUDZIE)/25
              End If 
           Next M
           RES=MS mod 10
           KON$=""
           If RES>1 and RES<5 : KON$="a" : End If 
           If MS=1 : KON$="o" : End If 
           B$=Str$(MS)+" miast"+KON$+", "+Str$(LUDZIE)+" mieszka?ców"
           C$="Dzienny dochód : "+Str$(POD)
             */

            Label6 = new Label(GuiServices)
            {
                Text = _texts.Get("gameStatistics.treasure", _playersRepository.UserPlayer.Money)
            };

            Elements.Add(InnerPanel);
            Elements.Add(OkButton);
            Elements.Add(ChartsButton);
            Elements.Add(Label1);
            Elements.Add(Label2);
            Elements.Add(Label3);
            Elements.Add(Label4);
            Elements.Add(Label5);
            Elements.Add(Label6);

            UpdateBounds();
        }

        private void UpdateBounds()
        {
            var width = DefaultWidth;
            var height = DefaultHeight;
            var x = (GuiServices.GameBounds.Width / 2) - (width / 2);
            var y = (GuiServices.GameBounds.Height / 2) - (height / 2);
            Bounds = new Rectangle(x, y, width, height);

            InnerPanel.Bounds = new Rectangle(Bounds.X + 4, Bounds.Y + 4, 152, 92);
            ChartsButton.Bounds = new Rectangle(Bounds.X + 4, Bounds.Y + 100, 40, 15);
            OkButton.Bounds = new Rectangle(Bounds.X + 116, Bounds.Y + 100, 40, 15);

            Label1.Bounds = new Rectangle(Bounds.X + 8, Bounds.Y + 16 - 8, 10, 10);
            Label2.Bounds = new Rectangle(Bounds.X + 8, Bounds.Y + 26 - 8, 10, 10);
            Label3.Bounds = new Rectangle(Bounds.X + 8, Bounds.Y + 44 - 8, 10, 10);
            Label4.Bounds = new Rectangle(Bounds.X + 8, Bounds.Y + 54 - 8, 10, 10);
            Label5.Bounds = new Rectangle(Bounds.X + 8, Bounds.Y + 74 - 8, 10, 10);
            Label6.Bounds = new Rectangle(Bounds.X + 8, Bounds.Y + 84 - 8, 10, 10);
        }
    }
}