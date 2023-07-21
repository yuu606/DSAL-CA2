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
using DSAL_CA1.Classes;

namespace DSAL_CA2
{
    public partial class AddEmployeeForm : Form
    {
        private DataManager dataManager;
        private Employee _oneEmployee;
        private RoleTreeNode _roleTreeStructure;
        public delegate void AddItemDelegate(string employeeName, int salary, string role);
        public AddItemDelegate AddItemCallback;

        public AddEmployeeForm()
        {
            InitializeComponent();
            _oneEmployee = new Employee();
            _oneEmployee.UUID = General.GenerateUUID();
        }

        private void AddEmployeeForm_Load(object sender, EventArgs e)
        {
            TreeNode selectedNode = ((EmployeeForm)Owner.ActiveMdiChild).treeViewEmployee.SelectedNode;
            int level = selectedNode.Level;
            isDummyData.Click += isDummyData_Click;
            dataManager = new DataManager();
            _roleTreeStructure = dataManager.LoadRoleData();
            Queue<RoleTreeNode> q = _roleTreeStructure.SearchByLevelOrderTraversal(_roleTreeStructure, level);

            this.reportingOfficerTextBox.Text = selectedNode.Text;
            foreach (RoleTreeNode node in q)
            {
                roleComboBox.Items.Add(node.Role.Name);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string employeeName = nameTextBox.Text.Trim();
            int salary = int.Parse(salaryTextBox.Text.Trim());
            string role = roleComboBox.SelectedText.Trim();

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
                AddItemCallback(employeeName, salary, role);
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
