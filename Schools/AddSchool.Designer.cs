namespace Scholar_Bowl {
    partial class AddSchool {
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
            this.schoolBox = new System.Windows.Forms.TextBox();
            this.teamListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.saveFinishButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "School Name:";
            // 
            // schoolBox
            // 
            this.schoolBox.Location = new System.Drawing.Point(12, 25);
            this.schoolBox.Name = "schoolBox";
            this.schoolBox.Size = new System.Drawing.Size(220, 20);
            this.schoolBox.TabIndex = 1;
            // 
            // teamListView
            // 
            this.teamListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.teamListView.FullRowSelect = true;
            this.teamListView.Location = new System.Drawing.Point(12, 51);
            this.teamListView.Name = "teamListView";
            this.teamListView.Size = new System.Drawing.Size(220, 194);
            this.teamListView.TabIndex = 3;
            this.teamListView.UseCompatibleStateImageBehavior = false;
            this.teamListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Teams";
            this.columnHeader1.Width = 204;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(12, 251);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(71, 23);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "&Add Team";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(186, 251);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(46, 23);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "&Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Error;
            this.toolTip1.ToolTipTitle = "School Already Exists!";
            // 
            // saveFinishButton
            // 
            this.saveFinishButton.Location = new System.Drawing.Point(89, 251);
            this.saveFinishButton.Name = "saveFinishButton";
            this.saveFinishButton.Size = new System.Drawing.Size(91, 23);
            this.saveFinishButton.TabIndex = 6;
            this.saveFinishButton.Text = "Save and &Finish";
            this.saveFinishButton.UseVisualStyleBackColor = true;
            this.saveFinishButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // AddSchool
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 285);
            this.Controls.Add(this.saveFinishButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.teamListView);
            this.Controls.Add(this.schoolBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AddSchool";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setup New School";
            this.Load += new System.EventHandler(this.AddSchool_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox schoolBox;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button saveButton;
        public System.Windows.Forms.ListView teamListView;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button saveFinishButton;
    }
}