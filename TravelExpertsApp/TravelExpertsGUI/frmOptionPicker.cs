    namespace TravelExpertsGUI
{
    public partial class frmOptionPicker : Form
    {

        string rootDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
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

        private void frmOptionPicker_Load(object sender, EventArgs e)
        {
            picLogo.Image = Image.FromFile(rootDir + "\\Images\\travel-experts.png");
            Icon = Icon.ExtractAssociatedIcon(rootDir + "\\Images\\airplane.ico");
        }

        private void btnManagePackages_Click(object sender, EventArgs e)
        {
            frmManagePackages managePackages = new frmManagePackages();
            managePackages.ShowDialog();
        }

        private void btnManageAgents_Click(object sender, EventArgs e)
        {
            frmAgents newForm = new frmAgents();
            newForm.ShowDialog();
        }
    }
}
