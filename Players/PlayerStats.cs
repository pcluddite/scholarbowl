using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Scholar_Bowl {
    public partial class PlayerStats : Form {
        MainForm main;
        List<ListViewItem> players = new List<ListViewItem>();
        public PlayerStats(MainForm main) {
            this.main = main;
            InitializeComponent();
        }

        private void PlayerStats_Load(object sender, EventArgs e) {
            reload();
            comboBox1.Items.Add("");
            comboBox1.Items.AddRange(MainForm.Schools.Keys.ToArray());
        }

        void reload() {
            listView1.Items.Clear();
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
                    item.SubItems.Add(avg.ToString("0.###").PadLeft(1, '0'));
                }
                else {
                    item.SubItems.Add("--");
                }
                listView1.Items.Add(item);
                players.Add(item);
                lastAvg = avg;
                lastGames = games;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            listView1.Items.Clear();
            foreach (ListViewItem p in players) {
                if (p.SubItems[1].Text.ToLower().Contains(textBox1.Text.ToLower())) {
                    listView1.Items.Add(p);
                }
            }
            comboBox1.SelectedIndex = comboBox2.SelectedIndex = -1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            comboBox2.Items.Clear();
            if (comboBox1.SelectedIndex > 0) {
                textBox1.Text = "";
                comboBox2.Items.Add("");
                comboBox2.Items.AddRange(MainForm.Schools[comboBox1.SelectedItem.ToString()].Teams.Keys.ToArray());
            }
            listView1.Items.Clear();
            foreach (ListViewItem p in players) {
                if (p.SubItems[2].Text.StartsWith(comboBox1.SelectedItem.ToString())) {
                    listView1.Items.Add(p);
                }
            }
        }

        void listViewAdd(string[] p) {
            ListViewItem item = new ListViewItem(p[0]);
            item.SubItems.Add(p[1]);
            item.SubItems.Add(p[2]);
            item.SubItems.Add(p[3]);
            item.SubItems.Add(p[4]);
            item.SubItems.Add(p[5]);
            listView1.Items.Add(item);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) {
            if (comboBox2.SelectedIndex < 0) {
                return;
            }
            listView1.Items.Clear();
            foreach (ListViewItem p in players) {
                if (p.SubItems[2].Text.StartsWith(comboBox1.SelectedItem.ToString()) && 
                    p.SubItems[2].Text.EndsWith(comboBox2.SelectedItem.ToString())) {
                        listView1.Items.Add(p);
                }
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e) {
            if (listView1.SelectedItems.Count == 1) {
                ViewPlayer vp = new ViewPlayer(
                    MainForm.Players[listView1.SelectedItems[0].SubItems[1].Text],
                    main);
                vp.ShowDialog(this);
                reload();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
            List<Player> players = null;
            Invoke(new MethodInvoker(delegate { players = MainForm.Players.Values.ToList(); }));
            ExcelGenerator.AllPlayers(players);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            groupBox1.Enabled = groupBox2.Enabled =
                listView1.Enabled = button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e) {
            groupBox1.Enabled = groupBox2.Enabled =
                listView1.Enabled = button1.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e) {
            button2.Enabled = 
                button3.Enabled = (listView1.SelectedItems.Count == 1);
        }

        private void button3_Click(object sender, EventArgs e) {
            if (!listView1.SelectedItems[0].SubItems[4].Text.Equals("0")) {
                MessageBox.Show(this, "This player has already participated in some games and cannot be removed from the roster.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (MessageBox.Show(this, "Are you sure you want to remove this player from the roster?", this.Text,
             MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes) {
                MainForm.Players.Remove(listView1.SelectedItems[0].SubItems[1].Text);
                reload();
            }
        }
    }
}
