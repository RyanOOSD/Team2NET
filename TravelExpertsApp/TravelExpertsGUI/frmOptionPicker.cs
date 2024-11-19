    namespace TravelExpertsGUI
{
    public partial class frmOptionPicker : Form
    {
        public frmOptionPicker()
        {
            InitializeComponent();

            frmLogin newForm = new frmLogin();
            newForm.ShowDialog();
        }

        private void btnManageProducts_Click(object sender, EventArgs e)
        {
            frmProductAndSupplier newForm = new frmProductAndSupplier();
            newForm.ShowDialog();         
        }

        private void btnManageAgents_Click(object sender, EventArgs e)
        {
            frmAgents newForm = new frmAgents();
            newForm.ShowDialog();
        }
    }
}
