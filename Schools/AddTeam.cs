using System;
using System.Windows.Forms;

namespace Scholar_Bowl
{
    public partial class AddTeam : Form {

        AddSchool parent;

        public AddTeam(AddSchool parent) {
            this.parent = parent;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (textBox1.Text.Trim().Equals("")) {
                toolTip1.ToolTipTitle = "No Team Name!";
                toolTip1.Show("You cannot add a team without a name.", textBox1);
            }
            else if (parent.teams.Contains(textBox1.Text.Trim())) {
                toolTip1.ToolTipTitle = "Team Already Exists!";
                toolTip1.Show("You cannot add two teams with the same name.", textBox1);
            }
            else {
                this.parent.teams.Add(textBox1.Text.Trim());
                this.parent.listView1.Items.Add(textBox1.Text.Trim());
                this.Close();
            }
        }
    }
}
