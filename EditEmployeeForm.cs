using DSAL_CA1;
using DSAL_CA2;
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
    public partial class EditEmployeeForm : Form
    {
        private Employee _oneEmployee;
        public delegate void ModifyItemDelegate(string uuid, string Name);
        public ModifyItemDelegate ModifyItemCallback;

        public EditEmployeeForm()
        {
            InitializeComponent();
        }

        public EditEmployeeForm(string uuid, string Name)
        {
            InitializeComponent();
            this._oneEmployee = new Employee();
            this._oneEmployee.Name = Name;
            this._oneEmployee.UUID = uuid;
        }

        private void EditEmployeeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
