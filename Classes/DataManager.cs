using DSAL_CA1.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
        public List<Project> ProjectList { get; set; }   

        private Data _data;
        private string _filePath; // Saved data file path

        public DataManager(Data data)
        {
            _data = data;
            _filePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\Data.dat";
        }

        //Manage role data methods 
        //--------------------------------------------------------------------------------------------
        public RoleTreeNode generateDefaultRoleTree()
        {
            RoleTreeStructure = new RoleTreeNode(new Role("ROOT"));
            return RoleTreeStructure;   
        }
        public void SaveRoleData()
        {
            _data.RoleTreeStructure.SaveToFileBinary(_filePath);
        }//end of SaveRoleData

        public RoleTreeNode LoadRoleData()
        {
            _data.RoleTreeStructure = _data.RoleTreeStructure.ReadFromFileBinary(_filePath);
            if (_data.RoleTreeStructure == null)
            {
                return null;
            }
            _data.RoleTreeStructure.RebuildTreeNodes();
            return _data.RoleTreeStructure;

        } //end of LoadRoleData method
        //--------------------------------------------------------------------------------------------

        //Manage employee data methods 
        //--------------------------------------------------------------------------------------------
        public EmployeeTreeNode generateDefaultEmployeeTree()
        {
            Employee newEmployee = new Employee("ROOT");
            newEmployee.role = RoleTreeStructure.Role;
            _data.EmployeeTreeStructure = new EmployeeTreeNode(newEmployee);
            return _data.EmployeeTreeStructure;
        }

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
        //--------------------------------------------------------------------------------------------

        public List<ColumnHeader> generateDefaultProjectListView()
        {
            List<string> headers = new List<string>(){"UUID", "Project Name", "Revenue", "Team Leader"};
            List<ColumnHeader> chs = new List<ColumnHeader>();
            foreach (string header in headers)
            {
                ColumnHeader ch = new ColumnHeader(header);
                chs.Add(ch);
            }
            return chs;
        }

        //Manage project data methods 
        //--------------------------------------------------------------------------------------------
        public void SaveProjectList()
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                Stream stream = new FileStream(_filePath, FileMode.OpenOrCreate, FileAccess.Write);
                bf.Serialize(stream, this.ProjectList);
                stream.Close();

                MessageBox.Show("Data is added to file");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<Project> LoadProjectList()
        {
            try
            {
                Stream stream = new FileStream(_filePath, FileMode.OpenOrCreate, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                List<Project> projectList = null;
                if (stream.Length != 0)
                {
                    projectList = (List<Project>)bf.Deserialize(stream);
                }
                stream.Close();

                return projectList;
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Unable to find file.");
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        } 
        //--------------------------------------------------------------------------------------------

        public void saveData()
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                Stream stream = new FileStream(_filePath, FileMode.OpenOrCreate, FileAccess.Write);
                bf.Serialize(stream, this._data);
                stream.Close();

                MessageBox.Show("Data is added to file");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Data ReadFromFile()
        {
            try
            {
                Stream stream = new FileStream(_filePath, FileMode.OpenOrCreate, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                
                if (stream.Length != 0)
                {
                    _data = (Data)bf.Deserialize(stream);
                }
                stream.Close();

                return _data;
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Unable to find file.");
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }//end of class RoleManager
}
