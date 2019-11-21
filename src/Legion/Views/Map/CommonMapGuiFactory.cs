using Gui.Services;
using Legion.Model;
using Legion.Model.Types;
using Legion.Views.Map.Controls;

namespace Legion.Views.Map
{
    public class CommonMapGuiFactory : ICommonMapGuiFactory
    {
        private readonly IGuiServices _guiServices;
        private readonly IPlayersRepository _playersRepository;

        public CommonMapGuiFactory(
            IGuiServices guiServices,
            IPlayersRepository playersRepository)
        {
            _guiServices = guiServices;
            _playersRepository = playersRepository;
        }

        public BuyInformationWindow CreateBuyInformationWindow(MapObject target)
        {
            var window = new BuyInformationWindow(_guiServices);

            window.OkClicked += args =>
            {
                var user = _playersRepository.UserPlayer;
                if (user.Money - window.Price >= 0 && window.Price > 100)
                {
                    if (target is Army) ((Army)target).DaysToGetInfo = window.Days;
                    if (target is City) ((City)target).DaysToGetInfo = window.Days;
                    user.Money -= window.Price;
                }
            };

            return window;
        }
    }
}