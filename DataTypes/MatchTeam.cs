using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scholar_Bowl
{
    /// <summary>
    /// Represents match information for a given team
    /// </summary>
    public class MatchTeam
    {
        public string Name { get { return this.Team.Name; } }
        public School School { get { return this.Team.School; } }
        public decimal Score { get; set; }
        public Team Team { get; set; }
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
