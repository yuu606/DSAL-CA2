namespace DSAL_CA2
{
    partial class EditRoleForm
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
            UUIDtextBox = new TextBox();
            projLeadCheckBox = new CheckBox();
            cancelButton = new Button();
            editButton = new Button();
            label3 = new Label();
            label = new Label();
            label1 = new Label();
            label2 = new Label();
            parentRoleTextBox = new TextBox();
            SuspendLayout();
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(157, 72);
            nameTextBox.Margin = new Padding(2, 2, 2, 2);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(262, 23);
            nameTextBox.TabIndex = 15;
            // 
            // UUIDtextBox
            // 
            UUIDtextBox.Enabled = false;
            UUIDtextBox.Location = new Point(157, 35);
            UUIDtextBox.Margin = new Padding(2, 2, 2, 2);
            UUIDtextBox.Name = "UUIDtextBox";
            UUIDtextBox.Size = new Size(262, 23);
            UUIDtextBox.TabIndex = 14;
            // 
            // projLeadCheckBox
            // 
            projLeadCheckBox.AutoSize = true;
            projLeadCheckBox.Location = new Point(21, 142);
            projLeadCheckBox.Margin = new Padding(2, 2, 2, 2);
            projLeadCheckBox.Name = "projLeadCheckBox";
            projLeadCheckBox.Size = new Size(132, 19);
            projLeadCheckBox.TabIndex = 13;
            projLeadCheckBox.Text = "Project Leader Role?";
            projLeadCheckBox.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.Firebrick;
            cancelButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cancelButton.ForeColor = SystemColors.ButtonHighlight;
            cancelButton.Location = new Point(236, 175);
            cancelButton.Margin = new Padding(2, 2, 2, 2);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(183, 30);
            cancelButton.TabIndex = 12;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += cancelButton_Click;
            // 
            // editButton
            // 
            editButton.BackColor = Color.DarkGreen;
            editButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            editButton.ForeColor = SystemColors.ButtonHighlight;
            editButton.Location = new Point(21, 175);
            editButton.Margin = new Padding(2, 2, 2, 2);
            editButton.Name = "editButton";
            editButton.Size = new Size(188, 30);
            editButton.TabIndex = 11;
            editButton.Text = "Edit";
            editButton.UseVisualStyleBackColor = false;
            editButton.Click += editButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(15, 76);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 10;
            label3.Text = "Name";
            // 
            // label
            // 
            label.AutoSize = true;
            label.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label.Location = new Point(15, 35);
            label.Margin = new Padding(2, 0, 2, 0);
            label.Name = "label";
            label.Size = new Size(38, 15);
            label.TabIndex = 9;
            label.Text = "UUID";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(178, 5);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 8;
            label1.Text = "Edit Role";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(15, 114);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 16;
            label2.Text = "Parent Role";
            // 
            // parentRoleTextBox
            // 
            parentRoleTextBox.Location = new Point(157, 110);
            parentRoleTextBox.Margin = new Padding(2, 2, 2, 2);
            parentRoleTextBox.Name = "parentRoleTextBox";
            parentRoleTextBox.Size = new Size(262, 23);
            parentRoleTextBox.TabIndex = 17;
            // 
            // EditRoleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(440, 226);
            Controls.Add(parentRoleTextBox);
            Controls.Add(label2);
            Controls.Add(nameTextBox);
            Controls.Add(UUIDtextBox);
            Controls.Add(projLeadCheckBox);
            Controls.Add(cancelButton);
            Controls.Add(editButton);
            Controls.Add(label3);
            Controls.Add(label);
            Controls.Add(label1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "EditRoleForm";
            Text = "EditRoleForm";
            Load += EditRoleForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nameTextBox;
        private TextBox UUIDtextBox;
        private CheckBox projLeadCheckBox;
        private Button cancelButton;
        private Button editButton;
        private Label label3;
        private Label label;
        private Label label1;
        private Label label2;
        private TextBox parentRoleTextBox;
    }
}