namespace DSAL_CA2
{
    partial class EmployeeForm
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
            treeViewEmployee = new TreeView();
            textBoxConsole = new TextBox();
            buttonCollapseAll = new Button();
            buttonExpandAll = new Button();
            label7 = new Label();
            label5 = new Label();
            label1 = new Label();
            buttonLoad = new Button();
            buttonSave = new Button();
            buttonReset = new Button();
            panel1 = new Panel();
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
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            dummyDataCheckBox = new CheckBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // treeViewEmployee
            // 
            treeViewEmployee.Location = new Point(418, 67);
            treeViewEmployee.Margin = new Padding(2);
            treeViewEmployee.Name = "treeViewEmployee";
            treeViewEmployee.Size = new Size(631, 446);
            treeViewEmployee.TabIndex = 34;
            // 
            // textBoxConsole
            // 
            textBoxConsole.BackColor = SystemColors.Menu;
            textBoxConsole.Location = new Point(26, 387);
            textBoxConsole.Margin = new Padding(2);
            textBoxConsole.Multiline = true;
            textBoxConsole.Name = "textBoxConsole";
            textBoxConsole.Size = new Size(368, 126);
            textBoxConsole.TabIndex = 33;
            // 
            // buttonCollapseAll
            // 
            buttonCollapseAll.BackColor = Color.SkyBlue;
            buttonCollapseAll.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCollapseAll.ForeColor = SystemColors.ControlLightLight;
            buttonCollapseAll.Location = new Point(962, 19);
            buttonCollapseAll.Margin = new Padding(2);
            buttonCollapseAll.Name = "buttonCollapseAll";
            buttonCollapseAll.Size = new Size(91, 33);
            buttonCollapseAll.TabIndex = 32;
            buttonCollapseAll.Text = "Collapse All";
            buttonCollapseAll.UseVisualStyleBackColor = false;
            buttonCollapseAll.Click += buttonCollapseAll_Click;
            // 
            // buttonExpandAll
            // 
            buttonExpandAll.BackColor = Color.RoyalBlue;
            buttonExpandAll.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonExpandAll.ForeColor = SystemColors.ControlLightLight;
            buttonExpandAll.Location = new Point(843, 19);
            buttonExpandAll.Margin = new Padding(2);
            buttonExpandAll.Name = "buttonExpandAll";
            buttonExpandAll.Size = new Size(94, 33);
            buttonExpandAll.TabIndex = 31;
            buttonExpandAll.Text = "Expand All";
            buttonExpandAll.UseVisualStyleBackColor = false;
            buttonExpandAll.Click += buttonExpandAll_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(418, 37);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(371, 15);
            label7.TabIndex = 30;
            label7.Text = "Right click to perform actions such as edit, remove or add employees";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(418, 13);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(153, 15);
            label5.TabIndex = 29;
            label5.Text = "Employee Node Tree View";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(21, 355);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(62, 20);
            label1.TabIndex = 28;
            label1.Text = "Console";
            // 
            // buttonLoad
            // 
            buttonLoad.BackColor = Color.SkyBlue;
            buttonLoad.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonLoad.ForeColor = SystemColors.ControlLightLight;
            buttonLoad.Location = new Point(271, 324);
            buttonLoad.Margin = new Padding(2);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(123, 25);
            buttonLoad.TabIndex = 27;
            buttonLoad.Text = "Load";
            buttonLoad.UseVisualStyleBackColor = false;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.RoyalBlue;
            buttonSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonSave.ForeColor = SystemColors.ControlLightLight;
            buttonSave.Location = new Point(147, 324);
            buttonSave.Margin = new Padding(2);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(120, 25);
            buttonSave.TabIndex = 26;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonReset
            // 
            buttonReset.BackColor = Color.Navy;
            buttonReset.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonReset.ForeColor = SystemColors.ControlLightLight;
            buttonReset.Location = new Point(21, 324);
            buttonReset.Margin = new Padding(2);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(122, 25);
            buttonReset.TabIndex = 25;
            buttonReset.Text = "Reset";
            buttonReset.UseVisualStyleBackColor = false;
            buttonReset.Click += buttonReset_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(dummyDataCheckBox);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(projectsTextBox);
            panel1.Controls.Add(roleTextBox);
            panel1.Controls.Add(salaryTextBox);
            panel1.Controls.Add(nameTextBox);
            panel1.Controls.Add(reportingOfficerTextBox);
            panel1.Controls.Add(uuidTextBox);
            panel1.Controls.Add(salaryAccCheckBox);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(21, 19);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(372, 290);
            panel1.TabIndex = 24;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(15, 197);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(52, 15);
            label11.TabIndex = 15;
            label11.Text = "Projects";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(15, 164);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(32, 15);
            label10.TabIndex = 14;
            label10.Text = "Role";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(15, 132);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(65, 15);
            label9.TabIndex = 13;
            label9.Text = "Salary ($$)";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(15, 68);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(106, 15);
            label8.TabIndex = 12;
            label8.Text = "Reporting Officer";
            // 
            // projectsTextBox
            // 
            projectsTextBox.BackColor = SystemColors.ScrollBar;
            projectsTextBox.Enabled = false;
            projectsTextBox.Location = new Point(174, 197);
            projectsTextBox.Margin = new Padding(2);
            projectsTextBox.Name = "projectsTextBox";
            projectsTextBox.Size = new Size(169, 23);
            projectsTextBox.TabIndex = 11;
            // 
            // roleTextBox
            // 
            roleTextBox.BackColor = SystemColors.ScrollBar;
            roleTextBox.Enabled = false;
            roleTextBox.Location = new Point(174, 163);
            roleTextBox.Margin = new Padding(2);
            roleTextBox.Name = "roleTextBox";
            roleTextBox.Size = new Size(169, 23);
            roleTextBox.TabIndex = 10;
            // 
            // salaryTextBox
            // 
            salaryTextBox.BackColor = SystemColors.ScrollBar;
            salaryTextBox.Enabled = false;
            salaryTextBox.Location = new Point(174, 131);
            salaryTextBox.Margin = new Padding(2);
            salaryTextBox.Name = "salaryTextBox";
            salaryTextBox.Size = new Size(169, 23);
            salaryTextBox.TabIndex = 9;
            // 
            // nameTextBox
            // 
            nameTextBox.BackColor = SystemColors.ScrollBar;
            nameTextBox.Enabled = false;
            nameTextBox.Location = new Point(174, 95);
            nameTextBox.Margin = new Padding(2);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(169, 23);
            nameTextBox.TabIndex = 8;
            // 
            // reportingOfficerTextBox
            // 
            reportingOfficerTextBox.BackColor = SystemColors.ScrollBar;
            reportingOfficerTextBox.Enabled = false;
            reportingOfficerTextBox.Location = new Point(174, 65);
            reportingOfficerTextBox.Margin = new Padding(2);
            reportingOfficerTextBox.Name = "reportingOfficerTextBox";
            reportingOfficerTextBox.Size = new Size(169, 23);
            reportingOfficerTextBox.TabIndex = 7;
            // 
            // uuidTextBox
            // 
            uuidTextBox.BackColor = SystemColors.ScrollBar;
            uuidTextBox.Enabled = false;
            uuidTextBox.Location = new Point(174, 36);
            uuidTextBox.Margin = new Padding(2);
            uuidTextBox.Name = "uuidTextBox";
            uuidTextBox.Size = new Size(169, 23);
            uuidTextBox.TabIndex = 6;
            // 
            // salaryAccCheckBox
            // 
            salaryAccCheckBox.AutoSize = true;
            salaryAccCheckBox.Enabled = false;
            salaryAccCheckBox.Location = new Point(211, 237);
            salaryAccCheckBox.Margin = new Padding(2);
            salaryAccCheckBox.Name = "salaryAccCheckBox";
            salaryAccCheckBox.Size = new Size(132, 19);
            salaryAccCheckBox.TabIndex = 5;
            salaryAccCheckBox.Text = "Salary Accountable?";
            salaryAccCheckBox.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Enabled = false;
            label6.Location = new Point(138, 263);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(63, 15);
            label6.TabIndex = 4;
            label6.Text = "Read-Only";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(15, 99);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 2;
            label4.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(15, 36);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 1;
            label3.Text = "UUID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(90, 5);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(206, 15);
            label2.TabIndex = 0;
            label2.Text = "Selected Employee Node Information";
            // 
            // dummyDataCheckBox
            // 
            dummyDataCheckBox.AutoSize = true;
            dummyDataCheckBox.Enabled = false;
            dummyDataCheckBox.Location = new Point(15, 237);
            dummyDataCheckBox.Margin = new Padding(2);
            dummyDataCheckBox.Name = "dummyDataCheckBox";
            dummyDataCheckBox.Size = new Size(101, 19);
            dummyDataCheckBox.TabIndex = 16;
            dummyDataCheckBox.Text = "Dummy Data?";
            dummyDataCheckBox.UseVisualStyleBackColor = true;
            // 
            // EmployeeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1074, 530);
            Controls.Add(treeViewEmployee);
            Controls.Add(textBoxConsole);
            Controls.Add(buttonCollapseAll);
            Controls.Add(buttonExpandAll);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label1);
            Controls.Add(buttonLoad);
            Controls.Add(buttonSave);
            Controls.Add(buttonReset);
            Controls.Add(panel1);
            Margin = new Padding(2);
            Name = "EmployeeForm";
            Text = "EmployeeForm";
            Load += EmployeeForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public TreeView treeViewEmployee;
        private TextBox textBoxConsole;
        private Button buttonCollapseAll;
        private Button buttonExpandAll;
        private Label label7;
        private Label label5;
        private Label label1;
        private Button buttonLoad;
        private Button buttonSave;
        private Button buttonReset;
        private Panel panel1;
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
        private Label label6;
        private Label label4;
        private Label label3;
        private Label label2;
        private CheckBox dummyDataCheckBox;
    }
}