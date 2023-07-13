using DSAL_CA1.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAL_CA2.Classes
{
    [Serializable]
    internal class DataManager
    //******************************** IMPORTANT *********************************************
    //About DataManager
    //You should manage all the employee data, role data and project data by applying code
    //in this DataManager instead of having seperate RoleManager, EmployeeManager and ProjectManager class
    //****************************************************************************************
    {
        public RoleTreeNode RoleTreeStructure { get; set; }
        public EmployeeTreeNode EmployeeTreeStructure { get; set; }
        public List<Project> ProjectTreeStructure { get; set; }   
        private string _filePath; // Saved data file path

        public DataManager()
        {
            _filePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\Data.dat";
        }

        public RoleTreeNode generateDefaultRoleTree()
        {
            RoleTreeStructure = new RoleTreeNode(new Role("ROOT"));
            return RoleTreeStructure;   
        }

        public EmployeeTreeNode generateDefaultEmployeeTree()
        {
            EmployeeTreeStructure = new EmployeeTreeNode(new Employee("ROOT"));
            return EmployeeTreeStructure;
        }

        public void generateDefualtProjectListView()
        {

        }

        public void SaveRoleData()
        {
            this.RoleTreeStructure.SaveToFileBinary(_filePath);
        }//end of SaveRoleData

        public RoleTreeNode LoadRoleData()
        {
            this.RoleTreeStructure = this.RoleTreeStructure.ReadFromFileBinary(_filePath);
            this.RoleTreeStructure.RebuildTreeNodes();
            return this.RoleTreeStructure;

        } //end of LoadRoleData method

        public void SaveEmployeeData()
        {
            this.EmployeeTreeStructure.SaveToFileBinary(_filePath);
        }

        public EmployeeTreeNode LoadEmployeeData()
        {
            this.EmployeeTreeStructure = this.EmployeeTreeStructure.ReadFromFileBinary(_filePath);
            this.EmployeeTreeStructure.RebuildTreeNodes();
            return this.EmployeeTreeStructure;
        }

        public void SaveProjectList()
        {

        }

        public void LoadProjectList()
        {

        }

    }//end of class RoleManager
}
