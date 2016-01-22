using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Scholar_Bowl
{
    public partial class ViewPlayer : Form
    {
        private Player player;
        private Dictionary<ListViewItem, Match> matches = new Dictionary<ListViewItem, Match>();

        public ViewPlayer(Player p)
        {
            player = p;
            InitializeComponent();
        }

        private void ViewPlayer_Load(object sender, EventArgs e)
        {
            playerBox.Text = player.Name;
            schoolBox.Text = player.Team.School.Name;
            teamBox.Items.AddRange(player.Team.School.Teams.Keys.ToArray());
            teamBox.SelectedItem = player.Team.Name;
            tossupBox.Text = MainForm.AllMatches.GetTotalTossups(player).ToString();
            gamesBox.Text = MainForm.AllMatches.GetGamesPlayed(player).ToString();
            decimal avg = MainForm.AllMatches.GetAverage(player);
            if (avg > -1) {
                avgBox.Text = avg.ToString("0.###");
            }
            else {
                avgBox.Text = "--";
            }
            decimal wins = 0, losses = 0;
            foreach (Match match in MainForm.AllMatches.GetMatches(player)) {
                MatchPlayer mPlayer = match.GetPlayer(player);
                MatchTeam opponent = match.GetOppenent(player);
                string result;
                if (match.Winner.Players.ToList().Contains(mPlayer)) {
                    result = "W";
                    wins++;
                }
                else {
                    result = "L";
                    losses++;
                }
                ListViewItem item = new ListViewItem();
                item.Text = match.Date.ToShortDateString();
                item.SubItems.Add(opponent.Team.School.Name + " - " + opponent.Name);
                item.SubItems.Add(mPlayer.Tossups.ToString());
                item.SubItems.Add(mPlayer.Duration.ToString());
                item.SubItems.Add(result);
                matches.Add(item, match);
                matchListView.Items.Add(item);
            }
            winsBox.Text = wins.ToString();
            lossesBox.Text = losses.ToString();
            if ((wins + losses) > 0) {
                winpctBox.Text = (wins * 100 / (wins + losses)).ToString("0.##") + "%";
            }
            else {
                winpctBox.Text = "--";
            }
        }

        private void excelButton_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = groupBox2.Enabled = groupBox3.Enabled = false;
            excelWorker.RunWorkerAsync(player);
        }

        private void excelWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ExcelGenerator.ThisPlayer((Player)e.Argument);
        }

        private void excelWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            groupBox1.Enabled = groupBox2.Enabled = groupBox3.Enabled = true;
        }

        private void matchListView_DoubleClick(object sender, EventArgs e)
        {
            if (matchListView.SelectedItems.Count == 1) {
                MatchEditor me = new MatchEditor(matches[matchListView.SelectedItems[0]],
                                                 MainForm.Players.Values.ToArray());
                me.ShowDialog(this);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string playerName = playerBox.Text.Trim();
            if (!player.Name.Equals(playerName) && MainForm.Players.ContainsKey(playerName)) {
                toolTip1.ToolTipTitle = "Player Already Exists!";
                toolTip1.Show("You cannot have two players with the same name.", playerBox);
            }
            else {
                string team;
                if (teamBox.SelectedIndex > -1) {
                    team = teamBox.SelectedItem.ToString();
                }
                else {
                    team = "No Team";
                }
                player.Name = playerBox.Text;
                player.Team = MainForm.Schools[schoolBox.Text].Teams[team];
                Dictionary<string, Player> players = new Dictionary<string, Player>();
                foreach (Player p in MainForm.Players.Values) {
                    players.Add(p.Name, p);
                }
                MainForm.Players = players;
                Close();
            }
        }
    }
}
