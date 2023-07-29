using DSAL_CA2.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DSAL_CA1.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections;

namespace DSAL_CA2
{
    public partial class ProjectForm : Form
    {
        DataManager projectManager;
        Data data;
        RoleTreeNode _roleTreeStructure;
        EmployeeTreeNode _employeeTreeStructure;
        List<Project> _projectList;
        private EmployeeTreeNode _employeeTreeNode;
        private bool handle = true;
        private List<TreeNode> CurrentNodeMatches = new List<TreeNode>();
        private int LastNodeIndex = 0;
        private string LastSearchText;
        private string _foundTeam;

        public ProjectForm()
        {
            InitializeComponent();
        }

        private void ProjectForm_Load(object sender, EventArgs e)
        {
            data = new Data();
            projectManager = new DataManager(data);

            _roleTreeStructure = projectManager.LoadRoleData();
            if (_roleTreeStructure == null)
            {
                MessageBox.Show("Please set up the role hierarchy before setting up project list");
            }

            _employeeTreeStructure = projectManager.LoadEmployeeData();
            if (_employeeTreeStructure == null)
            {
                MessageBox.Show("Please set up the employee hierarchy before setting up the project list");
            }
            else
            {
                treeViewEmployee.Nodes.Add(_employeeTreeStructure);
            }

            _projectList = projectManager.LoadProjectList();
            this.treeViewEmployee.ExpandAll();

            modeComboBox.Items.Add("View");
            modeComboBox.Items.Add("Edit");
            modeComboBox.Items.Add("Add");
            modeComboBox.SelectedValueChanged += ComboBox_SelectionChanged;

            this.projectListView.View = View.Details;

            //add list view headers 
            List<ColumnHeader> chs = projectManager.generateDefaultProjectListView();
            foreach (ColumnHeader ch in chs)
            {
                projectListView.Columns.Add(ch);
            }
        }

        //expand employee tree view 
        private void buttonExpandAll_Click(object sender, EventArgs e)
        {
            treeViewEmployee.ExpandAll();
        }

        //collapse employee tree view 
        private void buttonCollapseAll_Click(object sender, EventArgs e)
        {
            treeViewEmployee.CollapseAll();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            projectListView.Items.Clear();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            projectManager.SaveProjectList();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            projectManager.LoadProjectList();

        }

        //search for teams button in add project panel 
        private void searchButton_Click(object sender, EventArgs e)
        {
            searchForTeam();
        }

        //cancel button in add project view 
        private void cancelButton_Click(object sender, EventArgs e)
        {
            projNameTextBox.Text = "";
            revenueTextBox.Text = "";
            teamLeadComboBox.Items.Clear();
            MessageBox.Show("Add new project has been cancelled");
        }

        //confirm add button in add project panel
        private void confirmAddButton_Click(object sender, EventArgs e)
        {
            string projName = projNameTextBox.Text.Trim();
            int revenue = int.Parse(revenueTextBox.Text.Trim());
            string teamLead = teamLeadComboBox.SelectedText.Trim();

            List<EmployeeTreeNode> resultNodes = new List<EmployeeTreeNode>();
            _employeeTreeStructure.SearchByEmployeeName(teamLead, ref resultNodes);

            Project newProject = new Project(projName);
            newProject.revenue = revenue;
            newProject.teamLead = resultNodes[0].Employee;

            ListViewItem proj = new ListViewItem(newProject.UUID);
            proj.SubItems.Add(newProject.projName);
            proj.SubItems.Add(newProject.revenue.ToString());
            proj.SubItems.Add(newProject.teamLead.Name);
            proj.Tag = newProject;

            projectListView.Items.Add(proj);
            MessageBox.Show("Project has been added");
        }

        //search for teams in view/edit project panel
        private void searchButton2_Click(object sender, EventArgs e)
        {
            searchForTeam();
        }

