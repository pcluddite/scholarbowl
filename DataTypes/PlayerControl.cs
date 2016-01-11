using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Scholar_Bowl {
    public class PlayerControl {

        public decimal Tossups {
            get {
                return decimal.Parse(tossupTextBox.Text);
            }
            set {
                tossupTextBox.Text = value.ToString();
            }
        }

        public decimal Durration {
            get {
                return decimal.Parse(durTextBox.Text);
            }
            set {
                durTextBox.Text = value.ToString();
            }
        }

        public Player Player {
            get {
                return player;
            }
            set {
                player = value;
                if (player == null) {
                    this.empty();
                }
                else {
                    nameTextBox.Text = player.Name;
                    nameTextBox.ForeColor = Color.Black;
                    nameTextBox.Font = new Font(nameTextBox.Font, FontStyle.Regular);
                    tossupTextBox.Enabled = durTextBox.Enabled = true;
                }
            }
        }

        public bool Enabled {
            get {
                return enabled;
            }
            set {
                enabled = value;
                nameTextBox.Enabled = 
                    tossupTextBox.Enabled = durTextBox.Enabled = enabled;
                if (enabled) {
                    this.empty();
                }
                else {
                    this.Clear();
                }
            }
        }

        public bool IsEmpty {
            get {
                return (this.Player == null);
            }
        }

        private bool enabled = true;
        private Player player;
        private Control nameTextBox, tossupTextBox, durTextBox;

        public Control NameControl {
            get {
                return nameTextBox;
            }
        }
        public Control TossupControl {
            get {
                return tossupTextBox;
            }
        }
        public Control DurationControl {
            get {
                return durTextBox;
            }
        }

        public PlayerControl(Control name, Control tossups, Control dur) {
            this.nameTextBox = name;
            this.tossupTextBox = tossups;
            this.durTextBox = dur;
        }

        public void Clear() {
            nameTextBox.Text = durTextBox.Text = tossupTextBox.Text = "";
            nameTextBox.ForeColor = Control.DefaultForeColor;
            nameTextBox.BackColor = Control.DefaultBackColor;
        }

        private void empty() {
            this.player = null;
            nameTextBox.Text = "Click to select player...";
            nameTextBox.Font = new Font(nameTextBox.Font, FontStyle.Italic);
            nameTextBox.ForeColor = Color.Gray;
            nameTextBox.BackColor = Color.White;
            tossupTextBox.Text = durTextBox.Text = "";
            tossupTextBox.Enabled = durTextBox.Enabled = false;
        }

        public bool HasControl(Control control) {
            if (nameTextBox == control) {
                return true;
            }
            else if (tossupTextBox == control) {
                return true;
            }
            else if (durTextBox == control) {
                return true;
            }
            else {
                return false;
            }
        }

        public bool CheckInfo(ToolTip toolTip) {
            decimal tossups, dur;
            if (!decimal.TryParse(tossupTextBox.Text, out tossups)) {
                toolTip.ToolTipIcon = ToolTipIcon.Error;
                toolTip.ToolTipTitle = "No Tossups Entered!";
                toolTip.Show("You have not entered any tossups for this player.", tossupTextBox);
                return false;
            }
            if (!decimal.TryParse(durTextBox.Text, out dur)) {
                toolTip.ToolTipIcon = ToolTipIcon.Error;
                toolTip.ToolTipTitle = "No Durration Entered!";
                toolTip.Show("You have not entered the duration for which this player played.", durTextBox);
                return false;
            }
            return true;
        }
    }
}
