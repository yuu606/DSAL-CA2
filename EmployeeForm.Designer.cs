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
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // treeViewEmployee
            // 
            treeViewEmployee.Location = new Point(597, 112);
            treeViewEmployee.Name = "treeViewEmployee";
            treeViewEmployee.Size = new Size(900, 740);
            treeViewEmployee.TabIndex = 34;
            // 
            // textBoxConsole
            // 
            textBoxConsole.BackColor = SystemColors.Menu;
            textBoxConsole.Location = new Point(37, 645);
            textBoxConsole.Multiline = true;
            textBoxConsole.Name = "textBoxConsole";
            textBoxConsole.Size = new Size(524, 207);
            textBoxConsole.TabIndex = 33;
            // 
            // buttonCollapseAll
            // 
            buttonCollapseAll.BackColor = Color.SkyBlue;
            buttonCollapseAll.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCollapseAll.ForeColor = SystemColors.ControlLightLight;
            buttonCollapseAll.Location = new Point(1374, 31);
            buttonCollapseAll.Name = "buttonCollapseAll";
            buttonCollapseAll.Size = new Size(130, 34);
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
            buttonExpandAll.Location = new Point(1204, 31);
            buttonExpandAll.Name = "buttonExpandAll";
            buttonExpandAll.Size = new Size(135, 34);
            buttonExpandAll.TabIndex = 31;
            buttonExpandAll.Text = "Expand All";
            buttonExpandAll.UseVisualStyleBackColor = false;
            buttonExpandAll.Click += buttonExpandAll_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(597, 62);
            label7.Name = "label7";
            label7.Size = new Size(561, 25);
            label7.TabIndex = 30;
            label7.Text = "Right click to perform actions such as edit, remove or add employees";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(597, 22);
            label5.Name = "label5";
            label5.Size = new Size(234, 25);
            label5.TabIndex = 29;
            label5.Text = "Employee Node Tree View";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(30, 591);
            label1.Name = "label1";
            label1.Size = new Size(91, 30);
            label1.TabIndex = 28;
            label1.Text = "Console";
            // 
            // buttonLoad
            // 
            buttonLoad.BackColor = Color.SkyBlue;
            buttonLoad.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonLoad.ForeColor = SystemColors.ControlLightLight;
            buttonLoad.Location = new Point(431, 540);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(130, 34);
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
            buttonSave.Location = new Point(228, 540);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(135, 34);
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
            buttonReset.Location = new Point(30, 540);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(141, 34);
            buttonReset.TabIndex = 25;
            buttonReset.Text = "Reset";
            buttonReset.UseVisualStyleBackColor = false;
            buttonReset.Click += buttonReset_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
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
            panel1.Location = new Point(30, 31);
            panel1.Name = "panel1";
            panel1.Size = new Size(531, 482);
            panel1.TabIndex = 24;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(21, 329);
            label11.Name = "label11";
            label11.Size = new Size(80, 25);
            label11.TabIndex = 15;
            label11.Text = "Projects";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(21, 274);
            label10.Name = "label10";
            label10.Size = new Size(50, 25);
            label10.TabIndex = 14;
            label10.Text = "Role";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(21, 220);
            label9.Name = "label9";
            label9.Size = new Size(104, 25);
            label9.TabIndex = 13;
            label9.Text = "Salary ($$)";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(21, 114);
            label8.Name = "label8";
            label8.Size = new Size(162, 25);
            label8.TabIndex = 12;
            label8.Text = "Reporting Officer";
            // 
            // projectsTextBox
            // 
            projectsTextBox.BackColor = SystemColors.ScrollBar;
            projectsTextBox.Enabled = false;
            projectsTextBox.Location = new Point(249, 328);
            projectsTextBox.Name = "projectsTextBox";
            projectsTextBox.Size = new Size(240, 31);
            projectsTextBox.TabIndex = 11;
            // 
            // roleTextBox
            // 
            roleTextBox.BackColor = SystemColors.ScrollBar;
            roleTextBox.Enabled = false;
            roleTextBox.Location = new Point(249, 271);
            roleTextBox.Name = "roleTextBox";
            roleTextBox.Size = new Size(240, 31);
            roleTextBox.TabIndex = 10;
            // 
            // salaryTextBox
            // 
            salaryTextBox.BackColor = SystemColors.ScrollBar;
            salaryTextBox.Enabled = false;
            salaryTextBox.Location = new Point(249, 218);
            salaryTextBox.Name = "salaryTextBox";
            salaryTextBox.Size = new Size(240, 31);
            salaryTextBox.TabIndex = 9;
            // 
            // nameTextBox
            // 
            nameTextBox.BackColor = SystemColors.ScrollBar;
            nameTextBox.Enabled = false;
            nameTextBox.Location = new Point(249, 159);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(240, 31);
            nameTextBox.TabIndex = 8;
            // 
            // reportingOfficerTextBox
            // 
            reportingOfficerTextBox.BackColor = SystemColors.ScrollBar;
            reportingOfficerTextBox.Enabled = false;
            reportingOfficerTextBox.Location = new Point(249, 108);
            reportingOfficerTextBox.Name = "reportingOfficerTextBox";
            reportingOfficerTextBox.Size = new Size(240, 31);
            reportingOfficerTextBox.TabIndex = 7;
            // 
            // uuidTextBox
            // 
            uuidTextBox.BackColor = SystemColors.ScrollBar;
            uuidTextBox.Enabled = false;
            uuidTextBox.Location = new Point(249, 60);
            uuidTextBox.Name = "uuidTextBox";
            uuidTextBox.Size = new Size(240, 31);
            uuidTextBox.TabIndex = 6;
            // 
            // salaryAccCheckBox
            // 
            salaryAccCheckBox.AutoSize = true;
            salaryAccCheckBox.Enabled = false;
            salaryAccCheckBox.Location = new Point(21, 389);
            salaryAccCheckBox.Name = "salaryAccCheckBox";
            salaryAccCheckBox.Size = new Size(196, 29);
            salaryAccCheckBox.TabIndex = 5;
            salaryAccCheckBox.Text = "Salary Accountable?";
            salaryAccCheckBox.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Enabled = false;
            label6.Location = new Point(197, 438);
            label6.Name = "label6";
            label6.Size = new Size(95, 25);
            label6.TabIndex = 4;
            label6.Text = "Read-Only";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(21, 165);
            label4.Name = "label4";
            label4.Size = new Size(62, 25);
            label4.TabIndex = 2;
            label4.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(21, 60);
            label3.Name = "label3";
            label3.Size = new Size(57, 25);
            label3.TabIndex = 1;
            label3.Text = "UUID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(128, 8);
            label2.Name = "label2";
            label2.Size = new Size(324, 25);
            label2.TabIndex = 0;
            label2.Text = "Selected Employee Node Information";
            // 
            // EmployeeForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1534, 883);
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
    }
}