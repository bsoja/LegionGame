using System.Collections.Generic;
using Legion.Model.Types;

namespace Legion.Model
{
    public class PlayersRepository : IPlayersRepository
    {
        public PlayersRepository()
        {
            Players = new List<Player>();
        }

        public List<Player> Players { get; private set; }

        public Player UserPlayer { get; set; }
        public Player ChaosPlayer { get; set; }
    }

}