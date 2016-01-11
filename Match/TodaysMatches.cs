using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Scholar_Bowl {
    public partial class TodaysMatches : Form {

        MainForm main;
        Dictionary<ListViewItem, Match> matches = new Dictionary<ListViewItem, Match>();

        public TodaysMatches(MainForm main) {
            this.main = main;
            InitializeComponent();
        }

        private void TodaysMatches_Load(object sender, EventArgs e) {
            reload();
        }

        void reload() {
            listView1.Items.Clear();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox1.Items.Add("");
            comboBox2.Items.Add("");
            comboBox3.Items.Add("");
            comboBox4.Items.Add("");
            MatchList.AllMatches.Sort((a, b) => b.Date.CompareTo(a.Date));
            dateTimePicker2.Value = MatchList.AllMatches.GetFirstDate();
            dateTimePicker1.Value = MatchList.AllMatches.GetLastDate();
            comboBox1.Items.AddRange(MainForm.Schools.Keys.ToArray());
            comboBox4.Items.AddRange(MainForm.Schools.Keys.ToArray());
            foreach (Match m in MatchList.AllMatches) {
                addMatchToList(m);
            }
        }

        void addMatchToList(Match m) {
            ListViewItem item = new ListViewItem();
            item.Name = m.ID.ToString();
            item.Text = m.Date.ToShortDateString();
            item.SubItems.Add(m.FirstTeam.School.Name + " - " + m.FirstTeam.Name);
            item.SubItems.Add(m.SecondTeam.School.Name + " - " + m.SecondTeam.Name);
            item.SubItems.Add(m.Winner.School.Name + " - " + m.Winner.Name);
            item.SubItems.Add(m.FirstTeam.Score + "-" + m.SecondTeam.Score);
            listView1.Items.Add(item);
            matches.Add(item, m);
        }

        void comboBoxClear(ComboBox comboBox) {
            comboBox.Items.Clear();
            comboBox.Items.Add("");
        }

        private void listView1_DoubleClick(object sender, EventArgs e) {
            if (listView1.SelectedItems.Count == 1) {
                MatchEditor me = new MatchEditor(this.main, matches[listView1.SelectedItems[0]], MainForm.Players.Values.ToArray());
                me.ShowDialog(this);
                reload();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            ComboBox cbox = (ComboBox)sender;
            if (cbox == comboBox1) {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("");
                if (cbox.SelectedIndex > 0) {
                    comboBox2.Items.AddRange(
                        MainForm.Schools[cbox.SelectedItem.ToString()].Teams.Keys.ToArray());
                }
            }
            else if (cbox == comboBox4) {
                comboBox3.Items.Clear();
                comboBox3.Items.Add("");
                if (cbox.SelectedIndex > 0) {
                    comboBox3.Items.AddRange(
                        MainForm.Schools[cbox.SelectedItem.ToString()].Teams.Keys.ToArray());
                }
            }
            reloadListBox();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) {
            if (dateTimePicker1.Value.CompareTo(dateTimePicker2.Value) > 0) {
                toolTip1.ToolTipTitle = "Dates do not overlap";
                toolTip1.Show("This date cannot take place after the second date.", dateTimePicker1);
            }
            reloadListBox();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e) {
            if (dateTimePicker2.Value.CompareTo(dateTimePicker1.Value) < 0) {
                toolTip1.ToolTipTitle = "Dates do not overlap";
                toolTip1.Show("This date cannot take place before the first date.", dateTimePicker2);
            }
            reloadListBox();
        }

        void reloadListBox() {
            listView1.Items.Clear();
            if (comboBox1.SelectedIndex == -1) {
                comboBox1.SelectedIndex = 0;
            }
            if (comboBox4.SelectedIndex == -1) {
                comboBox4.SelectedIndex = 0;
            }
            if (comboBox2.SelectedIndex == -1) {
                comboBox2.SelectedIndex = 0;
            }
            if (comboBox3.SelectedIndex == -1) {
                comboBox3.SelectedIndex = 0;
            }
            foreach (var m in matches) {
                if (m.Value.Date.CompareTo(dateTimePicker1.Value) >= 0 && m.Value.Date.CompareTo(dateTimePicker2.Value) <= 0) {
                    if (
                        // Check Left Side if it contains first school and team
                        ((m.Value.FirstTeam.School.Name.StartsWith(comboBox1.SelectedItem.ToString()) &&
                        m.Value.FirstTeam.Name.EndsWith(comboBox2.SelectedItem.ToString())) &&
                        // Check Right Side if it contains second school and team
                        (m.Value.SecondTeam.School.Name.StartsWith(comboBox4.SelectedItem.ToString()) && 
                        m.Value.SecondTeam.Name.EndsWith(comboBox3.SelectedItem.ToString())))
                        ||
                        // Check Right Side if it contains first school and team
                        ((m.Value.SecondTeam.School.Name.StartsWith(comboBox1.SelectedItem.ToString()) &&
                        m.Value.SecondTeam.Name.EndsWith(comboBox2.SelectedItem.ToString())) &&
                        // Check Left Side if it contains second school and team
                        (m.Value.FirstTeam.School.Name.StartsWith(comboBox4.SelectedItem.ToString()) &&
                        m.Value.FirstTeam.Name.EndsWith(comboBox3.SelectedItem.ToString())))
                        )
                    {
                        if (!listView1.Items.ContainsKey(m.Key.Name)) {
                            listView1.Items.Add(m.Key);
                        }
                    }
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e) {
            button1.Enabled = button2.Enabled = (listView1.SelectedItems.Count == 1);
        }

        private void button1_Click(object sender, EventArgs e) {
            listView1_DoubleClick(sender, e);
        }

        private void button2_Click(object sender, EventArgs e) {
            if (listView1.SelectedItems.Count == 1 && MessageBox.Show(this,
                "Are you sure you want to remove this match?\r\n(THIS CANNOT BE UNDONE!)", this.Text,
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes) {
                    Match matchToRemove = matches[listView1.SelectedItems[0]];
                    MatchList.AllMatches.RemoveMatch(matchToRemove);
                    matches.Remove(listView1.SelectedItems[0]);
                    reloadListBox();
            }
        }
    }
}
