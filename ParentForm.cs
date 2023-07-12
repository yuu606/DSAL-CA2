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
    public partial class ParentForm : Form
    {
        public RoleForm form1;
        public EmployeeForm form2;
        public ProjectForm form3;

        public ParentForm()
        {
            InitializeComponent();
            this.roleToolStripMenuItem.Click += new EventHandler(this.RoleFormToolStripMenuItem_Click);
            this.employeeToolStripMenuItem.Click += new EventHandler(this.EmployeeFormToolStripMenuItem_Click);
            this.projectToolStripMenuItem.Click += new EventHandler(this.ProjectFormToolStripMenuItem_Click);
        }

        private void RoleFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (form1 != null)
            {
                form1.Show();
            }
            else
            {
                form1 = new RoleForm();
                form1.MdiParent = this;
                form1.Show();
            }
        }

        private void EmployeeFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (form2 != null)
            {
                form2.Show();
            }
            else
            {
                form2 = new EmployeeForm();
                form2.MdiParent = this;
                form2.Show();
            }
        }

        private void ProjectFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (form3 != null)
            {
                form3.Show();
            }
            else
            {
                form3 = new ProjectForm();
                form3.MdiParent = this;
                form3.Show();
            }
        }

        private void ParentForm_Load(object sender, EventArgs e)
        {

        }
    }
}
