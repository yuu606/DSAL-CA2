namespace DSAL_CA2
{
    partial class SwapEmployeeForm
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            selectedEmployeeTextBox = new TextBox();
            bindingSource1 = new BindingSource(components);
            label3 = new Label();
            treeViewEmployee2 = new TreeView();
            panel1 = new Panel();
            nameTextBox = new TextBox();
            salaryTextBox = new TextBox();
            cancelButton = new Button();
            swapButton = new Button();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            projectsTextBox = new TextBox();
            roleTextBox = new TextBox();
            reportingOfficerTextBox = new TextBox();
            uuidTextBox = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label = new Label();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(17, 13);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(83, 15);
            label1.TabIndex = 0;
            label1.Text = "Employee List";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 35);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(98, 15);
            label2.TabIndex = 1;
            label2.Text = "You are replacing";
            // 
            // selectedEmployeeTextBox
            // 
            selectedEmployeeTextBox.BackColor = SystemColors.Menu;
            selectedEmployeeTextBox.Enabled = false;
            selectedEmployeeTextBox.Location = new Point(128, 35);
            selectedEmployeeTextBox.Margin = new Padding(2);
            selectedEmployeeTextBox.Name = "selectedEmployeeTextBox";
            selectedEmployeeTextBox.Size = new Size(250, 23);
            selectedEmployeeTextBox.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 79);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(210, 15);
            label3.TabIndex = 3;
            label3.Text = "Select employee node to replace with: ";
            // 
            // treeViewEmployee2
            // 
            treeViewEmployee2.Location = new Point(21, 104);
            treeViewEmployee2.Margin = new Padding(2);
            treeViewEmployee2.Name = "treeViewEmployee2";
            treeViewEmployee2.Size = new Size(390, 316);
            treeViewEmployee2.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.Controls.Add(nameTextBox);
            panel1.Controls.Add(salaryTextBox);
            panel1.Controls.Add(cancelButton);
            panel1.Controls.Add(swapButton);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(projectsTextBox);
            panel1.Controls.Add(roleTextBox);
            panel1.Controls.Add(reportingOfficerTextBox);
            panel1.Controls.Add(uuidTextBox);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label);
            panel1.Location = new Point(430, 104);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(359, 314);
            panel1.TabIndex = 5;
            // 
            // nameTextBox
            // 
            nameTextBox.BackColor = SystemColors.ScrollBar;
            nameTextBox.Enabled = false;
            nameTextBox.Location = new Point(175, 102);
            nameTextBox.Margin = new Padding(2);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(169, 23);
            nameTextBox.TabIndex = 49;
            // 
            // salaryTextBox
            // 
            salaryTextBox.BackColor = SystemColors.ScrollBar;
            salaryTextBox.Enabled = false;
            salaryTextBox.Location = new Point(175, 133);
            salaryTextBox.Margin = new Padding(2);
            salaryTextBox.Name = "salaryTextBox";
            salaryTextBox.Size = new Size(169, 23);
            salaryTextBox.TabIndex = 48;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.Firebrick;
            cancelButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cancelButton.ForeColor = SystemColors.ButtonHighlight;
            cancelButton.Location = new Point(188, 260);
            cancelButton.Margin = new Padding(2);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(155, 34);
            cancelButton.TabIndex = 47;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += cancelButton_Click;
            // 
            // swapButton
            // 
            swapButton.BackColor = Color.DarkGreen;
            swapButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            swapButton.ForeColor = SystemColors.ButtonHighlight;
            swapButton.Location = new Point(15, 260);
            swapButton.Margin = new Padding(2);
            swapButton.Name = "swapButton";
            swapButton.Size = new Size(160, 34);
            swapButton.TabIndex = 46;
            swapButton.Text = "Swap";
            swapButton.UseVisualStyleBackColor = false;
            swapButton.Click += swapButton_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(15, 202);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(52, 15);
            label11.TabIndex = 45;
            label11.Text = "Projects";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(15, 169);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(32, 15);
            label10.TabIndex = 44;
            label10.Text = "Role";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(15, 137);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(65, 15);
            label9.TabIndex = 43;
            label9.Text = "Salary ($$)";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(15, 73);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(106, 15);
            label8.TabIndex = 42;
            label8.Text = "Reporting Officer";
            // 
            // projectsTextBox
            // 
            projectsTextBox.BackColor = SystemColors.ScrollBar;
            projectsTextBox.Enabled = false;
            projectsTextBox.Location = new Point(175, 202);
            projectsTextBox.Margin = new Padding(2);
            projectsTextBox.Name = "projectsTextBox";
            projectsTextBox.Size = new Size(169, 23);
            projectsTextBox.TabIndex = 41;
            // 
            // roleTextBox
            // 
            roleTextBox.BackColor = SystemColors.ScrollBar;
            roleTextBox.Enabled = false;
            roleTextBox.Location = new Point(175, 167);
            roleTextBox.Margin = new Padding(2);
            roleTextBox.Name = "roleTextBox";
            roleTextBox.Size = new Size(169, 23);
            roleTextBox.TabIndex = 40;
            // 
            // reportingOfficerTextBox
            // 
            reportingOfficerTextBox.BackColor = SystemColors.ScrollBar;
            reportingOfficerTextBox.Enabled = false;
            reportingOfficerTextBox.Location = new Point(175, 70);
            reportingOfficerTextBox.Margin = new Padding(2);
            reportingOfficerTextBox.Name = "reportingOfficerTextBox";
            reportingOfficerTextBox.Size = new Size(169, 23);
            reportingOfficerTextBox.TabIndex = 37;
            // 
            // uuidTextBox
            // 
            uuidTextBox.BackColor = SystemColors.ScrollBar;
            uuidTextBox.Enabled = false;
            uuidTextBox.Location = new Point(175, 41);
            uuidTextBox.Margin = new Padding(2);
            uuidTextBox.Name = "uuidTextBox";
            uuidTextBox.Size = new Size(169, 23);
            uuidTextBox.TabIndex = 36;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(15, 104);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 34;
            label4.Text = "Name";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(15, 41);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 33;
            label5.Text = "UUID";
            // 
            // label
            // 
            label.AutoSize = true;
            label.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label.Location = new Point(113, 10);
            label.Margin = new Padding(2, 0, 2, 0);
            label.Name = "label";
            label.Size = new Size(77, 15);
            label.TabIndex = 32;
            label.Text = "Replace With";
            // 
            // SwapEmployeeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(808, 436);
            Controls.Add(panel1);
            Controls.Add(treeViewEmployee2);
            Controls.Add(label3);
            Controls.Add(selectedEmployeeTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(2);
            Name = "SwapEmployeeForm";
            Text = "SwapEmployeeForm";
            Load += SwapEmployeeForm_Load;
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox selectedEmployeeTextBox;
        private BindingSource bindingSource1;
        private Label label3;
        private TreeView treeViewEmployee2;
        private Panel panel1;
        private Button cancelButton;
        private Button swapButton;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private TextBox projectsTextBox;
        private TextBox roleTextBox;
        private TextBox reportingOfficerTextBox;
        private TextBox uuidTextBox;
        private CheckBox salaryAccCheckBox;
        private Label label4;
        private Label label5;
        private Label label;
        private TextBox nameTextBox;
        private TextBox salaryTextBox;
    }
}