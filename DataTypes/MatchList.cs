using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Scholar_Bowl {
    /// <summary>
    /// Represents a list of matches
    /// </summary>
    public class MatchList : ICollection<Match> {
        /// <summary>
        /// All matches played in the league
        /// </summary>
        public static MatchList AllMatches { get; set; }

        private List<Match> matches;

        public MatchList(List<Match> matches) {
            this.matches = matches;
        }

        /// <summary>
        /// Gets all matches taken place on a given date
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public IEnumerable<Match> GetOnDate(DateTime dt) {
            foreach (Match m in matches) {
                if (m.Date.Date == dt.Date.Date) {
                    yield return m;
                }
            }
        }


        /// <summary>
        /// Gets all matches played by a player
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public IEnumerable<Match> GetMatchesPlayed(Player player) {

            foreach (Match match in this.matches) {
                if (match.DidPlay(player)) {
                    yield return match;
                }
            }

        }

        /// <summary>
        /// Gets all matches played by a team
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public IEnumerable<Match> GetMatchesPlayed(Team t)
        {
            foreach (Match match in matches) {
                if (match.DidPlay(t)) {
                    yield return match;
                }
            }
        }

        /// <summary>
        /// Gets the tossups and duration for each date
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public Dictionary<DateTime, decimal[]> GetForEachDate(Player player) {
            Dictionary<DateTime, decimal[]> ret = new Dictionary<DateTime, decimal[]>();
            List<Match> matchesPlayed = this.GetMatchesPlayed(player).ToList();
            matchesPlayed.Sort((a, b) => a.Date.CompareTo(b.Date));
            foreach (Match match in matchesPlayed) {
                DateTime current = match.Date.Date;
                if (!ret.ContainsKey(current)) {
                    ret.Add(current, new decimal[] { 0, 0 });
                }
                ret[current][0] += match.GetTossups(player);
                ret[current][1] += match.GetDuration(player);
            }

            return ret;
        }

        /// <summary>
        /// Gets the number of tossups a player received on a given date
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public decimal GetTossupsOnDate(DateTime dt, Player p) {
            decimal ret = 0;
            foreach (Match m in GetOnDate(dt)) {
                ret += m.GetTossups(p);
            }
            return ret;
        }

        /// <summary>
        /// Gets the total number of tossups a player has been awarded
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public decimal GetTotalTossups(Player p) {
            decimal ret = 0;
            foreach (Match m in matches) {
                ret += m.GetTossups(p);
            }
            return ret;
        }

        /// <summary>
        /// Gets the total number of games a player has played
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public decimal GetGamesPlayed(Player p) {
            decimal ret = 0;
            foreach (Match m in matches) {
                ret += m.GetDuration(p);
            }
            return ret;
        }

        /// <summary>
        /// Gets the total number of games a team has played
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int GetGamesPlayed(Team t)
        {
            int ret = 0;
            foreach (Match m in matches) {
                if (m.DidPlay(t)) {
                    ++ret;
                }
            }
            return ret;
        }


        public decimal GetAverage(Player p)
        {
            decimal g = GetGamesPlayed(p);
            if (g == 0) {
                return -1;
            }
            else {
                return GetTotalTossups(p) / g;
            }
        }

        /// <summary>
        /// Gets the average number of wins per game, or -1 if no games played
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public decimal GetAverageWins(Team t)
        {
            decimal w = GetWins(t);
            decimal l = GetLosses(t);
            if ((w + l) == 0) {
                return -1;
            }
            else {
                return w / (w + l);
            }
        }

        /// <summary>
        /// Gets the average number of wins per game, or -1 if no games played
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public decimal GetAverageLosses(Team t)
        {
            decimal w = GetWins(t);
            decimal l = GetLosses(t);
            if ((w + l) == 0) {
                return -1;
            }
            else {
                return l / (w + l);
            }
        }

        /// <summary>
        /// Gets the number of wins for a given team
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public decimal GetWins(Team t) {
            decimal ret = 0;
            foreach (Match m in matches) {
                if (m.Winner.School.Name.Equals(t.School.Name) &&
                    m.Winner.Name.Equals(t.Name)) {
                    ret++;
                }
            }
            return ret;
        }

        /// <summary>
        /// Gets the total number of losses from a team
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public decimal GetLosses(Team t) {
            decimal ret = 0;
            foreach (Match m in matches) {
                if (m.Loser.School.Name.Equals(t.School.Name) &&
                    m.Loser.Name.Equals(t.Name)) {
                    ret++;
                }
            }
            return ret;
        }

        /// <summary>
        /// Gets all matches played by a player
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public IEnumerable<Match> GetMatches(Player p)
        {
            foreach (Match m in matches) {
                if (m.DidPlay(p)) {
                    yield return m;
                }
            }
        }

        public IEnumerator<Match> GetEnumerator() {
            return matches.GetEnumerator();
        }

        public void Sort(Comparison<Match> comparator) {
            matches.Sort(comparator);
        }

        /// <summary>
        /// Gets the date of the first match
        /// </summary>
        /// <returns></returns>
        public DateTime GetFirstDate() {
            if (matches.Count > 0) {
                return matches[0].Date;
            }
            else {
                return DateTime.Now;
            }
        }

        /// <summary>
        /// Gets the date of the last match
        /// </summary>
        /// <returns></returns>
        public DateTime GetLastDate() {
            if (matches.Count > 0) {
                return matches[matches.Count - 1].Date;
            }
            else {
                return DateTime.Now;
            }
        }

        /// <summary>
        /// Removes a match from the list
        /// </summary>
        /// <param name="m"></param>
        public void RemoveMatch(Match m) {
            List<Match> newList = new List<Match>();
            foreach (Match match in this) {
                if (match.ID != m.ID) {
                    newList.Add(match);
                }
            }
            this.matches = newList;
        }

        static Random rand = new Random();

        public static MatchList FromXml(XmlDocument doc, Dictionary<string, School> schools, Dictionary<string, Player> players) {
            List<Match> matches = new List<Match>();
            XmlNode nMatches = doc.SelectSingleNode("scholarbowl/matches");
            foreach (XmlNode nMatch in nMatches) {
                List<MatchTeam> teams = new List<MatchTeam>();
                foreach (XmlNode nTeam in nMatch.SelectNodes("team")) {
                    School school = schools[nTeam.Attributes["school"].Value];
                    Team team = school.Teams[nTeam.Attributes["team"].Value];
                    List<MatchPlayer> mplayers = new List<MatchPlayer>();
                    foreach (XmlNode nPlayer in nTeam.SelectNodes("player")) {
                        mplayers.Add(new MatchPlayer(
                            players[nPlayer.Attributes["name"].Value],
                            decimal.Parse(nPlayer.Attributes["tossups"].Value),
                            decimal.Parse(nPlayer.Attributes["dur"].Value)));
                    }
                    teams.Add(
                        new MatchTeam(team,
                            decimal.Parse(nTeam.Attributes["score"].Value),
                            mplayers.ToArray()));
                }
                matches = AddMatch(
                    DateTime.Parse(nMatch.Attributes["date"].Value),
                    teams[0], teams[1], matches);
            }
            return new MatchList(matches);
        }

        /// <summary>
        /// Adds a match to a list (assigning it a unique id)
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="team1"></param>
        /// <param name="team2"></param>
        /// <param name="matches"></param>
        /// <returns></returns>
        static List<Match> AddMatch(DateTime dt, MatchTeam team1, MatchTeam team2, List<Match> matches) {
            int id;
            while (MatchExists(id = rand.Next(), matches)) ;
            matches.Add(new Match(id, dt, team1, team2));
            return matches;
        }

        public static bool MatchExists(int matchID, List<Match> matches) {
            foreach (Match m in matches) {
                if (m.ID == matchID) {
                    return true;
                }
            }
            return false;
        }

        public void AddMatch(DateTime dt, MatchTeam team1, MatchTeam team2) {
            int id;
            while (this.MatchExists(id = rand.Next())) ;
            matches.Add(new Match(id, dt, team1, team2));
        }

        public bool MatchExists(int matchID) {
            foreach (Match m in matches) {
                if (m.ID == matchID) {
                    return true;
                }
            }
            return false;
        }

        public void Add(Match item)
        {
            matches.Add(item);
        }

        public void Clear()
        {
            matches.Clear();
        }

        public bool Contains(Match item)
        {
            return matches.Contains(item);
        }

        public void CopyTo(Match[] array, int arrayIndex)
        {
            matches.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return matches.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(Match item)
        {
            return matches.Remove(item);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return matches.GetEnumerator();
        }
    }
}
