using DSAL_CA1.Classes;
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
    public partial class SwapEmployeeForm : Form
    {
        private Employee _oneEmployee;
        public delegate void SwapItemDelegate(string uuid, string roleName);
        public SwapItemDelegate SwapItemCallback;

        public SwapEmployeeForm(string name)
        {
            InitializeComponent();
            this._oneEmployee = new Employee();
            this._oneEmployee.Name = name;
        }

        private void SwapEmployeeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
