using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Scholar_Bowl {
    public partial class AddPlayer : Form {
        MainForm main;
        public AddPlayer(MainForm form) {
            this.main = form;
            InitializeComponent();
            this.Size = new Size(this.Size.Width, 127);
        }

        private void AddPlayer_Load(object sender, EventArgs e) {
            foreach (var v in MainForm.Schools) {
                comboBox1.Items.Add(v.Key);
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            string player = textBox1.Text.Trim();
            if (player.CompareTo("") == 0) {
                toolTip1.ToolTipTitle = "Player Has No Name!";
                toolTip1.Show("You cannot have a player without a name.", textBox1);
            }
            else if (MainForm.Players.ContainsKey(player)) {
                toolTip1.ToolTipTitle = "Player Already Exists!";
                toolTip1.Show("You cannot have two players with the same name.", textBox1);
            }
            else if (comboBox1.SelectedIndex == -1) {
                toolTip1.ToolTipTitle = "No School";
                toolTip1.Show("You must select a school for this player.", comboBox1);
            }
            else {
                School school = MainForm.Schools[comboBox1.SelectedItem.ToString()];
                Team team;
                if (comboBox2.SelectedIndex == -1) {
                    team = school.Teams["No Team"];
                }
                else {
                    team = school.Teams[comboBox2.SelectedItem.ToString()];
                }
                MainForm.Players.Add(player, new Player(player, team));
                if ((sender as Button) == button1) {
                    textBox1.Text = "";
                    comboBox1.SelectedItem = -1;
                    comboBox2.SelectedItem = -1;
                    textBox1.Focus();
                    label3.Show();
                    timer1.Start();
                }
                else {
                    this.Close();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            comboBox2.Items.Clear();
            if (comboBox1.SelectedIndex == -1) {
                return;
            }
            School school = MainForm.Schools[comboBox1.SelectedItem.ToString()];
            foreach (var v in school.Teams) {
                comboBox2.Items.Add(v.Key);
            }
        }

        private void label3_Click(object sender, EventArgs e) {
            label3.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            label3.Hide();
            timer1.Stop();
        }
    }
}
