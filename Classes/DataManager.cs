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
    {
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
            newEmployee.roleList.Add(_data.RoleTreeStructure.Role);
            RoleTreeNode root = LoadRoleData();
            _data.EmployeeTreeStructure = new EmployeeTreeNode(newEmployee);
            _data.EmployeeTreeStructure.localRoleTreeNode = root;
            return _data.EmployeeTreeStructure;
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


        public List<Project> LoadProjectList()
        {
            _data = ReadFromFile();
            if (_data.ProjectList == null)
            {
                _data.ProjectList = new List<Project>();
            }

            return _data.ProjectList;
            
        } 
        //--------------------------------------------------------------------------------------------

        public void SaveData()
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                Stream stream = new FileStream(_filePath, FileMode.OpenOrCreate, FileAccess.Write);
                bf.Serialize(stream, this._data);
                stream.Close();

                MessageBox.Show("Data Saved");
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

        public bool IsTeamFull(RoleTreeNode roleTree, EmployeeTreeNode employeeTree)
        {
            List<Role> fullTeam = getTeam(roleTree);

            if (roleTree == null && employeeTree == null)
                return true;

            if (roleTree == null || employeeTree == null)
                return false;

            if (!(roleTree.Role.Name == employeeTree.localRoleTreeNode.Role.Name))
                return false;

            if (employeeTree.ChildEmployeeTreeNodes.Count < roleTree.ChildRoleTreeNodes.Count)
                return false;

            int j = 0;
            for (int i = 0; i < fullTeam.Count; i++)
            {
                if (fullTeam[i].Name.Equals(employeeTree.ChildEmployeeTreeNodes[i].localRoleTreeNode.Role.Name))
                {
                    j++;
                }
                else
                {
                    return false;
                }
            }

            if (j > fullTeam.Count)
            {
                return false;
            }

            return true;
        }

        public List<Role> getTeam(RoleTreeNode parentRoleNode)
        {
            List<Role> fullTeam = new List<Role>();
            for (int i = 0; i < parentRoleNode.ChildRoleTreeNodes.Count; i++)
            {
                fullTeam.Add(parentRoleNode.ChildRoleTreeNodes[i].Role);
            }
            return fullTeam;
        }

        public EmployeeTreeNode CopyTreeNode(EmployeeTreeNode sourceNode)
        {
            if (sourceNode == null)
                return null;

            EmployeeTreeNode copyNode = new EmployeeTreeNode(sourceNode.Employee);

            foreach (var child in sourceNode.ChildEmployeeTreeNodes)
            {
                EmployeeTreeNode childCopy = CopyTreeNode(child);
                copyNode.ChildEmployeeTreeNodes.Add(childCopy);
            }

            return copyNode;
        }

    }//end of class RoleManager
}
