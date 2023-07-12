using DSAL_CA1.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DSAL_CA2.Classes
{
    [Serializable]
    internal class EmployeeTreeNode : TreeNode, ISerializable
    {
        public EmployeeTreeNode ParentEmployeeTreeNode { get; set; }
        public Employee Employee { get; set; }
        public List<EmployeeTreeNode> ChildEmployeeTreeNodes { get; set; }

        public EmployeeTreeNode(Employee employee) 
        {
            ParentEmployeeTreeNode = null;
            ChildEmployeeTreeNodes = new List<EmployeeTreeNode>();
            Employee = employee;
            this.Text = employee.Name;
        }

        public EmployeeTreeNode() { }

        public void AddChildEmployeeTreeNode(EmployeeTreeNode employeeNode)
        {
            employeeNode.ParentEmployeeTreeNode = this;
            ChildEmployeeTreeNodes.Add(employeeNode);
            this.Nodes.Add(employeeNode);
        }

        public void RebuildTreeNodes()
        {
            this.Text = this.Employee.Name;
            if (this.ChildEmployeeTreeNodes.Count > 0)
            {
                int i = 0;
                for (i = 0; i < this.ChildEmployeeTreeNodes.Count; i++)
                {
                    this.Nodes.Add(this.ChildEmployeeTreeNodes[i]);
                    this.ChildEmployeeTreeNodes[i].ParentEmployeeTreeNode = this;
                    this.ChildEmployeeTreeNodes[i].RebuildTreeNodes();
                }
            }

        }//End of RebuildTreeNodes
        // File IO Functions ------------------------------------------------------------------

        public void SaveToFileBinary(string filepath)
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                Stream stream = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write);
                bf.Serialize(stream, this);
                stream.Close();

                MessageBox.Show("Data is added to file");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } //End of SaveToFileBinary

        public EmployeeTreeNode ReadFromFileBinary(string filepath)
        {
            try
            {
                Stream stream = new FileStream(@filepath, FileMode.OpenOrCreate, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                EmployeeTreeNode root = null;
                if (stream.Length != 0)
                {
                    root = (EmployeeTreeNode)bf.Deserialize(stream);
                }
                stream.Close();

                return root;
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

        }//end of ReadFromFileBinary

        // [ SERIALIZE ]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //add the required data to file
            info.AddValue("Employee", Employee);
            info.AddValue("ChildrenEmployeeTreeNodes", ChildEmployeeTreeNodes);
            info.AddValue("ParentEmployeeTreeNode", ParentEmployeeTreeNode);

        }//end of GetObjectData [ SERIALIZE ]

        // [DESERIALIZE]
        protected EmployeeTreeNode(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
            this.Employee = (Employee)info.GetValue("Employee", typeof(Employee));
            this.Employee.Container = this;
            this.ChildEmployeeTreeNodes = (List<EmployeeTreeNode>)info.GetValue("ChildrenEmployeeTreeNodes", typeof(List<EmployeeTreeNode>));
            this.ParentEmployeeTreeNode = (EmployeeTreeNode)info.GetValue("ParentEmployeeTreeNode", typeof(EmployeeTreeNode));
        }//end of RoleTreeNode [ DESERIALIZE ]

        // End Of File IO Functions ---------------------------------------------------------------------------------------


        public void SearchByUUID(string uuid, ref List<EmployeeTreeNode> foundNodes)
        {
            if (this.ChildEmployeeTreeNodes.Count > 0)//Note: This if block may not be necessary at all. Though the logic works.
            {
                int i = 0;
                for (i = 0; i < this.ChildEmployeeTreeNodes.Count; i++)
                {
                    if (this.ChildEmployeeTreeNodes[i].Employee.UUID == uuid)
                    { 
                        foundNodes.Add(this.ChildEmployeeTreeNodes[i]);
                    }
                    else
                    { 
                        this.ChildEmployeeTreeNodes[i].SearchByUUID(uuid, ref foundNodes);
                    }
                }
            }
        }//End of SearchByUUID method
    }
}
