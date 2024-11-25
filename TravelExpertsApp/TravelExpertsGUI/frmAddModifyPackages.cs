using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelExpertsGUI
{
    public partial class frmAddModifyPackages : Form
    {
        public bool isNewPackage;
        public TravelExpertsData.Package package;

        public frmAddModifyPackages()
        {
            InitializeComponent();
        }

        private void frmAddModifyPackages_Load(object sender, EventArgs e)
        {
            if (isNewPackage)
            {
                this.Text = "Add Package";
            }
            else
            {
                this.Text = "Modify Package";
                ShowPackage();
            }
        }

        private void ShowPackage()
        {
            if (package != null)
            {
                txtPkgName.Text = package.PkgName;
                dtpPkgStartDate.Value = Convert.ToDateTime(package.PkgStartDate);
                dtpPkgEndDate.Value = Convert.ToDateTime(package.PkgEndDate);
                txtPkgDesc.Text = package.PkgDesc;
                txtPkgBasePrice.Text = package.PkgBasePrice.ToString();
                txtAgencyCommission.Text = package.PkgAgencyCommission.ToString();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (isNewPackage)
            {
                package = new TravelExpertsData.Package();
                PopulatePackage();
            }
            else
            {
                PopulatePackage();
            }
            this.DialogResult = DialogResult.OK;
        }

        private void PopulatePackage()
        {
            package.PkgName = txtPkgName.Text;
            package.PkgStartDate = dtpPkgStartDate.Value;
            package.PkgEndDate = dtpPkgEndDate.Value;
            package.PkgDesc = txtPkgDesc.Text;
            package.PkgBasePrice = Convert.ToDecimal(txtPkgBasePrice.Text);
            package.PkgAgencyCommission = Convert.ToDecimal(txtAgencyCommission.Text);
        }
    }
}
