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
            salaryAccCheckBox = new CheckBox();
            roleComboBox = new ComboBox();
            checkBox1 = new CheckBox();
            SuspendLayout();
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(225, 130);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(373, 31);
            nameTextBox.TabIndex = 15;
            // 
            // reportingOfficerTextBox
            // 
            reportingOfficerTextBox.Enabled = false;
            reportingOfficerTextBox.Location = new Point(225, 68);
            reportingOfficerTextBox.Name = "reportingOfficerTextBox";
            reportingOfficerTextBox.Size = new Size(373, 31);
            reportingOfficerTextBox.TabIndex = 14;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.Firebrick;
            cancelButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cancelButton.ForeColor = SystemColors.ButtonHighlight;
            cancelButton.Location = new Point(337, 384);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(261, 34);
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
            addButton.Location = new Point(23, 384);
            addButton.Name = "addButton";
            addButton.Size = new Size(269, 34);
            addButton.TabIndex = 11;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = false;
            addButton.Click += addButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(23, 130);
            label3.Name = "label3";
            label3.Size = new Size(62, 25);
            label3.TabIndex = 10;
            label3.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(23, 71);
            label2.Name = "label2";
            label2.Size = new Size(162, 25);
            label2.TabIndex = 9;
            label2.Text = "Reporting Officer";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(256, 19);
            label1.Name = "label1";
            label1.Size = new Size(135, 25);
            label1.TabIndex = 8;
            label1.Text = "Add Employee";
            // 
            // salaryTextBox
            // 
            salaryTextBox.Location = new Point(225, 186);
            salaryTextBox.Name = "salaryTextBox";
            salaryTextBox.Size = new Size(373, 31);
            salaryTextBox.TabIndex = 17;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(23, 192);
            label4.Name = "label4";
            label4.Size = new Size(99, 25);
            label4.TabIndex = 16;
            label4.Text = "Salary($$)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(23, 250);
            label5.Name = "label5";
            label5.Size = new Size(50, 25);
            label5.TabIndex = 18;
            label5.Text = "Role";
            // 
            // salaryAccCheckBox
            // 
            salaryAccCheckBox.AutoSize = true;
            salaryAccCheckBox.Location = new Point(402, 318);
            salaryAccCheckBox.Name = "salaryAccCheckBox";
            salaryAccCheckBox.Size = new Size(196, 29);
            salaryAccCheckBox.TabIndex = 20;
            salaryAccCheckBox.Text = "Salary Accountable?";
            salaryAccCheckBox.UseVisualStyleBackColor = true;
            // 
            // roleComboBox
            // 
            roleComboBox.FormattingEnabled = true;
            roleComboBox.Location = new Point(225, 247);
            roleComboBox.Name = "roleComboBox";
            roleComboBox.Size = new Size(373, 33);
            roleComboBox.TabIndex = 21;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(23, 318);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(150, 29);
            checkBox1.TabIndex = 22;
            checkBox1.Text = "Dummy data?";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // AddEmployeeForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(627, 450);
            Controls.Add(checkBox1);
            Controls.Add(roleComboBox);
            Controls.Add(salaryAccCheckBox);
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
        private CheckBox salaryAccCheckBox;
        private ComboBox roleComboBox;
        private CheckBox checkBox1;
    }
}