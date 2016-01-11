using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Scholar_Bowl {
    public partial class SelectPlayer : Form {

        MainForm main;
        School school;
        Dictionary<string, Player> players = new Dictionary<string, Player>();
        PlayerControl pc;

        public SelectPlayer(Team team, MainForm main, PlayerControl textBox) {
            this.pc = textBox;
            this.main = main;
            this.school = team.School;
            InitializeComponent();
        }

        private void SelectPlayer_Load(object sender, EventArgs e) {
            foreach (Player p in school.GetPlayers(MainForm.Players.Values)) {
                players.Add(p.Name, p);
                addListView(p);
            }
            textBox1.Select();
        }

        private void button2_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (listView1.SelectedItems.Count == 1) {
                pc.Player = players[listView1.SelectedItems[0].Text];
                pc.Tossups = 0;
                pc.Durration = 1;
                this.Close();
            }
            else {
                toolTip1.ToolTipTitle = "No Player Selected";
                toolTip1.Show("You haven't selected a player yet!", listView1);
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (e.Button == System.Windows.Forms.MouseButtons.Left) {
                button1_Click(sender, e);
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            pc.Player = null;
            this.Close();
        }

        void addListView(Player p) {
            ListViewItem item = new ListViewItem(p.Name);
            item.SubItems.Add(MatchList.AllMatches.GetTotalTossups(p).ToString());
            item.SubItems.Add(MatchList.AllMatches.GetGamesPlayed(p).ToString());
            listView1.Items.Add(item);
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            this.listView1.Items.Clear();
            foreach (var v in this.players) {
                if (v.Key.ToLower().Contains(textBox1.Text.ToLower())) {
                    addListView(v.Value);
                }
            }
            if (listView1.Items.Count == 1) {
                listView1.Items[0].Selected = true;
            }
        }

        private void SelectPlayer_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                this.Close();
            }
        }
    }
}
