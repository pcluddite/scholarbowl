using System;
using System.Collections.Generic;
using System.Xml;

namespace Scholar_Bowl
{
    /// <summary>
    /// Represents a match that has been played between two teams
    /// </summary>
    public class Match : ICloneable {
        /// <summary>
        /// Gets or sets a unique ID for this match
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets a the first team playing
        /// </summary>
        public MatchTeam FirstTeam { get; set; }

        /// <summary>
        /// Gets or sets a the second team playing
        /// </summary>
        public MatchTeam SecondTeam { get; set; }

        /// <summary>
        /// Gets or sets the date when this match was played
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets the winner for this match, or null if a tie
        /// </summary>
        public MatchTeam Winner {
            get {
                if (FirstTeam.Score > SecondTeam.Score) {
                    return FirstTeam;
                }
                else if (FirstTeam.Score < SecondTeam.Score) {
                    return SecondTeam;
                }
                else {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the loser for this match, or null if a tie
        /// </summary>
        public MatchTeam Loser {
            get {
                if (FirstTeam.Score < SecondTeam.Score) {
                    return FirstTeam;
                }
                else if (FirstTeam.Score > SecondTeam.Score) {
                    return SecondTeam;
                }
                else {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets all players in this match
        /// </summary>
        public ICollection<MatchPlayer> Players {
            get {
                List<MatchPlayer> ret = new List<MatchPlayer>();
                ret.AddRange(this.FirstTeam.Players);
                ret.AddRange(this.SecondTeam.Players);
                return ret;
            }
        }

        /// <summary>
        /// Returns whether or not a team played in this match
        /// </summary>
        /// <param name="t">the team</param>
        /// <returns>true if the team played, false otherwise</returns>
        public bool DidPlay(Team t) {
            return (t == FirstTeam.Team) || (t == SecondTeam.Team);
        }

        /// <summary>
        /// Returns whether or not a player played in this match
        /// </summary>
        /// <param name="t">the player</param>
        /// <returns>true if the player played, false otherwise</returns>
        public bool DidPlay(Player p) {
            foreach (MatchPlayer mp in this.Players) {
                if (mp.Player == p) {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns the opponent of the given player
        /// </summary>
        /// <param name="p"></param>
        /// <returns>the team this player played against</returns>
        public MatchTeam GetOppenent(Player p) {
            if (this.FirstTeam.HasPlayer(p)) {
                return this.SecondTeam;
            }
            else if (this.SecondTeam.HasPlayer(p)) {
                return this.FirstTeam;
            }
            else {
                return null;
            }
        }

        /// <summary>
        /// Returns the team a given player played for
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public MatchTeam GetTeam(Player player) {
            if (this.FirstTeam.HasPlayer(player)) {
                return this.FirstTeam;
            }
            else if (this.SecondTeam.HasPlayer(player)) {
                return this.SecondTeam;
            }
            else {
                return null;
            }
        }

        /// <summary>
        /// Gets a player's match information
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public MatchPlayer GetPlayer(Player player) {
            foreach (MatchPlayer mplayer in this.Players) {
                if (mplayer.Player == player) {
                    return mplayer;
                }
            }
            return null;
        }

        /// <summary>
        /// Returns the number of tossups a player a player got
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public decimal GetTossups(Player player) {
            decimal ret = 0;
            foreach (MatchTeam mt in GetTeamsAsList()) {
                foreach (var p in mt.Players) {
                    if (p.Name.Equals(player.Name)) {
                        ret += p.Tossups;
                    }
                }
            }
            return ret;
        }

        /// <summary>
        /// Returns the duration for which a player played
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public decimal GetDuration(Player player) {
            decimal ret = 0;
            foreach (MatchTeam mt in GetTeamsAsList()) {
                foreach (var p in mt.Players) {
                    if (p.Name.Equals(player.Name)) {
                        ret += p.Duration;
                    }
                }
            }
            return ret;
        }

        private List<MatchTeam> GetTeamsAsList()
        {
            return new List<MatchTeam>() { FirstTeam, SecondTeam };
        }

        /// <summary>
        /// Constructs a new match
        /// </summary>
        /// <param name="id">the unique id for this match</param>
        /// <param name="dt">the date on which this match was played</param>
        /// <param name="team1">the match information for the first team</param>
        /// <param name="team2">the match information for the second team</param>
        public Match(int id, DateTime dt, MatchTeam team1, MatchTeam team2) {
            this.Date = dt;
            this.FirstTeam = team1;
            this.SecondTeam = team2;
            this.ID = id;
        }

        /// <summary>
        /// Clones this Match
        /// </summary>
        /// <returns></returns>
        public Match Clone() {
            MatchTeam firstTeam = new MatchTeam(this.FirstTeam.Team, this.FirstTeam.Score, this.FirstTeam.Players);
            MatchTeam secondTeam = new MatchTeam(this.SecondTeam.Team, this.SecondTeam.Score, this.SecondTeam.Players);
            return new Match(this.ID, this.Date, firstTeam, secondTeam);
        }

        /// <summary>
        /// Converts this object to an XmlNode
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public XmlNode ToXmlNode(XmlDocument doc) {
            XmlElement ret = doc.CreateElement("match");
            ret.SetAttribute("date", this.Date.ToShortDateString());
            foreach (MatchTeam mt in GetTeamsAsList()) {
                XmlElement team = doc.CreateElement("team");
                team.SetAttribute("school", mt.School.Name);
                team.SetAttribute("team", mt.Name);
                team.SetAttribute("score", mt.Score.ToString());

                foreach (var p in mt.Players) {
                    XmlElement pnode = doc.CreateElement("player");
                    pnode.SetAttribute("name", p.Name);
                    pnode.SetAttribute("tossups", p.Tossups.ToString());
                    pnode.SetAttribute("dur", p.Duration.ToString());
                    team.AppendChild(pnode);
                }

                ret.AppendChild(team);
            }
            return ret;
        }

        object ICloneable.Clone()
        {
            return Clone();
        }
    }
}