        //confirm edit button in view/edit project panel
        private void confirmEditButton_Click(object sender, EventArgs e)
        {
            string uuid = projectListView.SelectedItems[0].SubItems[0].Text;
            string projname = projectListView.SelectedItems[0].SubItems[1].Text;
            string revenue = projectListView.SelectedItems[0].SubItems[2].Text;
            string teamLead = projectListView.SelectedItems[0].SubItems[3].Text;

            List<EmployeeTreeNode> resultNodes = new List<EmployeeTreeNode>();
            _employeeTreeStructure.SearchByEmployeeName(teamLead, ref resultNodes);

            foreach (Project proj in _projectList)
            {
                if (proj.UUID == uuid)
                {
                    proj.projName = projname;
                    proj.revenue = int.Parse(revenue);
                    proj.teamLead = resultNodes[0].Employee;
                }
            }
            projectManager.SaveProjectList();
        }

        //delete button in view/edit project panel
        private void deleteButton_Click(object sender, EventArgs e)
        {
            Project proj = (Project)projectListView.SelectedItems[0].Tag;
            projectListView.SelectedItems.Clear();
            _projectList.Remove(proj);
            projectManager.SaveProjectList();
            MessageBox.Show("Project has been deleted");
        }

        private void ComboBox_SelectionChanged(object sender, EventArgs e)
        {
            switch (modeComboBox.SelectedItem.ToString())
            {
                case "View":
                    addNewProjPanel.Enabled = false;
                    viewEditProjPanel.Enabled = false;
                    break;
                case "Add":
                    addNewProjPanel.Enabled = true;
                    viewEditProjPanel.Enabled = false;
                    break;
                case "Edit":
                    addNewProjPanel.Enabled = false;
                    viewEditProjPanel.Enabled = true;
                    break;
            }
        }

        private void searchForTeam()
        {
            Queue<EmployeeTreeNode> fullTeams = new Queue<EmployeeTreeNode>();

            int level = _employeeTreeStructure.LastNode.Level + 1;
            Queue<EmployeeTreeNode> teamLeaders = _employeeTreeStructure.SearchByLevelOrderTraversal(_employeeTreeStructure, level);

            level = _roleTreeStructure.LastNode.Level + 1;
            Queue<RoleTreeNode> teamLeaderRoles = _roleTreeStructure.LevelOrderTraversal(_roleTreeStructure, level);

            while (teamLeaderRoles.Count > 0)
            {
                RoleTreeNode role = teamLeaderRoles.Dequeue();
                while (teamLeaders.Count > 0)
                {
                    EmployeeTreeNode teamLeader = teamLeaders.Dequeue();
                    bool isFullTeam = projectManager.IsTeamFull(role, teamLeader);
                    if (isFullTeam)
                    {
                        fullTeams.Enqueue(teamLeader);
                    }
                }
            }

            //need to check whether the revenue of the team matches the combined cost to hire the team

            List<int> teamCost = new List<int>();
            int revenue = int.Parse(revenueTextBox.Text);
            int revenue2 = int.Parse(revenue2TextBox.Text);

            while (fullTeams.Count > 0)
            {
                int combinedCost = 0;
                EmployeeTreeNode teamLeader = fullTeams.Dequeue();
                if (teamLeader.Employee.isSalaryAcc == true)
                {
                    combinedCost += teamLeader.Employee.Salary;
                }

                foreach (EmployeeTreeNode child in teamLeader.ChildEmployeeTreeNodes)
                {
                    if (child.Employee.isSalaryAcc == true)
                    {
                        combinedCost += child.Employee.Salary;
                    }
                }
                teamCost.Add(combinedCost);
            }

            List<int> index = new List<int>();

            int i = 0;
            foreach (int cost in teamCost)
            {
                if (revenue >= cost)
                {
                    index.Add(i);
                }
                if (revenue2 >= cost)
                {
                    index.Add(i);
                }
                i++;
            }

            int k = 0;
            while (fullTeams.Count > 0)
            {
                EmployeeTreeNode teamLeader = fullTeams.Dequeue();
                foreach (int j in index)
                {
                    if (k == j)
                    {
                        teamLeader.BackColor = Color.Gold;
                        teamLeadComboBox.Items.Add(teamLeader.Employee.Name);
                        teamLead2ComboBox.Items.Add(teamLeader.Employee.Name);

                        foreach (EmployeeTreeNode child in teamLeader.ChildEmployeeTreeNodes)
                        {
                            child.BackColor = Color.Gold;
                        }
                    }
                }
                k++;
            }
        }
    }
}
