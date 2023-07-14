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
    public partial class ProjectForm : Form
    {
        DataManager projectManager;
        private bool handle = true;

        public ProjectForm()
        {
            InitializeComponent();
        }

        private void ProjectForm_Load(object sender, EventArgs e)
        {
            projectManager = new DataManager();
            projectManager.LoadRoleData();
            this.treeViewEmployee.Nodes.Clear();
            this.treeViewEmployee.Nodes.Add(projectManager.RoleTreeStructure);
            this.treeViewEmployee.ExpandAll();

            modeComboBox.Items.Add("View");
            modeComboBox.Items.Add("Edit");
            modeComboBox.Items.Add("Add");
            modeComboBox.SelectedValueChanged += ComboBox_SelectionChanged;

            projectListView.Columns.Add("UUID");
            projectListView.Columns.Add("UUID");

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

        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {

        }

        //search for teams button in add project panel 
        private void searchButton_Click(object sender, EventArgs e)
        {

        }

        //cancel button in add project view 
        private void cancelButton_Click(object sender, EventArgs e)
        {

        }

        //confirm add button in add project panel
        private void confirmAddButton_Click(object sender, EventArgs e)
        {

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

        }

        private void ComboBox_SelectionChanged(object sender, EventArgs e)
        {
            switch (modeComboBox.SelectedItem.ToString())
            {
                case "View":
                    //Handle for the first combobox
                    break;
                case "Add":
                    //Handle for the second combobox
                    break;
                case "Edit":
                    //Handle for the third combobox
                    break;
            }
        }
    }
}
