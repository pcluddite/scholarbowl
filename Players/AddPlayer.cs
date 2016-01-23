using System;
using System.Drawing;
using System.Windows.Forms;

namespace Scholar_Bowl
{
    public partial class AddPlayer : Form
    {
        public AddPlayer()
        {
            InitializeComponent();
        }

        private void AddPlayer_Load(object sender, EventArgs e)
        {
            foreach (var v in MainForm.Schools) {
                schoolBox.Items.Add(v.Key);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string player = playerBox.Text.Trim();
            if (player.Equals("")) {
                toolTip1.ToolTipTitle = "Player Has No Name!";
                toolTip1.Show("You cannot have a player without a name.", playerBox);
            }
            else if (MainForm.Players.ContainsKey(player)) {
                toolTip1.ToolTipTitle = "Player Already Exists!";
                toolTip1.Show("You cannot have two players with the same name.", playerBox);
            }
            else if (schoolBox.SelectedIndex == -1) {
                toolTip1.ToolTipTitle = "No School";
                toolTip1.Show("You must select a school for this player.", schoolBox);
            }
            else {
                School school = MainForm.Schools[schoolBox.SelectedItem.ToString()];
                Team team;
                if (teamBox.SelectedIndex == -1) {
                    team = school.Teams["No Team"];
                }
                else {
                    team = school.Teams[teamBox.SelectedItem.ToString()];
                }
                MainForm.Players.Add(player, new Player(player, team));
                if (sender == saveButton) {
                    playerBox.Text = "";
                    schoolBox.SelectedItem = -1;
                    teamBox.SelectedItem = -1;
                    playerBox.Focus();
                    infoLabel.Show();
                    timer1.Start();
                }
                else {
                    this.Close();
                }
            }
        }

        private void schoolBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            teamBox.Items.Clear();
            if (schoolBox.SelectedIndex == -1) {
                return;
            }
            School school = MainForm.Schools[schoolBox.SelectedItem.ToString()];
            foreach (var v in school.Teams) {
                teamBox.Items.Add(v.Key);
            }
        }

        private void infoLabel_Click(object sender, EventArgs e)
        {
            infoLabel.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            infoLabel.Hide();
            timer1.Stop();
        }
    }
}