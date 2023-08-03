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
        public delegate void ModifyItemDelegate(string uuid, string employeeName, int salary, bool isSalaryAcc, bool isDummyDataValue);
        public ModifyItemDelegate ModifyItemCallback;
        private Data data;

        public EditEmployeeForm()
        {
            InitializeComponent();
        }

        private void EditEmployeeForm_Load(object sender, EventArgs e)
        {
            isDummyData.Click += isDummyData_Click;

            EmployeeTreeNode selectedNode = (EmployeeTreeNode)((EmployeeForm)Owner.ActiveMdiChild).treeViewEmployee.SelectedNode;
            String projStr = "";
            if (selectedNode.Employee.Projects.Count > 0)
            {
                switch (selectedNode.Employee.Projects.Count)
                {
                    case 1:
                        projStr = selectedNode.Employee.Projects[0].projName;
                        break;
                    case 2:
                        projStr = selectedNode.Employee.Projects[0].projName + ", " +
                                  selectedNode.Employee.Projects[1].projName;
                        break;
                }
            }
            else
            {
                projStr = "No projects";
            }

            
            this.uuidTextBox.Text = selectedNode.Employee.UUID;
            this.reportingOfficerTextBox.Text = selectedNode.localRO.Name;
            this.nameTextBox.Text = selectedNode.Employee.Name;
            this.salaryTextBox.Text = selectedNode.Employee.Salary.ToString();
            this.roleTextBox.Text = selectedNode.localRoleTreeNode.ToString();
            this.projectsTextBox.Text = projStr;
            this.isDummyData.Checked = selectedNode.Employee.isDummyData;
            this.isAccCheckBox.Checked = selectedNode.Employee.isSalaryAcc;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            try
            {
                string uuid = uuidTextBox.Text.Trim();
                string employeeName = nameTextBox.Text.Trim();
                int salary = int.Parse(salaryTextBox.Text.Trim());
                bool isSalaryAcc = true;
                bool isDummyDataValue = false;

                if (salary <= 0)
                {
                    MessageBox.Show("Employee salary must not be less than 0. Please enter a valid employee salary");
                    return;
                }

                if (isAccCheckBox.Checked == false)
                {
                    isSalaryAcc = false;
                }

                if (isDummyDataValue)
                {
                    isDummyDataValue = true;
                    if (isAccCheckBox.Checked == false)
                    {
                        isSalaryAcc = false;
                    }
                    else
                    {
                        isSalaryAcc = true;
                    }
                }
                else
                {
                    isDummyDataValue = false;
                }

                if (employeeName != "" && salary > 0)
                {
                    ModifyItemCallback(uuid, employeeName, salary, isSalaryAcc, isDummyDataValue);
                    this.DialogResult = DialogResult.OK;
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

        private void isDummyData_Click(object sender, EventArgs e)
        {
            nameTextBox.Text = "Dummy";
            nameTextBox.BackColor = reportingOfficerTextBox.BackColor;
            isAccCheckBox.Enabled = true;
        }
    }
}
