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
using System.Xml.Linq;

namespace DSAL_CA2
{
    public partial class EmployeeForm : Form
    {
        DataManager employeeManager;
        EmployeeTreeNode _selectedNode;
        RoleTreeNode _roleTreeStructure;
        private EmployeeTreeNode _employeeTreeStructure;
        private ContextMenuStrip _employeeMenu;
        ToolStripMenuItem _removeMenuItem = new ToolStripMenuItem();
        ToolStripMenuItem _addMenuItem = new ToolStripMenuItem();
        ToolStripMenuItem _updateMenuItem = new ToolStripMenuItem();
        ToolStripMenuItem _swapMenuItem = new ToolStripMenuItem();
        ToolStripMenuItem _editEmployeeDetails = new ToolStripMenuItem();
        ToolStripMenuItem _editRoleReportOff = new ToolStripMenuItem();
        private Data data;

        public EmployeeForm() 
        {
            InitializeComponent();
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            data = new Data();
            employeeManager = new DataManager(data);
            _selectedNode = null;

            //add console text
            textBoxConsole.Text = "Each Employee can have a maximum of 2 employee nodes.";


            data.RoleTreeStructure = _roleTreeStructure;
            _roleTreeStructure = employeeManager.LoadRoleData();
            if (_roleTreeStructure == null)
            {
                MessageBox.Show("Please set up the role hierarchy before setting up the Employee hierarchy");
            }

            data.EmployeeTreeStructure = _employeeTreeStructure;
            _employeeTreeStructure = employeeManager.LoadEmployeeData();
            if (_employeeTreeStructure == null)
            {
                _employeeTreeStructure = employeeManager.generateDefaultEmployeeTree();
                treeViewEmployee.Nodes.Add(_employeeTreeStructure); 
            }
            else
            {
                treeViewEmployee.Nodes.Add(_employeeTreeStructure);
            }

            treeViewEmployee.ExpandAll();
            treeViewEmployee.AfterSelect += employeeNodeTreeView_Click;
            InitializeMenuTreeView();
        }

        public void InitializeMenuTreeView()
        {
            // Create the ContextMenuStrip
            _employeeMenu = new ContextMenuStrip();
            _removeMenuItem.Text = "Remove Employee";
            _addMenuItem.Text = "Add Employee";
            _updateMenuItem.Text = "Edit Employee";
            _swapMenuItem.Text = "Swap Employee";
            _editEmployeeDetails.Text = "Edit Employee Details";
            _editRoleReportOff.Text = "Edit Role/Reporting Officer";

            //add submenu items to update menu item
            _updateMenuItem.DropDownItems.Add("Edit Employee Details", null, (s, e) => EditEmployeeDetails_Click());
            _updateMenuItem.DropDownItems.Add("Edit Role/Reporting Officer", null, (s,e) => EditEmployeeRRO_Click());

            //add event handlers
            _employeeMenu.ItemClicked += new ToolStripItemClickedEventHandler(contextMenu_ItemClicked);
            _employeeMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_Opening);

            //add all tool strip menu items 
            _employeeMenu.Items.AddRange(new ToolStripMenuItem[] { _removeMenuItem, _addMenuItem, _updateMenuItem, _swapMenuItem });
            this.treeViewEmployee.ContextMenuStrip = _employeeMenu;
        }

        public void contextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            _selectedNode = (EmployeeTreeNode)treeViewEmployee.SelectedNode;

