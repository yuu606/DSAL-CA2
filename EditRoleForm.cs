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
        private Role _oneRole;
        public delegate void ModifyItemDelegate(string uuid, string roleName);
        public ModifyItemDelegate ModifyItemCallback;

        public EditRoleForm()
        {
            InitializeComponent();
        }

        public EditRoleForm(string uuid, string roleName)
        {
            InitializeComponent();
            this._oneRole = new Role();
            this._oneRole.Name = roleName;
            this._oneRole.UUID = uuid;
        }

        private void EditRoleForm_Load(object sender, EventArgs e)
        {
            this.UUIDtextBox.Text = this._oneRole.UUID.ToString();
            TreeNode selectedNode = ((RoleForm)Owner.ActiveMdiChild).treeViewRole.SelectedNode;
            this.parentRoleTextBox.Text = selectedNode.Text;
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
                ModifyItemCallback(uuid, name);
                this.DialogResult = DialogResult.OK;

            }
        }
    }
}
