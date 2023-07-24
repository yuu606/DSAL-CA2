using DSAL_CA1.Classes;
using DSAL_CA2.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DSAL_CA2
{
    public partial class RoleForm : Form
    {
        public AddRoleForm addRoleForm;
        public EditRoleForm editRoleForm;
        DataManager roleManager;
        private Data data;
        RoleTreeNode _selectedNode;
        RoleTreeNode _roleTreeStructure;
        private ContextMenuStrip _roleMenu;
        ToolStripMenuItem _removeMenuItem = new ToolStripMenuItem();
        ToolStripMenuItem _addMenuItem = new ToolStripMenuItem();
        ToolStripMenuItem _updateMenuItem = new ToolStripMenuItem();

        public RoleForm()
        {
            InitializeComponent();
        }

        private void RoleForm_Load(object sender, EventArgs e)
        {
            data = new Data();
            _selectedNode = null;
            textBoxConsole.Text = "Roles cannot be added if there are projects assigned." + Environment.NewLine
                + "Roles cannot be removed if there are employees under it." + Environment.NewLine
                + "Only one level of role is allowed under a project leader role.";

            roleManager = new DataManager(data);
            data.RoleTreeStructure = new();

            _roleTreeStructure = data.RoleTreeStructure;
            _roleTreeStructure = roleManager.LoadRoleData();
            if (_roleTreeStructure == null)
            {
                treeViewRole.Nodes.Add(roleManager.generateDefaultRoleTree());
            }
            else
            {
                treeViewRole.Nodes.Add(_roleTreeStructure);
            }
            treeViewRole.AfterSelect += roleNodeTreeView_Click;
            InitializeMenuTreeView();
        }

        public void InitializeMenuTreeView()
        {
            // Create the ContextMenuStrip.
            _roleMenu = new ContextMenuStrip();
            _removeMenuItem.Text = "Remove Role";
            _addMenuItem.Text = "Add Role";
            _updateMenuItem.Text = "Edit Role";


            _roleMenu.ItemClicked += new ToolStripItemClickedEventHandler(contextMenu_ItemClicked);
            _roleMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_Opening);

            //Add the menu items to the menu.
            _roleMenu.Items.AddRange(new ToolStripMenuItem[] { _removeMenuItem, _addMenuItem, _updateMenuItem });
            //Set the ContextMenuStrip property to the ContextMenuStrip.
            this.treeViewRole.ContextMenuStrip = _roleMenu;
        }
        public void contextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            _selectedNode = (RoleTreeNode)treeViewRole.SelectedNode;
            if ((item != null) && (_selectedNode != null))
            {
                if (item.Text == "Edit Role")
                {
                    Role role = _selectedNode.Role;
                    EditRoleForm editRoleForm = new EditRoleForm(role.UUID, role.isProjLead);
                    editRoleForm.ModifyItemCallback = new EditRoleForm.ModifyItemDelegate(this.ModifyItemCallbackFn);
                    editRoleForm.ShowDialog(this);
                }
                if (item.Text == "Add Role")
                {
                    Role role = _selectedNode.Role;
                    // if (rolenode info is being used by projects form) { Message.Show(""); }
                    AddRoleForm addRoleForm = new AddRoleForm();
                    addRoleForm.AddItemCallback = new AddRoleForm.AddItemDelegate(this.AddItemCallbackFn);
                    addRoleForm.ShowDialog(this);
                }
                if (item.Text == "Remove Role")
                {
                    //if (rolenode info is being used by employee node) { Message.Show("Unable to delete selected role. There are currently employees under the selected role"); }
                    MessageBox.Show("Are you sure you want to delete the role? Child roles will also be deleted.");
                    roleManager.RoleTreeStructure.DeleteNode(_selectedNode.ParentRoleTreeNode, _selectedNode);
                    treeViewRole.Nodes.Remove(_selectedNode);
                }
            }

        }//end of contextMenu_ItemClicked

        private void contextMenu_Opening(object sender, CancelEventArgs e)
        {
            _selectedNode = (RoleTreeNode)this.treeViewRole.SelectedNode;
            //Enable all menu items first. Then disable the menu items which are not appropriate
            foreach (ToolStripMenuItem item in _roleMenu.Items)
            {
                item.Enabled = true;
            }

            if (_selectedNode.Text == "ROOT")
            {
                this._updateMenuItem.Visible = false;
                this._removeMenuItem.Visible = false;
                this._addMenuItem.Visible = true;
            }
            if (_selectedNode.Text != "ROOT")
            {
                this._updateMenuItem.Visible = true;
                this._removeMenuItem.Visible = true;
                this._addMenuItem.Visible = true;

                if (_selectedNode.ParentRoleTreeNode.Role.isProjLead == true)
                {
                    this._updateMenuItem.Visible = true;
                    this._removeMenuItem.Visible = true;
                    this._addMenuItem.Visible = false;
                }
            }
        }

        private void ModifyItemCallbackFn(string uuid, string roleName, bool isProjLead)
        {
            List<RoleTreeNode> resultNodes = new List<RoleTreeNode>();
            //Find the RoleTreeNode object which has the role object containing the matching
            //UUID value.
            roleManager.RoleTreeStructure.SearchByUUID(uuid, ref resultNodes);
            //By right, there should only be one RoleTreeNode object found. Therefore,
            //I directly point to the first element inside the List to access the Role object's Name and Text property data.
            resultNodes[0].Role.Name = roleName;
            resultNodes[0].Text = roleName;
            resultNodes[0].Role.isProjLead = isProjLead;
            if (isProjLead == true)
            {
                resultNodes[0].IsLeaf = true;
            }
            textBoxConsole.Text = "Role Edited:" + Environment.NewLine + " Name:" + roleName;
            roleManager.SaveRoleData();
        }//end of ModifyItemCallbackFn method

        private void AddItemCallbackFn(string roleName, bool projLead)
        {
            Role newRole = new Role(roleName);
            newRole.isProjLead = projLead;
            RoleTreeNode newNode = new RoleTreeNode(newRole);
            this._selectedNode.AddChildRoleTreeNode(newNode);
            treeViewRole.ExpandAll();
            textBoxConsole.Text = "Role Added:" + Environment.NewLine + " Name:" + roleName;
            roleManager.SaveRoleData();
        }//end of AddItemCallbackFn method

        private void buttonReset_Click(object sender, EventArgs e)
        {
            this.treeViewRole.Nodes.Clear();
            this.treeViewRole.Nodes.Add(roleManager.generateDefaultRoleTree());
            MessageBox.Show("Hierarchy simulation has been reset");
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            roleManager.saveData();
            MessageBox.Show("Hierarchy simulation has been successfully saved");
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            _roleTreeStructure = roleManager.LoadRoleData();
            if (_roleTreeStructure == null)
            {
                MessageBox.Show("You have not saved any progress");
            }
            else
            {
                this.treeViewRole.Nodes.Clear();
                this.treeViewRole.Nodes.Add(_roleTreeStructure);
                this.treeViewRole.ExpandAll();
            }
        }

        private void buttonExpandAll_Click(object sender, EventArgs e)
        {
            this.treeViewRole.ExpandAll();
        }

        private void buttonCollapseAll_Click(object sender, EventArgs e)
        {
            this.treeViewRole.CollapseAll();
        }

        void roleNodeTreeView_Click(object sender, EventArgs e)
        {
            RoleTreeNode roleNode = (RoleTreeNode)this.treeViewRole.SelectedNode;
            uuidTextBox.Text = roleNode.Role.UUID.ToString();
            nameTextBox.Text = roleNode.Role.Name.ToString();
            projLeadCheckBox.Checked = roleNode.Role.isProjLead;
        }
    }
}
