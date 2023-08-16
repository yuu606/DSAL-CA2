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
using Microsoft.VisualBasic;

namespace DSAL_CA2
{
    public partial class ProjectForm : Form
    {
        DataManager projectManager;
        Data data;
        RoleTreeNode _roleTreeStructure;
        EmployeeTreeNode _employeeTreeStructure;
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

            data.RoleTreeStructure = _roleTreeStructure;
            _roleTreeStructure = projectManager.LoadRoleData();
            if (_roleTreeStructure == null)
            {
                MessageBox.Show("Please set up the role hierarchy before setting up project list");
            }

            data.EmployeeTreeStructure = _employeeTreeStructure;
            _employeeTreeStructure = projectManager.LoadEmployeeData();
            if (_employeeTreeStructure == null)
            {
                MessageBox.Show("Please set up the employee hierarchy before setting up the project list");
            }
            else
            {
                treeViewEmployee.Nodes.Add(_employeeTreeStructure);
            }
            this.treeViewEmployee.ExpandAll();

            modeComboBox.Items.Add("View");
            modeComboBox.Items.Add("Edit");
            modeComboBox.Items.Add("Add");
            modeComboBox.SelectedValueChanged += ComboBox_SelectionChanged;
            modeComboBox.SelectedIndex = 0;
            addNewProjPanel.Enabled = false;
            viewEditProjPanel.Enabled = false;

            this.projectListView.View = View.Details;
            projectListView.Click += projectlvi_Click;

            data.ProjectList = projectManager.LoadProjectList();
            if (data.ProjectList != null)
            {
                if (data.ProjectList.Count > 0)
                {
                    foreach (var proj in data.ProjectList)
                    {
                        ListViewItem projectlvi = new ListViewItem(proj.UUID);
                        projectlvi.SubItems.Add(proj.projName);
                        projectlvi.SubItems.Add(proj.revenue.ToString());
                        projectlvi.SubItems.Add(proj.teamLead.Name);
                        projectlvi.Tag = proj;
                        projectListView.Items.Add(projectlvi);
                    }
                }
            }
            //else
            //{
            //    data.ProjectList = new List<Project>();
            //}

            List<string> headers = new List<string>() { "UUID", "Project Name", "Revenue", "Team Leader" };
            List<ColumnHeader> chs = new List<ColumnHeader>();
            foreach (string header in headers)
            {
                ColumnHeader ch = new ColumnHeader(header);
                projectListView.Columns.Add(ch.ImageKey);
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
            projectManager.SaveData();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            data.ProjectList = projectManager.LoadProjectList();
            if (data.ProjectList != null)
            {
                if (data.ProjectList.Count > 0)
                {
                    foreach (var proj in data.ProjectList)
                    {
                        ListViewItem projectlvi = new ListViewItem(proj.UUID);
                        projectlvi.SubItems.Add(proj.projName);
                        projectlvi.SubItems.Add(proj.revenue.ToString());
                        projectlvi.SubItems.Add(proj.teamLead.Name);
                        projectlvi.Tag = proj;
                        projectListView.Items.Add(projectlvi);
                    }
                }
            }

        }

        //search for teams button in add project panel 
        private void searchButton_Click(object sender, EventArgs e)
        {
            getValidTeamList();
        }

        //cancel button in add project view 
        private void cancelButton_Click(object sender, EventArgs e)
        {
            treeViewEmployee.BackColor = Color.AliceBlue;
            projNameTextBox.Text = "";
            revenueTextBox.Text = "";
            teamLeadComboBox.SelectedText = "";
            teamLeadComboBox.Items.Clear();
            MessageBox.Show("Add new project has been cancelled");
        }

