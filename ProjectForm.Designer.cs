namespace DSAL_CA2
{
    partial class ProjectForm
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
            buttonCollapseAll = new Button();
            buttonExpandAll = new Button();
            label5 = new Label();
            buttonLoad = new Button();
            buttonSave = new Button();
            buttonReset = new Button();
            addNewProjPanel = new Panel();
            teamLeadComboBox = new ComboBox();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            confirmAddButton = new Button();
            cancelButton = new Button();
            revenueTextBox = new TextBox();
            searchButton = new Button();
            projNameTextBox = new TextBox();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            textBoxConsole = new TextBox();
            label1 = new Label();
            viewEditProjPanel = new Panel();
            uuidTextBox = new TextBox();
            label14 = new Label();
            teamLead2ComboBox = new ComboBox();
            label13 = new Label();
            confirmEditButton = new Button();
            deleteButton = new Button();
            revenue2TextBox = new TextBox();
            searchButton2 = new Button();
            projName2TextBox = new TextBox();
            label20 = new Label();
            label21 = new Label();
            label22 = new Label();
            label15 = new Label();
            projectListView = new ListView();
            label16 = new Label();
            modeComboBox = new ComboBox();
            addNewProjPanel.SuspendLayout();
            viewEditProjPanel.SuspendLayout();
            SuspendLayout();
            // 
            // treeViewEmployee
            // 
            treeViewEmployee.Location = new Point(19, 88);
            treeViewEmployee.Margin = new Padding(2);
            treeViewEmployee.Name = "treeViewEmployee";
            treeViewEmployee.Size = new Size(462, 432);
            treeViewEmployee.TabIndex = 28;
            // 
            // buttonCollapseAll
            // 
            buttonCollapseAll.BackColor = Color.SkyBlue;
            buttonCollapseAll.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCollapseAll.ForeColor = SystemColors.ControlLightLight;
            buttonCollapseAll.Location = new Point(388, 55);
            buttonCollapseAll.Margin = new Padding(2);
            buttonCollapseAll.Name = "buttonCollapseAll";
            buttonCollapseAll.Size = new Size(91, 26);
            buttonCollapseAll.TabIndex = 27;
            buttonCollapseAll.Text = "Collapse All";
            buttonCollapseAll.UseVisualStyleBackColor = false;
            buttonCollapseAll.Click += buttonCollapseAll_Click;
            // 
            // buttonExpandAll
            // 
            buttonExpandAll.BackColor = Color.RoyalBlue;
            buttonExpandAll.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonExpandAll.ForeColor = SystemColors.ControlLightLight;
            buttonExpandAll.Location = new Point(267, 55);
            buttonExpandAll.Margin = new Padding(2);
            buttonExpandAll.Name = "buttonExpandAll";
            buttonExpandAll.Size = new Size(94, 26);
            buttonExpandAll.TabIndex = 26;
            buttonExpandAll.Text = "Expand All";
            buttonExpandAll.UseVisualStyleBackColor = false;
            buttonExpandAll.Click += buttonExpandAll_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(19, 58);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(120, 15);
            label5.TabIndex = 24;
            label5.Text = "Employee Tree View";
            // 
            // buttonLoad
            // 
            buttonLoad.BackColor = Color.SkyBlue;
            buttonLoad.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonLoad.ForeColor = SystemColors.ControlLightLight;
            buttonLoad.Location = new Point(220, 21);
            buttonLoad.Margin = new Padding(2);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(91, 26);
            buttonLoad.TabIndex = 31;
            buttonLoad.Text = "Load";
            buttonLoad.UseVisualStyleBackColor = false;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.RoyalBlue;
            buttonSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonSave.ForeColor = SystemColors.ControlLightLight;
            buttonSave.Location = new Point(122, 21);
            buttonSave.Margin = new Padding(2);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(94, 26);
            buttonSave.TabIndex = 30;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonReset
            // 
            buttonReset.BackColor = Color.Navy;
            buttonReset.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonReset.ForeColor = SystemColors.ControlLightLight;
            buttonReset.Location = new Point(19, 21);
            buttonReset.Margin = new Padding(2);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(99, 26);
            buttonReset.TabIndex = 29;
            buttonReset.Text = "Reset";
            buttonReset.UseVisualStyleBackColor = false;
            buttonReset.Click += buttonReset_Click;
            // 
            // addNewProjPanel
            // 
            addNewProjPanel.BorderStyle = BorderStyle.FixedSingle;
            addNewProjPanel.Controls.Add(teamLeadComboBox);
            addNewProjPanel.Controls.Add(label12);
            addNewProjPanel.Controls.Add(label11);
            addNewProjPanel.Controls.Add(label10);
            addNewProjPanel.Controls.Add(label9);
            addNewProjPanel.Controls.Add(label8);
            addNewProjPanel.Controls.Add(label7);
            addNewProjPanel.Controls.Add(confirmAddButton);
            addNewProjPanel.Controls.Add(cancelButton);
            addNewProjPanel.Controls.Add(revenueTextBox);
            addNewProjPanel.Controls.Add(searchButton);
            addNewProjPanel.Controls.Add(projNameTextBox);
            addNewProjPanel.Controls.Add(label6);
            addNewProjPanel.Controls.Add(label4);
            addNewProjPanel.Controls.Add(label3);
            addNewProjPanel.Controls.Add(label2);
            addNewProjPanel.Location = new Point(514, 58);
            addNewProjPanel.Margin = new Padding(2);
            addNewProjPanel.Name = "addNewProjPanel";
            addNewProjPanel.Size = new Size(441, 321);
            addNewProjPanel.TabIndex = 32;
            // 
            // teamLeadComboBox
            // 
            teamLeadComboBox.BackColor = SystemColors.ScrollBar;
            teamLeadComboBox.Enabled = false;
            teamLeadComboBox.FormattingEnabled = true;
            teamLeadComboBox.Location = new Point(159, 243);
            teamLeadComboBox.Margin = new Padding(2);
            teamLeadComboBox.Name = "teamLeadComboBox";
            teamLeadComboBox.Size = new Size(246, 23);
            teamLeadComboBox.TabIndex = 42;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label12.Location = new Point(26, 249);
            label12.Margin = new Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Size = new Size(78, 15);
            label12.TabIndex = 41;
            label12.Text = "Team Leader";
            // 
            // label11
            // 
            label11.Location = new Point(79, 138);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(343, 26);
            label11.TabIndex = 40;
            label11.Text = "Click the \"Confirm Add\" button";
            // 
            // label10
            // 
            label10.Location = new Point(80, 86);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(343, 33);
            label10.TabIndex = 39;
            label10.Text = "Select  team leader via the dropdown(Highlighted in Employee Tree View)";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(26, 89);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(46, 15);
            label9.TabIndex = 38;
            label9.Text = "Step 2:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(26, 138);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(46, 15);
            label8.TabIndex = 37;
            label8.Text = "Step 3:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(26, 40);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(46, 15);
            label7.TabIndex = 36;
            label7.Text = "Step 1:";
            // 
            // confirmAddButton
            // 
            confirmAddButton.BackColor = Color.SkyBlue;
            confirmAddButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            confirmAddButton.ForeColor = SystemColors.ControlLightLight;
            confirmAddButton.Location = new Point(288, 280);
            confirmAddButton.Margin = new Padding(2);
            confirmAddButton.Name = "confirmAddButton";
            confirmAddButton.Size = new Size(116, 26);
            confirmAddButton.TabIndex = 35;
            confirmAddButton.Text = "Confirm Add";
            confirmAddButton.UseVisualStyleBackColor = false;
            confirmAddButton.Click += confirmAddButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.RoyalBlue;
            cancelButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cancelButton.ForeColor = SystemColors.ControlLightLight;
            cancelButton.Location = new Point(190, 280);
            cancelButton.Margin = new Padding(2);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(94, 26);
            cancelButton.TabIndex = 34;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += cancelButton_Click;
            // 
            // revenueTextBox
            // 
            revenueTextBox.BackColor = SystemColors.HighlightText;
            revenueTextBox.Location = new Point(159, 208);
            revenueTextBox.Margin = new Padding(2);
            revenueTextBox.Name = "revenueTextBox";
            revenueTextBox.Size = new Size(246, 23);
            revenueTextBox.TabIndex = 7;
            // 
            // searchButton
            // 
            searchButton.BackColor = Color.Navy;
            searchButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            searchButton.ForeColor = SystemColors.ControlLightLight;
            searchButton.Location = new Point(26, 280);
            searchButton.Margin = new Padding(2);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(160, 28);
            searchButton.TabIndex = 33;
            searchButton.Text = "Search for Teams";
            searchButton.UseVisualStyleBackColor = false;
            searchButton.Click += searchButton_Click;
            // 
            // projNameTextBox
            // 
            projNameTextBox.BackColor = SystemColors.HighlightText;
            projNameTextBox.Location = new Point(158, 172);
            projNameTextBox.Margin = new Padding(2);
            projNameTextBox.Name = "projNameTextBox";
            projNameTextBox.Size = new Size(246, 23);
            projNameTextBox.TabIndex = 6;
            // 
            // label6
            // 
            label6.Location = new Point(79, 40);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(343, 33);
            label6.TabIndex = 4;
            label6.Text = "Enter project name and revenue, then click on the \"Search for Teams\" button";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(26, 213);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(82, 15);
            label4.TabIndex = 2;
            label4.Text = "Revenue (S$)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(26, 178);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(83, 15);
            label3.TabIndex = 1;
            label3.Text = "Project Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(159, 4);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(96, 15);
            label2.TabIndex = 0;
            label2.Text = "Add New Project";
            // 
            // textBoxConsole
            // 
            textBoxConsole.BackColor = SystemColors.Menu;
            textBoxConsole.Enabled = false;
            textBoxConsole.Location = new Point(514, 424);
            textBoxConsole.Margin = new Padding(2);
            textBoxConsole.Multiline = true;
            textBoxConsole.Name = "textBoxConsole";
            textBoxConsole.Size = new Size(442, 96);
            textBoxConsole.TabIndex = 24;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(514, 390);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(62, 20);
            label1.TabIndex = 23;
            label1.Text = "Console";
            // 
            // viewEditProjPanel
            // 
            viewEditProjPanel.BorderStyle = BorderStyle.FixedSingle;
            viewEditProjPanel.Controls.Add(uuidTextBox);
            viewEditProjPanel.Controls.Add(label14);
            viewEditProjPanel.Controls.Add(teamLead2ComboBox);
            viewEditProjPanel.Controls.Add(label13);
            viewEditProjPanel.Controls.Add(confirmEditButton);
            viewEditProjPanel.Controls.Add(deleteButton);
            viewEditProjPanel.Controls.Add(revenue2TextBox);
            viewEditProjPanel.Controls.Add(searchButton2);
            viewEditProjPanel.Controls.Add(projName2TextBox);
            viewEditProjPanel.Controls.Add(label20);
            viewEditProjPanel.Controls.Add(label21);
            viewEditProjPanel.Controls.Add(label22);
            viewEditProjPanel.Location = new Point(970, 59);
            viewEditProjPanel.Margin = new Padding(2);
            viewEditProjPanel.Name = "viewEditProjPanel";
            viewEditProjPanel.Size = new Size(362, 198);
            viewEditProjPanel.TabIndex = 43;
            // 
            // uuidTextBox
            // 
            uuidTextBox.BackColor = SystemColors.ButtonFace;
            uuidTextBox.Enabled = false;
            uuidTextBox.Location = new Point(129, 34);
            uuidTextBox.Margin = new Padding(2);
            uuidTextBox.Name = "uuidTextBox";
            uuidTextBox.Size = new Size(217, 23);
            uuidTextBox.TabIndex = 44;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label14.Location = new Point(17, 38);
            label14.Margin = new Padding(2, 0, 2, 0);
            label14.Name = "label14";
            label14.Size = new Size(38, 15);
            label14.TabIndex = 43;
            label14.Text = "UUID";
            // 
            // teamLead2ComboBox
            // 
            teamLead2ComboBox.BackColor = SystemColors.ScrollBar;
            teamLead2ComboBox.Enabled = false;
            teamLead2ComboBox.FormattingEnabled = true;
            teamLead2ComboBox.Location = new Point(129, 122);
            teamLead2ComboBox.Margin = new Padding(2);
            teamLead2ComboBox.Name = "teamLead2ComboBox";
            teamLead2ComboBox.Size = new Size(217, 23);
            teamLead2ComboBox.TabIndex = 42;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label13.Location = new Point(17, 126);
            label13.Margin = new Padding(2, 0, 2, 0);
            label13.Name = "label13";
            label13.Size = new Size(78, 15);
            label13.TabIndex = 41;
            label13.Text = "Team Leader";
            // 
            // confirmEditButton
            // 
            confirmEditButton.BackColor = Color.SkyBlue;
            confirmEditButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            confirmEditButton.ForeColor = SystemColors.ControlLightLight;
            confirmEditButton.Location = new Point(143, 157);
            confirmEditButton.Margin = new Padding(2);
            confirmEditButton.Name = "confirmEditButton";
            confirmEditButton.Size = new Size(96, 27);
            confirmEditButton.TabIndex = 35;
            confirmEditButton.Text = "Confirm Edit";
            confirmEditButton.UseVisualStyleBackColor = false;
            confirmEditButton.Click += confirmEditButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.BackColor = Color.RoyalBlue;
            deleteButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            deleteButton.ForeColor = SystemColors.ControlLightLight;
            deleteButton.Location = new Point(250, 157);
            deleteButton.Margin = new Padding(2);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(94, 26);
            deleteButton.TabIndex = 34;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = false;
            deleteButton.Click += deleteButton_Click;
            // 
            // revenue2TextBox
            // 
            revenue2TextBox.BackColor = SystemColors.HighlightText;
            revenue2TextBox.Location = new Point(129, 92);
            revenue2TextBox.Margin = new Padding(2);
            revenue2TextBox.Name = "revenue2TextBox";
            revenue2TextBox.Size = new Size(217, 23);
            revenue2TextBox.TabIndex = 7;
            // 
            // searchButton2
            // 
            searchButton2.BackColor = Color.Navy;
            searchButton2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            searchButton2.ForeColor = SystemColors.ControlLightLight;
            searchButton2.Location = new Point(10, 157);
            searchButton2.Margin = new Padding(2);
            searchButton2.Name = "searchButton2";
            searchButton2.Size = new Size(125, 28);
            searchButton2.TabIndex = 33;
            searchButton2.Text = "Search for Teams";
            searchButton2.UseVisualStyleBackColor = false;
            searchButton2.Click += searchButton2_Click;
            // 
            // projName2TextBox
            // 
            projName2TextBox.BackColor = SystemColors.HighlightText;
            projName2TextBox.Location = new Point(129, 64);
            projName2TextBox.Margin = new Padding(2);
            projName2TextBox.Name = "projName2TextBox";
            projName2TextBox.Size = new Size(217, 23);
            projName2TextBox.TabIndex = 6;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label20.Location = new Point(17, 95);
            label20.Margin = new Padding(2, 0, 2, 0);
            label20.Name = "label20";
            label20.Size = new Size(82, 15);
            label20.TabIndex = 2;
            label20.Text = "Revenue (S$)";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label21.Location = new Point(17, 65);
            label21.Margin = new Padding(2, 0, 2, 0);
            label21.Name = "label21";
            label21.Size = new Size(83, 15);
            label21.TabIndex = 1;
            label21.Text = "Project Name";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label22.Location = new Point(129, 5);
            label22.Margin = new Padding(2, 0, 2, 0);
            label22.Name = "label22";
            label22.Size = new Size(98, 15);
            label22.TabIndex = 0;
            label22.Text = "View/Edit Project";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(974, 272);
            label15.Margin = new Padding(2, 0, 2, 0);
            label15.Name = "label15";
            label15.Size = new Size(117, 20);
            label15.TabIndex = 44;
            label15.Text = "Project List View";
            // 
            // projectListView
            // 
            projectListView.AllowDrop = true;
            projectListView.FullRowSelect = true;
            projectListView.Location = new Point(974, 308);
            projectListView.Margin = new Padding(2);
            projectListView.MultiSelect = false;
            projectListView.Name = "projectListView";
            projectListView.Size = new Size(358, 212);
            projectListView.TabIndex = 45;
            projectListView.UseCompatibleStateImageBehavior = false;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label16.Location = new Point(1134, 23);
            label16.Margin = new Padding(2, 0, 2, 0);
            label16.Name = "label16";
            label16.Size = new Size(51, 20);
            label16.TabIndex = 46;
            label16.Text = "Mode:";
            // 
            // modeComboBox
            // 
            modeComboBox.FormattingEnabled = true;
            modeComboBox.Location = new Point(1213, 24);
            modeComboBox.Margin = new Padding(2);
            modeComboBox.Name = "modeComboBox";
            modeComboBox.Size = new Size(120, 23);
            modeComboBox.TabIndex = 43;
            // 
            // ProjectForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1347, 536);
            Controls.Add(modeComboBox);
            Controls.Add(label16);
            Controls.Add(projectListView);
            Controls.Add(label15);
            Controls.Add(viewEditProjPanel);
            Controls.Add(textBoxConsole);
            Controls.Add(addNewProjPanel);
            Controls.Add(label1);
            Controls.Add(buttonLoad);
            Controls.Add(buttonSave);
            Controls.Add(buttonReset);
            Controls.Add(treeViewEmployee);
            Controls.Add(buttonCollapseAll);
            Controls.Add(buttonExpandAll);
            Controls.Add(label5);
            Margin = new Padding(2);
            Name = "ProjectForm";
            Text = "ProjectForm";
            Load += ProjectForm_Load;
            addNewProjPanel.ResumeLayout(false);
            addNewProjPanel.PerformLayout();
            viewEditProjPanel.ResumeLayout(false);
            viewEditProjPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public TreeView treeViewEmployee;
        private Button buttonCollapseAll;
        private Button buttonExpandAll;
        private Label label5;
        private Button buttonLoad;
        private Button buttonSave;
        private Button buttonReset;
        private Panel addNewProjPanel;
        private TextBox revenueTextBox;
        private TextBox projNameTextBox;
        private Label label6;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button confirmAddButton;
        private Button cancelButton;
        private Button searchButton;
        private TextBox textBoxConsole;
        private Label label1;
        private Label label9;
        private Label label8;
        private Label label7;
        private ComboBox teamLeadComboBox;
        private Label label12;
        private Label label11;
        private Label label10;
        private Panel viewEditProjPanel;
        private ComboBox teamLead2ComboBox;
        private Label label13;
        private Button confirmEditButton;
        private Button deleteButton;
        private TextBox revenue2TextBox;
        private Button searchButton2;
        private TextBox projName2TextBox;
        private Label label20;
        private Label label21;
        private Label label22;
        private TextBox uuidTextBox;
        private Label label14;
        private Label label15;
        private ListView projectListView;
        private Label label16;
        private ComboBox modeComboBox;
    }
}