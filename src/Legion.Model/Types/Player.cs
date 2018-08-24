using System.Collections.Generic;

namespace Legion.Model.Types
{
    // GRACZE(4, 3)
    public class Player
    {
        public Player()
        {
            Name = "";
            Wars = new Dictionary<Player, int>();
        }

        public int Id { get; set; }

        /// <summary>
        /// IMIONA$
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// GRACZE(1,1)
        /// </summary>
        public int Money { get; set; }

        /// <summary>
        /// GRACZE(1,2)
        /// </summary>
        public int Power { get; set; }

        /// <summary>
        /// GRACZE(1,3) - used only when drawing status reports?
        /// </summary>
        public int Unknown { get; set; }

        // TODO magic number == 1
        public bool IsUserControlled
        {
            get { return Id == 1; }
        }

        // TODO magic number
        public bool IsChaosControlled
        {
            get { return Id == 5; }
        }

        /// <summary>
        /// WOJNA(5,5)
        /// </summary>
        /// <value>The wars.</value>
        private Dictionary<Player, int> Wars { get; set; }
        private int WarWithNoOwner { get; set; }

        public void UpdateWar(Player player, int days)
        {
            if (player == this) return;

            if (player == null)
            {
                WarWithNoOwner = days;
                return;
            }

            if (Wars.ContainsKey(player))
            {
                Wars[player] = days;
            }
            else
            {
                Wars.Add(player, days);
            }
        }

        public int GetWar(Player player)
        {
            if (player == null) return WarWithNoOwner;
            if (player == this) return 0;
            if (Wars.ContainsKey(player)) return Wars[player];
            return 0;
        }

        public void DecreaseAllWars(int days)
        {
            var players = new List<Player>(Wars.Keys);
            foreach (var player in players)
            {
                if (Wars[player] > 0)
                {
                    Wars[player] -= days;
                }
            }
            if (WarWithNoOwner > 0)
            {
                WarWithNoOwner -= days;
            }
        }

    }
}