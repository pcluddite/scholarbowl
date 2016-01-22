namespace Scholar_Bowl {
    partial class PlayerStats {
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
            this.playerListView = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.playerGroupBox = new System.Windows.Forms.GroupBox();
            this.playerNameBox = new System.Windows.Forms.TextBox();
            this.schoolGroupBox = new System.Windows.Forms.GroupBox();
            this.teamBox = new System.Windows.Forms.ComboBox();
            this.schoolBox = new System.Windows.Forms.ComboBox();
            this.excelButton = new System.Windows.Forms.Button();
            this.excelWorker = new System.ComponentModel.BackgroundWorker();
            this.statsButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.playerGroupBox.SuspendLayout();
            this.schoolGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // playerListView
            // 
            this.playerListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playerListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.playerListView.FullRowSelect = true;
            this.playerListView.GridLines = true;
            this.playerListView.Location = new System.Drawing.Point(12, 72);
            this.playerListView.Name = "playerListView";
            this.playerListView.Size = new System.Drawing.Size(647, 469);
            this.playerListView.TabIndex = 0;
            this.playerListView.UseCompatibleStateImageBehavior = false;
            this.playerListView.View = System.Windows.Forms.View.Details;
            this.playerListView.SelectedIndexChanged += new System.EventHandler(this.playerListView_SelectedIndexChanged);
            this.playerListView.DoubleClick += new System.EventHandler(this.playerListView_DoubleClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Rank";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Name";
            this.columnHeader8.Width = 166;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "School";
            this.columnHeader9.Width = 220;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Tossups";
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Games";
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Average";
            // 
            // playerGroupBox
            // 
            this.playerGroupBox.Controls.Add(this.playerNameBox);
            this.playerGroupBox.Location = new System.Drawing.Point(12, 12);
            this.playerGroupBox.Name = "playerGroupBox";
            this.playerGroupBox.Size = new System.Drawing.Size(328, 54);
            this.playerGroupBox.TabIndex = 1;
            this.playerGroupBox.TabStop = false;
            this.playerGroupBox.Text = "Find Player By Name";
            // 
            // playerNameBox
            // 
            this.playerNameBox.Location = new System.Drawing.Point(6, 19);
            this.playerNameBox.Name = "playerNameBox";
            this.playerNameBox.Size = new System.Drawing.Size(316, 20);
            this.playerNameBox.TabIndex = 2;
            this.playerNameBox.TextChanged += new System.EventHandler(this.playerNameBox_TextChanged);
            // 
            // schoolGroupBox
            // 
            this.schoolGroupBox.Controls.Add(this.teamBox);
            this.schoolGroupBox.Controls.Add(this.schoolBox);
            this.schoolGroupBox.Location = new System.Drawing.Point(346, 12);
            this.schoolGroupBox.Name = "schoolGroupBox";
            this.schoolGroupBox.Size = new System.Drawing.Size(313, 54);
            this.schoolGroupBox.TabIndex = 2;
            this.schoolGroupBox.TabStop = false;
            this.schoolGroupBox.Text = "Find Player By School and Team";
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
            // excelButton
            // 
            this.excelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.excelButton.Location = new System.Drawing.Point(542, 547);
            this.excelButton.Name = "excelButton";
            this.excelButton.Size = new System.Drawing.Size(117, 23);
            this.excelButton.TabIndex = 3;
            this.excelButton.Text = "Export to Excel";
            this.excelButton.UseVisualStyleBackColor = true;
            this.excelButton.Click += new System.EventHandler(this.excelButton_Click);
            // 
            // excelWorker
            // 
            this.excelWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.excelWorker_DoWork);
            this.excelWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.excelWorker_RunWorkerCompleted);
            // 
            // statsButton
            // 
            this.statsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statsButton.Enabled = false;
            this.statsButton.Location = new System.Drawing.Point(12, 547);
            this.statsButton.Name = "statsButton";
            this.statsButton.Size = new System.Drawing.Size(124, 23);
            this.statsButton.TabIndex = 4;
            this.statsButton.Text = "View Player Statistics";
            this.statsButton.UseVisualStyleBackColor = true;
            this.statsButton.Click += new System.EventHandler(this.playerListView_DoubleClick);
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeButton.Enabled = false;
            this.removeButton.Location = new System.Drawing.Point(142, 547);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(119, 23);
            this.removeButton.TabIndex = 5;
            this.removeButton.Text = "Remove Player";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // PlayerStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 582);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.statsButton);
            this.Controls.Add(this.excelButton);
            this.Controls.Add(this.schoolGroupBox);
            this.Controls.Add(this.playerGroupBox);
            this.Controls.Add(this.playerListView);
            this.Name = "PlayerStats";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Player Rankings";
            this.Load += new System.EventHandler(this.PlayerStats_Load);
            this.playerGroupBox.ResumeLayout(false);
            this.playerGroupBox.PerformLayout();
            this.schoolGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView playerListView;
        private System.Windows.Forms.GroupBox playerGroupBox;
        private System.Windows.Forms.TextBox playerNameBox;
        private System.Windows.Forms.GroupBox schoolGroupBox;
        private System.Windows.Forms.ComboBox teamBox;
        private System.Windows.Forms.ComboBox schoolBox;
        private System.Windows.Forms.Button excelButton;
        private System.ComponentModel.BackgroundWorker excelWorker;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.Button statsButton;
        private System.Windows.Forms.Button removeButton;
    }
}