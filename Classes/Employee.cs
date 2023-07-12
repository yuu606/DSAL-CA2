using DSAL_CA1.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DSAL_CA2.Classes
{
    [Serializable]
    internal class Employee
    {
        public EmployeeTreeNode Container { get; set; }
        public string UUID { get; set; }
        public string ReportingOfficer { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Role { get; set; }
        public List<Project> Projects { get; set; }

        public Employee(string name) 
        {
            UUID = General.GenerateUUID();
            Name = name;
        }

        public Employee() { }
    }
}
