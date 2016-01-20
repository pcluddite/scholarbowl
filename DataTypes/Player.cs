using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Scholar_Bowl {
    /// <summary>
    /// Represents a player
    /// </summary>
    public class Player : IComparable<Player>, ICloneable {
        /// <summary>
        /// Gets or sets the player name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the team on which this player plays.
        /// </summary>
        public Team Team { get; set; }

        /// <summary>
        /// Constructs a new Player
        /// </summary>
        /// <param name="name">the player name</param>
        /// <param name="team">the team on which this player plays</param>
        public Player(string name, Team team) {
            this.Name = name;
            this.Team = team;
        }

        /// <summary>
        /// Compares this player's average to another player
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int CompareTo(Player p) {
            decimal t1 = MainForm.AllMatches.GetTotalTossups(this);
            decimal g1 = MainForm.AllMatches.GetGamesPlayed(this);
            decimal t2 = MainForm.AllMatches.GetTotalTossups(p);
            decimal g2 = MainForm.AllMatches.GetGamesPlayed(p);

            decimal avg1 = (g1 == 0) ? -1 : t1 / g1;
            decimal avg2 = (g2 == 0) ? -1 : t2 / g2;

            if (avg1 == avg2) {
                if (g1 > g2) {
                    return -1;
                }
                else if (g1 < g2) {
                    return 1;
                }
                return 0;
            }
            else if (avg1 > avg2) {
                return -1;
            }
            else {
                return 1;
            }
        }

        public Player Clone() {
            return new Player(this.Name, this.Team);
        }

        public XmlNode ToXmlNode(XmlDocument doc) {
            XmlElement ret = doc.CreateElement("scholar");
            ret.SetAttribute("name", this.Name);
            ret.SetAttribute("school", this.Team.School.Name);
            ret.SetAttribute("team", this.Team.Name);
            return ret;
        }

        public static Dictionary<string, Player> FromXmlNode(XmlDocument doc, Dictionary<string, School> schools) {
            Dictionary<string, Player> ret = new Dictionary<string, Player>();
            XmlNode players = doc.SelectSingleNode("scholarbowl/scholars");
            foreach (XmlNode player in players.SelectNodes("scholar")) {
                ret.Add(player.Attributes["name"].Value,
                    new Player(player.Attributes["name"].Value,
                        schools[player.Attributes["school"].Value]
                        .Teams[player.Attributes["team"].Value]));
            }
            return ret;
        }

        object ICloneable.Clone()
        {
            return Clone();
        }
    }
}
