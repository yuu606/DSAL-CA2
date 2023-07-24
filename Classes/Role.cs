using DSAL_CA1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAL_CA2.Classes
{
    [Serializable]
    public class Role
    {
        public RoleTreeNode Container { get; set; }
        public string UUID { get; set; }
        public string Name { get; set; }
        public bool isProjLead { get; set; }  

        public Role(){ }//end of constructor

        public Role(string name)
        {
            UUID = General.GenerateUUID();
            Name = name;
            isProjLead = false;
        } // end of constructor
        //end of two constructors

        public void EditRole(string name)
        {
            Name = name;
        }// End of EditRole method
    }//end of Role class
}
