using DSAL_CA1.Classes;
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
    public partial class EditRoleForm : Form
    {
        public delegate void ModifyItemDelegate(string uuid, string roleName, bool isProjLead);
        public ModifyItemDelegate ModifyItemCallback;

        public EditRoleForm()
        {
            InitializeComponent();
        }

        public EditRoleForm(string uuid, bool isProjLead)
        {
            InitializeComponent();
            this.UUIDtextBox.Text = uuid;
            this.projLeadCheckBox.Checked = isProjLead;
        }

        private void EditRoleForm_Load(object sender, EventArgs e)
        {
            RoleTreeNode selectedNode = (RoleTreeNode)((RoleForm)Owner.ActiveMdiChild).treeViewRole.SelectedNode;
            if (selectedNode.ParentRoleTreeNode.Role.isProjLead == true)
            {
                projLeadCheckBox.Enabled = false;
            }
            this.parentRoleTextBox.Text = selectedNode.Parent.Text;
            this.nameTextBox.Text = selectedNode.Text;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text.Trim();
            string uuid = UUIDtextBox.Text.Trim();
            bool projLead = false;
            if (projLeadCheckBox.Checked == true)
            {
                projLead = true;
            }
            if (name != "")
            {
                ModifyItemCallback(uuid, name, projLead);
                this.DialogResult = DialogResult.OK;

            }
        }
    }
}
