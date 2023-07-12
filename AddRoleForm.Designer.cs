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
            label1.Location = new Point(266, 28);
            label1.Name = "label1";
            label1.Size = new Size(95, 25);
            label1.TabIndex = 0;
            label1.Text = "Add Role ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(33, 78);
            label2.Name = "label2";
            label2.Size = new Size(111, 25);
            label2.TabIndex = 1;
            label2.Text = "Parent Role";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(33, 145);
            label3.Name = "label3";
            label3.Size = new Size(62, 25);
            label3.TabIndex = 2;
            label3.Text = "Name";
            // 
            // addButton
            // 
            addButton.BackColor = Color.DarkGreen;
            addButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            addButton.ForeColor = SystemColors.ButtonHighlight;
            addButton.Location = new Point(40, 270);
            addButton.Name = "addButton";
            addButton.Size = new Size(269, 34);
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
            cancelButton.Location = new Point(347, 270);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(261, 34);
            cancelButton.TabIndex = 4;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += cancelButton_Click;
            // 
            // projLeadCheckBox
            // 
            projLeadCheckBox.AutoSize = true;
            projLeadCheckBox.Location = new Point(40, 197);
            projLeadCheckBox.Name = "projLeadCheckBox";
            projLeadCheckBox.Size = new Size(196, 29);
            projLeadCheckBox.TabIndex = 5;
            projLeadCheckBox.Text = "Project Leader Role?";
            projLeadCheckBox.UseVisualStyleBackColor = true;
            // 
            // parentRoleTextBox
            // 
            parentRoleTextBox.Enabled = false;
            parentRoleTextBox.Location = new Point(235, 77);
            parentRoleTextBox.Name = "parentRoleTextBox";
            parentRoleTextBox.Size = new Size(373, 31);
            parentRoleTextBox.TabIndex = 6;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(235, 139);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(373, 31);
            nameTextBox.TabIndex = 7;
            // 
            // AddRoleForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(639, 327);
            Controls.Add(nameTextBox);
            Controls.Add(parentRoleTextBox);
            Controls.Add(projLeadCheckBox);
            Controls.Add(cancelButton);
            Controls.Add(addButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
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