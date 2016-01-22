using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Scholar_Bowl
{
    public partial class AddSchool : Form
    {
        public List<string> teams = new List<string>();

        public AddSchool()
        {
            InitializeComponent();
        }

        private void AddSchool_Load(object sender, EventArgs e)
        {
            teams.Add("No Team");
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddTeam at = new AddTeam(this);
            at.ShowDialog(this);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string school = schoolBox.Text.Trim();
            if (MainForm.Schools.ContainsKey(school)) {
                toolTip1.ToolTipTitle = "School Already Exists!";
                toolTip1.Show("You cannot have two schools with the same name.", schoolBox);
            }
            else if (school.Equals("")) {
                toolTip1.ToolTipTitle = "School Has No Name!";
                toolTip1.Show("You must choose a name for the school.", schoolBox);
            }
            else {
                teams.Remove("No Team");
                teams.Add("No Team");
                MainForm.Schools.Add(school, new School(school, teams.ToArray()));
                if (sender == saveFinishButton) {
                    this.Close();
                }
                else {
                    teamListView.Items.Clear();
                    schoolBox.Text = "";
                    schoolBox.Focus();
                }
            }
        }
    }
}
