using DSAL_CA2.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSAL_CA2
{
    public partial class EditEmployee2Form : Form
    {
        private Employee _oneEmployee;
        public delegate void ModifyItem2Delegate(string uuid, string role, string reportingOfficer);
        public ModifyItem2Delegate ModifyItem2Callback;

        public EditEmployee2Form()
        {
            InitializeComponent();
        }

        public EditEmployee2Form(string uuid, string role, string reportingOfficer)
        {
            InitializeComponent();
            this._oneEmployee = new Employee();
            this._oneEmployee.Name = Name;
            this._oneEmployee.UUID = uuid;
        }

        private void EditEmployee2Form_Load(object sender, EventArgs e)
        {

        }
    }
}
