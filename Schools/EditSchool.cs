using System;
using System.Text;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Scholar_Bowl
{
    public partial class EditSchool : Form
    {
        private Dictionary<ListViewItem, Team> teams = new Dictionary<ListViewItem, Team>();
        public School school;

        public EditSchool(School school)
        {
            this.school = school;
            InitializeComponent();
        }

        private void EditSchool_Load(object sender, EventArgs e)
        {
            schoolBox.Text = school.Name;
            foreach(Team t in school.Teams.Values) {
                AddTeamToList(t);
            }
        }

        public void AddTeamToList(Team t)
        {
            ListViewItem teamItem = new ListViewItem(t.Name);
            teamItem.SubItems.Add(MainForm.AllMatches.GetWins(t).ToString());
            teamItem.SubItems.Add(MainForm.AllMatches.GetLosses(t).ToString());
            decimal avg = MainForm.AllMatches.GetAverageWins(t);
            if (avg == -1) {
                teamItem.SubItems.Add("--");
            }
            else {
                teamItem.SubItems.Add(avg.ToString("0.##") + '%');
            }
            teamListView.Items.Add(teamItem);
            teams.Add(teamItem, t);
        }

        private void teamListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (teamListView.SelectedItems.Count != 1) {
                removeButton.Enabled = false;
                return;
            }
            removeButton.Enabled = true;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddTeam addTeam = new AddTeam(this);
            addTeam.ShowDialog(this);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (!teamListView.SelectedItems[0].SubItems[3].Text.Equals("--")) {
                MessageBox.Show(this, "This team has already participated in some games. It cannot be removed.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
                Team selected = teams[teamListView.SelectedItems[0]];
                teams.Remove(teamListView.SelectedItems[0]);
                teamListView.Items.Remove(teamListView.SelectedItems[0]);
                school.Teams.Remove(selected.Name);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!schoolBox.Text.Equals(school.Name) && MainForm.Schools.ContainsKey(schoolBox.Text)) {
                toolTip1.ToolTipTitle = "School Already Exists";
                toolTip1.Show("A school with this name already exists.", schoolBox);
            }
            else {
                MainForm.Schools.Remove(school.Name);
                school.Name = schoolBox.Text;
                MainForm.Schools.Add(school.Name, school);
                Close();
            }
        }
    }
}