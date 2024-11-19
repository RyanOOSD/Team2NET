namespace TravelExpertsGUI
{
    public partial class frmOptionPicker : Form
    {
        public frmOptionPicker()
        {
            InitializeComponent();
        }

        private void btnManageAgents_Click(object sender, EventArgs e)
        {
            frmAgents newForm = new frmAgents();
            newForm.ShowDialog();
        }
    }
}
