namespace Scholar_Bowl {
    partial class AddPlayer {
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
            this.label1 = new System.Windows.Forms.Label();
            this.playerBox = new System.Windows.Forms.TextBox();
            this.schoolBox = new System.Windows.Forms.ComboBox();
            this.teamBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.finishButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.infoLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player Name:";
            // 
            // playerBox
            // 
            this.playerBox.Location = new System.Drawing.Point(112, 12);
            this.playerBox.Name = "playerBox";
            this.playerBox.Size = new System.Drawing.Size(264, 20);
            this.playerBox.TabIndex = 1;
            // 
            // schoolBox
            // 
            this.schoolBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.schoolBox.FormattingEnabled = true;
            this.schoolBox.Location = new System.Drawing.Point(112, 38);
            this.schoolBox.Name = "schoolBox";
            this.schoolBox.Size = new System.Drawing.Size(163, 21);
            this.schoolBox.TabIndex = 2;
            this.schoolBox.SelectedIndexChanged += new System.EventHandler(this.schoolBox_SelectedIndexChanged);
            // 
            // teamBox
            // 
            this.teamBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.teamBox.FormattingEnabled = true;
            this.teamBox.Location = new System.Drawing.Point(281, 38);
            this.teamBox.Name = "teamBox";
            this.teamBox.Size = new System.Drawing.Size(95, 21);
            this.teamBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "School and Team:";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(301, 65);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "&Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // finishButton
            // 
            this.finishButton.Location = new System.Drawing.Point(198, 65);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(97, 23);
            this.finishButton.TabIndex = 6;
            this.finishButton.Text = "Save and &Finish";
            this.finishButton.UseVisualStyleBackColor = true;
            this.finishButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Error;
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.BackColor = System.Drawing.SystemColors.Info;
            this.infoLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.infoLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoLabel.Location = new System.Drawing.Point(39, 62);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(155, 32);
            this.infoLabel.TabIndex = 7;
            this.infoLabel.Text = "The player has been added\r\nsuccessfully";
            this.infoLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.infoLabel.Visible = false;
            this.infoLabel.Click += new System.EventHandler(this.infoLabel_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 2500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // AddPlayer
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 100);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.finishButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.teamBox);
            this.Controls.Add(this.schoolBox);
            this.Controls.Add(this.playerBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AddPlayer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setup New Player";
            this.Load += new System.EventHandler(this.AddPlayer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox playerBox;
        private System.Windows.Forms.ComboBox schoolBox;
        private System.Windows.Forms.ComboBox teamBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button finishButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Timer timer1;
    }
}