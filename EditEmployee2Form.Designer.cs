namespace DSAL_CA2
{
    partial class EditEmployee2Form
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
            nameTextBox = new TextBox();
            salaryTextBox = new TextBox();
            cancelButton = new Button();
            editButton = new Button();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            projectsTextBox = new TextBox();
            uuidTextBox = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label = new Label();
            reportingOfficerComboBox = new ComboBox();
            roleComboBox = new ComboBox();
            isAccCheckBox = new CheckBox();
            isDummyData = new CheckBox();
            SuspendLayout();
            // 
            // nameTextBox
            // 
            nameTextBox.BackColor = SystemColors.ScrollBar;
            nameTextBox.Enabled = false;
            nameTextBox.Location = new Point(182, 103);
            nameTextBox.Margin = new Padding(2);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(169, 23);
            nameTextBox.TabIndex = 64;
            // 
            // salaryTextBox
            // 
            salaryTextBox.BackColor = SystemColors.ScrollBar;
            salaryTextBox.Enabled = false;
            salaryTextBox.Location = new Point(182, 134);
            salaryTextBox.Margin = new Padding(2);
            salaryTextBox.Name = "salaryTextBox";
            salaryTextBox.Size = new Size(169, 23);
            salaryTextBox.TabIndex = 63;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.Firebrick;
            cancelButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cancelButton.ForeColor = SystemColors.ButtonHighlight;
            cancelButton.Location = new Point(195, 270);
            cancelButton.Margin = new Padding(2);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(155, 25);
            cancelButton.TabIndex = 62;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += cancelButton_Click;
            // 
            // editButton
            // 
            editButton.BackColor = Color.DarkGreen;
            editButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            editButton.ForeColor = SystemColors.ButtonHighlight;
            editButton.Location = new Point(22, 270);
            editButton.Margin = new Padding(2);
            editButton.Name = "editButton";
            editButton.Size = new Size(160, 25);
            editButton.TabIndex = 61;
            editButton.Text = "Edit";
            editButton.UseVisualStyleBackColor = false;
            editButton.Click += editButton_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(22, 203);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(52, 15);
            label11.TabIndex = 60;
            label11.Text = "Projects";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(22, 170);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(32, 15);
            label10.TabIndex = 59;
            label10.Text = "Role";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(22, 137);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(65, 15);
            label9.TabIndex = 58;
            label9.Text = "Salary ($$)";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(22, 74);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(106, 15);
            label8.TabIndex = 57;
            label8.Text = "Reporting Officer";
            // 
            // projectsTextBox
            // 
            projectsTextBox.BackColor = SystemColors.ScrollBar;
            projectsTextBox.Enabled = false;
            projectsTextBox.Location = new Point(182, 202);
            projectsTextBox.Margin = new Padding(2);
            projectsTextBox.Name = "projectsTextBox";
            projectsTextBox.Size = new Size(169, 23);
            projectsTextBox.TabIndex = 56;
            // 
            // uuidTextBox
            // 
            uuidTextBox.BackColor = SystemColors.ScrollBar;
            uuidTextBox.Enabled = false;
            uuidTextBox.Location = new Point(182, 41);
            uuidTextBox.Margin = new Padding(2);
            uuidTextBox.Name = "uuidTextBox";
            uuidTextBox.Size = new Size(169, 23);
            uuidTextBox.TabIndex = 53;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(22, 104);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 52;
            label4.Text = "Name";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(22, 41);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 51;
            label5.Text = "UUID";
            // 
            // label
            // 
            label.AutoSize = true;
            label.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label.Location = new Point(120, 10);
            label.Margin = new Padding(2, 0, 2, 0);
            label.Name = "label";
            label.Size = new Size(77, 15);
            label.TabIndex = 50;
            label.Text = "Replace With";
            // 
            // reportingOfficerComboBox
            // 
            reportingOfficerComboBox.FormattingEnabled = true;
            reportingOfficerComboBox.Location = new Point(182, 71);
            reportingOfficerComboBox.Margin = new Padding(2);
            reportingOfficerComboBox.Name = "reportingOfficerComboBox";
            reportingOfficerComboBox.Size = new Size(169, 23);
            reportingOfficerComboBox.TabIndex = 65;
            // 
            // roleComboBox
            // 
            roleComboBox.FormattingEnabled = true;
            roleComboBox.Location = new Point(182, 168);
            roleComboBox.Margin = new Padding(2);
            roleComboBox.Name = "roleComboBox";
            roleComboBox.Size = new Size(169, 23);
            roleComboBox.TabIndex = 66;
            // 
            // isAccCheckBox
            // 
            isAccCheckBox.AutoSize = true;
            isAccCheckBox.Checked = true;
            isAccCheckBox.CheckState = CheckState.Checked;
            isAccCheckBox.Enabled = false;
            isAccCheckBox.Location = new Point(218, 238);
            isAccCheckBox.Margin = new Padding(2);
            isAccCheckBox.Name = "isAccCheckBox";
            isAccCheckBox.Size = new Size(132, 19);
            isAccCheckBox.TabIndex = 67;
            isAccCheckBox.Text = "Salary Accountable?";
            isAccCheckBox.UseVisualStyleBackColor = true;
            // 
            // isDummyData
            // 
            isDummyData.AutoSize = true;
            isDummyData.Enabled = false;
            isDummyData.Location = new Point(22, 238);
            isDummyData.Margin = new Padding(2);
            isDummyData.Name = "isDummyData";
            isDummyData.Size = new Size(96, 19);
            isDummyData.TabIndex = 68;
            isDummyData.Text = "Dummy Data";
            isDummyData.UseVisualStyleBackColor = true;
            // 
            // EditEmployee2Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(377, 306);
            Controls.Add(isDummyData);
            Controls.Add(isAccCheckBox);
            Controls.Add(roleComboBox);
            Controls.Add(reportingOfficerComboBox);
            Controls.Add(nameTextBox);
            Controls.Add(salaryTextBox);
            Controls.Add(cancelButton);
            Controls.Add(editButton);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(projectsTextBox);
            Controls.Add(uuidTextBox);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label);
            Margin = new Padding(2);
            Name = "EditEmployee2Form";
            Text = "EditEmployee2Form";
            Load += EditEmployee2Form_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nameTextBox;
        private TextBox salaryTextBox;
        private Button cancelButton;
        private Button editButton;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private TextBox projectsTextBox;
        private TextBox uuidTextBox;
        private Label label4;
        private Label label5;
        private Label label;
        private ComboBox reportingOfficerComboBox;
        private ComboBox roleComboBox;
        private CheckBox isAccCheckBox;
        private CheckBox isDummyData;
    }
}