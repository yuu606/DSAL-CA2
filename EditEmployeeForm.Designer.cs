namespace DSAL_CA2
{
    partial class EditEmployeeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            projectsTextBox = new TextBox();
            roleTextBox = new TextBox();
            salaryTextBox = new TextBox();
            nameTextBox = new TextBox();
            reportingOfficerTextBox = new TextBox();
            uuidTextBox = new TextBox();
            salaryAccCheckBox = new CheckBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            cancelButton = new Button();
            editButton = new Button();
            SuspendLayout();
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(24, 330);
            label11.Name = "label11";
            label11.Size = new Size(80, 25);
            label11.TabIndex = 29;
            label11.Text = "Projects";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(24, 275);
            label10.Name = "label10";
            label10.Size = new Size(50, 25);
            label10.TabIndex = 28;
            label10.Text = "Role";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(24, 221);
            label9.Name = "label9";
            label9.Size = new Size(104, 25);
            label9.TabIndex = 27;
            label9.Text = "Salary ($$)";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(24, 115);
            label8.Name = "label8";
            label8.Size = new Size(162, 25);
            label8.TabIndex = 26;
            label8.Text = "Reporting Officer";
            // 
            // projectsTextBox
            // 
            projectsTextBox.BackColor = SystemColors.ScrollBar;
            projectsTextBox.Enabled = false;
            projectsTextBox.Location = new Point(252, 329);
            projectsTextBox.Name = "projectsTextBox";
            projectsTextBox.Size = new Size(240, 31);
            projectsTextBox.TabIndex = 25;
            // 
            // roleTextBox
            // 
            roleTextBox.BackColor = SystemColors.ScrollBar;
            roleTextBox.Enabled = false;
            roleTextBox.Location = new Point(252, 272);
            roleTextBox.Name = "roleTextBox";
            roleTextBox.Size = new Size(240, 31);
            roleTextBox.TabIndex = 24;
            // 
            // salaryTextBox
            // 
            salaryTextBox.BackColor = SystemColors.HighlightText;
            salaryTextBox.Location = new Point(252, 219);
            salaryTextBox.Name = "salaryTextBox";
            salaryTextBox.Size = new Size(240, 31);
            salaryTextBox.TabIndex = 23;
            // 
            // nameTextBox
            // 
            nameTextBox.BackColor = SystemColors.HighlightText;
            nameTextBox.Location = new Point(252, 160);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(240, 31);
            nameTextBox.TabIndex = 22;
            // 
            // reportingOfficerTextBox
            // 
            reportingOfficerTextBox.BackColor = SystemColors.ScrollBar;
            reportingOfficerTextBox.Enabled = false;
            reportingOfficerTextBox.Location = new Point(252, 109);
            reportingOfficerTextBox.Name = "reportingOfficerTextBox";
            reportingOfficerTextBox.Size = new Size(240, 31);
            reportingOfficerTextBox.TabIndex = 21;
            // 
            // uuidTextBox
            // 
            uuidTextBox.BackColor = SystemColors.ScrollBar;
            uuidTextBox.Enabled = false;
            uuidTextBox.Location = new Point(252, 61);
            uuidTextBox.Name = "uuidTextBox";
            uuidTextBox.Size = new Size(240, 31);
            uuidTextBox.TabIndex = 20;
            // 
            // salaryAccCheckBox
            // 
            salaryAccCheckBox.AutoSize = true;
            salaryAccCheckBox.Enabled = false;
            salaryAccCheckBox.Location = new Point(24, 390);
            salaryAccCheckBox.Name = "salaryAccCheckBox";
            salaryAccCheckBox.Size = new Size(196, 29);
            salaryAccCheckBox.TabIndex = 19;
            salaryAccCheckBox.Text = "Salary Accountable?";
            salaryAccCheckBox.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(24, 166);
            label4.Name = "label4";
            label4.Size = new Size(62, 25);
            label4.TabIndex = 18;
            label4.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(24, 61);
            label3.Name = "label3";
            label3.Size = new Size(57, 25);
            label3.TabIndex = 17;
            label3.Text = "UUID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(163, 9);
            label2.Name = "label2";
            label2.Size = new Size(192, 25);
            label2.TabIndex = 16;
            label2.Text = "Edit Employee Details";
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.Firebrick;
            cancelButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cancelButton.ForeColor = SystemColors.ButtonHighlight;
            cancelButton.Location = new Point(271, 467);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(221, 34);
            cancelButton.TabIndex = 31;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            // 
            // editButton
            // 
            editButton.BackColor = Color.DarkGreen;
            editButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            editButton.ForeColor = SystemColors.ButtonHighlight;
            editButton.Location = new Point(27, 467);
            editButton.Name = "editButton";
            editButton.Size = new Size(229, 34);
            editButton.TabIndex = 30;
            editButton.Text = "Edit";
            editButton.UseVisualStyleBackColor = false;
            // 
            // EditEmployeeForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(530, 566);
            Controls.Add(cancelButton);
            Controls.Add(editButton);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(projectsTextBox);
            Controls.Add(roleTextBox);
            Controls.Add(salaryTextBox);
            Controls.Add(nameTextBox);
            Controls.Add(reportingOfficerTextBox);
            Controls.Add(uuidTextBox);
            Controls.Add(salaryAccCheckBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "EditEmployeeForm";
            Text = "EditEmployeeForm";
            Load += EditEmployeeForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private TextBox projectsTextBox;
        private TextBox roleTextBox;
        private TextBox salaryTextBox;
        private TextBox nameTextBox;
        private TextBox reportingOfficerTextBox;
        private TextBox uuidTextBox;
        private CheckBox salaryAccCheckBox;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button cancelButton;
        private Button editButton;
    }
}