namespace DSAL_CA2
{
    partial class RoleForm
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
            nameTextBox = new TextBox();
            uuidTextBox = new TextBox();
            checkBox1 = new CheckBox();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            treeViewRole = new TreeView();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxConsole
            // 
            textBoxConsole.BackColor = SystemColors.Menu;
            textBoxConsole.Location = new Point(29, 248);
            textBoxConsole.Margin = new Padding(2);
            textBoxConsole.Multiline = true;
            textBoxConsole.Name = "textBoxConsole";
            textBoxConsole.Size = new Size(289, 192);
            textBoxConsole.TabIndex = 22;
            // 
            // buttonCollapseAll
            // 
            buttonCollapseAll.BackColor = Color.SkyBlue;
            buttonCollapseAll.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCollapseAll.ForeColor = SystemColors.ControlLightLight;
            buttonCollapseAll.Location = new Point(877, 22);
            buttonCollapseAll.Margin = new Padding(2);
            buttonCollapseAll.Name = "buttonCollapseAll";
            buttonCollapseAll.Size = new Size(91, 24);
            buttonCollapseAll.TabIndex = 21;
            buttonCollapseAll.Text = "Collapse All";
            buttonCollapseAll.UseVisualStyleBackColor = false;
            buttonCollapseAll.Click += buttonCollapseAll_Click;
            // 
            // buttonExpandAll
            // 
            buttonExpandAll.BackColor = Color.RoyalBlue;
            buttonExpandAll.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonExpandAll.ForeColor = SystemColors.ControlLightLight;
            buttonExpandAll.Location = new Point(758, 22);
            buttonExpandAll.Margin = new Padding(2);
            buttonExpandAll.Name = "buttonExpandAll";
            buttonExpandAll.Size = new Size(94, 24);
            buttonExpandAll.TabIndex = 20;
            buttonExpandAll.Text = "Expand All";
            buttonExpandAll.UseVisualStyleBackColor = false;
            buttonExpandAll.Click += buttonExpandAll_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(333, 41);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(339, 15);
            label7.TabIndex = 19;
            label7.Text = "Right click to perform actions such as edit, remove or add roles";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(333, 17);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(124, 15);
            label5.TabIndex = 18;
            label5.Text = "Role Node Tree View";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(28, 223);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(62, 20);
            label1.TabIndex = 17;
            label1.Text = "Console";
            // 
            // buttonLoad
            // 
            buttonLoad.BackColor = Color.SkyBlue;
            buttonLoad.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonLoad.ForeColor = SystemColors.ControlLightLight;
            buttonLoad.Location = new Point(226, 187);
            buttonLoad.Margin = new Padding(2);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(91, 24);
            buttonLoad.TabIndex = 16;
            buttonLoad.Text = "Load";
            buttonLoad.UseVisualStyleBackColor = false;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.RoyalBlue;
            buttonSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonSave.ForeColor = SystemColors.ControlLightLight;
            buttonSave.Location = new Point(127, 187);
            buttonSave.Margin = new Padding(2);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(94, 24);
            buttonSave.TabIndex = 15;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonReset
            // 
            buttonReset.BackColor = Color.Navy;
            buttonReset.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonReset.ForeColor = SystemColors.ControlLightLight;
            buttonReset.Location = new Point(24, 187);
            buttonReset.Margin = new Padding(2);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(99, 24);
            buttonReset.TabIndex = 14;
            buttonReset.Text = "Reset";
            buttonReset.UseVisualStyleBackColor = false;
            buttonReset.Click += buttonReset_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(nameTextBox);
            panel1.Controls.Add(uuidTextBox);
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(24, 22);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(293, 150);
            panel1.TabIndex = 12;
            // 
            // nameTextBox
            // 
            nameTextBox.BackColor = SystemColors.ScrollBar;
            nameTextBox.Enabled = false;
            nameTextBox.Location = new Point(108, 65);
            nameTextBox.Margin = new Padding(2);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(169, 23);
            nameTextBox.TabIndex = 7;
            // 
            // uuidTextBox
            // 
            uuidTextBox.BackColor = SystemColors.ScrollBar;
            uuidTextBox.Enabled = false;
            uuidTextBox.Location = new Point(108, 36);
            uuidTextBox.Margin = new Padding(2);
            uuidTextBox.Name = "uuidTextBox";
            uuidTextBox.Size = new Size(169, 23);
            uuidTextBox.TabIndex = 6;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Enabled = false;
            checkBox1.Location = new Point(15, 95);
            checkBox1.Margin = new Padding(2);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(132, 19);
            checkBox1.TabIndex = 5;
            checkBox1.Text = "Project Leader Role?";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Enabled = false;
            label6.Location = new Point(102, 121);
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
            label4.Location = new Point(15, 65);
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
            label2.Location = new Point(52, 8);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(177, 15);
            label2.TabIndex = 0;
            label2.Text = "Selected Role Node Information";
            // 
            // treeViewRole
            // 
            treeViewRole.Location = new Point(338, 71);
            treeViewRole.Margin = new Padding(2);
            treeViewRole.Name = "treeViewRole";
            treeViewRole.Size = new Size(631, 369);
            treeViewRole.TabIndex = 23;
            // 
            // RoleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(991, 466);
            Controls.Add(treeViewRole);
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
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "RoleForm";
            Text = "RoleForm";
            Load += RoleForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

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
        private TextBox nameTextBox;
        private TextBox uuidTextBox;
        private CheckBox checkBox1;
        private Label label6;
        private Label label4;
        private Label label3;
        private Label label2;
        public TreeView treeViewRole;
    }
}