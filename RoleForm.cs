using DSAL_CA1.Classes;
using DSAL_CA2.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
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
        EmployeeTreeNode _employeeTreeStructure;
        private ContextMenuStrip _roleMenu;
        ToolStripMenuItem _removeMenuItem = new ToolStripMenuItem();
        ToolStripMenuItem _addMenuItem = new ToolStripMenuItem();
        ToolStripMenuItem _updateMenuItem = new ToolStripMenuItem();

        public RoleForm()
        {
            InitializeComponent();
        }

        //Role form load 
        //---------------------------------------------------------------------------------------------
        private void RoleForm_Load(object sender, EventArgs e)
        {
            //instantiate data  and data manager obj
            data = new Data();
            roleManager = new DataManager(data);
            _selectedNode = null;

            //add console text
            textBoxConsole.Text = "Roles cannot be added if there are projects assigned." + Environment.NewLine
                + "Roles cannot be removed if there are employees under it." + Environment.NewLine
                + "Only one level of role is allowed under a project leader role.";

            //load previously saved role hierarchy data (if any)
            data.RoleTreeStructure = _roleTreeStructure;
            _roleTreeStructure = roleManager.LoadRoleData();
            //if no role hierarchy data was saved, generate default role tree structure 
            if (_roleTreeStructure == null)
            {
                _roleTreeStructure = roleManager.generateDefaultRoleTree();
                treeViewRole.Nodes.Add(_roleTreeStructure);
            }
            else //if previous saved data found, add nodes to tree view
            {
                treeViewRole.Nodes.Add(_roleTreeStructure);
            }

            data.EmployeeTreeStructure = roleManager.LoadEmployeeData();
            _employeeTreeStructure = data.EmployeeTreeStructure;

            treeViewRole.ExpandAll(); //expand tree view 
            treeViewRole.AfterSelect += roleNodeTreeView_Click; //add tree view node onclick event handler
            InitializeMenuTreeView(); //initialize tree view's menu
        }
        //---------------------------------------------------------------------------------------------

        //Initialize tree view menu function
        //---------------------------------------------------------------------------------------------
        public void InitializeMenuTreeView()
        {
            //instantiate context menu strip obj
            _roleMenu = new ContextMenuStrip();
            //add role menu item text
            _removeMenuItem.Text = "Remove Role";
            _addMenuItem.Text = "Add Role";
            _updateMenuItem.Text = "Edit Role";

            //add role menu item onclick event handler 
            _roleMenu.ItemClicked += new ToolStripItemClickedEventHandler(contextMenu_ItemClicked);
            //add role menu item opening logic
            _roleMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_Opening);

            //Add the menu items to the menu.
            _roleMenu.Items.AddRange(new ToolStripMenuItem[] { _removeMenuItem, _addMenuItem, _updateMenuItem });
            //Set the ContextMenuStrip property to the ContextMenuStrip.
            this.treeViewRole.ContextMenuStrip = _roleMenu;
        }
        //---------------------------------------------------------------------------------------------

        //menu item onclick event handler 
        //---------------------------------------------------------------------------------------------
        public void contextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem; //get clicked menu item 
            _selectedNode = (RoleTreeNode)treeViewRole.SelectedNode; //get selected node cast to role tree node 
            if ((item != null) && (_selectedNode != null))
            {
                if (item.Text == "Edit Role") //if item is edit role
                {
                    Role role = _selectedNode.Role; //get selected node's role obj
                    EditRoleForm editRoleForm = new EditRoleForm(role.UUID, role.isProjLead); //instantiate edit role form obj
                    editRoleForm.ModifyItemCallback = new EditRoleForm.ModifyItemDelegate(this.ModifyItemCallbackFn); //edit role item callback
                    editRoleForm.ShowDialog(this);
                }
                if (item.Text == "Add Role") //if item is add role 
                {
                    Role role = _selectedNode.Role; //get selected node's role obj
                    List<EmployeeTreeNode> resultNodes = new List<EmployeeTreeNode>();
                    _employeeTreeStructure.usedByProject(role, ref resultNodes);
                    if (resultNodes.Count != 0)
                    {
                        MessageBox.Show("The role structure is currently being used, you are not allowed to add a role");
                    }
                    else
                    {
                        AddRoleForm addRoleForm = new AddRoleForm(); //instantiate add role form obj
                        addRoleForm.AddItemCallback = new AddRoleForm.AddItemDelegate(this.AddItemCallbackFn); //add role item callback
                        addRoleForm.ShowDialog(this);
                    }
                }
                if (item.Text == "Remove Role") //if item is remove role 
                {
                    List<EmployeeTreeNode> resultNodes = new List<EmployeeTreeNode>();
                    _employeeTreeStructure.doesRoleExist(_selectedNode.Role, ref resultNodes);
                    if (resultNodes.Count != 0)
                    {
                        MessageBox.Show("The role structure is currently being used by employees, you are not allowed to remove the role");
                    }
                    else
                    {
                        MessageBox.Show("Are you sure you want to delete the role? Child roles will also be deleted.");
                        _roleTreeStructure.DeleteNode(_selectedNode.ParentRoleTreeNode, _selectedNode); //delete node from actual role tree structure 
                        treeViewRole.Nodes.Remove(_selectedNode); //remove node from role tree view
                    }
                } 
            }

        }
        //---------------------------------------------------------------------------------------------

        //menu opening event handler 
        //---------------------------------------------------------------------------------------------
        private void contextMenu_Opening(object sender, CancelEventArgs e)
        {
            _selectedNode = (RoleTreeNode)this.treeViewRole.SelectedNode;
            //Enable all menu items first. Then disable the menu items which are not appropriate
            foreach (ToolStripMenuItem item in _roleMenu.Items)
            {
                item.Enabled = true;
            }

            if (_selectedNode.Text == "ROOT") //if selected node is root node 
            {
                this._updateMenuItem.Visible = false;
                this._removeMenuItem.Visible = false;
                this._addMenuItem.Visible = true;
            }
            if (_selectedNode.Text != "ROOT") //else
            {
                this._updateMenuItem.Visible = true;
                this._removeMenuItem.Visible = true;
                this._addMenuItem.Visible = true;

                if (_selectedNode.ParentRoleTreeNode.Role.isProjLead == true) //if selected node's parent node is set to a project leader 
                {
                    this._updateMenuItem.Visible = true;
                    this._removeMenuItem.Visible = true;
                    this._addMenuItem.Visible = false;
                }
            }
        }
        //---------------------------------------------------------------------------------------------

        //modify role item callback function
        //---------------------------------------------------------------------------------------------
        private void ModifyItemCallbackFn(string uuid, string roleName, bool isProjLead)
        {
            List<RoleTreeNode> resultNodes = new List<RoleTreeNode>(); //instantiate role tree node list for search by uuid operator 
            _roleTreeStructure.SearchByUUID(uuid, ref resultNodes); //search for specific node we want to modify

            string oldRoleName = "Backend Developer";

            resultNodes[0].Role.Name = roleName; //set updated role name 
            resultNodes[0].Text = roleName; //set updated role name for tree view node text
            resultNodes[0].Role.isProjLead = isProjLead; //set updated isProjLead bool

            List<EmployeeTreeNode> employeeNodes = new List<EmployeeTreeNode>(); //instantiate employee node list for search by employee role name operator 
            _employeeTreeStructure.SearchByEmployeeRole(oldRoleName, ref employeeNodes); //search for specific employee node we wish to update 
            employeeNodes[0].localRoleTreeNode.Role = resultNodes[0].Role;

            if (employeeNodes.Count > 0)//check if employeeNode was found 
            {
                foreach (EmployeeTreeNode employeeNode in employeeNodes)
                {
                    int i = 0;
                    foreach (Role role in employeeNode.Employee.roleList)
                    {
                        if (role.Name == oldRoleName)
                        {
                            employeeNode.Employee.roleList[i].Name = roleName;
                            employeeNode.Employee.roleList[i].isProjLead = isProjLead;
                            employeeNode.localRoleTreeNode = resultNodes[0];
                        }
                        i++;
                    }
                }
            }

            textBoxConsole.Text = "Role Edited:" + Environment.NewLine + " Name:" + roleName; //update console text
            roleManager.SaveData(); //save role data 
        }
        //---------------------------------------------------------------------------------------------

        //add role item callback function
        //---------------------------------------------------------------------------------------------
        private void AddItemCallbackFn(string roleName, bool projLead)
        {
            Role newRole = new Role(roleName); //instantiate new role obj
            newRole.isProjLead = projLead; //set isProjLead bool

            RoleTreeNode newNode = new RoleTreeNode(newRole); //instantiate new role tree node obj
            this._selectedNode.AddChildRoleTreeNode(newNode); //add role tree node obj to parent node's list of child nodes 

            treeViewRole.ExpandAll(); // expand tree view 
            textBoxConsole.Text = "Role Added:" + Environment.NewLine + " Name:" + roleName; //update console text
            roleManager.SaveData(); //save role data 
        }
        //---------------------------------------------------------------------------------------------

        //Reset button onclick handler 
        //---------------------------------------------------------------------------------------------
        private void buttonReset_Click(object sender, EventArgs e)
        {
            this.treeViewRole.Nodes.Clear(); //clear all previous tree nodes (if any)
            this.treeViewRole.Nodes.Add(roleManager.generateDefaultRoleTree()); //set up default tree view structure 
            MessageBox.Show("Hierarchy simulation has been reset");
        }
        //---------------------------------------------------------------------------------------------

        //Save button onclick handler 
        //---------------------------------------------------------------------------------------------
        private void buttonSave_Click(object sender, EventArgs e)
        {
            roleManager.SaveData(); //call save role data operator 
            MessageBox.Show("Hierarchy simulation has been successfully saved");
        }
        //---------------------------------------------------------------------------------------------

        //Load button onclick handler 
        //---------------------------------------------------------------------------------------------
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            _roleTreeStructure = roleManager.LoadRoleData(); // call load role data operator
            if (_roleTreeStructure == null) 
            {
                MessageBox.Show("You have not saved any progress");
            }
            else
            {
                this.treeViewRole.Nodes.Clear(); //clear previous tree nodes (if any)
                this.treeViewRole.Nodes.Add(_roleTreeStructure); //add loaded role tree structure 
                this.treeViewRole.ExpandAll(); // expand tree view 
            }
        }
        //---------------------------------------------------------------------------------------------

        //Expand all button onclick handler 
        //---------------------------------------------------------------------------------------------
        private void buttonExpandAll_Click(object sender, EventArgs e)
        {
            this.treeViewRole.ExpandAll();
        }
        //---------------------------------------------------------------------------------------------

        //Collapse all button onclick handler 
        //---------------------------------------------------------------------------------------------
        private void buttonCollapseAll_Click(object sender, EventArgs e)
        {
            this.treeViewRole.CollapseAll();
        }
        //---------------------------------------------------------------------------------------------

        //Role tree view node onclick event handler 
        //---------------------------------------------------------------------------------------------
        void roleNodeTreeView_Click(object sender, EventArgs e)
        {
            RoleTreeNode roleNode = (RoleTreeNode)this.treeViewRole.SelectedNode; //get selected node as role tree node 
            uuidTextBox.Text = roleNode.Role.UUID.ToString(); //set uuid text
            nameTextBox.Text = roleNode.Role.Name.ToString(); //set role name text
            projLeadCheckBox.Checked = roleNode.Role.isProjLead; //set project leader checkbox state
        }
        //---------------------------------------------------------------------------------------------
    }
}
