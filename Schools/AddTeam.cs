using System;
using System.Windows.Forms;

namespace Scholar_Bowl
{
    public partial class AddTeam : Form
    {
        private AddSchool schoolform;
        private EditSchool editorForm;

        public AddTeam(AddSchool schoolform)
        {
            this.schoolform = schoolform;
            InitializeComponent();
        }

        public AddTeam(EditSchool editorForm)
        {
            this.editorForm = editorForm;
            InitializeComponent();
        }


        private void addButton_Click(object sender, EventArgs e)
        {
            if (teamBox.Text.Equals("")) {
                toolTip1.ToolTipTitle = "No Team Name!";
                toolTip1.Show("You cannot add a team without a name.", teamBox);
            }
            else {
                if (schoolform == null) {
                    if (editorForm.school.Teams.ContainsKey(teamBox.Text)) {
                        ShowDuplicateError();
                        return;
                    }
                    else {
                        Team team = new Team(editorForm.school, teamBox.Text);
                        editorForm.school.Teams.Add(team.Name, team);
                        editorForm.AddTeamToList(team);
                    }
                }
                else {
                    if (schoolform.teams.Contains(teamBox.Text)) {
                        ShowDuplicateError();
                        return;
                    }
                    else {
                        schoolform.teams.Add(teamBox.Text.Trim());
                        schoolform.teamListView.Items.Add(teamBox.Text.Trim());
                    }
                }
                Close();
            }
        }

        private void ShowDuplicateError()
        {
            toolTip1.ToolTipTitle = "Team Already Exists!";
            toolTip1.Show("You cannot add two teams with the same name.", teamBox);
        }
    }
}
