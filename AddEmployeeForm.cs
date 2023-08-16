using DSAL_CA2.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DSAL_CA1.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace DSAL_CA2
{
    public partial class AddEmployeeForm : Form
    {
        private DataManager dataManager;
        private RoleTreeNode _roleTreeStructure;
        public delegate void AddItemDelegate(string employeeName, int salary, string role, String reportingOfficer, bool isDummyDataValue, bool isSalaryAcc);
        public AddItemDelegate AddItemCallback;
        public Data data;

        public AddEmployeeForm()
        {
            InitializeComponent();
        }

        private void AddEmployeeForm_Load(object sender, EventArgs e)
        {
            isDummyData.CheckedChanged += isDummyData_CheckedChanged;

            EmployeeTreeNode selectedNode = (EmployeeTreeNode)((EmployeeForm)Owner.ActiveMdiChild).treeViewEmployee.SelectedNode;
            String parentRoleUUID = selectedNode.localRoleTreeNode.Role.UUID;

            Data data = new Data(); 
            dataManager = new DataManager(data);
            _roleTreeStructure = dataManager.LoadRoleData();
            List<RoleTreeNode> resultNodes = new List<RoleTreeNode>();
            _roleTreeStructure.SearchByUUID(parentRoleUUID, ref resultNodes);

            if (selectedNode.localRoleTreeNode.Role.Name == "ROOT")
            {
                resultNodes.Add(_roleTreeStructure);
            }

            Queue<RoleTreeNode> q = new Queue<RoleTreeNode>();
            q = _roleTreeStructure.SearchByLevelOrderTraversal(resultNodes[0], 1);
            this.reportingOfficerTextBox.Text = selectedNode.Employee.Name;
            foreach (RoleTreeNode node in q)
            {
                roleComboBox.Items.Add(node.Role.Name);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            EmployeeTreeNode selectedNode = (EmployeeTreeNode)((EmployeeForm)Owner.ActiveMdiChild).treeViewEmployee.SelectedNode;
            try
            {
                string employeeName = nameTextBox.Text.Trim();
                int salary = int.Parse(salaryTextBox.Text.Trim());
                string reportingOfficer = reportingOfficerTextBox.Text.Trim();
                bool isDummyDataValue = false;
                bool isSalaryAcc = true;

                if (salary <= 0)
                {
                    MessageBox.Show("Employee salary must not be less than 0. Please enter a valid employee salary");
                } else if (selectedNode.ParentEmployeeTreeNode.Employee.Salary < salary)
                {
                    MessageBox.Show("Employee salary must not be higher than its reporting officer's salary");
                }
                else
                {
                    if (roleComboBox.SelectedItem == null)
                    {
                        MessageBox.Show("Please select a role before adding");
                    }
                    else
                    {
                        string role = roleComboBox.SelectedItem.ToString();

                        if (isAccCheckBox.Checked == false)
                        {
                            isSalaryAcc = false;
                        }
                        else
                        {
                            isSalaryAcc = true;
                        }

                        if (isDummyData.Checked == false)
                        {
                            isDummyDataValue = false;
                        }
                        else
                        {
                            isDummyDataValue = true;
                        }

                        if (employeeName != "" && role != "" && reportingOfficer != "")
                        {
                            AddItemCallback(employeeName, salary, role, reportingOfficer, isDummyDataValue, isSalaryAcc);
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("Something went wrong");
                        }
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please input valid salary value.");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void isDummyData_CheckedChanged(object sender, EventArgs e)
        {
            if (isDummyData.Checked)
            {
                nameTextBox.Text = "Dummy";
                nameTextBox.BackColor = reportingOfficerTextBox.BackColor;
                isAccCheckBox.Enabled = true;
            }
            else
            {
                nameTextBox.Text = "";
                nameTextBox.BackColor = roleComboBox.BackColor;
                isAccCheckBox.Checked = true;
                isAccCheckBox.Enabled = false;
            }
        }
    }
}
