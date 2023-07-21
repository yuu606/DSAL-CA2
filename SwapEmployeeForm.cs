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
    public partial class SwapEmployeeForm : Form
    {
        public delegate void SwapItemDelegate(string uuid, string name, string reportingOfficer, int salary, string roleStr, string projectStr);
        public SwapItemDelegate SwapItemCallback;

        public SwapEmployeeForm(string uuid, string name, string reportingOfficer, int salary, string roleStr, string projectStr)
        {
            InitializeComponent();
            uuidTextBox.Text = uuid;
            nameTextBox.Text = name;
            reportingOfficerTextBox.Text = reportingOfficer;
            salaryTextBox.Text = salary.ToString();
            roleTextBox.Text = roleStr;
            projectsTextBox.Text = projectStr;
        }

        private void SwapEmployeeForm_Load(object sender, EventArgs e)
        {
            TreeNode selectedNode = ((EmployeeForm)Owner.ActiveMdiChild).treeViewEmployee.SelectedNode;
            selectedEmployeeTextBox.Text = selectedNode.Text;
            foreach (TreeNode node in ((EmployeeForm)Owner.ActiveMdiChild).treeViewEmployee.Nodes)
            {
                treeViewEmployee2.Nodes.Add(node);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void swapButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text.Trim();
            string uuid = uuidTextBox.Text.Trim();
            string reportingOfficer = reportingOfficerTextBox.Text.Trim();
            int salary = int.Parse(salaryTextBox.Text);
            string roleStr = roleTextBox.Text.Trim();
            string projectStr = projectsTextBox.Text.Trim();

            if (name != "")
            {
                SwapItemCallback(uuid, name, reportingOfficer, salary, roleStr, projectStr);
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
