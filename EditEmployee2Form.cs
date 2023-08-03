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
        private EmployeeTreeNode _employeeTreeStructure;
        public delegate void ModifyItem2Delegate(string uuid, string role, string reportingOfficer);
        public ModifyItem2Delegate ModifyItem2Callback;
        private Data data;

        public EditEmployee2Form()
        {
            InitializeComponent();
        }

        private void EditEmployee2Form_Load(object sender, EventArgs e)
        {
            //add event handler
            isDummyData.CheckedChanged += isDummyData_CheckedChanged;
            roleComboBox.SelectedValueChanged += role_AfterSelect;

            //get selectednode 
            EmployeeTreeNode selectedNode = (EmployeeTreeNode)((EmployeeForm)Owner.ActiveMdiChild).treeViewEmployee.SelectedNode;
            String parentRoleUUID = selectedNode.localRoleTreeNode.Role.UUID;

            //load role tree structure 
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

            //populate textboxes
            this.uuidTextBox.Text = selectedNode.Employee.UUID;
            this.isAccCheckBox.Checked = selectedNode.Employee.isSalaryAcc;
            this.isDummyData.Checked = selectedNode.Employee.isDummyData;
            this.reportingOfficerComboBox.SelectedText = selectedNode.localRO.Name;
            this.roleComboBox.SelectedText = selectedNode.localRoleTreeNode.Role.Name;

            //populate role combobox options
            foreach (RoleTreeNode node in q)
            {
                roleComboBox.Items.Add(node.Role.Name);
            }

            //load employee tree structure 
            _employeeTreeStructure = dataManager.LoadEmployeeData();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            //get final value inputs  
            string uuid = uuidTextBox.Text.Trim();
            string role = roleComboBox.SelectedText;
            string reportingOfficer = reportingOfficerComboBox.SelectedText;

            if (uuid != "")
            {
                ModifyItem2Callback(uuid, role, reportingOfficer);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void role_AfterSelect(object sender, EventArgs e)
        {
            //empty reporting officer text
            reportingOfficerComboBox.SelectedText = "";
            string roleName = roleComboBox.SelectedItem.ToString(); //get selected role name

            List<RoleTreeNode> foundNodes = new List<RoleTreeNode>();
            _roleTreeStructure.SearchByRoleName(roleName, ref foundNodes); //find role node via rolename
            RoleTreeNode roleNode = foundNodes[0];

            int level = roleNode.Level + 1; //get parent node's level
            Queue<EmployeeTreeNode> q = _employeeTreeStructure.SearchByLevelOrderTraversal(_employeeTreeStructure, level); //find all employee nodes on that level

            while (q.Count > 0)
            {
                EmployeeTreeNode node = q.Dequeue(); //get employee node
                reportingOfficerComboBox.Items.Add(node.Employee.Name); //populate reporting officer combobox
            }
        }

        private void isDummyData_CheckedChanged(object sender, EventArgs e)
        {
            if (isDummyData.Checked)
            {
                nameTextBox.Text = "Dummy";
                nameTextBox.BackColor = reportingOfficerComboBox.BackColor;
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
