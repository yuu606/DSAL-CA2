namespace DSAL_CA2
{
    partial class AddRoleForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            addButton = new Button();
            cancelButton = new Button();
            projLeadCheckBox = new CheckBox();
            parentRoleTextBox = new TextBox();
            nameTextBox = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(186, 17);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 0;
            label1.Text = "Add Role ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(23, 47);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 1;
            label2.Text = "Parent Role";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(23, 87);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 2;
            label3.Text = "Name";
            // 
            // addButton
            // 
            addButton.BackColor = Color.DarkGreen;
            addButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            addButton.ForeColor = SystemColors.ButtonHighlight;
            addButton.Location = new Point(28, 162);
            addButton.Margin = new Padding(2, 2, 2, 2);
            addButton.Name = "addButton";
            addButton.Size = new Size(188, 39);
            addButton.TabIndex = 3;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = false;
            addButton.Click += addButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.Firebrick;
            cancelButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cancelButton.ForeColor = SystemColors.ButtonHighlight;
            cancelButton.Location = new Point(243, 162);
            cancelButton.Margin = new Padding(2, 2, 2, 2);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(183, 39);
            cancelButton.TabIndex = 4;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += cancelButton_Click;
            // 
            // projLeadCheckBox
            // 
            projLeadCheckBox.AutoSize = true;
            projLeadCheckBox.Location = new Point(28, 118);
            projLeadCheckBox.Margin = new Padding(2, 2, 2, 2);
            projLeadCheckBox.Name = "projLeadCheckBox";
            projLeadCheckBox.Size = new Size(132, 19);
            projLeadCheckBox.TabIndex = 5;
            projLeadCheckBox.Text = "Project Leader Role?";
            projLeadCheckBox.UseVisualStyleBackColor = true;
            // 
            // parentRoleTextBox
            // 
            parentRoleTextBox.Enabled = false;
            parentRoleTextBox.Location = new Point(164, 46);
            parentRoleTextBox.Margin = new Padding(2, 2, 2, 2);
            parentRoleTextBox.Name = "parentRoleTextBox";
            parentRoleTextBox.Size = new Size(262, 23);
            parentRoleTextBox.TabIndex = 6;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(164, 83);
            nameTextBox.Margin = new Padding(2, 2, 2, 2);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(262, 23);
            nameTextBox.TabIndex = 7;
            // 
            // AddRoleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(447, 212);
            Controls.Add(nameTextBox);
            Controls.Add(parentRoleTextBox);
            Controls.Add(projLeadCheckBox);
            Controls.Add(cancelButton);
            Controls.Add(addButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(2, 2, 2, 2);
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "AddRoleForm";
            Text = "AddRoleForm";
            Load += AddRoleForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button addButton;
        private Button cancelButton;
        private CheckBox projLeadCheckBox;
        private TextBox parentRoleTextBox;
        private TextBox nameTextBox;
    }
}