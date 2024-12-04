using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelExpertsData;

namespace TravelExpertsGUI
{
    public partial class frmAddModifyPackagesProducts : Form
    {
        // Create a flag and package product object that can be passed from the main form
        public bool isNewPackageProduct;
        public PackagesProductsSupplier packageProduct;

        public frmAddModifyPackagesProducts()
        {
            InitializeComponent();
        }

        private void frmAddModifyPackagesProducts_Load(object sender, EventArgs e)
        {
            // Fill the comboboxes on form load
            LoadPackages();
            LoadPackageProducts();

            /* Check the flag to see if it is a new package product
             * If it is, set the window title and ID textbox text
             * Otherwise, set the window title and pre-select the values in the comboboxes
             */
            if (isNewPackageProduct)
            {
                this.Text = "Add Package Product";
                txtPackageProductID.Text = "New";
            }
            else
            {
                this.Text = "Modify Package Product";
                ShowPackageProduct();
            }
        }

        // If an existing package product is passed to the form, pre-select the values in the comboboxes
        private void ShowPackageProduct()
        {
            if (packageProduct != null)
            {
                txtPackageProductID.Text = packageProduct.PackageProductSupplierId.ToString();
                cmbPackages.SelectedValue = packageProduct.PackageId;
                cmbProducts.SelectedValue = packageProduct.ProductSupplierId;
            }
        }

        // Fill the packages combobox with packages from the database
        private void LoadPackages()
        {
            List<Package> list = PackageDB.GetPackageCombobox();
            cmbPackages.DataSource = list;
            cmbPackages.DisplayMember = "PkgName";
            cmbPackages.ValueMember = "PackageId";
        }

        // Fill the package products combobox with package products from the database
        private void LoadPackageProducts()
        {
            List<PackagesProductsSupplierDTO> list = PackagesProductsSupplierDB.GetPackageProductsCombobox();
            cmbProducts.DataSource = list;
            cmbProducts.ValueMember = "ProductSupId";
        }

        // Format the package products combobox to display both the product and supplier
        private void cmbProducts_Format(object sender, ListControlConvertEventArgs e)
        {
            string prod = ((PackagesProductsSupplierDTO)e.ListItem).ProductName;
            string sup = ((PackagesProductsSupplierDTO)e.ListItem).SupName;
            e.Value = prod + " - " + sup;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Validate that values in the comboboxes are selected, and provide error messages
            if (ValidatorUtils.IsComboBoxSelected(cmbPackages, "A package must be selected.")
                && ValidatorUtils.IsComboBoxSelected(cmbProducts, "A product must be selected."))
            {
                /* Check the flag to se if it is a new package product
                 * If it is, create a new package product object and assign values to its attributes
                 * Otherwise, just assign updated values to its attributes
                 */
                if (isNewPackageProduct)
                {
                    packageProduct = new PackagesProductsSupplier();
                    PopulatePackageProduct();
                }
                else
                {
                    PopulatePackageProduct();
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        // Assigns the values of the package product object's attributes from the comboboxes
        private void PopulatePackageProduct()
        {
            packageProduct.PackageId = Convert.ToInt32(cmbPackages.SelectedValue);
            packageProduct.ProductSupplierId = Convert.ToInt32(cmbProducts.SelectedValue);
        }

        // Closes the add/modify package products window
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
