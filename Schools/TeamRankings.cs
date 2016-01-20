using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Scholar_Bowl {
    public partial class TeamRankings : Form {
        MainForm main;
        //List<ListViewItem> teams = new List<ListViewItem>();
        
        Dictionary<ListViewItem, Team> teams = new Dictionary<ListViewItem, Team>();
        public TeamRankings(MainForm main) {
            this.main = main;
            InitializeComponent();
        }

        private void TeamRankings_Load(object sender, EventArgs e) {
            reload();
        }

        void reload() {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            listView1.Items.Clear();
            List<Team> rankedTeams = new List<Team>();
            button2.Enabled = false;
            comboBox1.Items.Add("");
            foreach (School school in MainForm.Schools.Values) {
                foreach (Team team in school.Teams.Values) {
                    rankedTeams.Add(team);
                }
                comboBox1.Items.Add(school.Name);
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
                listView1.Items.Add(item);
                teams.Add(item, t);
                lastAvg = avg;
                lastGames = games;
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            groupBox2.Enabled =
                listView1.Enabled = button1.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
            List<Team> teams = null;
            Invoke(new MethodInvoker(delegate { teams = this.teams.Values.ToList(); }));
            ExcelGenerator.AllTeams(teams);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            groupBox2.Enabled =
                listView1.Enabled = button1.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            comboBox2.Items.Clear();
            if (comboBox1.SelectedIndex > 0) {
                comboBox2.Items.Add("");
                comboBox2.Items.AddRange(
                    MainForm.Schools[comboBox1.SelectedItem.ToString()].Teams.Keys.ToArray());
            }
            listView1.Items.Clear();
            foreach (ListViewItem team in teams.Keys) {
                if (team.SubItems[1].Text.Equals(comboBox1.SelectedItem.ToString())) {
                    listView1.Items.Add(team);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) {
            if (comboBox2.SelectedIndex < 0) {
                comboBox2.SelectedIndex = 0;
            }
            listView1.Items.Clear();
            foreach (ListViewItem team in teams.Keys) {
                if (team.SubItems[1].Text.Equals(comboBox1.SelectedItem.ToString()) && (
                    team.SubItems[2].Text.Equals(comboBox2.SelectedItem.ToString()) ||
                    comboBox2.SelectedItem.ToString().Equals(""))) {
                    listView1.Items.Add(team);
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e) {
            button2.Enabled = (listView1.SelectedItems.Count == 1);
        }

        private void button2_Click(object sender, EventArgs e) {
            if (listView1.SelectedItems.Count == 1 && MessageBox.Show(this,
                "Are you sure you want to remove this team?\r\n(THIS CANNOT BE UNDONE!)", this.Text,
                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes) {
                foreach (var t in teams) {
                    if (t.Key == listView1.SelectedItems[0]) {
                        if (MainForm.AllMatches.GetGamesPlayed(t.Value) == 0) {
                            t.Value.School.Teams.Remove(t.Value.Name);
                            if (t.Value.School.Teams.Count == 1 &&
                                MessageBox.Show(this, "The team has been removed, but this is the last team in the school. Do you want to remove the school completely?",
                                    this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) {
                                MainForm.Schools.Remove(listView1.SelectedItems[0].SubItems[1].Text);
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

