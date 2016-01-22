using System;
using System.Windows.Forms;

namespace Scholar_Bowl
{
    public partial class AddTeam : Form
    {
        private AddSchool schoolform;

        public AddTeam(AddSchool schoolform)
        {
            this.schoolform = schoolform;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Equals("")) {
                toolTip1.ToolTipTitle = "No Team Name!";
                toolTip1.Show("You cannot add a team without a name.", textBox1);
            }
            else if (schoolform.teams.Contains(textBox1.Text.Trim())) {
                toolTip1.ToolTipTitle = "Team Already Exists!";
                toolTip1.Show("You cannot add two teams with the same name.", textBox1);
            }
            else {
                schoolform.teams.Add(textBox1.Text.Trim());
                schoolform.teamListView.Items.Add(textBox1.Text.Trim());
                Close();
            }
        }
    }
}
