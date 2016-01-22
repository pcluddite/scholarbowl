namespace Scholar_Bowl {
    partial class TeamRankings {
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.teamBox = new System.Windows.Forms.ComboBox();
            this.schoolBox = new System.Windows.Forms.ComboBox();
            this.teamListView = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.excelButton = new System.Windows.Forms.Button();
            this.excelWorker = new System.ComponentModel.BackgroundWorker();
            this.removeButton = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.teamBox);
            this.groupBox2.Controls.Add(this.schoolBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(313, 54);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Find School and Team";
            // 
            // teamBox
            // 
            this.teamBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.teamBox.FormattingEnabled = true;
            this.teamBox.Location = new System.Drawing.Point(209, 19);
            this.teamBox.Name = "teamBox";
            this.teamBox.Size = new System.Drawing.Size(93, 21);
            this.teamBox.TabIndex = 1;
            this.teamBox.SelectedIndexChanged += new System.EventHandler(this.teamBox_SelectedIndexChanged);
            // 
            // schoolBox
            // 
            this.schoolBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.schoolBox.FormattingEnabled = true;
            this.schoolBox.Location = new System.Drawing.Point(6, 19);
            this.schoolBox.Name = "schoolBox";
            this.schoolBox.Size = new System.Drawing.Size(197, 21);
            this.schoolBox.TabIndex = 0;
            this.schoolBox.SelectedIndexChanged += new System.EventHandler(this.schoolBox_SelectedIndexChanged);
            // 
            // teamListView
            // 
            this.teamListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.teamListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader8,
            this.columnHeader1,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.teamListView.FullRowSelect = true;
            this.teamListView.GridLines = true;
            this.teamListView.Location = new System.Drawing.Point(12, 72);
            this.teamListView.Name = "teamListView";
            this.teamListView.Size = new System.Drawing.Size(621, 479);
            this.teamListView.TabIndex = 4;
            this.teamListView.UseCompatibleStateImageBehavior = false;
            this.teamListView.View = System.Windows.Forms.View.Details;
            this.teamListView.SelectedIndexChanged += new System.EventHandler(this.teamListView_SelectedIndexChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Rank";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "School";
            this.columnHeader8.Width = 213;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Team";
            this.columnHeader1.Width = 91;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Wins";
            this.columnHeader9.Width = 77;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Losses";
            this.columnHeader10.Width = 70;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Win %";
            this.columnHeader11.Width = 85;
            // 
            // excelButton
            // 
            this.excelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.excelButton.Location = new System.Drawing.Point(516, 557);
            this.excelButton.Name = "excelButton";
            this.excelButton.Size = new System.Drawing.Size(117, 23);
            this.excelButton.TabIndex = 5;
            this.excelButton.Text = "Export to Excel";
            this.excelButton.UseVisualStyleBackColor = true;
            this.excelButton.Click += new System.EventHandler(this.excelButton_Click);
            // 
            // excelWorker
            // 
            this.excelWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.excelWorker_DoWork);
            this.excelWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.excelWorker_RunWorkerCompleted);
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeButton.Enabled = false;
            this.removeButton.Location = new System.Drawing.Point(12, 557);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 6;
            this.removeButton.Text = "&Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // TeamRankings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 592);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.excelButton);
            this.Controls.Add(this.teamListView);
            this.Controls.Add(this.groupBox2);
            this.Name = "TeamRankings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Team Rankings";
            this.Load += new System.EventHandler(this.TeamRankings_Load);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox teamBox;
        private System.Windows.Forms.ComboBox schoolBox;
        private System.Windows.Forms.ListView teamListView;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.Button excelButton;
        private System.ComponentModel.BackgroundWorker excelWorker;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}