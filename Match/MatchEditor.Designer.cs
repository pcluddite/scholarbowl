namespace Scholar_Bowl {
    partial class MatchEditor {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.teamBox1 = new System.Windows.Forms.ComboBox();
            this.schoolBox1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.scoreBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.removePlayerButton1 = new System.Windows.Forms.Button();
            this.addPlayerButton1 = new System.Windows.Forms.Button();
            this.durationBox1 = new System.Windows.Forms.TextBox();
            this.tossupBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.playerBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.playerListView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label7 = new System.Windows.Forms.Label();
            this.matchDatePicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.teamBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.schoolBox2 = new System.Windows.Forms.TextBox();
            this.scoreBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.removePlayerButton2 = new System.Windows.Forms.Button();
            this.addPlayerButton2 = new System.Windows.Forms.Button();
            this.durationBox2 = new System.Windows.Forms.TextBox();
            this.tossupBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.playerBox2 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.playerListView2 = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.teamBox1);
            this.groupBox1.Controls.Add(this.schoolBox1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.scoreBox1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.removePlayerButton1);
            this.groupBox1.Controls.Add(this.addPlayerButton1);
            this.groupBox1.Controls.Add(this.durationBox1);
            this.groupBox1.Controls.Add(this.tossupBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.playerBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.playerListView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(298, 386);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "First Team";
            // 
            // teamBox1
            // 
            this.teamBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.teamBox1.FormattingEnabled = true;
            this.teamBox1.Location = new System.Drawing.Point(204, 19);
            this.teamBox1.Name = "teamBox1";
            this.teamBox1.Size = new System.Drawing.Size(88, 21);
            this.teamBox1.TabIndex = 15;
            // 
            // schoolBox1
            // 
            this.schoolBox1.Location = new System.Drawing.Point(9, 19);
            this.schoolBox1.Name = "schoolBox1";
            this.schoolBox1.ReadOnly = true;
            this.schoolBox1.Size = new System.Drawing.Size(189, 20);
            this.schoolBox1.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Players:";
            // 
            // scoreBox1
            // 
            this.scoreBox1.Location = new System.Drawing.Point(238, 43);
            this.scoreBox1.Name = "scoreBox1";
            this.scoreBox1.Size = new System.Drawing.Size(54, 20);
            this.scoreBox1.TabIndex = 11;
            this.scoreBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericOnlyTextBox_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(169, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Final Score:";
            // 
            // removePlayerButton1
            // 
            this.removePlayerButton1.Enabled = false;
            this.removePlayerButton1.Location = new System.Drawing.Point(143, 357);
            this.removePlayerButton1.Name = "removePlayerButton1";
            this.removePlayerButton1.Size = new System.Drawing.Size(87, 23);
            this.removePlayerButton1.TabIndex = 9;
            this.removePlayerButton1.Text = "Remove Player";
            this.removePlayerButton1.UseVisualStyleBackColor = true;
            this.removePlayerButton1.Click += new System.EventHandler(this.removePlayerButton_Click);
            // 
            // addPlayerButton1
            // 
            this.addPlayerButton1.Location = new System.Drawing.Point(65, 357);
            this.addPlayerButton1.Name = "addPlayerButton1";
            this.addPlayerButton1.Size = new System.Drawing.Size(75, 23);
            this.addPlayerButton1.TabIndex = 2;
            this.addPlayerButton1.Text = "Add Player";
            this.addPlayerButton1.UseVisualStyleBackColor = true;
            this.addPlayerButton1.Click += new System.EventHandler(this.addPlayerButton_Click);
            // 
            // durationBox1
            // 
            this.durationBox1.Location = new System.Drawing.Point(225, 335);
            this.durationBox1.Name = "durationBox1";
            this.durationBox1.Size = new System.Drawing.Size(53, 20);
            this.durationBox1.TabIndex = 8;
            this.durationBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericOnlyTextBox_KeyPress);
            // 
            // tossupBox1
            // 
            this.tossupBox1.Location = new System.Drawing.Point(162, 335);
            this.tossupBox1.Name = "tossupBox1";
            this.tossupBox1.Size = new System.Drawing.Size(54, 20);
            this.tossupBox1.TabIndex = 2;
            this.tossupBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericOnlyTextBox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(222, 318);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Duration";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 318);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tossups";
            // 
            // playerBox1
            // 
            this.playerBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.playerBox1.FormattingEnabled = true;
            this.playerBox1.Location = new System.Drawing.Point(6, 334);
            this.playerBox1.Name = "playerBox1";
            this.playerBox1.Size = new System.Drawing.Size(150, 21);
            this.playerBox1.TabIndex = 5;
            this.playerBox1.SelectedIndexChanged += new System.EventHandler(this.playerBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 318);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Player";
            // 
            // playerListView1
            // 
            this.playerListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playerListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.playerListView1.FullRowSelect = true;
            this.playerListView1.GridLines = true;
            this.playerListView1.Location = new System.Drawing.Point(6, 69);
            this.playerListView1.Name = "playerListView1";
            this.playerListView1.Size = new System.Drawing.Size(286, 246);
            this.playerListView1.TabIndex = 2;
            this.playerListView1.UseCompatibleStateImageBehavior = false;
            this.playerListView1.View = System.Windows.Forms.View.Details;
            this.playerListView1.SelectedIndexChanged += new System.EventHandler(this.playerListView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 151;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tossups";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Duration";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 406);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "This match took place on";
            // 
            // matchDatePicker
            // 
            this.matchDatePicker.Location = new System.Drawing.Point(141, 404);
            this.matchDatePicker.Name = "matchDatePicker";
            this.matchDatePicker.Size = new System.Drawing.Size(200, 20);
            this.matchDatePicker.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.teamBox2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.schoolBox2);
            this.groupBox2.Controls.Add(this.scoreBox2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.removePlayerButton2);
            this.groupBox2.Controls.Add(this.addPlayerButton2);
            this.groupBox2.Controls.Add(this.durationBox2);
            this.groupBox2.Controls.Add(this.tossupBox2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.playerBox2);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.playerListView2);
            this.groupBox2.Location = new System.Drawing.Point(316, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(298, 386);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Second Team";
            // 
            // teamBox2
            // 
            this.teamBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.teamBox2.FormattingEnabled = true;
            this.teamBox2.Location = new System.Drawing.Point(204, 19);
            this.teamBox2.Name = "teamBox2";
            this.teamBox2.Size = new System.Drawing.Size(88, 21);
            this.teamBox2.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Players:";
            // 
            // schoolBox2
            // 
            this.schoolBox2.Location = new System.Drawing.Point(9, 19);
            this.schoolBox2.Name = "schoolBox2";
            this.schoolBox2.ReadOnly = true;
            this.schoolBox2.Size = new System.Drawing.Size(189, 20);
            this.schoolBox2.TabIndex = 16;
            // 
            // scoreBox2
            // 
            this.scoreBox2.Location = new System.Drawing.Point(238, 43);
            this.scoreBox2.Name = "scoreBox2";
            this.scoreBox2.Size = new System.Drawing.Size(54, 20);
            this.scoreBox2.TabIndex = 11;
            this.scoreBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericOnlyTextBox_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(169, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Final Score:";
            // 
            // removePlayerButton2
            // 
            this.removePlayerButton2.Enabled = false;
            this.removePlayerButton2.Location = new System.Drawing.Point(143, 357);
            this.removePlayerButton2.Name = "removePlayerButton2";
            this.removePlayerButton2.Size = new System.Drawing.Size(87, 23);
            this.removePlayerButton2.TabIndex = 9;
            this.removePlayerButton2.Text = "Remove Player";
            this.removePlayerButton2.UseVisualStyleBackColor = true;
            this.removePlayerButton2.Click += new System.EventHandler(this.removePlayerButton_Click);
            // 
            // addPlayerButton2
            // 
            this.addPlayerButton2.Location = new System.Drawing.Point(65, 357);
            this.addPlayerButton2.Name = "addPlayerButton2";
            this.addPlayerButton2.Size = new System.Drawing.Size(75, 23);
            this.addPlayerButton2.TabIndex = 2;
            this.addPlayerButton2.Text = "Add Player";
            this.addPlayerButton2.UseVisualStyleBackColor = true;
            this.addPlayerButton2.Click += new System.EventHandler(this.addPlayerButton_Click);
            // 
            // durationBox2
            // 
            this.durationBox2.Location = new System.Drawing.Point(225, 335);
            this.durationBox2.Name = "durationBox2";
            this.durationBox2.Size = new System.Drawing.Size(53, 20);
            this.durationBox2.TabIndex = 8;
            this.durationBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericOnlyTextBox_KeyPress);
            // 
            // tossupBox2
            // 
            this.tossupBox2.Location = new System.Drawing.Point(162, 335);
            this.tossupBox2.Name = "tossupBox2";
            this.tossupBox2.Size = new System.Drawing.Size(54, 20);
            this.tossupBox2.TabIndex = 2;
            this.tossupBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericOnlyTextBox_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(222, 318);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Duration";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(159, 318);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Tossups";
            // 
            // playerBox2
            // 
            this.playerBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.playerBox2.FormattingEnabled = true;
            this.playerBox2.Location = new System.Drawing.Point(6, 334);
            this.playerBox2.Name = "playerBox2";
            this.playerBox2.Size = new System.Drawing.Size(150, 21);
            this.playerBox2.TabIndex = 5;
            this.playerBox2.SelectedIndexChanged += new System.EventHandler(this.playerBox_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 318);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Player";
            // 
            // playerListView2
            // 
            this.playerListView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playerListView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.playerListView2.FullRowSelect = true;
            this.playerListView2.GridLines = true;
            this.playerListView2.Location = new System.Drawing.Point(6, 69);
            this.playerListView2.Name = "playerListView2";
            this.playerListView2.Size = new System.Drawing.Size(286, 246);
            this.playerListView2.TabIndex = 2;
            this.playerListView2.UseCompatibleStateImageBehavior = false;
            this.playerListView2.View = System.Windows.Forms.View.Details;
            this.playerListView2.SelectedIndexChanged += new System.EventHandler(this.playerListView2_SelectedIndexChanged);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Name";
            this.columnHeader4.Width = 151;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Tossups";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Duration";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(536, 404);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 14;
            this.saveButton.Text = "&Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(455, 404);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "Ca&ncel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Error;
            // 
            // MatchEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 436);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.matchDatePicker);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MatchEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Match Editor";
            this.Load += new System.EventHandler(this.MatchEditor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button removePlayerButton1;
        private System.Windows.Forms.Button addPlayerButton1;
        private System.Windows.Forms.TextBox durationBox1;
        private System.Windows.Forms.TextBox tossupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox playerBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView playerListView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker matchDatePicker;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox scoreBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox scoreBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button removePlayerButton2;
        private System.Windows.Forms.Button addPlayerButton2;
        private System.Windows.Forms.TextBox durationBox2;
        private System.Windows.Forms.TextBox tossupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox playerBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListView playerListView2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ComboBox teamBox1;
        private System.Windows.Forms.TextBox schoolBox1;
        private System.Windows.Forms.ComboBox teamBox2;
        private System.Windows.Forms.TextBox schoolBox2;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ToolTip toolTip1;

    }
}