﻿using DSAL_CA1.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DSAL_CA2.Classes
{
    [Serializable]
    public class EmployeeTreeNode : GenericTreeNode<Employee>, ISerializable
    {
        public EmployeeTreeNode ParentEmployeeTreeNode { get; set; }
        public Employee Employee { get; set; }
        public List<EmployeeTreeNode> ChildEmployeeTreeNodes { get; set; }
        public int localIndex { get; set; }
        public RoleTreeNode localRoleTreeNode { get; set; }
        public Employee localRO { get; set; }
        public bool IsLeaf { get; set; }
        public bool IsRoot { get; set; }

        public EmployeeTreeNode(Employee data) : base(data)
        {
            ParentEmployeeTreeNode = null;
            ChildEmployeeTreeNodes = new List<EmployeeTreeNode>();
            localRoleTreeNode = new RoleTreeNode();
            this.Employee = data;
            Employee.Container = this;
            localIndex = 0;
            localRO = null;
            string roleText = "";
            int i = 0;
            foreach (Role role in data.roleList)
            {
                roleText += role.Name;
                if (i == 1)
                {
                    roleText +=  ", " + role.Name;
                }
                i++;
            }
            this.Text = data.Name + " - " + roleText + " (S$" + data.Salary + ")";
        }

        public EmployeeTreeNode() { }

        // [ SERIALIZE ]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //add the required data to file
            info.AddValue("Employee", Employee);
            info.AddValue("ChildrenEmployeeTreeNodes", ChildEmployeeTreeNodes);
            info.AddValue("ParentEmployeeTreeNode", ParentEmployeeTreeNode);
            info.AddValue("localRoleTreeNode", localRoleTreeNode);
            info.AddValue("localRO", localRO);
            info.AddValue("localIndex", localIndex);

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
            this.localRoleTreeNode = (RoleTreeNode)info.GetValue("localRoleTreeNode", typeof(RoleTreeNode));
            this.localRO = info.GetValue("localRO", typeof(Employee)) as Employee;
            this.localIndex = (int)info.GetValue("localIndex", typeof(int));
        }//end of RoleTreeNode [ DESERIALIZE ]

        // End Of File IO Functions ---------------------------------------------------------------------------------------

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

        public void SwapNodes(EmployeeTreeNode node1, EmployeeTreeNode node2)
        {
            if (node1 != null && node2 != null && node1 != node2)
            {
                EmployeeTreeNode parent1 = node1.ParentEmployeeTreeNode;
                EmployeeTreeNode parent2 = node2.ParentEmployeeTreeNode;

                if (parent1 != null && parent2 != null)
                {
                    int index1 = parent1.ChildEmployeeTreeNodes.IndexOf(node1);
                    int index2 = parent2.ChildEmployeeTreeNodes.IndexOf(node2);

                    parent1.ChildEmployeeTreeNodes[index1] = node2;
                    parent2.ChildEmployeeTreeNodes[index2] = node1;
                }
            }
        }

        public Queue<EmployeeTreeNode> SearchByLevelOrderTraversal(EmployeeTreeNode root, int level)
        {
            if (root == null)
                return null;

            // Standard level order traversal code
            // using queue
            Queue<EmployeeTreeNode> q = new Queue<EmployeeTreeNode>(); // Create a queue
            q.Enqueue(root); // Enqueue root
            int k = 0;
            while (q.Count != 0)
            {
                int n = q.Count;

                // If this node has children
                while (n > 0)
                {
                    // Dequeue an item from queue
                    // and print it
                    EmployeeTreeNode p = q.Peek();
                    q.Dequeue();
                    Console.Write(p.data + " ");

                    // Enqueue all children of
                    // the dequeued item
                    for (int i = 0; i < p.ChildTreeNodes.Count; i++)
                        q.Enqueue(p.ChildEmployeeTreeNodes[i]);
                    n--;
                }

                k++;
                if (k == level)
                {
                    return q;
                }
            }
            return null;
        }

        public void RebuildTreeNodes()
        {
            int j = 0;
            String roleText = "";
            foreach (Role role in this.Employee.roleList)
            {
                roleText += role.Name;
                if (j == 1)
                {
                    roleText += ", " + role.Name;
                }
                j++;
            }
            this.Text = this.Employee.Name + " - " + roleText + " (S$" + this.Employee.Salary + ")";

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
            if (employeeName == "ROOT")
            {
                return;
            }
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

        public void PreOrderTraversal(Action<Employee> action)
        {
            PreOrderTraversalRecursive(this, action);
        }

        private void PreOrderTraversalRecursive(EmployeeTreeNode node, Action<Employee> action)
        {
            if (node == null)
                return;

            action(node.Employee);

            foreach (var child in node.ChildEmployeeTreeNodes)
            {
                PreOrderTraversalRecursive(child, action);
            }
        }
    }
}
