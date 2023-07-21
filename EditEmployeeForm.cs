using DSAL_CA1;
using DSAL_CA1.Classes;
using DSAL_CA2;
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
    public partial class EditEmployeeForm : Form
    {
        private DataManager dataManager;
        private RoleTreeNode _roleTreeStructure;
        public delegate void ModifyItemDelegate(string uuid, string employeeName, int salary);
        public ModifyItemDelegate ModifyItemCallback;

        public EditEmployeeForm()
        {
            InitializeComponent();
        }

        private void EditEmployeeForm_Load(object sender, EventArgs e)
        {
            EmployeeTreeNode selectedNode = (EmployeeTreeNode)((EmployeeForm)Owner.ActiveMdiChild).treeViewEmployee.SelectedNode;
            int level = selectedNode.Level;
            isDummyData.Click += isDummyData_Click;
            dataManager = new DataManager();
            _roleTreeStructure = dataManager.LoadRoleData();
            Queue<RoleTreeNode> q = _roleTreeStructure.SearchByLevelOrderTraversal(_roleTreeStructure, level);

            this.reportingOfficerTextBox.Text = selectedNode.Text;
            this.uuidTextBox.Text = selectedNode.Employee.UUID;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            string employeeName = nameTextBox.Text.Trim();
            int salary = int.Parse(salaryTextBox.Text.Trim());
            string uuid = uuidTextBox.Text.Trim();

            if (salary < 0)
            {
                MessageBox.Show("Employee salary must not be less than 0. Please enter a valid employee salary");
            }

            if (isDummyData.Checked == true)
            {
                if (isAccCheckBox.Checked == true)
                {

                }
            }
            if (employeeName != "")
            {
                ModifyItemCallback(uuid, employeeName, salary);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void isDummyData_Click(object sender, EventArgs e)
        {
            nameTextBox.Text = "Dummy";
            nameTextBox.BackColor = reportingOfficerTextBox.BackColor;
            isAccCheckBox.Enabled = true;
        }
    }
}
