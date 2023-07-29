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

            _roleTreeStructure = employeeManager.LoadRoleData();
            if (_roleTreeStructure == null)
            {
                MessageBox.Show("Please set up the role hierarchy before setting up the Employee hierarchy");
            }

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
            employeeManager.SaveEmployeeData();
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
            _updateMenuItem.DropDownItems.Add(_editEmployeeDetails);
            _updateMenuItem.DropDownItems.Add(_editRoleReportOff);

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
                if (item.Text == "Edit Employee Details")
                {
                    Employee employee = _selectedNode.Employee;
                    EditEmployeeForm editEmployeeForm = new EditEmployeeForm();
                    editEmployeeForm.ModifyItemCallback = new EditEmployeeForm.ModifyItemDelegate(this.ModifyDetailsItemCallbackFn);
                    editEmployeeForm.ShowDialog(this);
                }
                if (item.Text == "Edit Role/Reporting Officer")
                {
                    Employee employee = _selectedNode.Employee;
                    EditEmployee2Form editEmployee2Form = new EditEmployee2Form();
                    editEmployee2Form.ModifyItem2Callback = new EditEmployee2Form.ModifyItem2Delegate(this.ModifyRROItemCallbackFn);
                    editEmployee2Form.ShowDialog(this);

                }
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
                    _roleTreeStructure.SearchByRoleName(_selectedNode.ParentEmployeeTreeNode.Name, ref roleNodes);
                    RoleTreeNode _roleParent = roleNodes[0];

                    EmployeeTreeNode _employeeParent = employeeManager.CopyTreeNode(_selectedNode.ParentEmployeeTreeNode);
                    List<EmployeeTreeNode> resultNodes = new List<EmployeeTreeNode>();
                    _employeeParent.SearchByEmployeeName(_selectedNode.Employee.Name, ref resultNodes);
                    _employeeParent.DeleteNode(_employeeParent, resultNodes[0]);

                    bool isEqual = employeeManager.IsTeamFull(_roleParent, _employeeParent);

                    //check if employee has been assigned a project
                    //check if employee has subordinates
                    if (_selectedNode.ChildEmployeeTreeNodes.Count > 0 || _selectedNode.Employee.Projects.Count > 0 || isEqual == false)
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
                        _employeeTreeStructure.DeleteNode(_selectedNode.ParentEmployeeTreeNode, _selectedNode);
                        treeViewEmployee.Nodes.Remove(_selectedNode);
                    }
                }
            }

        }//end of contextMenu_ItemClicked

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
                if (_selectedNode.IsLeaf)
                {
                    this._updateMenuItem.Visible = true;
                    this._removeMenuItem.Visible = true;
                    this._swapMenuItem.Visible = true;
                    this._addMenuItem.Visible = false;
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
            newEmployee.ReportingOfficer.Add(employeeNodes[0].Employee);
            newEmployee.isDummyData = isDummyDataValue;
            newEmployee.isSalaryAcc = isSalaryAcc;

            //instantiate new employee tree node
            EmployeeTreeNode newEmployeeNode = new EmployeeTreeNode(newEmployee);
            newEmployeeNode.localRole = roleNodes[0].Role;
            newEmployeeNode.localRO = employeeNodes[0].Employee;
            this._selectedNode.AddChildEmployeeTreeNode(newEmployeeNode);

            //save to data file
            employeeManager.SaveEmployeeData();
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
            resultNodes[0].Text = employeeName;
            employeeManager.SaveEmployeeData();
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
            newEmployeeTreeNode.localRole = roleNodes[0].Role; //assign local role
            newEmployeeTreeNode.localRO = employeeNodes[0].Employee; //assign local RO
            employeeNodes[0].AddChildEmployeeTreeNode(newEmployeeTreeNode); //add new employee tree node 

            employeeManager.SaveEmployeeData();
            treeViewEmployee.ExpandAll();
        }

        private void SwapItemCallbackFn(string uuid, string selectedNodeText)
        {
            List<EmployeeTreeNode> resultNodes = new List<EmployeeTreeNode>();
            _employeeTreeStructure.SearchByUUID(uuid, ref resultNodes);
            EmployeeTreeNode node1 = resultNodes[0];

            TreeNode[] foundNode = treeViewEmployee.Nodes.Find(selectedNodeText, true);
            EmployeeTreeNode node2 = (EmployeeTreeNode)foundNode[0];

            _employeeTreeStructure.SwapNodes(node1, node2);

            employeeManager.SaveEmployeeData();
            treeViewEmployee.ExpandAll();
        }

        private void employeeNodeTreeView_Click(object sender, TreeViewEventArgs e)
        {
            //get employeetreenode of selected node 
            EmployeeTreeNode employeeNode = (EmployeeTreeNode)this.treeViewEmployee.SelectedNode;
            string projStr = "No Projects";

            //check whether employee has projects assigned 
            if (employeeNode.Employee.Projects.Count> 0)
            {
                if (employeeNode.Employee.Projects.Count > 1)
                {
                    //populate project string
                    foreach (Project proj in employeeNode.Employee.Projects)
                    {
                        projStr += proj.projName + " ";
                    }
                }
                else
                {
                    projStr = employeeNode.Employee.Projects[0].projName;
                }
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
            employeeManager.SaveEmployeeData();
        }

        //Load button event handler 
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            employeeManager.SaveEmployeeData();
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
