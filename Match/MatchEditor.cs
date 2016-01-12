using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Scholar_Bowl {
    public partial class MatchEditor : Form {
        
        Match thisMatch;
        Player[] players;
        Match oldMatch;
        MainForm main;
        public MatchEditor(MainForm form, Match m, Player[] playerList) {
            this.main = form;
            this.oldMatch = m;
            this.thisMatch = m.Clone();
            this.players = playerList;
            InitializeComponent();
        }

        private void MatchEditor_Load(object sender, EventArgs e) {
            #region Load Team 1
            textBox5.Text = thisMatch.FirstTeam.Score.ToString();
            textBox7.Text = thisMatch.FirstTeam.School.Name;
            comboBox1.Items.AddRange(thisMatch.FirstTeam.School.Teams.Keys.ToArray());
            comboBox1.SelectedItem = thisMatch.FirstTeam.Team.Name;
            foreach (MatchPlayer player in thisMatch.FirstTeam.Players) {
                ListViewItem item = new ListViewItem();
                item.Text = player.Name;
                item.SubItems.Add(player.Tossups.ToString());
                item.SubItems.Add(player.Duration.ToString());
                listView1.Items.Add(item);
            }
            #endregion

            #region Load Team 2
            textBox3.Text = thisMatch.SecondTeam.Score.ToString();
            textBox8.Text = thisMatch.SecondTeam.School.Name;
            comboBox2.Items.AddRange(thisMatch.SecondTeam.School.Teams.Keys.ToArray());
            comboBox2.SelectedItem = thisMatch.SecondTeam.Team.Name;
            foreach (MatchPlayer player in thisMatch.SecondTeam.Players) {
                ListViewItem item = new ListViewItem();
                item.Text = player.Name;
                item.SubItems.Add(player.Tossups.ToString());
                item.SubItems.Add(player.Duration.ToString());
                listView2.Items.Add(item);
            }
            #endregion

            foreach (Player player in thisMatch.FirstTeam.School.GetPlayers(players)) {
                comboBox3.Items.Add(player.Name);
            }
            foreach (Player player in thisMatch.SecondTeam.School.GetPlayers(players)) {
                comboBox4.Items.Add(player.Name);
            }
            this.dateTimePicker1.Value = thisMatch.Date;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e) {
            ListView listView = (ListView)sender;
            if (listView == listView1 && listView1.SelectedItems.Count == 1) {
                comboBox3.SelectedItem = listView1.SelectedItems[0].Text;
                textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
                textBox2.Text = listView1.SelectedItems[0].SubItems[2].Text;
            }
            else if (listView == listView2 && listView2.SelectedItems.Count == 1) {
                comboBox4.SelectedItem = listView2.SelectedItems[0].Text;
                textBox6.Text = listView2.SelectedItems[0].SubItems[1].Text;
                textBox4.Text = listView2.SelectedItems[0].SubItems[2].Text;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) {
            ComboBox playerSelect = (ComboBox)sender;
            TextBox tossupBox;
            TextBox durBox;
            Button addButton;
            Button removeButton;
            MatchTeam team;

            if (playerSelect == comboBox3) {
                tossupBox = textBox1;
                durBox = textBox2;
                addButton = button1;
                removeButton = button2;
                team = this.thisMatch.FirstTeam;
            }
            else {
                tossupBox = textBox6;
                durBox = textBox4;
                addButton = button4;
                removeButton = button3;
                team = this.thisMatch.SecondTeam;
            }

            foreach(MatchPlayer mp in team.Players) {
                if (playerSelect.SelectedItem.ToString().Equals(mp.Name)) {
                    tossupBox.Text = mp.Tossups.ToString();
                    durBox.Text = mp.Duration.ToString();
                    addButton.Text = "Set Player";
                    removeButton.Enabled = true;
                    return;
                }
            }
            tossupBox.Text = "0";
            durBox.Text = "1";
            addButton.Text = "Add Player";
            removeButton.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e) {
            ListView listView;
            ComboBox comboBox;
            Button addButton;
            Button delButton;
            MatchTeam team;
            if ((delButton = button2) == (Button)sender) {
                addButton = button1;
                listView = listView1;
                comboBox = comboBox3;
                team = this.thisMatch.FirstTeam;
            }
            else {
                delButton = button3;
                addButton = button4;
                listView = listView2;
                comboBox = comboBox4;
                team = this.thisMatch.SecondTeam;
            }

            if (comboBox.SelectedIndex > -1 && MessageBox.Show(this,
                "Are you sure you want to remove this player?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                System.Windows.Forms.DialogResult.Yes) {
                team.RemovePlayer(comboBox.SelectedItem.ToString());
                listView.Items.Clear();
                foreach (MatchPlayer player in team.Players) {
                    ListViewItem item = new ListViewItem();
                    item.Text = player.Name;
                    item.SubItems.Add(player.Tossups.ToString());
                    item.SubItems.Add(player.Duration.ToString());
                    listView.Items.Add(item);
                }
                addButton.Text = "Add Player";
                delButton.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            Button addButton = (Button)sender;
            ComboBox playerSelect;
            TextBox tossupBox;
            TextBox durBox;
            ListView listView;
            Button removeButton;
            MatchTeam team;
            if (addButton == button1) {
                playerSelect = comboBox3;
                tossupBox = textBox1;
                durBox = textBox2;
                listView = listView1;
                team = this.thisMatch.FirstTeam;
                removeButton = button2;
            }
            else {
                playerSelect = comboBox4;
                tossupBox = textBox6;
                durBox = textBox4;
                listView = listView2;
                team = this.thisMatch.SecondTeam;
                removeButton = button3;
            }

            if (playerSelect.SelectedIndex == -1) {
                toolTip1.ToolTipTitle = "No Player Selected!";
                toolTip1.Show("You have selected a player for these statistics to be applied.", playerSelect);
                return;
            }
            if (tossupBox.Text.Equals("")) {
                toolTip1.ToolTipTitle = "No Tossups Entered!";
                toolTip1.Show("You have not entered any tossups for this player.", tossupBox);
                return;
            }
            if (durBox.Text.Equals("")) {
                toolTip1.ToolTipTitle = "No Durration Entered!";
                toolTip1.Show("You have not entered the duration for which this player played.", durBox);
                return;
            }
            MatchPlayer player;
            if ((player = team.FindPlayer(playerSelect.SelectedItem.ToString())) == null) {
                player = new MatchPlayer(
                    MainForm.Players[playerSelect.SelectedItem.ToString()],
                    decimal.Parse(tossupBox.Text),
                    decimal.Parse(durBox.Text));
                team.AddPlayer(player);
                ListViewItem item = new ListViewItem();
                item.Text = player.Name;
                item.SubItems.Add(player.Tossups.ToString());
                item.SubItems.Add(player.Duration.ToString());
                listView.Items.Add(item);
                addButton.Text = "Set Player";
                removeButton.Enabled = true;
            }
            else {
                player.Tossups = decimal.Parse(tossupBox.Text);
                player.Duration = decimal.Parse(durBox.Text);
                foreach (ListViewItem item in listView.Items) {
                    if (item.Text.Equals(player.Name)) {
                        item.SubItems[1].Text = player.Tossups.ToString();
                        item.SubItems[2].Text = player.Duration.ToString();
                    }
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
            if ((sender as TextBox).Size.Width == 53 &&
                e.KeyChar == '.' &&
                (sender as TextBox).Text.IndexOf('.') == -1) {
                e.Handled = false;
            }
        }

        private void button6_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e) {
            if (textBox5.Text.Equals("")) {
                toolTip1.ToolTipTitle = "No Final Score!";
                toolTip1.Show("This team must have a final score.", textBox5);
                textBox5.Focus();
                return;
            }
            if (textBox3.Text.Equals("")) {
                toolTip1.ToolTipTitle = "No Final Score!";
                toolTip1.Show("This team must have a final score.", textBox3);
                textBox3.Focus();
                return;
            }
            decimal score1 = decimal.Parse(textBox5.Text);
            decimal score2 = decimal.Parse(textBox3.Text);
            if (score1 == score2) {
                MessageBox.Show(this, "This match indicates a tie!\r\nOne team must have a higher score than the other.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox5.Focus();
                return;
            }
            MatchList.AllMatches.RemoveMatch(oldMatch);
            this.thisMatch.FirstTeam.Score = score1;
            this.thisMatch.SecondTeam.Score = score2;
            this.thisMatch.FirstTeam.Team = this.thisMatch.FirstTeam.School.Teams[this.comboBox1.SelectedItem.ToString()];
            this.thisMatch.SecondTeam.Team = this.thisMatch.SecondTeam.School.Teams[this.comboBox2.SelectedItem.ToString()];
            this.thisMatch.Date = dateTimePicker1.Value;
            MatchList.AllMatches.Add(thisMatch);
            this.Close();
        }
    }
}
