using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Scholar_Bowl {
    /// <summary>
    /// Represents a school
    /// </summary>
    public class School {
        public string Name { get; set; }
        public Dictionary<string, Team> Teams { get { return teams; } }

        private Dictionary<string, Team> teams;

        public School(string name, string[] teams) {
            this.Name = name;
            this.teams = new Dictionary<string, Team>();
            foreach (string s in teams) {
                this.teams.Add(s, new Team(this, s));
            }
        }

        public XmlNode ToXmlNode(XmlDocument doc) {
            XmlElement ret = doc.CreateElement("school");
            ret.SetAttribute("name", this.Name);
            foreach (var t in this.teams) {
                if (t.Key.CompareTo("No Team") != 0) {
                    XmlElement team = doc.CreateElement("team");
                    team.SetAttribute("name", t.Key);
                    ret.AppendChild(team);
                }
            }
            return ret;
        }

        public static Dictionary<string, School> FromXmlNode(XmlDocument doc) {
            Dictionary<string, School> ret = new Dictionary<string, School>();
            XmlNode schools = doc.SelectSingleNode("scholarbowl/schools");
            foreach (XmlNode school in schools.SelectNodes("school")) {
                List<string> teams = new List<string>();
                foreach (XmlNode team in school.SelectNodes("team")) {
                    teams.Add(team.Attributes["name"].Value);
                }
                teams.Add("No Team");
                ret.Add(school.Attributes["name"].Value,
                    new School(school.Attributes["name"].Value, teams.ToArray()));
            }
            return ret;
        }

        public IEnumerable<Player> GetPlayers(IEnumerable<Player> playerList) {
            foreach (Player p in playerList) {
                if (p.Team.School == this) {
                    yield return p;
                }
            }
        }
    }
}
