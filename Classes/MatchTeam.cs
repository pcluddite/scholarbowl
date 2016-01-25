using System.Collections.Generic;

namespace Scholar_Bowl
{
    /// <summary>
    /// Represents match information for a given team
    /// </summary>
    public class MatchTeam
    {
        /// <summary>
        /// Gets the name of this team
        /// </summary>
        public string Name { get { return this.Team.Name; } }
        /// <summary>
        /// Gets the school this team is a member of
        /// </summary>
        public School School { get { return this.Team.School; } }
        /// <summary>
        /// Gets this team's final score for this match
        /// </summary>
        public decimal Score { get; set; }
        /// <summary>
        /// Gets the team
        /// </summary>
        public Team Team { get; set; }
        /// <summary>
        /// Gets the players who played in this match
        /// </summary>
        public MatchPlayer[] Players { get; set; }

        public MatchTeam(Team t, decimal s, MatchPlayer[] players)
        {
            this.Players = players;
            this.Team = t;
            this.Score = s;
        }

        public bool HasPlayer(Player p)
        {
            foreach (MatchPlayer mp in this.Players) {
                if (mp.Player == p) {
                    return true;
                }
            }
            return false;
        }

        public bool HasPlayer(string playerName)
        {
            foreach (MatchPlayer mp in this.Players) {
                if (mp.Player.Name.Equals(playerName)) {
                    return true;
                }
            }
            return false;
        }

        public MatchPlayer FindPlayer(string playerName)
        {
            foreach (MatchPlayer mp in this.Players) {
                if (mp.Player.Name.Equals(playerName)) {
                    return mp;
                }
            }
            return null;
        }

        public void AddPlayer(MatchPlayer mp)
        {
            List<MatchPlayer> newPlayers = new List<MatchPlayer>();
            newPlayers.AddRange(this.Players);
            newPlayers.Add(mp);
            this.Players = newPlayers.ToArray();
        }

        public void RemovePlayer(string playerName)
        {
            List<MatchPlayer> newPlayers = new List<MatchPlayer>();
            foreach (MatchPlayer mp in this.Players) {
                if (!mp.Name.Equals(playerName)) {
                    newPlayers.Add(mp);
                }
            }
            this.Players = newPlayers.ToArray();
        }
    }
}
