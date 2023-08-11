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
    public partial class SwapEmployeeForm : Form
    {
        private DataManager dataManager;
        private EmployeeTreeNode _employeeTreeStructure;
        public delegate void SwapItemDelegate(int index2, string uuid2);
        public SwapItemDelegate SwapItemCallback;

        public SwapEmployeeForm()
        {
            InitializeComponent();
        }

        private void SwapEmployeeForm_Load(object sender, EventArgs e)
        {
            EmployeeTreeNode selectedNode = (EmployeeTreeNode)((EmployeeForm)Owner.ActiveMdiChild).treeViewEmployee.SelectedNode;
            selectedEmployeeTextBox.Text = selectedNode.Text;

            Data data = new Data();
            dataManager = new DataManager(data);
            _employeeTreeStructure = dataManager.LoadEmployeeData();
            treeViewEmployee2.Nodes.Add(_employeeTreeStructure);
            treeViewEmployee2.ExpandAll();
            treeViewEmployee2.AfterSelect += employeeNodeTreeView_Click;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void swapButton_Click(object sender, EventArgs e)
        {
            EmployeeTreeNode selectedNode = (EmployeeTreeNode)((EmployeeForm)Owner.ActiveMdiChild).treeViewEmployee.SelectedNode;
            string uuid = selectedNode.Employee.UUID;
            string uuid2 = uuidTextBox.Text.Trim();
            int index2 = treeViewEmployee2.SelectedNode.Index;

            if (selectedNode.Level != treeViewEmployee2.SelectedNode.Level)
            {
                MessageBox.Show("You can only swap employees on the same role level");
            }
            else
            {
                if (index2 != null || uuid2 != "" )
                {
                    if (uuid == uuid2)
                    {
                        MessageBox.Show("You cannot swap the same employee");
                        return;
                    }
                    else
                    {
                        SwapItemCallback(index2, uuid2);
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    MessageBox.Show("you have not selected a node to swap");
                }
            }
        }

        private void employeeNodeTreeView_Click(object sender, TreeViewEventArgs e)
        {
            //get employeetreenode of selected node 
            EmployeeTreeNode employeeNode = (EmployeeTreeNode)this.treeViewEmployee2.SelectedNode;
            string projStr = "No Projects";

            //check whether employee has projects assigned 
            if (employeeNode.Employee.Projects.Count > 0)
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

            //populate read-only textboxes
            nameTextBox.Text = employeeNode.Employee.Name;
            roleTextBox.Text = employeeNode.localRoleTreeNode.Role.Name;
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
                reportingOfficerTextBox.Text = employeeNode.localRO.Name;
                uuidTextBox.Text = employeeNode.Employee.UUID;
            }

        }
    }
}
