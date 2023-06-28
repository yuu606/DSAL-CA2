namespace DSAL_CA2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            panel3 = new Panel();
            buttonReset = new Button();
            buttonSave = new Button();
            buttonLoad = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label6 = new Label();
            checkBox1 = new CheckBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label5 = new Label();
            label7 = new Label();
            buttonCollapseAll = new Button();
            buttonExpandAll = new Button();
            textBoxConsole = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(27, 28);
            panel1.Name = "panel1";
            panel1.Size = new Size(418, 249);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ButtonHighlight;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Location = new Point(468, 104);
            panel3.Name = "panel3";
            panel3.Size = new Size(791, 618);
            panel3.TabIndex = 2;
            // 
            // buttonReset
            // 
            buttonReset.BackColor = Color.Navy;
            buttonReset.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonReset.ForeColor = SystemColors.ControlLightLight;
            buttonReset.Location = new Point(27, 302);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(141, 34);
            buttonReset.TabIndex = 3;
            buttonReset.Text = "Reset";
            buttonReset.UseVisualStyleBackColor = false;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.RoyalBlue;
            buttonSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonSave.ForeColor = SystemColors.ControlLightLight;
            buttonSave.Location = new Point(174, 302);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(135, 34);
            buttonSave.TabIndex = 4;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = false;
            // 
            // buttonLoad
            // 
            buttonLoad.BackColor = Color.SkyBlue;
            buttonLoad.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonLoad.ForeColor = SystemColors.ControlLightLight;
            buttonLoad.Location = new Point(315, 302);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(130, 34);
            buttonLoad.TabIndex = 5;
            buttonLoad.Text = "Load";
            buttonLoad.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(32, 363);
            label1.Name = "label1";
            label1.Size = new Size(91, 30);
            label1.TabIndex = 6;
            label1.Text = "Console";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(74, 14);
            label2.Name = "label2";
            label2.Size = new Size(280, 25);
            label2.TabIndex = 0;
            label2.Text = "Selected Role Node Information";
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(21, 108);
            label4.Name = "label4";
            label4.Size = new Size(62, 25);
            label4.TabIndex = 2;
            label4.Text = "Name";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(146, 202);
            label6.Name = "label6";
            label6.Size = new Size(95, 25);
            label6.TabIndex = 4;
            label6.Text = "Read-Only";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(21, 149);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(196, 29);
            checkBox1.TabIndex = 5;
            checkBox1.Text = "Project Leader Role?";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(155, 60);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(240, 31);
            textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(155, 108);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(240, 31);
            textBox2.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(476, 22);
            label5.Name = "label5";
            label5.Size = new Size(189, 25);
            label5.TabIndex = 7;
            label5.Text = "Role Node Tree View";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(476, 59);
            label7.Name = "label7";
            label7.Size = new Size(513, 25);
            label7.TabIndex = 8;
            label7.Text = "Right click to perform actions such as edit, remove or add roles";
            // 
            // buttonCollapseAll
            // 
            buttonCollapseAll.BackColor = Color.SkyBlue;
            buttonCollapseAll.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCollapseAll.ForeColor = SystemColors.ControlLightLight;
            buttonCollapseAll.Location = new Point(1127, 28);
            buttonCollapseAll.Name = "buttonCollapseAll";
            buttonCollapseAll.Size = new Size(130, 34);
            buttonCollapseAll.TabIndex = 10;
            buttonCollapseAll.Text = "Collapse All";
            buttonCollapseAll.UseVisualStyleBackColor = false;
            // 
            // buttonExpandAll
            // 
            buttonExpandAll.BackColor = Color.RoyalBlue;
            buttonExpandAll.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonExpandAll.ForeColor = SystemColors.ControlLightLight;
            buttonExpandAll.Location = new Point(986, 28);
            buttonExpandAll.Name = "buttonExpandAll";
            buttonExpandAll.Size = new Size(135, 34);
            buttonExpandAll.TabIndex = 9;
            buttonExpandAll.Text = "Expand All";
            buttonExpandAll.UseVisualStyleBackColor = false;
            // 
            // textBoxConsole
            // 
            textBoxConsole.BackColor = SystemColors.Menu;
            textBoxConsole.Location = new Point(34, 405);
            textBoxConsole.Multiline = true;
            textBoxConsole.Name = "textBoxConsole";
            textBoxConsole.Size = new Size(411, 317);
            textBoxConsole.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1282, 749);
            Controls.Add(textBoxConsole);
            Controls.Add(buttonCollapseAll);
            Controls.Add(buttonExpandAll);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label1);
            Controls.Add(buttonLoad);
            Controls.Add(buttonSave);
            Controls.Add(buttonReset);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Button buttonReset;
        private Button buttonSave;
        private Button buttonLoad;
        private Label label1;
        private TextBox textBox2;
        private TextBox textBox1;
        private CheckBox checkBox1;
        private Label label6;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label5;
        private Label label7;
        private Button buttonCollapseAll;
        private Button buttonExpandAll;
        private TextBox textBoxConsole;
    }
}