        //confirm add button in add project panel
        private void confirmAddButton_Click(object sender, EventArgs e)
        {
            if (projNameTextBox.Text == "" || int.Parse(revenueTextBox.Text) < 0 || teamLeadComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please fill out all options before confirming");
            }
            else
            {
                string projName = projNameTextBox.Text.Trim();
                int revenue = int.Parse(revenueTextBox.Text.Trim());
                string teamLead = teamLeadComboBox.SelectedItem.ToString();

                List<EmployeeTreeNode> resultNodes = new List<EmployeeTreeNode>();
                _employeeTreeStructure.SearchByEmployeeName(teamLead, ref resultNodes);

                Project newProject = new Project(projName);
                newProject.revenue = revenue;
                newProject.teamLead = resultNodes[0].Employee;
                resultNodes[0].Employee.Projects.Add(newProject);
                foreach (EmployeeTreeNode employeeNode in resultNodes[0].ChildEmployeeTreeNodes)
                {
                    employeeNode.Employee.Projects.Add(newProject);
                }
                resultNodes[0].TraverseUpAddProject(newProject);

                ListViewItem proj = new ListViewItem(newProject.UUID);
                proj.SubItems.Add(newProject.projName);
                proj.SubItems.Add(newProject.revenue.ToString());
                proj.SubItems.Add(newProject.teamLead.Name);
                proj.Tag = newProject;

                data.ProjectList.Add(newProject);

                projectListView.Items.Add(proj);
                textBoxConsole.Text = "Project Added:" + Environment.NewLine + "Name: " + newProject.projName + Environment.NewLine + "Revenue: " + newProject.revenue + Environment.NewLine + "Team Leader: " + newProject.teamLead.Name;
                MessageBox.Show("Project has been added");
            }

            projNameTextBox.Text = "";
            revenueTextBox.Text = "";
            teamLeadComboBox.SelectedText = "";
            teamLeadComboBox.Items.Clear();
            teamLeadComboBox.Enabled = false;

            projectManager.SaveData();
        }

        //search for teams in view/edit project panel
        private void searchButton2_Click(object sender, EventArgs e)
        {
            getValidTeamList();
        }

        //confirm edit button in view/edit project panel
        private void confirmEditButton_Click(object sender, EventArgs e)
        {
            Project project = (Project)projectListView.SelectedItems[0].Tag;
            Employee previousTeamLead = project.teamLead;
            previousTeamLead.Projects.Remove(project);

            List<EmployeeTreeNode> uuidNodes = new List<EmployeeTreeNode>();
            _employeeTreeStructure.SearchByUUID(previousTeamLead.UUID, ref uuidNodes); //get employee node
            //
            foreach (var child in uuidNodes[0].ChildEmployeeTreeNodes)
            {
                child.Employee.Projects.Remove(project);
            }
            uuidNodes[0].TraverseUpDeleteProject(project);

            string projname = projName2TextBox.Text;
            string revenue = revenue2TextBox.Text;
            string teamLead = teamLead2ComboBox.SelectedItem.ToString();

            List<EmployeeTreeNode> resultNodes = new List<EmployeeTreeNode>();
            _employeeTreeStructure.SearchByEmployeeName(teamLead, ref resultNodes);


            project.projName = projname;
            project.revenue = int.Parse(revenue);
            project.teamLead = resultNodes[0].Employee;
        
            resultNodes[0].Employee.Projects.Add(project);
            foreach (var child in resultNodes[0].ChildEmployeeTreeNodes)
            {
                child.Employee.Projects.Add(project);
            }
            resultNodes[0].TraverseUpAddProject(project);

            projectListView.Items.Remove(projectListView.SelectedItems[0]);

            projectListView.SelectedItems[0].SubItems[0].Text = projname;
            projectListView.SelectedItems[0].SubItems[1].Text = revenue;
            projectListView.SelectedItems[0].SubItems[2].Text = teamLead;

            projName2TextBox.Text = "";
            revenue2TextBox.Text = "";
            teamLeadComboBox.SelectedText = "";
            teamLead2ComboBox.Items.Clear();
            teamLead2ComboBox.Enabled = false;

            projectManager.SaveData();
        }

