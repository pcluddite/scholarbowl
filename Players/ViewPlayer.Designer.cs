namespace Scholar_Bowl {
    partial class ViewPlayer {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.playerBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.schoolBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.teamBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.excelButton = new System.Windows.Forms.Button();
            this.winpctBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lossesBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.winsBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.avgBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gamesBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tossupBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.matchListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.excelWorker = new System.ComponentModel.BackgroundWorker();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // playerBox
            // 
            this.playerBox.Location = new System.Drawing.Point(91, 31);
            this.playerBox.Name = "playerBox";
            this.playerBox.Size = new System.Drawing.Size(194, 20);
            this.playerBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Player Name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.schoolBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.teamBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.playerBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 131);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General";
            // 
            // schoolBox
            // 
            this.schoolBox.Location = new System.Drawing.Point(91, 57);
            this.schoolBox.Name = "schoolBox";
            this.schoolBox.ReadOnly = true;
            this.schoolBox.Size = new System.Drawing.Size(194, 20);
            this.schoolBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Team:";
            // 
            // teamBox
            // 
            this.teamBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.teamBox.FormattingEnabled = true;
            this.teamBox.Location = new System.Drawing.Point(91, 84);
            this.teamBox.Name = "teamBox";
            this.teamBox.Size = new System.Drawing.Size(87, 21);
            this.teamBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "School:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.excelButton);
            this.groupBox2.Controls.Add(this.winpctBox);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.lossesBox);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.winsBox);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.avgBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.gamesBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tossupBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(318, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(300, 131);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Statistics";
            // 
            // excelButton
            // 
            this.excelButton.Location = new System.Drawing.Point(85, 97);
            this.excelButton.Name = "excelButton";
            this.excelButton.Size = new System.Drawing.Size(140, 23);
            this.excelButton.TabIndex = 5;
            this.excelButton.Text = "Create Detailed Report";
            this.excelButton.UseVisualStyleBackColor = true;
            this.excelButton.Click += new System.EventHandler(this.excelButton_Click);
            // 
            // winpctBox
            // 
            this.winpctBox.Location = new System.Drawing.Point(226, 71);
            this.winpctBox.Name = "winpctBox";
            this.winpctBox.ReadOnly = true;
            this.winpctBox.Size = new System.Drawing.Size(59, 20);
            this.winpctBox.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(180, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "% Win:";
            // 
            // lossesBox
            // 
            this.lossesBox.Location = new System.Drawing.Point(226, 45);
            this.lossesBox.Name = "lossesBox";
            this.lossesBox.ReadOnly = true;
            this.lossesBox.Size = new System.Drawing.Size(59, 20);
            this.lossesBox.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(177, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Losses:";
            // 
            // winsBox
            // 
            this.winsBox.Location = new System.Drawing.Point(226, 19);
            this.winsBox.Name = "winsBox";
            this.winsBox.ReadOnly = true;
            this.winsBox.Size = new System.Drawing.Size(59, 20);
            this.winsBox.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(186, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Wins:";
            // 
            // avgBox
            // 
            this.avgBox.Location = new System.Drawing.Point(102, 71);
            this.avgBox.Name = "avgBox";
            this.avgBox.ReadOnly = true;
            this.avgBox.Size = new System.Drawing.Size(59, 20);
            this.avgBox.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Tossups/Game:";
            // 
            // gamesBox
            // 
            this.gamesBox.Location = new System.Drawing.Point(102, 45);
            this.gamesBox.Name = "gamesBox";
            this.gamesBox.ReadOnly = true;
            this.gamesBox.Size = new System.Drawing.Size(59, 20);
            this.gamesBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Games Played:";
            // 
            // tossupBox
            // 
            this.tossupBox.Location = new System.Drawing.Point(102, 19);
            this.tossupBox.Name = "tossupBox";
            this.tossupBox.ReadOnly = true;
            this.tossupBox.Size = new System.Drawing.Size(59, 20);
            this.tossupBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Total Tossups:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.matchListView);
            this.groupBox3.Location = new System.Drawing.Point(12, 149);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(606, 205);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Matches";
            // 
            // matchListView
            // 
            this.matchListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.matchListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.matchListView.FullRowSelect = true;
            this.matchListView.GridLines = true;
            this.matchListView.Location = new System.Drawing.Point(12, 19);
            this.matchListView.Name = "matchListView";
            this.matchListView.Size = new System.Drawing.Size(579, 169);
            this.matchListView.TabIndex = 0;
            this.matchListView.UseCompatibleStateImageBehavior = false;
            this.matchListView.View = System.Windows.Forms.View.Details;
            this.matchListView.DoubleClick += new System.EventHandler(this.matchListView_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Date";
            this.columnHeader1.Width = 109;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Opponent";
            this.columnHeader2.Width = 260;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tossups";
            this.columnHeader3.Width = 69;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Duration";
            this.columnHeader4.Width = 70;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "W/L";
            // 
            // excelWorker
            // 
            this.excelWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.excelWorker_DoWork);
            this.excelWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.excelWorker_RunWorkerCompleted);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(543, 360);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "&Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(462, 360);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Ca&ncel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Error;
            // 
            // ViewPlayer
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 393);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ViewPlayer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Player Statistics";
            this.Load += new System.EventHandler(this.ViewPlayer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox playerBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox teamBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox avgBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox gamesBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tossupBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox lossesBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox winsBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button excelButton;
        private System.Windows.Forms.TextBox winpctBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView matchListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.ComponentModel.BackgroundWorker excelWorker;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox schoolBox;
    }
}