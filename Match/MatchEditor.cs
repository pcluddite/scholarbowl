using System;
using System.Linq;
using System.Windows.Forms;

namespace Scholar_Bowl
{
    public partial class MatchEditor : Form
    {

        Match thisMatch;
        Player[] players;
        Match oldMatch;

        public MatchEditor(Match m, Player[] playerList)
        {
            this.oldMatch = m;
            this.thisMatch = m.Clone();
            this.players = playerList;
            InitializeComponent();
        }

        private void MatchEditor_Load(object sender, EventArgs e)
        {
            #region Load Team 1
            scoreBox1.Text = thisMatch.FirstTeam.Score.ToString();
            schoolBox1.Text = thisMatch.FirstTeam.School.Name;
            teamBox1.Items.AddRange(thisMatch.FirstTeam.School.Teams.Keys.ToArray());
            teamBox1.SelectedItem = thisMatch.FirstTeam.Team.Name;
            foreach (MatchPlayer player in thisMatch.FirstTeam.Players) {
                ListViewItem item = new ListViewItem();
                item.Text = player.Name;
                item.SubItems.Add(player.Tossups.ToString());
                item.SubItems.Add(player.Duration.ToString());
                playerListView1.Items.Add(item);
            }
            #endregion

            #region Load Team 2
            scoreBox2.Text = thisMatch.SecondTeam.Score.ToString();
            schoolBox2.Text = thisMatch.SecondTeam.School.Name;
            teamBox2.Items.AddRange(thisMatch.SecondTeam.School.Teams.Keys.ToArray());
            teamBox2.SelectedItem = thisMatch.SecondTeam.Team.Name;
            foreach (MatchPlayer player in thisMatch.SecondTeam.Players) {
                ListViewItem item = new ListViewItem();
                item.Text = player.Name;
                item.SubItems.Add(player.Tossups.ToString());
                item.SubItems.Add(player.Duration.ToString());
                playerListView2.Items.Add(item);
            }
            #endregion

            foreach (Player player in thisMatch.FirstTeam.School.GetPlayers(players)) {
                playerBox1.Items.Add(player.Name);
            }
            foreach (Player player in thisMatch.SecondTeam.School.GetPlayers(players)) {
                playerBox2.Items.Add(player.Name);
            }
            this.matchDatePicker.Value = thisMatch.Date;
        }

        private void playerListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (playerListView1.SelectedItems.Count == 1) {
                playerBox1.SelectedItem = playerListView1.SelectedItems[0].Text;
                tossupBox1.Text = playerListView1.SelectedItems[0].SubItems[1].Text;
                durationBox1.Text = playerListView1.SelectedItems[0].SubItems[2].Text;
            }
        }

        private void playerListView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (playerListView2.SelectedItems.Count == 1) {
                playerBox2.SelectedItem = playerListView2.SelectedItems[0].Text;
                tossupBox2.Text = playerListView2.SelectedItems[0].SubItems[1].Text;
                durationBox2.Text = playerListView2.SelectedItems[0].SubItems[2].Text;
            }
        }

        private void playerBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox playerSelect = (ComboBox)sender;
            TextBox tossupBox;
            TextBox durBox;
            Button addButton;
            Button removeButton;
            MatchTeam team;

            if (playerSelect == playerBox1) {
                tossupBox = tossupBox1;
                durBox = durationBox1;
                addButton = addPlayerButton1;
                removeButton = removePlayerButton1;
                team = this.thisMatch.FirstTeam;
            }
            else {
                tossupBox = tossupBox2;
                durBox = durationBox2;
                addButton = addPlayerButton2;
                removeButton = removePlayerButton2;
                team = this.thisMatch.SecondTeam;
            }

            foreach (MatchPlayer mp in team.Players) {
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

        private void removePlayerButton_Click(object sender, EventArgs e)
        {
            ListView listView;
            ComboBox comboBox;
            Button addButton;
            Button delButton;
            MatchTeam team;
            if ((delButton = removePlayerButton1) == (Button)sender) {
                addButton = addPlayerButton1;
                listView = playerListView1;
                comboBox = playerBox1;
                team = this.thisMatch.FirstTeam;
            }
            else {
                delButton = removePlayerButton2;
                addButton = addPlayerButton2;
                listView = playerListView2;
                comboBox = playerBox2;
                team = this.thisMatch.SecondTeam;
            }

            if (comboBox.SelectedIndex > -1 && MessageBox.Show(this,
                "Are you sure you want to remove this player?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                DialogResult.Yes) {
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

        private void addPlayerButton_Click(object sender, EventArgs e)
        {
            Button addButton = (Button)sender;
            ComboBox playerSelect;
            TextBox tossupBox;
            TextBox durBox;
            ListView listView;
            Button removeButton;
            MatchTeam team;
            if (addButton == addPlayerButton1) {
                playerSelect = playerBox1;
                tossupBox = tossupBox1;
                durBox = durationBox1;
                listView = playerListView1;
                team = this.thisMatch.FirstTeam;
                removeButton = removePlayerButton1;
            }
            else {
                playerSelect = playerBox2;
                tossupBox = tossupBox2;
                durBox = durationBox2;
                listView = playerListView2;
                team = this.thisMatch.SecondTeam;
                removeButton = removePlayerButton2;
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

        private void numericOnlyTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
            if ((sender as TextBox).Size.Width == 53 && // a really sneaky (and terrible) way to tell if it's a duration box
                e.KeyChar == '.' &&
                (sender as TextBox).Text.IndexOf('.') == -1) {
                e.Handled = false;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (scoreBox1.Text.Equals("")) {
                toolTip1.ToolTipTitle = "No Final Score!";
                toolTip1.Show("This team must have a final score.", scoreBox1);
                scoreBox1.Focus();
                return;
            }
            if (scoreBox2.Text.Equals("")) {
                toolTip1.ToolTipTitle = "No Final Score!";
                toolTip1.Show("This team must have a final score.", scoreBox2);
                scoreBox2.Focus();
                return;
            }
            decimal score1 = decimal.Parse(scoreBox1.Text);
            decimal score2 = decimal.Parse(scoreBox2.Text);
            if (score1 == score2) {
                MessageBox.Show(this, "This match indicates a tie!\r\nOne team must have a higher score than the other.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                scoreBox1.Focus();
                return;
            }
            MainForm.AllMatches.RemoveMatch(oldMatch);
            this.thisMatch.FirstTeam.Score = score1;
            this.thisMatch.SecondTeam.Score = score2;
            this.thisMatch.FirstTeam.Team = this.thisMatch.FirstTeam.School.Teams[this.teamBox1.SelectedItem.ToString()];
            this.thisMatch.SecondTeam.Team = this.thisMatch.SecondTeam.School.Teams[this.teamBox2.SelectedItem.ToString()];
            this.thisMatch.Date = matchDatePicker.Value;
            MainForm.AllMatches.Add(thisMatch);
            this.Close();
        }
    }
}
