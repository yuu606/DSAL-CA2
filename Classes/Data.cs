using DSAL_CA1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DSAL_CA2.Classes
{
    [Serializable]
    public class Data : ISerializable
    {
        public RoleTreeNode RoleTreeStructure { get; set; }
        public EmployeeTreeNode EmployeeTreeStructure { get; set; }
        public List<Project> ProjectList { get; set; }

        public Data(){}

        // [ SERIALIZE ]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //add the required data to file
            info.AddValue("RoleTreeStructure", RoleTreeStructure);
            info.AddValue("EmployeeTreeStructure", EmployeeTreeStructure);
            info.AddValue("ProjectList", ProjectList);

        }//end of GetObjectData [ SERIALIZE ]

        // [DESERIALIZE]
        protected Data(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
            this.RoleTreeStructure = (RoleTreeNode)info.GetValue("RoleTreeStructure", typeof(RoleTreeNode));
            this.EmployeeTreeStructure = (EmployeeTreeNode)info.GetValue("EmployeeTreeStructure", typeof(EmployeeTreeNode));
            this.ProjectList = (List<Project>)info.GetValue("ProjectList", typeof(List<Project>));
        }//end of RoleTreeNode [ DESERIALIZE ]
    }
}
