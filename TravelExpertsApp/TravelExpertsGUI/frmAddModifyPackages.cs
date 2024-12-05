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
        // Create a flag and package object that can be passed from the main form
        public bool isNewPackage;
        public TravelExpertsData.Package package;

        public frmAddModifyPackages()
        {
            InitializeComponent();
        }

        private void frmAddModifyPackages_Load(object sender, EventArgs e)
        {
            /* Check the flag to see if it is a new package
             * If it is, set the window title and ID textbox text
             * Otherwise, set the window title and pre-fill the input fields
             */
            if (isNewPackage)
            {
                this.Text = "Add Package";
                txtPkgID.Text = "New";
            }
            else
            {
                this.Text = "Modify Package";
                ShowPackage();
            }
        }

        // If an existing package is passed to the form, pre-fill the input fields
        private void ShowPackage()
        {
            if (package != null)
            {
                txtPkgID.Text = package.PackageId.ToString();
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
            // Validate the input fields and provide error messages
            if (ValidatorUtils.IsTextBoxNotEmpty(txtPkgName, "Package name cannot be empty.")
                && ValidatorUtils.IsTextBoxNotEmpty(txtPkgDesc, "Package description cannot be empty.")
                && ValidatorUtils.IsTextBoxWithinMaxLength(txtPkgName, 50, "Package name cannot exceed 50 characters.")
                && ValidatorUtils.IsTextBoxWithinMaxLength(txtPkgDesc, 50, "Package description cannot exceed 50 characters.")
                && ValidatorUtils.IsStartDateNotEarlierThanToday(dtpPkgStartDate, "Package start date cannot be earlier than today's date.")
                && ValidatorUtils.IsEndDateAfterStartDate(dtpPkgStartDate, dtpPkgEndDate, "Package end date cannot be earlier than or equal to the start date.")
                && ValidatorUtils.IsNonNegativeDecimal(txtPkgBasePrice, "Package base price must be a non-negative numeric value.")
                && ValidatorUtils.IsNonNegativeDecimal(txtAgencyCommission, "Agency commission must be a non-negative numeric value."))
            {
                /* Check the flag to see if it is a new package
                 * If it is, create a new package object and assign values to its attributes
                 * Otherwise, just assign new values to its attributes
                 */
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
        }

        // Assigns the values of the package object's attributes from the input fields
        private void PopulatePackage()
        {
            package.PkgName = txtPkgName.Text;
            package.PkgStartDate = dtpPkgStartDate.Value;
            package.PkgEndDate = dtpPkgEndDate.Value;
            package.PkgDesc = txtPkgDesc.Text;
            package.PkgBasePrice = Convert.ToDecimal(txtPkgBasePrice.Text);
            package.PkgAgencyCommission = Convert.ToDecimal(txtAgencyCommission.Text);
        }

        // Closes the add/modify packages window
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