        //delete button in view/edit project panel
        private void deleteButton_Click(object sender, EventArgs e)
        {
            Project proj = (Project)projectListView.SelectedItems[0].Tag;

            Employee teamLeader = proj.teamLead;
            teamLeader.Projects.Remove(proj);

            List<EmployeeTreeNode> uuidNodes = new List<EmployeeTreeNode>();
            _employeeTreeStructure.SearchByUUID(teamLeader.UUID, ref uuidNodes); //get employee node
                                                                                 
            foreach (var child in uuidNodes[0].ChildEmployeeTreeNodes)
            {
                child.Employee.Projects.Remove(proj);
            }
            uuidNodes[0].TraverseUpDeleteProject(proj);

            projectListView.SelectedItems[0].SubItems.Clear();
            data.ProjectList.Remove(proj);
            projectManager.SaveData();
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

        private void projectlvi_Click(object sender, EventArgs e)
        {
            ListViewItem selectedItem = projectListView.SelectedItems[0];
            Project proj = (Project)selectedItem.Tag;
            uuidTextBox.Text = proj.UUID;
            projName2TextBox.Text = proj.projName;
            revenue2TextBox.Text = proj.revenue.ToString();
            teamLead2ComboBox.SelectedText = proj.teamLead.Name;
        }

        private void getValidTeamList()
        {
            int Revenue = 0;
            if (modeComboBox.SelectedItem.ToString() == "Add")
            {
                if (revenueTextBox.Text == "")
                {
                    MessageBox.Show("Please input revenue");
                    return;
                }
                teamLeadComboBox.Enabled = true;
                teamLeadComboBox.BackColor = projNameTextBox.BackColor;
                Revenue = int.Parse(revenueTextBox.Text);
            }
            else
            {
                if (revenue2TextBox.Text == "")
                {
                    MessageBox.Show("Please input revenue");
                    return;
                }
                teamLead2ComboBox.Enabled = true;
                teamLead2ComboBox.BackColor = projName2TextBox.BackColor;
                Revenue = int.Parse(revenue2TextBox.Text);
            }

            Queue<EmployeeTreeNode> fullTeams = new Queue<EmployeeTreeNode>();

            int level = _employeeTreeStructure.GetTreeDepth() - 2;
            Queue<EmployeeTreeNode> teamLeaders = _employeeTreeStructure.SearchByLevelOrderTraversal(_employeeTreeStructure, level);
            Queue<RoleTreeNode> teamLeaderRoles = _roleTreeStructure.LevelOrderTraversal(_roleTreeStructure, level);

            foreach (RoleTreeNode roleNode in teamLeaderRoles)
            {
                foreach (EmployeeTreeNode employeeNode in teamLeaders)
                {
                    bool isFullTeam = projectManager.IsTeamFull(roleNode, employeeNode);
                    if (isFullTeam)
                    {
                        fullTeams.Enqueue(employeeNode);
                    }
                }
            }
            //need to check whether the revenue of the team matches the combined cost to hire the team
            List<int> teamCost = _employeeTreeStructure.GetBranchSumValues();

            List<EmployeeTreeNode> teamLeadersList = teamLeaders.ToList();
            List<EmployeeTreeNode> validTeamList = new List<EmployeeTreeNode>();
            for (int i = 0; i < teamCost.Count; i++)
            {
                if (Revenue >= teamCost[i])
                {
                    foreach (var employee in fullTeams.ToList())
                    {
                        if (employee == teamLeadersList[i] && teamLeadersList[i].Employee.Projects.Count < 1)
                        {
                            teamLeadersList[i].BackColor = Color.Gold;
                            teamLeadComboBox.Items.Add(teamLeadersList[i].Employee.Name);
                            teamLead2ComboBox.Items.Add(teamLeadersList[i].Employee.Name);
                            validTeamList.Add(teamLeadersList[i]);
                        }
                    }
                }
            }
        }
    }
}
