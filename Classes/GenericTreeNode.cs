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
    public abstract class GenericTreeNode<T> : TreeNode
    {
        public GenericTreeNode<T> ParentTreeNode { get; set; }
        public T data { get; set; }
        public List<GenericTreeNode<T>> ChildTreeNodes { get; set; }

        public GenericTreeNode(T data)
        {
            this.data = data;
            this.ParentTreeNode = null;
            this.ChildTreeNodes = new List<GenericTreeNode<T>>();
        }

        public GenericTreeNode() { }
    }
}
