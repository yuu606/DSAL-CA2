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

            String projStr = "No Projects";
            if (selectedNode.Employee.Projects.Count > 0)
            {
                projStr = "";
                if (selectedNode.Employee.Projects.Count > 1)
                {
                    //populate project string
                    foreach (Project proj in selectedNode.Employee.Projects)
                    {
                        projStr += proj.projName + " ";
                    }
                }
                else
                {
                    projStr = selectedNode.Employee.Projects[0].projName;
                }
            }

            //populate textboxes
            this.uuidTextBox.Text = selectedNode.Employee.UUID;
            this.nameTextBox.Text = selectedNode.Employee.Name;
            this.salaryTextBox.Text = selectedNode.Employee.Salary.ToString();
            this.isAccCheckBox.Checked = selectedNode.Employee.isSalaryAcc;
            this.isDummyData.Checked = selectedNode.Employee.isDummyData;
            this.reportingOfficerComboBox.SelectedText = selectedNode.localRO.Name;
            this.roleComboBox.SelectedText = selectedNode.localRoleTreeNode.Role.Name;
            this.projectsTextBox.Text = projStr;

            List<Role> roleList = getRoleList(_roleTreeStructure);
            roleList.Remove(_roleTreeStructure.Role);
            foreach (Role role in roleList)//populate role combobox options
            {
                roleComboBox.Items.Add(role.Name);
            }

            //load employee tree structure 
            _employeeTreeStructure = dataManager.LoadEmployeeData();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            //get final value inputs  
            string uuid = uuidTextBox.Text.Trim();
            string role = roleComboBox.SelectedItem.ToString();
            string reportingOfficer = reportingOfficerComboBox.SelectedItem.ToString();

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
            reportingOfficerComboBox.Items.Clear();
            string roleName = roleComboBox.SelectedItem.ToString(); //get selected role name

            List<RoleTreeNode> foundNodes = new List<RoleTreeNode>();
            _roleTreeStructure.SearchByRoleName(roleName, ref foundNodes); //find role node via rolename
            RoleTreeNode roleNode = foundNodes[0];

            int level = roleNode.Level - 1; //get parent node's level
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

        private List<Role> getRoleList(RoleTreeNode root)
        {
            List<Role> roleList = new List<Role>();

            if (root == null)
                return null;

            Queue<RoleTreeNode> q = new Queue<RoleTreeNode>();
            q.Enqueue(root); // Enqueue root
            while (q.Count != 0)
            {
                int n = q.Count;

                // If this node has children
                while (n > 0)
                {
                    // Dequeue an item from queue
                    // and print it
                    RoleTreeNode p = q.Peek();
                    q.Dequeue();
                    roleList.Add(p.Role);

                    // Enqueue all children of
                    // the dequeued item
                    for (int i = 0; i < p.ChildRoleTreeNodes.Count; i++)
                    {
                        q.Enqueue(p.ChildRoleTreeNodes[i]);
                    }
                    n--;
                }
            }

            return roleList;
        }
    }
}
