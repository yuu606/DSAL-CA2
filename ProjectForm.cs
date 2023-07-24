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

            data.RoleTreeStructure = new();
            _roleTreeStructure = data.RoleTreeStructure;
            _roleTreeStructure = projectManager.LoadRoleData();

            this.treeViewEmployee.Nodes.Clear();
            this.treeViewEmployee.Nodes.Add(projectManager.EmployeeTreeStructure);
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


        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((ParentForm)this.MdiParent).form3 = null;
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
            string searchText = "";
            if (String.IsNullOrEmpty(searchText))
            {
                return;
            };

            if (LastSearchText != searchText)
            {
                //It's a new Search
                CurrentNodeMatches.Clear();
                LastSearchText = searchText;
                LastNodeIndex = 0;
                SearchNodes(searchText, treeViewEmployee.Nodes[0]);
            }

            if (LastNodeIndex >= 0 && CurrentNodeMatches.Count > 0 && LastNodeIndex < CurrentNodeMatches.Count)
            {
                TreeNode selectedNode = CurrentNodeMatches[LastNodeIndex];
                LastNodeIndex++;
                this.treeViewEmployee.SelectedNode = selectedNode;
                this.treeViewEmployee.SelectedNode.Expand();
                this.treeViewEmployee.Select();

            }
        }

        private void SearchNodes(string SearchText, TreeNode StartNode)
        {
            TreeNode node = null;
            while (StartNode != null)
            {
                if (StartNode.Text.ToLower().Contains(SearchText.ToLower()))
                {
                    CurrentNodeMatches.Add(StartNode);
                };
                if (StartNode.Nodes.Count != 0)
                {
                    SearchNodes(SearchText, StartNode.Nodes[0]);//Recursive Search 
                };
                StartNode = StartNode.NextNode;
            };

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
            //search for team leader 

            Project newProject = new Project(projName);
            newProject.revenue = revenue;
            //newProject.teamLead = teamLead;

            ListViewItem proj = new ListViewItem(newProject.UUID);
            proj.SubItems.Add(newProject.projName);
            proj.SubItems.Add(newProject.revenue.ToString());
            proj.SubItems.Add(newProject.teamLead.Name);
            proj.Tag = proj;

            projectListView.Items.Add(proj);
            MessageBox.Show("Project has been added");
        }

        //search for teams in view/edit project panel
        private void searchButton2_Click(object sender, EventArgs e)
        {

        }

        //confirm edit button in view/edit project panel
        private void confirmEditButton_Click(object sender, EventArgs e)
        {

        }

        //delete button in view/edit project panel
        private void deleteButton_Click(object sender, EventArgs e)
        {
            Project proj = (Project)projectListView.SelectedItems[0].Tag;
            projectListView.SelectedItems.Clear();
            projectManager.ProjectList.Remove(proj);
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

        }
    }
}
