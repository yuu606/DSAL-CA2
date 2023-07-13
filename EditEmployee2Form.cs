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
    public partial class EditEmployee2Form : Form
    {
        private DataManager dataManager;
        private RoleTreeNode _roleTreeStructure;
        private Employee _oneEmployee;
        public delegate void ModifyItem2Delegate(string uuid, string role, string reportingOfficer);
        public ModifyItem2Delegate ModifyItem2Callback;

        public EditEmployee2Form()
        {
            InitializeComponent();
            this._oneEmployee = new Employee();
            this._oneEmployee.Name = Name;
        }

        private void EditEmployee2Form_Load(object sender, EventArgs e)
        {
            EmployeeTreeNode selectedNode = (EmployeeTreeNode)((EmployeeForm)Owner.ActiveMdiChild).treeViewEmployee.SelectedNode;
            int level = selectedNode.Level;
            isDummyData.Click += isDummyData_Click;
            dataManager = new DataManager();
            _roleTreeStructure = dataManager.LoadRoleData();
            Queue<RoleTreeNode> q = _roleTreeStructure.LevelOrderTraversal(_roleTreeStructure, level);

            this.reportingOfficerComboBox.Text = selectedNode.Text;
            this.uuidTextBox.Text = selectedNode.Employee.UUID;
            foreach (RoleTreeNode node in q)
            {
                roleComboBox.Items.Add(node.Role.Name);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void isDummyData_Click(object sender, EventArgs e)
        {
            nameTextBox.Text = "Dummy";
            nameTextBox.BackColor = uuidTextBox.BackColor;
            isAccCheckBox.Enabled = true;
        }
    }


}
