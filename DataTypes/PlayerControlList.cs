using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Scholar_Bowl {
    public class PlayerControlList {
        public List<PlayerControl> Items { get { return items; } }

        private List<PlayerControl> items;

        private GroupBox gb;

        public PlayerControlList(GroupBox gb) {
            this.gb = gb;
            items = new List<PlayerControl>();
            Control playerBox = null, tossupBox = null, durBox = null;
            int build = 0;
            int tabIndex = gb.Controls.Count - 1;
            foreach (Control c in gb.Controls) {
                if (c.Size.Width == 161) {
                    playerBox = c;
                    build++;
                }
                if (c.Size.Width == 51) {
                    tossupBox = c;
                    build++;
                }
                if (c.Size.Width == 50) {
                    durBox = c;
                    build++;
                }
                if (build == 3) {
                    build = 0;
                    items.Add(new PlayerControl(playerBox, tossupBox, durBox));
                }
                c.TabIndex = tabIndex--;
            }
            items.Reverse();
        }

        public bool Enabled {
            get {
                return gb.Enabled;
            }
            set {
                gb.Enabled = value;
                foreach (PlayerControl pc in this.items) {
                    pc.Enabled = gb.Enabled;
                }
            }
        }

        public IEnumerable<PlayerControl> GetEnumermator() {
            return this.items;
        }

        public bool HasControl(Control control) {
            foreach (PlayerControl pc in this.items) {
                if (pc.HasControl(control)) {
                    return true;
                }
            }
            return false;
        }

        public PlayerControl GetNext(PlayerControl control) {
            for (int i = 0; i < items.Count; i++) {
                if (items[i] == control) {
                    if (i + 1 < items.Count) {
                        return items[i + 1];
                    }
                    else if (items.Count > -1) {
                        return items[0];
                    }
                    else {
                        break;
                    }
                }
            }
            return null;
        }

        public PlayerControl GetLast(PlayerControl control) {
            for (int i = 0; i < items.Count; i++) {
                if (items[i] == control) {
                    if (i > 0) {
                        return items[i - 1];
                    }
                    else if (items.Count > 1) {
                        return items[items.Count - 1];
                    }
                    else {
                        break;
                    }
                }
            }
            return null;
        }

        public void AddPlayers(IEnumerable<Player> players) {
            int i = 0;
            foreach (Player p in players) {
                this.items[i].Enabled = true;
                this.items[i].Player = p;
                this.items[i].Tossups = 0;
                this.items[i].Durration = 1;
                ++i;
            }
        }

        public Player[] GetPlayers() {
            List<Player> players = new List<Player>();

            foreach (PlayerControl pc in items) {
                if (!pc.IsEmpty) {
                    players.Add(pc.Player);
                }
            }

            return players.ToArray();
        }

        public PlayerControl GetFromControl(Control control) {
            foreach (PlayerControl pc in items) {
                if (pc.HasControl(control)) {
                    return pc;
                }
            }
            return null;
        }
    }
}
