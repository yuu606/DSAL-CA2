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
        public delegate void SwapItemDelegate(string uuid, string selectedNodeText);
        public SwapItemDelegate SwapItemCallback;

        public SwapEmployeeForm()
        {
            InitializeComponent();
        }

        private void SwapEmployeeForm_Load(object sender, EventArgs e)
        {
            EmployeeTreeNode selectedNode = (EmployeeTreeNode)((EmployeeForm)Owner.ActiveMdiChild).treeViewEmployee.SelectedNode;
            selectedEmployeeTextBox.Text = selectedNode.Text;

            foreach (TreeNode node in ((EmployeeForm)Owner.ActiveMdiChild).treeViewEmployee.Nodes)
            {
                treeViewEmployee2.Nodes.Add(node);
            }

            treeViewEmployee2.AfterSelect += employeeNodeTreeView_Click;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void swapButton_Click(object sender, EventArgs e)
        {
            string uuid = uuidTextBox.Text.Trim();
            string selectedNodeText = selectedEmployeeTextBox.Text.Trim();

            EmployeeTreeNode selectedNode = (EmployeeTreeNode)((EmployeeForm)Owner.ActiveMdiChild).treeViewEmployee.SelectedNode;
            if (selectedNode.Level != treeViewEmployee2.SelectedNode.Level)
            {
                MessageBox.Show("You can only swap employees on the same role level");
            }
            else
            {
                if (uuid != "" && selectedNodeText != "")
                {
                    SwapItemCallback(uuid, selectedNodeText);
                    this.DialogResult = DialogResult.OK;
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
            roleTextBox.Text = employeeNode.localRole.Name;
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
