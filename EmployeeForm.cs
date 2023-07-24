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

            data.RoleTreeStructure = new();
            data.EmployeeTreeStructure = new();

            _roleTreeStructure = data.RoleTreeStructure;
            _roleTreeStructure = employeeManager.LoadRoleData();

            _employeeTreeStructure = data.EmployeeTreeStructure;
            _employeeTreeStructure = employeeManager.LoadEmployeeData();

            if (_employeeTreeStructure == null)
            {
                _employeeTreeStructure = employeeManager.generateDefaultEmployeeTree();
                treeViewEmployee.Nodes.Add(_employeeTreeStructure);
            }
            
            if (_roleTreeStructure == null)
            {
                MessageBox.Show("Please set up the role hierarchy before setting up the Employee hierarchy");
            }

            treeViewEmployee.AfterSelect += employeeNodeTreeView_Click;
            InitializeMenuTreeView();
        }

        public void InitializeMenuTreeView()
        {
            textBoxConsole.Text = "Each Employee can have a maximum of 2 employee nodes.";
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
                    SwapEmployeeForm swapEmployeeForm = new SwapEmployeeForm(employee.UUID, employee.ReportingOfficer, employee.Name, employee.Salary, employee.role.Name, employee.Projects[0].projName);
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
                    //check if employee has been assigned a project
                    MessageBox.Show("Are you sure you want to delete the role? Child roles will also be deleted.");
                    employeeManager.EmployeeTreeStructure.DeleteNode(_selectedNode.ParentEmployeeTreeNode, _selectedNode);
                    treeViewEmployee.Nodes.Remove(_selectedNode);
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

        //ALL FUNCTIONS
        //------------------------------------------------------------------------------
        private void AddItemCallbackFn(string employeeName, int salary, string role, String reportingOfficer)
        {
            //search for role via name
            List<RoleTreeNode> roleNodes = new List<RoleTreeNode>();
            employeeManager.RoleTreeStructure.SearchByRoleName(role, ref roleNodes);

            //instantiate new employee object
            Employee newEmployee = new Employee(employeeName);
            newEmployee.Salary = salary;
            newEmployee.role = roleNodes[0].Role;
            newEmployee.ReportingOfficer = reportingOfficer;

            //instantiate new employee tree node
            EmployeeTreeNode newEmployeeNode = new EmployeeTreeNode(newEmployee);
            this._selectedNode.AddChildEmployeeTreeNode(newEmployeeNode);

            //save to data file
            employeeManager.SaveEmployeeData();
            //expand tree view
            treeViewEmployee.ExpandAll();
        }//end of AddItemCallbackFn method

        private void ModifyDetailsItemCallbackFn(string uuid, string employeeName, int salary)
        {
            List<EmployeeTreeNode> resultNodes = new List<EmployeeTreeNode>();
            employeeManager.EmployeeTreeStructure.SearchByUUID(uuid, ref resultNodes);
            resultNodes[0].Employee.Name = employeeName;
            resultNodes[0].Employee.Salary = salary;
            resultNodes[0].Text = employeeName;
            employeeManager.SaveEmployeeData();
            treeViewEmployee.ExpandAll();
        }//end of ModifyItemCallbackFn method

        private void ModifyRROItemCallbackFn(string uuid, string role, string reportingOfficer)
        {
            List<EmployeeTreeNode> uuidNodes = new List<EmployeeTreeNode>();
            List<RoleTreeNode> roleNodes = new List<RoleTreeNode>();
            employeeManager.EmployeeTreeStructure.SearchByUUID(uuid, ref uuidNodes);
            employeeManager.RoleTreeStructure.SearchByRoleName(role, ref roleNodes);
            uuidNodes[0].Employee.role = roleNodes[0].Role;
            uuidNodes[0].Employee.ReportingOfficer = reportingOfficer;
            employeeManager.SaveEmployeeData();
            treeViewEmployee.ExpandAll();
        }

        private void SwapItemCallbackFn(string uuid, string name, string reportingOfficer, int salary, string roleStr, string projectStr)
        {
            Employee newEmployee = new Employee(name);
            EmployeeTreeNode newEmployeeNode = new EmployeeTreeNode(newEmployee);
            this._selectedNode.AddChildEmployeeTreeNode(newEmployeeNode);
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

            //populate read-only textboxes
            nameTextBox.Text = employeeNode.Employee.Name;
            roleTextBox.Text = employeeNode.Employee.role.Name;
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
                reportingOfficerTextBox.Text = employeeNode.Employee.ReportingOfficer;
                uuidTextBox.Text = employeeNode.Employee.UUID;
            }

        }
        //--------------------------------------------------------------------------
        //END OF FUNCTIONS
    }
}
