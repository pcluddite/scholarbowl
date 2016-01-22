using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Scholar_Bowl
{
    public partial class PlayerStats : Form
    {
        MainForm main;
        List<ListViewItem> players = new List<ListViewItem>();
        public PlayerStats(MainForm main)
        {
            this.main = main;
            InitializeComponent();
        }

        private void PlayerStats_Load(object sender, EventArgs e)
        {
            reload();
            schoolBox.Items.Add("");
            schoolBox.Items.AddRange(MainForm.Schools.Keys.ToArray());
        }

        private void reload()
        {
            playerListView.Items.Clear();
            players.Clear();

            List<Player> rankedPlayers = MainForm.Players.Values.ToList();
            rankedPlayers.Sort((a, b) => a.CompareTo(b));
            int rank = 0;
            decimal lastAvg = -2;
            decimal lastGames = -2;
            foreach (Player p in rankedPlayers) {
                decimal avg = MainForm.AllMatches.GetAverage(p);
                decimal games = MainForm.AllMatches.GetGamesPlayed(p);
                if (avg != lastAvg) {
                    rank++;
                }
                else {
                    if (lastGames > games) {
                        rank++;
                    }
                }
                ListViewItem item = new ListViewItem(rank.ToString());
                item.SubItems.Add(p.Name);
                item.SubItems.Add(p.Team.School.Name + " - " + p.Team.Name);
                item.SubItems.Add(MainForm.AllMatches.GetTotalTossups(p).ToString());
                item.SubItems.Add(games.ToString());
                if (avg > -1) {
                    item.SubItems.Add(avg.ToString("0.###"));
                }
                else {
                    item.SubItems.Add("--");
                }
                playerListView.Items.Add(item);
                players.Add(item);
                lastAvg = avg;
                lastGames = games;
            }
        }

        private void playerNameBox_TextChanged(object sender, EventArgs e)
        {
            playerListView.Items.Clear();
            foreach (ListViewItem p in players) {
                if (p.SubItems[1].Text.ToLower().Contains(playerNameBox.Text.ToLower())) {
                    playerListView.Items.Add(p);
                }
            }
            schoolBox.SelectedIndex = teamBox.SelectedIndex = -1;
        }

        private void schoolBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            teamBox.Items.Clear();
            if (schoolBox.SelectedIndex > 0) {
                playerNameBox.Text = "";
                teamBox.Items.Add("");
                teamBox.Items.AddRange(MainForm.Schools[schoolBox.SelectedItem.ToString()].Teams.Keys.ToArray());
            }
            playerListView.Items.Clear();
            foreach (ListViewItem p in players) {
                if (p.SubItems[2].Text.StartsWith(schoolBox.SelectedItem.ToString())) {
                    playerListView.Items.Add(p);
                }
            }
        }

        private void listViewAdd(string[] p)
        {
            ListViewItem item = new ListViewItem(p[0]);
            item.SubItems.Add(p[1]);
            item.SubItems.Add(p[2]);
            item.SubItems.Add(p[3]);
            item.SubItems.Add(p[4]);
            item.SubItems.Add(p[5]);
            playerListView.Items.Add(item);
        }

        private void teamBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (teamBox.SelectedIndex < 0) {
                return;
            }
            playerListView.Items.Clear();
            foreach (ListViewItem p in players) {
                if (p.SubItems[2].Text.StartsWith(schoolBox.SelectedItem.ToString()) &&
                    p.SubItems[2].Text.EndsWith(teamBox.SelectedItem.ToString())) {
                    playerListView.Items.Add(p);
                }
            }
        }

        private void playerListView_DoubleClick(object sender, EventArgs e)
        {
            if (playerListView.SelectedItems.Count == 1) {
                ViewPlayer vp = new ViewPlayer(MainForm.Players[playerListView.SelectedItems[0].SubItems[1].Text]);
                vp.ShowDialog(this);
                reload();
            }
        }

        private void excelWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ExcelGenerator.AllPlayers((List<Player>)e.Argument);
        }

        private void excelWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            playerGroupBox.Enabled = schoolGroupBox.Enabled =
                playerListView.Enabled = excelButton.Enabled = true;
        }

        private void excelButton_Click(object sender, EventArgs e)
        {
            playerGroupBox.Enabled = schoolGroupBox.Enabled =
                playerListView.Enabled = excelButton.Enabled = false;
            excelWorker.RunWorkerAsync(MainForm.Players.Values.ToList());
        }

        private void playerListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsButton.Enabled =
                removeButton.Enabled = (playerListView.SelectedItems.Count == 1);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (!playerListView.SelectedItems[0].SubItems[4].Text.Equals("0")) {
                MessageBox.Show(this, "This player has already participated in some games and cannot be removed from the roster.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (MessageBox.Show(this, "Are you sure you want to remove this player from the roster?", Text,
             MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                MainForm.Players.Remove(playerListView.SelectedItems[0].SubItems[1].Text);
                reload();
            }
        }
    }
}
