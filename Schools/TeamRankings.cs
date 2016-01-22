using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Scholar_Bowl
{
    public partial class TeamRankings : Form
    {
        private Dictionary<ListViewItem, Team> teams = new Dictionary<ListViewItem, Team>();

        public TeamRankings()
        {
            InitializeComponent();
        }

        private void TeamRankings_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void reload()
        {
            schoolBox.Items.Clear();
            teamBox.Items.Clear();
            teamListView.Items.Clear();
            List<Team> rankedTeams = new List<Team>();
            removeButton.Enabled = false;
            schoolBox.Items.Add("");
            foreach (School school in MainForm.Schools.Values) {
                foreach (Team team in school.Teams.Values) {
                    rankedTeams.Add(team);
                }
                schoolBox.Items.Add(school.Name);
            }
            rankedTeams.Sort((a, b) => a.CompareTo(b));
            int rank = 0;
            decimal lastAvg = -2;
            decimal lastGames = -2;
            foreach (Team t in rankedTeams) {
                decimal avg = MainForm.AllMatches.GetAverageWins(t);
                decimal wins = MainForm.AllMatches.GetWins(t);
                decimal losses = MainForm.AllMatches.GetLosses(t);
                decimal games = wins + losses;
                if (avg != lastAvg) {
                    rank++;
                }
                else {
                    if (lastGames > games) {
                        rank++;
                    }
                }
                ListViewItem item = new ListViewItem(rank.ToString());
                item.SubItems.Add(t.School.Name);
                item.SubItems.Add(t.Name);
                item.SubItems.Add(wins.ToString());
                item.SubItems.Add(losses.ToString());
                if (avg > -1) {
                    item.SubItems.Add((avg * 100).ToString("#.##").PadLeft(1, '0') + "%");
                }
                else {
                    item.SubItems.Add("--");
                }
                teamListView.Items.Add(item);
                teams.Add(item, t);
                lastAvg = avg;
                lastGames = games;
            }
        }

        private void excelButton_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled =
                teamListView.Enabled = excelButton.Enabled = false;
            excelWorker.RunWorkerAsync(teams.Values.ToList());
        }

        private void excelWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ExcelGenerator.AllTeams((List<Team>)e.Argument);
        }

        private void excelWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            groupBox2.Enabled =
                teamListView.Enabled = excelButton.Enabled = true;
        }

        private void schoolBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            teamBox.Items.Clear();
            if (schoolBox.SelectedIndex > 0) {
                teamBox.Items.Add("");
                teamBox.Items.AddRange(
                    MainForm.Schools[schoolBox.SelectedItem.ToString()].Teams.Keys.ToArray());
            }
            teamListView.Items.Clear();
            foreach (ListViewItem team in teams.Keys) {
                if (team.SubItems[1].Text.Equals(schoolBox.SelectedItem.ToString())) {
                    teamListView.Items.Add(team);
                }
            }
        }

        private void teamBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (teamBox.SelectedIndex < 0) {
                teamBox.SelectedIndex = 0;
            }
            teamListView.Items.Clear();
            foreach (ListViewItem team in teams.Keys) {
                if (team.SubItems[1].Text.Equals(schoolBox.SelectedItem.ToString()) && (
                    team.SubItems[2].Text.Equals(teamBox.SelectedItem.ToString()) ||
                    teamBox.SelectedItem.ToString().Equals(""))) {
                    teamListView.Items.Add(team);
                }
            }
        }

        private void teamListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            removeButton.Enabled = (teamListView.SelectedItems.Count == 1);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (teamListView.SelectedItems.Count == 1 && MessageBox.Show(this,
                "Are you sure you want to remove this team?\r\n(THIS CANNOT BE UNDONE!)", this.Text,
                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes) {
                foreach (var t in teams) {
                    if (t.Key == teamListView.SelectedItems[0]) {
                        if (MainForm.AllMatches.GetGamesPlayed(t.Value) == 0) {
                            t.Value.School.Teams.Remove(t.Value.Name);
                            if (t.Value.School.Teams.Count == 1 &&
                                MessageBox.Show(this, "The team has been removed, but this is the last team in the school. Do you want to remove the school completely?",
                                    this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) {
                                MainForm.Schools.Remove(teamListView.SelectedItems[0].SubItems[1].Text);
                            }
                        }
                        else {
                            MessageBox.Show(this, "You cannot remove this team because it has already participated in some matches.",
                                this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        reload();
                        break;
                    }
                }
            }
        }
    }
}

