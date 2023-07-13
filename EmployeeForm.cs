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
    public partial class EmployeeForm : Form
    {
        DataManager employeeManager;
        EmployeeTreeNode _selectedNode;
        private ContextMenuStrip _employeeMenu;
        ToolStripMenuItem _removeMenuItem = new ToolStripMenuItem();
        ToolStripMenuItem _addMenuItem = new ToolStripMenuItem();
        ToolStripMenuItem _updateMenuItem = new ToolStripMenuItem();
        ToolStripMenuItem _swapMenuItem = new ToolStripMenuItem();
        ToolStripMenuItem _editEmployeeDetails = new ToolStripMenuItem();
        ToolStripMenuItem _editRoleReportOff = new ToolStripMenuItem();

        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            employeeManager = new DataManager();
            _selectedNode = null;
            treeViewEmployee.Nodes.Add(employeeManager.generateDefaultEmployeeTree());
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
            _employeeMenu.Items.AddRange(new ToolStripMenuItem[] { _removeMenuItem, _addMenuItem, _updateMenuItem });
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
                    SwapEmployeeForm swapEmployeeForm = new SwapEmployeeForm(_selectedNode.Name);
                    swapEmployeeForm.SwapItemCallback = new SwapEmployeeForm.SwapItemDelegate(this.SwapItemCallbackFn);
                    swapEmployeeForm.ShowDialog(this);
                }
                if (item.Text == "Add Employee")
                {
                    //MessageBox.Show("No modal form created to service the add role operation.");
                    Employee employee = _selectedNode.Employee;
                    AddEmployeeForm addEmployeeForm = new AddEmployeeForm();
                    addEmployeeForm.AddItemCallback = new AddEmployeeForm.AddItemDelegate(this.AddItemCallbackFn);
                    addEmployeeForm.ShowDialog(this);
                }
                if (item.Text == "Remove Employee")
                {
                    MessageBox.Show("No modal form created to service the remove operation.");
                }
            }

        }//end of contextMenu_ItemClicked

        private void contextMenu_Opening(object sender, CancelEventArgs e)
        {
            _selectedNode = (EmployeeTreeNode)this.treeViewEmployee.SelectedNode;
            //Enable all menu items first. Then disable the menu items which are not appropriate
            foreach (ToolStripMenuItem item in _employeeMenu.Items)
            {
                item.Enabled = true;
            }

            if (_selectedNode.Text == "ROOT")
            {
                this._updateMenuItem.Visible = false;
                this._removeMenuItem.Visible = false;
                this._swapMenuItem.Visible = false;
            }
            if (_selectedNode.Text != "ROOT")
            {
                if (_selectedNode.ChildEmployeeTreeNodes.Count > 0)
                {
                    this._updateMenuItem.Enabled = true;
                    this._removeMenuItem.Enabled = false;
                }
            }
        }

        //ALL FUNCTIONS
        //------------------------------------------------------------------------------
        private void AddItemCallbackFn(string employeeName, int salary, string role)
        {
            Employee newEmployee = new Employee(employeeName);
            EmployeeTreeNode newEmployeeNode = new EmployeeTreeNode(newEmployee);
            newEmployeeNode.Employee.Salary = salary;
            newEmployeeNode.Employee.Role = role;
            this._selectedNode.AddChildEmployeeTreeNode(newEmployeeNode);
        }//end of AddItemCallbackFn method

        private void ModifyDetailsItemCallbackFn(string uuid, string employeeName, int salary)
        {
            List<EmployeeTreeNode> resultNodes = new List<EmployeeTreeNode>();
            employeeManager.EmployeeTreeStructure.SearchByUUID(uuid, ref resultNodes);
            resultNodes[0].Employee.Name = employeeName;
            resultNodes[0].Employee.Salary = salary;
            resultNodes[0].Text = employeeName;
        }//end of ModifyItemCallbackFn method

        private void ModifyRROItemCallbackFn(string uuid, string role, string reportingOfficer)
        {
            List<EmployeeTreeNode> resultNodes = new List<EmployeeTreeNode>();
            employeeManager.EmployeeTreeStructure.SearchByUUID(uuid, ref resultNodes);
            resultNodes[0].Employee.Role = role;
            resultNodes[0].Employee.ReportingOfficer = reportingOfficer;
        }

        private void SwapItemCallbackFn(string uuid, string employeeName)
        {
            Employee newEmployee = new Employee(employeeName);
            EmployeeTreeNode newEmployeeNode = new EmployeeTreeNode(newEmployee);
            this._selectedNode.AddChildEmployeeTreeNode(newEmployeeNode);
        }

        private void employeeNodeTreeView_Click(object sender, TreeViewEventArgs e)
        {
            EmployeeTreeNode employeeNode = (EmployeeTreeNode)this.treeViewEmployee.SelectedNode;
            string projStr = "";
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
            
            //populate read-only textboxes
            uuidTextBox.Text = employeeNode.Employee.UUID;
            reportingOfficerTextBox.Text = employeeNode.Employee.ReportingOfficer;
            nameTextBox.Text = employeeNode.Employee.Name;
            salaryTextBox.Text = employeeNode.Employee.Salary.ToString();
            roleTextBox.Text = employeeNode.Employee.Role;
            projectsTextBox.Text = projStr;
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
            employeeManager.SaveRoleData();
        }

        //Load button event handler 
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            employeeManager.SaveRoleData();
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
