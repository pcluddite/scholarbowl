using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scholar_Bowl
{
    /// <summary>
    /// Represents a team
    /// </summary>
    public class Team : IComparable<Team>
    {
        public string Name { get; set; }
        public School School { get; set; }
        
        /// <summary>
        /// Compares this team's wins to another
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Team other)
        {
            decimal avg1 = MainForm.AllMatches.GetAverageWins(this);
            decimal wins1 = MainForm.AllMatches.GetWins(this);
            decimal avg2 = MainForm.AllMatches.GetAverageWins(other);
            decimal wins2 = MainForm.AllMatches.GetWins(other);

            if (wins1 == wins2) {
                if (avg1 > avg2) {
                    return -1;
                }
                else if (avg1 < avg2) {
                    return 1;
                }
                return 0;
            }
            else if (wins1 > wins2) {
                return -1;
            }
            else {
                return 1;
            }
        }

        public Team(School s, string name)
        {
            this.Name = name;
            this.School = s;
        }

        public IEnumerable<Player> GetPlayers(IEnumerable<Player> playerList)
        {            
            foreach (Player p in playerList) {
                if (p.Team == this) {
                    yield return p;
                }
            }
        }
    }
}
