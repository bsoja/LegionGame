using System.Collections.Generic;
using Legion.Model.Types;

namespace Legion.Model
{
    public interface IPlayersRepository
    {
        List<Player> Players { get; }

        Player UserPlayer { get; set; }
        Player ChaosPlayer { get; set; }
    }

}