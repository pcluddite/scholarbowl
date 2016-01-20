namespace Scholar_Bowl
{
    /// <summary>
    /// Represents match information for a given player
    /// </summary>
    public class MatchPlayer
    {
        public Player Player { get; set; }
        public decimal Tossups { get; set; }
        public decimal Duration { get; set; }

        public string Name { get { return this.Player.Name; } }

        public MatchPlayer(Player p, decimal t, decimal d)
        {
            this.Player = p;
            this.Tossups = t;
            this.Duration = d;
        }
    }
}
