﻿using DSAL_CA1.Classes;
using DSAL_CA2.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSAL_CA2
{
    public partial class AddRoleForm : Form
    {
        public delegate void AddItemDelegate(string roleName, bool projLead);
        public AddItemDelegate AddItemCallback;

        public AddRoleForm()
        {
            InitializeComponent();
        }

        private void AddRoleForm_Load(object sender, EventArgs e)
        {
            RoleTreeNode selectedNode = (RoleTreeNode)((RoleForm)Owner.ActiveMdiChild).treeViewRole.SelectedNode;
            this.parentRoleTextBox.Text = selectedNode.Text;
            if (selectedNode.Role.isProjLead == true)
            {
                projLeadCheckBox.Enabled = false;
            }
            
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text.Trim();
            bool projLead = false;
            if (projLeadCheckBox.Checked == true)
            {
                projLead = true;
            }
            if (name != "")
            {
                AddItemCallback(name, projLead);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
