using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Scholar_Bowl {
    public partial class ViewPlayer : Form {

        MainForm main;
        Player player;
        Dictionary<ListViewItem, Match> matches = new Dictionary<ListViewItem, Match>();

        public ViewPlayer(Player p, MainForm main) {
            this.main = main;
            this.player = p;
            InitializeComponent();
        }

        private void ViewPlayer_Load(object sender, EventArgs e) {
            textBox1.Text = player.Name;
            textBox8.Text = player.Team.School.Name;
            comboBox2.Items.AddRange(player.Team.School.Teams.Keys.ToArray());
            comboBox2.SelectedItem = player.Team.Name;
            textBox2.Text = MainForm.AllMatches.GetTotalTossups(player).ToString();
            textBox3.Text = MainForm.AllMatches.GetGamesPlayed(player).ToString();
            decimal avg = MainForm.AllMatches.GetAverage(player);
            if (avg > -1) {
                textBox4.Text = avg.ToString("#.###").PadLeft(1, '0');
            }
            else {
                textBox4.Text = "--";
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
                listView1.Items.Add(item);
            }
            textBox5.Text = wins.ToString();
            textBox6.Text = losses.ToString();
            if ((wins + losses) > 0) {
                textBox7.Text = (wins * 100 / (wins + losses)).ToString("#.##").PadLeft(1, '0') + "%";
            }
            else {
                textBox7.Text = "--";
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            groupBox1.Enabled = groupBox2.Enabled = groupBox3.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
            Player player = null;
            Invoke(new MethodInvoker(delegate { player = this.player; }));
            ExcelGenerator.ThisPlayer(player);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            groupBox1.Enabled = groupBox2.Enabled = groupBox3.Enabled = true;
        }

        private void listView1_DoubleClick(object sender, EventArgs e) {
            if (listView1.SelectedItems.Count == 1) {
                MatchEditor me = new MatchEditor(this.main, matches[listView1.SelectedItems[0]],
                                                 MainForm.Players.Values.ToArray());
                me.ShowDialog(this);
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            string playerName = textBox1.Text.Trim();
            if (MainForm.Players.ContainsKey(playerName) && !player.Name.Equals(playerName)) {
                toolTip1.ToolTipTitle = "Player Already Exists!";
                toolTip1.Show("You cannot have two players with the same name.", textBox1);
            }
            else {
                string team;
                if (comboBox2.SelectedIndex > -1) {
                    team = comboBox2.SelectedItem.ToString();
                }
                else {
                    team = "No Team";
                }
                this.player.Name = textBox1.Text;
                this.player.Team = MainForm.Schools[textBox8.Text].Teams[team];
                Dictionary<string, Player> players = new Dictionary<string, Player>();
                foreach (Player p in MainForm.Players.Values) {
                    players.Add(p.Name, p);
                }
                MainForm.Players = players;
                this.Close();
            }
            
        }
    }
}
