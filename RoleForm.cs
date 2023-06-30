namespace DSAL_CA2
{
    public partial class RoleForm : Form
    {
        public RoleForm()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((ParentForm)this.MdiParent).form1 = null;
        }
    }
}