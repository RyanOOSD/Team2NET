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
        public bool isNewPackageProduct;
        public PackagesProductsSupplier packageProduct;

        public frmAddModifyPackagesProducts()
        {
            InitializeComponent();
        }

        private void frmAddModifyPackagesProducts_Load(object sender, EventArgs e)
        {
            LoadPackages();
            LoadPackageProducts();

            if (isNewPackageProduct)
            {
                this.Text = "Add Package Product";
            }
            else
            {
                this.Text = "Modify Package Product";
                ShowPackageProduct();
            }
        }

        private void ShowPackageProduct()
        {
            if (packageProduct != null)
            {
                cmbPackages.SelectedItem = packageProduct.PackageId;
                cmbProducts.SelectedItem = packageProduct.ProductSupplierId;
            }
        }

        private void LoadPackages()
        {
            List<Package> list = PackageDB.GetPackageCombobox();
            cmbPackages.DataSource = list;
            cmbPackages.DisplayMember = "PkgName";
            cmbPackages.ValueMember = "PackageId";
        }

        private void LoadPackageProducts()
        {
            List<PackagesProductsSupplierDTO> list = PackagesProductsSupplierDB.GetPackageProductsCombobox();
            cmbProducts.DataSource = list;
            cmbProducts.ValueMember = "ProductSupId";
        }

        private void cmbProducts_Format(object sender, ListControlConvertEventArgs e)
        {
            string prod = ((PackagesProductsSupplierDTO)e.ListItem).ProductName;
            string sup = ((PackagesProductsSupplierDTO)e.ListItem).SupName;
            e.Value = prod + " - " + sup;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
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

        private void PopulatePackageProduct()
        {
            packageProduct.PackageId = Convert.ToInt32(cmbPackages.SelectedValue);

            packageProduct.ProductSupplierId = Convert.ToInt32(cmbProducts.SelectedValue);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
