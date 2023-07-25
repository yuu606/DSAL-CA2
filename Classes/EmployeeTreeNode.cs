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
    public class EmployeeTreeNode : GenericTreeNode<Employee>, ISerializable
    {
        public EmployeeTreeNode ParentEmployeeTreeNode { get; set; }
        public Employee Employee { get; set; }
        public List<EmployeeTreeNode> ChildEmployeeTreeNodes { get; set; }
        public bool IsLeaf { get; set; }
        public bool IsRoot { get; set; }

        public EmployeeTreeNode(Employee data) : base(data)
        {
            ParentEmployeeTreeNode = null;
            ChildEmployeeTreeNodes = new List<EmployeeTreeNode>();
            this.Employee = data;
            Employee.Container = this;
            this.Text = data.Name + " - " + data.role.Name + " (S$" + data.Salary + ")";
        }

        public EmployeeTreeNode() { }

        public void AddChildEmployeeTreeNode(EmployeeTreeNode employeeNode)
        {
            employeeNode.ParentEmployeeTreeNode = this;
            ChildEmployeeTreeNodes.Add(employeeNode);
            this.Nodes.Add(employeeNode);
        }

        public void DeleteNode(EmployeeTreeNode parentNode, EmployeeTreeNode nodeToDelete)
        {
            if (parentNode == null || nodeToDelete == null)
            {
                return;
            }
            parentNode.ChildEmployeeTreeNodes.Remove(nodeToDelete);
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

        public void SearchByEmployeeName(string employeeName, ref List<EmployeeTreeNode> foundNodes)
        {
            if (this.ChildEmployeeTreeNodes.Count > 0)
            {
                int i = 0;
                for (i = 0; i < this.ChildEmployeeTreeNodes.Count; i++)
                {
                    if (this.ChildEmployeeTreeNodes[i].Employee.Name == employeeName)
                    {
                        foundNodes.Add(this.ChildEmployeeTreeNodes[i]);
                    }
                    else
                    {
                        this.ChildEmployeeTreeNodes[i].SearchByEmployeeName(employeeName, ref foundNodes);
                    }
                }
            }
        }// end of SearchByEmployeeName
    }
}
