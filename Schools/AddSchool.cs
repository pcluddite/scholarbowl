using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Scholar_Bowl {
    public partial class AddSchool : Form {

        MainForm main;
        public List<string> teams;

        public AddSchool(MainForm main) {
            this.main = main;
            teams = new List<string>();
            teams.Add("No Team");
            InitializeComponent();
        }

        private void AddSchool_Load(object sender, EventArgs e) {
            
        }

        private void button1_Click(object sender, EventArgs e) {
            AddTeam at = new AddTeam(this);
            at.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e) {
            string school = textBox1.Text.Trim();
            if (MainForm.Schools.ContainsKey(school)) {
                toolTip1.ToolTipTitle = "School Already Exists!";
                toolTip1.Show("You cannot have two schools with the same name.", textBox1);
            }
            else if (school.CompareTo("") == 0) {
                toolTip1.ToolTipTitle = "School Has No Name!";
                toolTip1.Show("You must choose a name for the school.", textBox1);
            }
            else {
                teams.Remove("No Team");
                teams.Add("No Team");
                MainForm.Schools.Add(school, new School(school, teams.ToArray()));
                if ((sender as Button) == button3) {
                    this.Close();
                }
                else {
                    listView1.Items.Clear();
                    textBox1.Text = "";
                    textBox1.Focus();
                }
            }
        }
    }
}
