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
    public class Project: ISerializable
    {
        public string UUID { get; set; }
        public string projName { get; set; }
        public int revenue { get; set; }
        public Employee teamLead { get; set; }

        public Project() { }

        public Project(string projName)
        {
            UUID = General.GenerateUUID();
            this.projName = projName;
        }

        // [ SERIALIZE ]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //add the required data to file
            info.AddValue("teamLead", teamLead);
            info.AddValue("revenue", revenue);
            info.AddValue("projName", projName);
            info.AddValue("UUID", UUID);

        }//end of GetObjectData [ SERIALIZE ]

        // [DESERIALIZE]
        protected Project(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
            this.teamLead = (Employee)info.GetValue("teamLead", typeof(Employee));
            this.revenue = (int)info.GetValue("revenue", typeof(int));
            this.projName = (string)info.GetValue("projName", typeof(string));
            this.UUID = (string)info.GetValue("UUID", typeof(string));

        }//end of RoleTreeNode [ DESERIALIZE ]
    }
}
