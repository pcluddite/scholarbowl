using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace Scholar_Bowl
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// All schools in the league
        /// </summary>
        public static Dictionary<string, School> Schools { get; set; }
        /// <summary>
        /// All players in the league
        /// </summary>
        public static Dictionary<string, Player> Players { get; set; }
        /// <summary>
        /// All matches played in the league
        /// </summary>
        public static MatchList AllMatches { get; set; }

        public PlayerControlList playerList1;
        public PlayerControlList playerList2;

        private Random rand = new Random();

        private Splash splash;

        public MainForm()
        {
            InitializeComponent();
        }

        #region Save/Load
        private void Form1_Load(object sender, EventArgs e)
        {
            splash = new Splash();
            splash.Show();
            backgroundWorker1.RunWorkerAsync();
            /*XmlDocument doc = new XmlDocument();
            if (File.Exists(Application.StartupPath + "\\scholarbowl.dat")) {
                doc.Load(Application.StartupPath + "\\scholarbowl.dat");
            }
            else {
                doc.LoadXml("<scholarbowl><schools></schools><scholars></scholars><matches></matches></scholarbowl>");
            }
            schools = School.distribute(doc);
            players = Player.distribute(doc, schools);
            matches = MatchList.Distribute(doc, schools, players);
            foreach (var v in schools) {
                v.Value.MatchList = matches;
            }

            listView1 = new PlayerControlList(groupBox1);
            listView2 = new PlayerControlList(groupBox2);

            reload();*/
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists(Application.StartupPath + "\\scholarbowl.dat")) {
                File.Move(Application.StartupPath + "\\scholarbowl.dat",
                    Application.StartupPath + "\\Statistics.xml");
            }
            if (File.Exists(Application.StartupPath + "\\Statistics.xml")) {
                doc.Load(Application.StartupPath + "\\Statistics.xml");
            }
            else {
                doc.LoadXml("<scholarbowl><schools></schools><scholars></scholars><matches></matches></scholarbowl>");
            }
            Schools = School.FromXmlNode(doc);
            Players = Player.FromXmlNode(doc, Schools);
            AllMatches = MatchList.FromXml(doc, Schools, Players);

            PlayerControlList listView1 = new PlayerControlList(groupBox1);
            PlayerControlList listView2 = new PlayerControlList(groupBox2);

            BeginInvoke(new MethodInvoker(delegate
            {
                playerList1 = listView1;
                playerList2 = listView2;
                reload();
            }));
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            splash.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml("<scholarbowl><schools></schools><scholars></scholars><matches></matches></scholarbowl>");
                XmlNode nschools = doc.SelectSingleNode("scholarbowl/schools");
                foreach (var s in Schools) {
                    nschools.AppendChild(s.Value.ToXmlNode(doc));
                }
                XmlNode scholars = doc.SelectSingleNode("scholarbowl/scholars");
                foreach (var p in Players) {
                    scholars.AppendChild(p.Value.ToXmlNode(doc));
                }
                XmlNode nmatches = doc.SelectSingleNode("scholarbowl/matches");
                foreach (var m in AllMatches) {
                    nmatches.AppendChild(m.ToXmlNode(doc));
                }
                doc.Save(Application.StartupPath + "\\Statistics.xml");
            }
            catch (Exception ex) {
                if (MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.Cancel) {
                    e.Cancel = true;
                }
            }
        }

        void reload()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            playerList1.Enabled = playerList2.Enabled =
                groupBox1.Enabled = groupBox2.Enabled =
                button5.Enabled = false;
            textBox1.Text = textBox2.Text = "0";
            foreach (var v in Schools) {
                comboBox1.Items.Add(v.Key);
                comboBox4.Items.Add(v.Key);
            }
        }

        void populate(GroupBox groupBox)
        {
            Team team;

            if (groupBox == groupBox1) {
                team = Schools[comboBox1.SelectedItem.ToString()].Teams[comboBox2.SelectedItem.ToString()];
            }
            else {
                team = Schools[comboBox4.SelectedItem.ToString()].Teams[comboBox3.SelectedItem.ToString()];
            }

            IEnumerable<Player> playersInTeam = team.GetPlayers(Players.Values);
            if (groupBox == groupBox1) {
                playerList1.AddPlayers(playersInTeam);
            }
            else {
                playerList2.AddPlayers(playersInTeam);
            }
        }

        #endregion

        #region Format Check

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }

            if ((sender as TextBox).Size.Width == 50 &&
                e.KeyChar == '.' &&
                (sender as TextBox).Text.IndexOf('.') == -1) {
                e.Handled = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1) {
                comboBox2.Items.Clear();
                foreach (var v in Schools[comboBox1.SelectedItem.ToString()].Teams) {
                    comboBox2.Items.Add(v.Key);
                }
            }
            groupBox1.Enabled = playerList1.Enabled = false;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex > -1) {
                comboBox3.Items.Clear();
                foreach (var v in Schools[comboBox4.SelectedItem.ToString()].Teams) {
                    comboBox3.Items.Add(v.Key);
                }
            }
            groupBox2.Enabled = playerList2.Enabled = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedIndex == -1) {
                return;
            }
            if (comboBox == comboBox2) {
                playerList1.Enabled = true;
                populate(groupBox1);
            }
            else {
                playerList2.Enabled = true;
                populate(groupBox2);
            }
            if (comboBox2.SelectedIndex > -1 && comboBox3.SelectedIndex > -1) {
                button5.Enabled = true;
            }
            else {
                button5.Enabled = false;
            }
        }

        private void textBox35_Click(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            ComboBox schoolSelect;
            ComboBox teamSelect;
            PlayerControlList list;
            if (playerList1.HasControl(textBox)) {
                teamSelect = comboBox2;
                schoolSelect = comboBox1;
                list = playerList1;
            }
            else {
                schoolSelect = comboBox4;
                teamSelect = comboBox3;
                list = playerList2;
            }
            if (teamSelect.SelectedIndex == -1) {
                return;
            }
            SelectPlayer sp = new SelectPlayer(Schools[schoolSelect.SelectedItem.ToString()]
                .Teams[teamSelect.SelectedItem.ToString()], this, list.GetFromControl(textBox));
            sp.ShowDialog(this);
        }

        #endregion

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("")) {
                toolTip1.ToolTipTitle = "No Score Has Been Entered!";
                toolTip1.Show("You have not entered a final score for this team.", textBox1);
                textBox1.Focus();
                return;
            }
            if (textBox2.Text.Equals("")) {
                toolTip1.ToolTipTitle = "No Score Has Been Entered!";
                toolTip1.Show("You have not entered a final score for this team.", textBox2);
                textBox2.Focus();
                return;
            }
            decimal score1 = decimal.Parse(textBox1.Text);
            decimal score2 = decimal.Parse(textBox2.Text);
            if (score1 == score2) {
                MessageBox.Show(this, "This match indicates a tie!\r\nOne team must have a higher score than the other.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }
            List<MatchPlayer> team1Players = new List<MatchPlayer>();
            foreach (PlayerControl p in playerList1.Items) {
                if (!p.IsEmpty) {
                    if (!p.CheckInfo(toolTip1)) {
                        return;
                    }
                    team1Players.Add(new MatchPlayer(p.Player, p.Tossups, p.Durration));
                }
            }
            MatchTeam team1 = new MatchTeam(Schools[comboBox1.SelectedItem.ToString()]
                .Teams[comboBox2.SelectedItem.ToString()], score1, team1Players.ToArray());

            List<MatchPlayer> team2Players = new List<MatchPlayer>();
            foreach (PlayerControl p in playerList2.Items) {
                if (!p.IsEmpty) {
                    if (!p.CheckInfo(toolTip1)) {
                        return;
                    }
                    team2Players.Add(new MatchPlayer(p.Player, p.Tossups, p.Durration));
                }
            }
            MatchTeam team2 = new MatchTeam(Schools[comboBox4.SelectedItem.ToString()]
                .Teams[comboBox3.SelectedItem.ToString()], score2, team2Players.ToArray());

            AllMatches.AddMatch(dateTimePicker1.Value, team1, team2);

            label12.Show();
            timer1.Start();
            reload();
        }

        private void setupNewPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddPlayer ap = new AddPlayer(this);
            ap.ShowDialog(this);
        }

        private void setupNewSchoolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSchool addschool = new AddSchool();
            addschool.ShowDialog(this);
            reload();
        }

        private void viewIndividualStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlayerStats ps = new PlayerStats(this);
            ps.ShowDialog(this);
            comboBox2_SelectedIndexChanged(comboBox2, e);
            comboBox2_SelectedIndexChanged(comboBox3, e);
        }

        private void allMatchesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TodaysMatches tm = new TodaysMatches(this);
            tm.ShowDialog(this);
        }

        private void label12_Click(object sender, EventArgs e)
        {
            label12.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label12.Hide();
            timer1.Stop();
        }

        private void viewRankingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TeamRankings tr = new TeamRankings();
            tr.ShowDialog(this);
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (e.KeyCode == Keys.Down) {
                PlayerControl control;
                PlayerControl next;
                if ((control = playerList1.GetFromControl((TextBox)sender)) == null) {
                    control = playerList2.GetFromControl((TextBox)sender);
                    next = playerList2.GetNext(control);
                }
                else {
                    next = playerList1.GetNext(control);
                }

                if (textBox.Size.Width == 51) {
                    next.TossupControl.Select();
                }
                else if (textBox.Size.Width == 50) {
                    next.DurationControl.Select();
                }
                else {
                    next.NameControl.Select();
                }
            }
            else if (e.KeyCode == Keys.Up) {
                PlayerControl control;
                PlayerControl last;
                if ((control = playerList1.GetFromControl((TextBox)sender)) == null) {
                    control = playerList2.GetFromControl((TextBox)sender);
                    last = playerList2.GetLast(control);
                }
                else {
                    last = playerList1.GetLast(control);
                }

                if (textBox.Size.Width == 51) {
                    last.TossupControl.Select();
                }
                else if (textBox.Size.Width == 50) {
                    last.DurationControl.Select();
                }
                else {
                    last.NameControl.Select();
                }
            }
            else if (e.KeyCode == Keys.Enter) {
                if (textBox.Size.Width == 161) {
                    textBox35_Click(sender, e);
                    e.SuppressKeyPress = true;
                }
            }
        }
    }
}
