using DSAL_CA1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAL_CA2.Classes
{
    [Serializable]
    public class Project
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
    }
}
