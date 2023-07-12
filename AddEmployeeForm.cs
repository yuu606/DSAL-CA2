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
    public partial class AddEmployeeForm : Form
    {
        private Employee _oneEmployee;
        public delegate void AddItemDelegate(string uuid, string roleName);
        public AddItemDelegate AddItemCallback;

        public AddEmployeeForm()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
        }

        private void AddEmployeeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
