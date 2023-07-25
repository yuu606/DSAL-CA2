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
        //public RoleTreeNode RoleTreeStructure { get; set; }
        //public EmployeeTreeNode EmployeeTreeStructure { get; set; }
        //public List<Project> ProjectList { get; set; }   

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
            _data.RoleTreeStructure = new RoleTreeNode(new Role("ROOT"));
            return _data.RoleTreeStructure;   
        }
        public void SaveRoleData()
        {
            _data.ProjectList = null;
            _data.EmployeeTreeStructure = null;
            saveData();
        }//end of SaveRoleData

        public RoleTreeNode LoadRoleData()
        {
            _data = ReadFromFile();
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
            newEmployee.role = _data.RoleTreeStructure.Role;
            _data.EmployeeTreeStructure = new EmployeeTreeNode(newEmployee);
            return _data.EmployeeTreeStructure;
        }

        public void SaveEmployeeData()
        {
            _data.ProjectList = null;
            _data.RoleTreeStructure = null;
            saveData();
        }

        public EmployeeTreeNode LoadEmployeeData()
        {
            _data = ReadFromFile();
            if (_data.EmployeeTreeStructure == null)
            {
                return null;
            }
            _data.EmployeeTreeStructure.RebuildTreeNodes();
            return _data.EmployeeTreeStructure;
        }
        //--------------------------------------------------------------------------------------------

        //Manage project data methods 
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

        public void SaveProjectList()
        {
            _data.RoleTreeStructure = null;
            _data.EmployeeTreeStructure = null;
            saveData();
        }

        public List<Project> LoadProjectList()
        {
            _data = ReadFromFile();
            return _data.ProjectList;
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
