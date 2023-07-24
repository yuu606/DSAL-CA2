using DSAL_CA2.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DSAL_CA1.Classes
{
    [Serializable]
    public class RoleTreeNode : GenericTreeNode<Role>, ISerializable
    {
        
        //getters and setters 
        public RoleTreeNode ParentRoleTreeNode { get; set; }
        public Role Role { get; set; }
        public List<RoleTreeNode> ChildRoleTreeNodes { get; set; }
        public bool IsLeaf { get; set; }
        public bool IsRoot { get; set; }

        //Two constructors
        public RoleTreeNode(Role data): base (data)
        {
            ParentRoleTreeNode = null;
            ChildRoleTreeNodes = new List<RoleTreeNode>();
            Role = data;
            Role.Container = this;
            this.Text = data.Name;
        } // end of constructor
        public RoleTreeNode() { } // End of constructor
        //End of two constructors

        public void AddChildRoleTreeNode(RoleTreeNode roleNode)
        {
            roleNode.ParentRoleTreeNode = this;
            ChildRoleTreeNodes.Add(roleNode);
            this.Nodes.Add(roleNode);
        } // End of AddChildRoleTreeNode method

        public void DeleteNode(RoleTreeNode parentNode, RoleTreeNode nodeToDelete)
        {
            if (parentNode == null || nodeToDelete == null)
            {
                return;
            }
            parentNode.ChildRoleTreeNodes.Remove(nodeToDelete);
        }

        public void RebuildTreeNodes()
        {
            this.Text = this.Role.Name;
            if (this.ChildRoleTreeNodes.Count > 0)
            {
                int i = 0;
                for (i = 0; i < this.ChildRoleTreeNodes.Count; i++)
                {
                    this.Nodes.Add(this.ChildRoleTreeNodes[i]);
                    this.ChildRoleTreeNodes[i].ParentRoleTreeNode = this;
                    this.ChildRoleTreeNodes[i].RebuildTreeNodes();
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
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                bf.Serialize(stream, this);
                stream.Close();

                MessageBox.Show("Data is added to file");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } //End of SaveToFileBinary

        public RoleTreeNode ReadFromFileBinary(string filepath)
        {
            try
            {
                Stream stream = new FileStream(@filepath, FileMode.OpenOrCreate, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                RoleTreeNode root = null;
                if (stream.Length != 0)
                {
                    root = (RoleTreeNode)bf.Deserialize(stream);
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
            info.AddValue("Role", Role);
            info.AddValue("ChildrenRoleTreeNodes", ChildRoleTreeNodes);
            info.AddValue("ParentRoleTreeNode", ParentRoleTreeNode);

        }//end of GetObjectData [ SERIALIZE ]

        // [DESERIALIZE]
        protected RoleTreeNode(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
            this.Role = (Role)info.GetValue("Role", typeof(Role));
            this.Role.Container = this;
            this.ChildRoleTreeNodes = (List<RoleTreeNode>)info.GetValue("ChildrenRoleTreeNodes", typeof(List<RoleTreeNode>));
            this.ParentRoleTreeNode = (RoleTreeNode)info.GetValue("ParentRoleTreeNode", typeof(RoleTreeNode));
        }//end of RoleTreeNode [ DESERIALIZE ]

        // End Of File IO Functions ---------------------------------------------------------------------------------------

        public void SearchByUUID(string uuid, ref List<RoleTreeNode> foundNodes)
        {
            if (this.ChildRoleTreeNodes.Count > 0)
            {
                int i = 0;
                for (i = 0; i < this.ChildRoleTreeNodes.Count; i++)
                {
                    if (this.ChildRoleTreeNodes[i].Role.UUID == uuid)
                    { 
                        foundNodes.Add(this.ChildRoleTreeNodes[i]);
                    }
                    else
                    {
                        this.ChildRoleTreeNodes[i].SearchByUUID(uuid, ref foundNodes);
                    }
                }
            }
        }//End of SearchByUUID method

        public void SearchByRoleName(string roleName, ref List<RoleTreeNode> foundNodes)
        {
            if (this.ChildRoleTreeNodes.Count > 0)
            {
                int i = 0;
                for (i = 0; i < this.ChildRoleTreeNodes.Count; i++)
                {
                    if (this.ChildRoleTreeNodes[i].Role.Name == roleName)
                    {
                        foundNodes.Add(this.ChildRoleTreeNodes[i]);
                    }
                    else
                    {
                        this.ChildRoleTreeNodes[i].SearchByRoleName(roleName, ref foundNodes);
                    }
                }
            }
        }


        public Queue<RoleTreeNode> SearchByLevelOrderTraversal(RoleTreeNode root, int level)
        {
            if (root == null)
                return null;

            
            Queue<RoleTreeNode> q = new Queue<RoleTreeNode>();
            q.Enqueue(root); 
            int k = 0;
            while (q.Count != 0)
            {
                int n = q.Count;

                while (n > 0)
                {
                    RoleTreeNode p = q.Peek();
                    q.Dequeue();

                    for (int i = 0; i < p.ChildRoleTreeNodes.Count; i++)
                        q.Enqueue(p.ChildRoleTreeNodes[i]);
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
    }//end of RoleTreeNode class
}


