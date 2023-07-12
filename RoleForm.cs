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
        RoleTreeNode _selectedNode;
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
            roleManager = new DataManager();
            _selectedNode = null;
            treeViewRole.Nodes.Add(roleManager.generateDefaultRoleTree());
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

            //Reference: https://stackoverflow.com/questions/5789023/how-to-respond-to-a-contextmenustrip-item-click
            //When the menu item is clicked, need the logic inside the contextMenu_ItemClicked method to
            //decide on operations such as make a form interface to appear for update, make a dialog interface appear to confirm delete etc.
            _roleMenu.ItemClicked += new ToolStripItemClickedEventHandler(contextMenu_ItemClicked);
            //When the menu is opening, need some logic to inspect the selected node's info so that
            //the correct menu item is displayed or enabled. The logic is defined inside the contextMenu_Opening method
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
                {   /**** A sample code which is frequently used to get a parent form work with a child form ****/
                    Role role = _selectedNode.Role;
                    //fur stands for form update role (ran out of naming ideas)
                    EditRoleForm editRoleForm = new EditRoleForm(role.UUID, role.Name);
                    editRoleForm.ModifyItemCallback = new EditRoleForm.ModifyItemDelegate(this.ModifyItemCallbackFn);
                    editRoleForm.ShowDialog(this);
                }
                if (item.Text == "Add Role")
                {
                    //MessageBox.Show("No modal form created to service the add role operation.");
                    Role role = _selectedNode.Role;
                    AddRoleForm addRoleForm = new AddRoleForm();
                    addRoleForm.AddItemCallback = new AddRoleForm.AddItemDelegate(this.AddItemCallbackFn);
                    addRoleForm.ShowDialog(this);
                }
                if (item.Text == "Remove Role")
                {
                    MessageBox.Show("No modal form created to service the remove operation.");
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
            }
            if (_selectedNode.Text != "ROOT")
            {
                this._updateMenuItem.Visible = true;
                this._removeMenuItem.Visible = true;
                
                if (_selectedNode.ParentRoleTreeNode.Role.isProjLead == true)
                {
                    this._updateMenuItem.Visible = false;
                    this._removeMenuItem.Visible = false;
                    this._addMenuItem.Visible = false;
                }
            }
        }

        private void ModifyItemCallbackFn(string uuid, string roleName)
        {
            List<RoleTreeNode> resultNodes = new List<RoleTreeNode>();
            //Find the RoleTreeNode object which has the role object containing the matching
            //UUID value.
            roleManager.RoleTreeStructure.SearchByUUID(uuid, ref resultNodes);
            //By right, there should only be one RoleTreeNode object found. Therefore,
            //I directly point to the first element inside the List to access the Role object's Name and Text property data.
            resultNodes[0].Role.Name = roleName;
            resultNodes[0].Text = roleName;

        }//end of ModifyItemCallbackFn method

        private void AddItemCallbackFn(string uuid, string roleName, bool projLead)
        {
            Role newRole = new Role(roleName);
            newRole.isProjLead = projLead;
            RoleTreeNode newNode = new RoleTreeNode(newRole);
            this._selectedNode.AddChildRoleTreeNode(newNode);
            treeViewRole.ExpandAll();
        }//end of AddItemCallbackFn method

        private void buttonReset_Click(object sender, EventArgs e)
        {
            this.treeViewRole.Nodes.Clear();
            MessageBox.Show("Hierarchy simulation has been reset");
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            roleManager.SaveRoleData();
            MessageBox.Show("Hierarchy simulation has been successfully saved");
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            roleManager.LoadRoleData();
            this.treeViewRole.Nodes.Clear();
            this.treeViewRole.Nodes.Add(roleManager.RoleTreeStructure);
            this.treeViewRole.ExpandAll();
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
        }
    }
}
