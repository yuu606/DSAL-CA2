using DSAL_CA1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DSAL_CA2.Classes
{
    [Serializable]
    internal class TreeNode<T> : TreeNode
    {
        public TreeNode<T> ParentTreeNode { get; set; }
        public T data { get; set; }
        public List<TreeNode<T>> ChildTreeNodes { get; set; }

        public TreeNode(T data)
        {
            this.data = data;
            this.ParentTreeNode = new TreeNode<T>(data);
            this.ChildTreeNodes = new List<TreeNode<T>>();
        }

        public void AddChildTreeNode(TreeNode<T> Node)
        {
            Node.ParentTreeNode = this;
            ChildTreeNodes.Add(Node);
            this.Nodes.Add(Node);
        } // End of AddChildRoleTreeNode method

        public Queue<TreeNode<T>> LevelOrderTraversal(TreeNode<T> root, int level)
        {
            if (root == null)
                return null;

            // Standard level order traversal code
            // using queue
            Queue<TreeNode<T>> q = new Queue<TreeNode<T>>(); // Create a queue
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
                    TreeNode<T> p = q.Peek();
                    q.Dequeue();
                    Console.Write(p.data + " ");

                    // Enqueue all children of
                    // the dequeued item
                    for (int i = 0; i < p.ChildTreeNodes.Count; i++)
                        q.Enqueue(p.ChildTreeNodes[i]);
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

        public TreeNode<T> ReadFromFileBinary(string filepath)
        {
            try
            {
                Stream stream = new FileStream(@filepath, FileMode.OpenOrCreate, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                TreeNode<T> root = null;
                if (stream.Length != 0)
                {
                    root = (TreeNode<T>)bf.Deserialize(stream);
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

    }
}
