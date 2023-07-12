using DSAL_CA1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DSAL_CA2.Classes
{
    [Serializable]
    internal class TreeNode<T> : TreeNode, ISerializable
    {
        public TreeNode<T> ParentTreeNode { get; set; }
        public T data { get; set; }
        public List<TreeNode<T>> ChildTreeNodes { get; set; }

        public void AddChildTreeNode(TreeNode<T> Node)
        {
            Node.ParentTreeNode = this;
            ChildTreeNodes.Add(Node);
            this.Nodes.Add(Node);
        } // End of AddChildRoleTreeNode method

        
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
