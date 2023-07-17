using DSAL_CA1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
#pragma warning disable SYSLIB0011

namespace DSAL_CA2.Classes
{
    [Serializable]
    internal class GenericTreeNode<T> : TreeNode
    {
        public GenericTreeNode<T> ParentTreeNode { get; set; }
        public T data { get; set; }
        public List<GenericTreeNode<T>> ChildTreeNodes { get; set; }

        public GenericTreeNode(T data)
        {
            this.data = data;
            this.ParentTreeNode = new GenericTreeNode<T>(data);
            this.ChildTreeNodes = new List<GenericTreeNode<T>>();
        }

        public GenericTreeNode() { }

        public void AddChildTreeNode(GenericTreeNode<T> Node)
        {
            Node.ParentTreeNode = this;
            ChildTreeNodes.Add(Node);
            this.Nodes.Add(Node);
        } // End of AddChildRoleTreeNode method

        public Queue<GenericTreeNode<T>> LevelOrderTraversal(GenericTreeNode<T> root, int level)
        {
            if (root == null)
                return null;

            // Standard level order traversal code
            // using queue
            Queue<GenericTreeNode<T>> q = new Queue<GenericTreeNode<T>>(); // Create a queue
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
                    GenericTreeNode<T> p = q.Peek();
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

        public GenericTreeNode<T> ReadFromFileBinary(string filepath)
        {
            try
            {
                Stream stream = new FileStream(@filepath, FileMode.OpenOrCreate, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                GenericTreeNode<T> root = null;
                if (stream.Length != 0)
                {
                    root = (GenericTreeNode<T>)bf.Deserialize(stream);
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
