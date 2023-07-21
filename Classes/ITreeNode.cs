using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAL_CA2.Classes
{
    
    public interface ITreeNode<T>
    {
        T Parent { get; set; }
        bool IsLeaf { get; set; }
        bool IsRoot { get; set; }
        T GetRootNode();
        string GetFullyQualifiedName();
    }
}
