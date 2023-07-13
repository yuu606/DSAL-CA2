namespace DSAL_CA2
{
    partial class AddEmployeeForm
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
            reportingOfficerTextBox = new TextBox();
            cancelButton = new Button();
            addButton = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            salaryTextBox = new TextBox();
            label4 = new Label();
            label5 = new Label();
            isAccCheckBox = new CheckBox();
            roleComboBox = new ComboBox();
            isDummyData = new CheckBox();
            SuspendLayout();
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(158, 78);
            nameTextBox.Margin = new Padding(2);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(262, 23);
            nameTextBox.TabIndex = 15;
            // 
            // reportingOfficerTextBox
            // 
            reportingOfficerTextBox.BackColor = SystemColors.ScrollBar;
            reportingOfficerTextBox.Enabled = false;
            reportingOfficerTextBox.Location = new Point(158, 41);
            reportingOfficerTextBox.Margin = new Padding(2);
            reportingOfficerTextBox.Name = "reportingOfficerTextBox";
            reportingOfficerTextBox.Size = new Size(262, 23);
            reportingOfficerTextBox.TabIndex = 14;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.Firebrick;
            cancelButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cancelButton.ForeColor = SystemColors.ButtonHighlight;
            cancelButton.Location = new Point(236, 222);
            cancelButton.Margin = new Padding(2);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(183, 29);
            cancelButton.TabIndex = 12;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += cancelButton_Click;
            // 
            // addButton
            // 
            addButton.BackColor = Color.DarkGreen;
            addButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            addButton.ForeColor = SystemColors.ButtonHighlight;
            addButton.Location = new Point(16, 222);
            addButton.Margin = new Padding(2);
            addButton.Name = "addButton";
            addButton.Size = new Size(188, 29);
            addButton.TabIndex = 11;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = false;
            addButton.Click += addButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(16, 78);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 10;
            label3.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(16, 43);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(106, 15);
            label2.TabIndex = 9;
            label2.Text = "Reporting Officer";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(179, 11);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(86, 15);
            label1.TabIndex = 8;
            label1.Text = "Add Employee";
            // 
            // salaryTextBox
            // 
            salaryTextBox.Location = new Point(158, 112);
            salaryTextBox.Margin = new Padding(2);
            salaryTextBox.Name = "salaryTextBox";
            salaryTextBox.Size = new Size(262, 23);
            salaryTextBox.TabIndex = 17;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(16, 115);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(62, 15);
            label4.TabIndex = 16;
            label4.Text = "Salary($$)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(16, 150);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(32, 15);
            label5.TabIndex = 18;
            label5.Text = "Role";
            // 
            // isAccCheckBox
            // 
            isAccCheckBox.AutoSize = true;
            isAccCheckBox.Checked = true;
            isAccCheckBox.CheckState = CheckState.Checked;
            isAccCheckBox.Enabled = false;
            isAccCheckBox.Location = new Point(281, 191);
            isAccCheckBox.Margin = new Padding(2);
            isAccCheckBox.Name = "isAccCheckBox";
            isAccCheckBox.Size = new Size(132, 19);
            isAccCheckBox.TabIndex = 20;
            isAccCheckBox.Text = "Salary Accountable?";
            isAccCheckBox.UseVisualStyleBackColor = true;
            // 
            // roleComboBox
            // 
            roleComboBox.FormattingEnabled = true;
            roleComboBox.Location = new Point(158, 148);
            roleComboBox.Margin = new Padding(2);
            roleComboBox.Name = "roleComboBox";
            roleComboBox.Size = new Size(262, 23);
            roleComboBox.TabIndex = 21;
            // 
            // isDummyData
            // 
            isDummyData.AutoSize = true;
            isDummyData.Location = new Point(16, 191);
            isDummyData.Margin = new Padding(2);
            isDummyData.Name = "isDummyData";
            isDummyData.Size = new Size(100, 19);
            isDummyData.TabIndex = 22;
            isDummyData.Text = "Dummy data?";
            isDummyData.UseVisualStyleBackColor = true;
            // 
            // AddEmployeeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(439, 270);
            Controls.Add(isDummyData);
            Controls.Add(roleComboBox);
            Controls.Add(isAccCheckBox);
            Controls.Add(label5);
            Controls.Add(salaryTextBox);
            Controls.Add(label4);
            Controls.Add(nameTextBox);
            Controls.Add(reportingOfficerTextBox);
            Controls.Add(cancelButton);
            Controls.Add(addButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(2);
            Name = "AddEmployeeForm";
            Text = "AddEmployeeForm";
            Load += AddEmployeeForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nameTextBox;
        private TextBox reportingOfficerTextBox;
        private Button cancelButton;
        private Button addButton;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox salaryTextBox;
        private Label label4;
        private Label label5;
        private CheckBox isAccCheckBox;
        private ComboBox roleComboBox;
        private CheckBox isDummyData;
    }
}