            if ((item != null) && (_selectedNode != null))
            {
                if (item.Text == "Swap Employee")
                {
                    Employee employee = _selectedNode.Employee;
                    SwapEmployeeForm swapEmployeeForm = new SwapEmployeeForm();
                    swapEmployeeForm.SwapItemCallback = new SwapEmployeeForm.SwapItemDelegate(this.SwapItemCallbackFn);
                    swapEmployeeForm.ShowDialog(this);
                }
                if (item.Text == "Add Employee")
                { 
                    AddEmployeeForm addEmployeeForm = new AddEmployeeForm();
                    addEmployeeForm.AddItemCallback = new AddEmployeeForm.AddItemDelegate(this.AddItemCallbackFn);
                    addEmployeeForm.ShowDialog(this);
                }
                if (item.Text == "Remove Employee")
                {
                    //check if the team will remain complete after removing the employee 
                    List<RoleTreeNode> roleNodes = new List<RoleTreeNode>();
                    _roleTreeStructure.SearchByRoleName(_selectedNode.ParentEmployeeTreeNode.localRoleTreeNode.Role.Name, ref roleNodes);
                    RoleTreeNode _roleParent = roleNodes[0];
                    EmployeeTreeNode _employeeParent = _selectedNode.ParentEmployeeTreeNode;

                    bool isEqual = employeeManager.IsTeamFull(_roleParent, _employeeParent);

                    //check if employee has been assigned a project
                    //check if employee has subordinates
                    if (_selectedNode.ChildEmployeeTreeNodes.Count > 0 || _selectedNode.Employee.Projects.Count > 0 || isEqual == true)
                    {
                        String title = "Execute Employee Swap";
                        string msg = "The employee can only be removed if there are no subordinates, no assigned projects or " +
                                     "if after removal will still remain a full team. Would you like to swap the employee with " +
                                     "another first?";
                        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                        DialogResult result = MessageBox.Show(msg, title, buttons, MessageBoxIcon.Warning);
                        if (result == DialogResult.OK)
                        {
                            SwapEmployeeForm swapEmployeeForm = new SwapEmployeeForm();
                            swapEmployeeForm.SwapItemCallback = new SwapEmployeeForm.SwapItemDelegate(this.SwapItemCallbackFn);
                            swapEmployeeForm.ShowDialog(this);
                        }
                    }
                    else
                    {
                        MessageBox.Show("confirm removal of employee? Click OK to proceed.");
                        List<EmployeeTreeNode> resultNodes = new List<EmployeeTreeNode>();
                        _employeeParent.SearchByEmployeeName(_selectedNode.Employee.Name, ref resultNodes);
                        Role role = resultNodes[0].localRoleTreeNode.Role;
                        resultNodes[0].Employee.roleList.Remove(role);
                        _employeeParent.DeleteNode(_employeeParent, resultNodes[0]);
                        //_employeeTreeStructure.DeleteNode(_selectedNode.ParentEmployeeTreeNode, _selectedNode);
                        treeViewEmployee.Nodes.Remove(_selectedNode);
                    }

                    employeeManager.SaveData();
                    treeViewEmployee.ExpandAll();
                }
            }

        }//end of contextMenu_ItemClicked

        private void EditEmployeeDetails_Click()
        {
            Employee employee = _selectedNode.Employee;
            EditEmployeeForm editEmployeeForm = new EditEmployeeForm();
            editEmployeeForm.ModifyItemCallback = new EditEmployeeForm.ModifyItemDelegate(this.ModifyDetailsItemCallbackFn);
            editEmployeeForm.ShowDialog(this);
        }

        private void EditEmployeeRRO_Click()
        {
            Employee employee = _selectedNode.Employee;
            EditEmployee2Form editEmployee2Form = new EditEmployee2Form();
            editEmployee2Form.ModifyItem2Callback = new EditEmployee2Form.ModifyItem2Delegate(this.ModifyRROItemCallbackFn);
            editEmployee2Form.ShowDialog(this);
        }

        private void contextMenu_Opening(object sender, CancelEventArgs e)
        {
            _selectedNode = (EmployeeTreeNode)this.treeViewEmployee.SelectedNode;
            
            foreach (ToolStripMenuItem item in _employeeMenu.Items)
            {
                item.Enabled = true;
            }

            if (_selectedNode.Text.Contains("ROOT") == true)
            {
                this._updateMenuItem.Visible = false;
                this._removeMenuItem.Visible = false;
                this._swapMenuItem.Visible = true;
                this._addMenuItem.Visible = true;
            }
            else 
            {
                if (_selectedNode.ParentEmployeeTreeNode.localRoleTreeNode.Role.isProjLead == true)
                {
                    this._updateMenuItem.Visible = true;
                    this._removeMenuItem.Visible = true;
                    this._swapMenuItem.Visible = true;
                    this._addMenuItem.Enabled = false;
                }
                this._updateMenuItem.Visible = true;
                this._removeMenuItem.Visible = true;
                this._swapMenuItem.Visible = true;
                this._addMenuItem.Visible = true;
            }
        }

        //ALL FUNCTIONS
        //------------------------------------------------------------------------------
        private void AddItemCallbackFn(string employeeName, int salary, string role, String reportingOfficer, bool isDummyDataValue, bool isSalaryAcc)
        {
            //search for role via name
            List<RoleTreeNode> roleNodes = new List<RoleTreeNode>();
            _roleTreeStructure.SearchByRoleName(role, ref roleNodes);

            List<EmployeeTreeNode> employeeNodes = new List<EmployeeTreeNode>();
            _employeeTreeStructure.SearchByEmployeeName(reportingOfficer, ref employeeNodes);

            //instantiate new employee object
            Employee newEmployee = new Employee(employeeName);
            newEmployee.Salary = salary;
            newEmployee.roleList.Add(roleNodes[0].Role);
            newEmployee.isDummyData = isDummyDataValue;
            newEmployee.isSalaryAcc = isSalaryAcc;

            //instantiate new employee tree node
            EmployeeTreeNode newEmployeeNode = new EmployeeTreeNode(newEmployee);
            newEmployeeNode.localRoleTreeNode.Role = roleNodes[0].Role;

            if (employeeNodes.Count == 0)
            {
                newEmployee.ReportingOfficer.Add(_employeeTreeStructure.Employee);
                newEmployeeNode.localRO = _employeeTreeStructure.Employee;
            }
            else
            {
                newEmployee.ReportingOfficer.Add(employeeNodes[0].Employee);
                newEmployeeNode.localRO = employeeNodes[0].Employee;
            }

            this._selectedNode.AddChildEmployeeTreeNode(newEmployeeNode);

            //save to data file
            employeeManager.SaveData();
            //expand tree view
            treeViewEmployee.ExpandAll();
        }//end of AddItemCallbackFn method

        private void ModifyDetailsItemCallbackFn(string uuid, string employeeName, int salary, bool isSalaryAcc, bool isDummyData)
        {
            List<EmployeeTreeNode> resultNodes = new List<EmployeeTreeNode>();
            _employeeTreeStructure.SearchByUUID(uuid, ref resultNodes);
            resultNodes[0].Employee.Name = employeeName;
            resultNodes[0].Employee.Salary = salary;
            resultNodes[0].Employee.isSalaryAcc = isSalaryAcc;
            resultNodes[0].Employee.isDummyData = isDummyData;
            string roleText = "";
            int i = 0;
            foreach (Role role in resultNodes[0].Employee.roleList)
            {
                roleText += role.Name;
                if (i == 1)
                {
                    roleText += ", " + role.Name;
                }
                i++;
            }
            string nodeText = resultNodes[0].Employee.Name + " - " + roleText + " (S$" + resultNodes[0].Employee.Salary + ")";
            resultNodes[0].Text = nodeText;
            employeeManager.SaveData();
            treeViewEmployee.ExpandAll();
        }//end of ModifyItemCallbackFn method

        private void ModifyRROItemCallbackFn(string uuid, string role, string reportingOfficer)
        {
            List<EmployeeTreeNode> uuidNodes = new List<EmployeeTreeNode>();
            List<RoleTreeNode> roleNodes = new List<RoleTreeNode>();
            _employeeTreeStructure.SearchByUUID(uuid, ref uuidNodes); //get employee node 
            _roleTreeStructure.SearchByRoleName(role, ref roleNodes); //get new role

            List<EmployeeTreeNode> employeeNodes = new List<EmployeeTreeNode>(); 
            _employeeTreeStructure.SearchByEmployeeName(reportingOfficer, ref employeeNodes); //get new RO node 

            Employee employeeRef = uuidNodes[0].Employee; //get referenced employee
            EmployeeTreeNode newEmployeeTreeNode = new EmployeeTreeNode(employeeRef); //instantiate new employee tree node
            newEmployeeTreeNode.Employee.roleList.Add(roleNodes[0].Role);
            newEmployeeTreeNode.localRoleTreeNode.Role = roleNodes[0].Role; //assign local role
            newEmployeeTreeNode.localRO = employeeNodes[0].Employee; //assign local RO

            string roleText = "";
            int i = 0;
            foreach (Role Role in newEmployeeTreeNode.Employee.roleList)
            {
                if (i == 1)
                {
                    roleText += ", " + Role.Name;
                }
                else
                {
                    roleText = Role.Name;
                }
                i++;
            }
            string nodeText = newEmployeeTreeNode.Employee.Name + " - " + roleText + " (S$" + newEmployeeTreeNode.Employee.Salary + ")";
            newEmployeeTreeNode.Text = nodeText;
            uuidNodes[0].Text = nodeText;
            employeeNodes[0].AddChildEmployeeTreeNode(newEmployeeTreeNode); //add new employee tree node 

            employeeManager.SaveData();
            treeViewEmployee.ExpandAll();
        }

        private void SwapItemCallbackFn(int index2, string uuid2)
        {
            //get main form selected node details 
            EmployeeTreeNode treeNode = (EmployeeTreeNode)treeViewEmployee.SelectedNode;
            string uuid = treeNode.Employee.UUID;
            int index1 = treeNode.Index;

            //get main form selected node 
            List<EmployeeTreeNode> resultNodes = new List<EmployeeTreeNode>();
            _employeeTreeStructure.SearchByUUID(uuid, ref resultNodes);
            EmployeeTreeNode node1 = resultNodes[0];

            //get swap employee form selected node 
            List<EmployeeTreeNode> resultNodes2 = new List<EmployeeTreeNode>();
            _employeeTreeStructure.SearchByUUID(uuid2, ref resultNodes2);
            EmployeeTreeNode node2 = resultNodes2[0];

            EmployeeTreeNode parent1 = node1.ParentEmployeeTreeNode;
            EmployeeTreeNode parent2 = node2.ParentEmployeeTreeNode;
            int count1 = parent1.Nodes.Count;
            int count2 = parent2.Nodes.Count;

            //get both selected nodes' roles 
            Role role1 = node1.localRoleTreeNode.Role;
            Role role2 = node2.localRoleTreeNode.Role;

            //swap roles in role list
            node1.Employee.roleList.Remove(role1);
            node1.Employee.roleList.Add(role2);
            node2.Employee.roleList.Remove(role2);
            node2.Employee.roleList.Add(role1);

            //swap local role tree node
            RoleTreeNode temp = new RoleTreeNode();
            temp = node1.localRoleTreeNode;
            node1.localRoleTreeNode = node2.localRoleTreeNode;
            node2.localRoleTreeNode = temp;

            //swap parents 
            
            parent1.ChildEmployeeTreeNodes.Remove(node1);
            parent1.ChildEmployeeTreeNodes.Add(node2);
            parent2.ChildEmployeeTreeNodes.Remove(node2);
            parent2.ChildEmployeeTreeNodes.Add(node1);

            node1.ParentEmployeeTreeNode = parent2;
            node2.ParentEmployeeTreeNode = parent1;

            TreeNode parent = (TreeNode)node2.ParentEmployeeTreeNode;

            //get node list
            List<EmployeeTreeNode> swappedNodes = new();
            swappedNodes.Add(node1);
            swappedNodes.Add(node2);

            //set node text
            foreach (EmployeeTreeNode node in swappedNodes)
            {
                node.setText();
            }

            //for (int k = 0; k < 2; k++)
            //{
            //    String nodeText = "";
            //    string roleText = "";
            //    int i = 0;
            //    if (swappedNodes[k].Employee.roleList.Count > 1)
            //    {
            //        //populate project string
            //        foreach (Role role in swappedNodes[k].Employee.roleList)
            //        {
            //            roleText += role.Name;
            //            if (i == 1)
            //            {
            //                roleText += ", " + role.Name;
            //            }
            //            i++;
            //        }
            //    }
            //    else
            //    {
            //        roleText = swappedNodes[k].Employee.roleList[0].Name;
            //    }
            //    nodeText = swappedNodes[k].Employee.Name + " - " + roleText + " (S$" + swappedNodes[k].Employee.Salary + ")";
            //    swappedNodes[k].Text = nodeText;
            //}

            //swap tree node in tree view 
            parent2.Nodes.RemoveAt(index2);
            parent1.Nodes.RemoveAt(index1);
            parent2.Nodes.Insert(index2, node1);
            parent1.Nodes.Insert(index1, node2);

            employeeManager.SaveData();
            treeViewEmployee.ExpandAll();
        }

        private void employeeNodeTreeView_Click(object sender, TreeViewEventArgs e)
        {
            //get employeetreenode of selected node 
            EmployeeTreeNode employeeNode = (EmployeeTreeNode)this.treeViewEmployee.SelectedNode;
            string projStr = "No Projects";

            //check whether employee has projects assigned 
            int i = 0;
            if (employeeNode.Employee.Projects.Count > 0)
            {
                projStr = "";
                //populate project string
                foreach (Project project in employeeNode.Employee.Projects)
                {
                    projStr += project.projName;
                    if (i > 1)
                    {
                        projStr += ", " + project.projName;
                    }
                }
                i++;
            }

            //check whether employee is dummy data 
            if (employeeNode.Employee.isDummyData == false)
            {
                dummyDataCheckBox.Checked = false;
            }
            else
            {
                dummyDataCheckBox.Checked = true;
            }

            //check whether employee's salary is accountable 
            if (employeeNode.Employee.isSalaryAcc == false)
            {
                salaryAccCheckBox.Checked = false;
            }
            else
            {
                salaryAccCheckBox.Checked = true;
            }

            int localIndex = employeeNode.localIndex;
            //populate read-only textboxes
            nameTextBox.Text = employeeNode.Employee.Name;
            roleTextBox.Text = employeeNode.Employee.roleList[localIndex].Name; //TO EDIT        
            projectsTextBox.Text = projStr;
            if (employeeNode.Text.Contains("ROOT") == true)
            {
                String na = "N.A.";
                reportingOfficerTextBox.Text = na;
                salaryTextBox.Text = na;
                uuidTextBox.Text = "ROOT";
            }
            else
            {
                salaryTextBox.Text = employeeNode.Employee.Salary.ToString();
                reportingOfficerTextBox.Text = employeeNode.Employee.ReportingOfficer[localIndex].Name;
                uuidTextBox.Text = employeeNode.Employee.UUID;
            }

        }
        //--------------------------------------------------------------------------
        //END OF FUNCTIONS

        //Reset button event handler 
        private void buttonReset_Click(object sender, EventArgs e)
        {
            treeViewEmployee.Nodes.Clear();
        }

        //Save button event handler 
        private void buttonSave_Click(object sender, EventArgs e)
        {
            employeeManager.SaveData();
            MessageBox.Show("Employee hierarchy simulation has been successfully saved");
        }

        //Load button event handler 
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            _employeeTreeStructure = employeeManager.LoadEmployeeData(); // call load role data operator
            if (_employeeTreeStructure == null)
            {
                MessageBox.Show("You have not saved any progress");
            }
            else
            {
                this.treeViewEmployee.Nodes.Clear(); //clear previous tree nodes (if any)
                this.treeViewEmployee.Nodes.Add(_employeeTreeStructure); //add loaded role tree structure 
                this.treeViewEmployee.ExpandAll(); // expand tree view 
            }
        }
        //Expand all nodes in employee tree view event handler 
        private void buttonExpandAll_Click(object sender, EventArgs e)
        {
            treeViewEmployee.ExpandAll();
        }

        //Collapse all nodes in employee tree view event handler 
        private void buttonCollapseAll_Click(object sender, EventArgs e)
        {
            treeViewEmployee.CollapseAll();
        }
    }
}
