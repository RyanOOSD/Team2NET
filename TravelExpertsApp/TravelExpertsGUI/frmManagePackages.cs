using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelExpertsData;

namespace TravelExpertsGUI
{
    public partial class frmManagePackages : Form
    {
        TravelExpertsData.Package? selectedPackage = null;
        PackagesProductsSupplier? selectedPackageProduct = null;

        List<PackageDTO> packages = new List<PackageDTO>();
        BindingSource dgvPkgBinding = new BindingSource();
        List<PackagesProductsSupplierDTO> packageProducts = new List<PackagesProductsSupplierDTO>();
        BindingSource dgvPkgProductsBinding = new BindingSource();

        const int modifyPkgIndex = 7;
        const int deletePkgIndex = 8;
        const int modifyPkgProductIndex = 5;
        const int deletePkgProductIndex = 6;

        public frmManagePackages()
        {
            InitializeComponent();
        }

        private void frmManagePackages_Load(object sender, EventArgs e)
        {
            DisplayPackages();
            DisplayPackageProducts();
        }

        private void tbcPkgPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayPackages();
            DisplayPackageProducts();
        }

        private void DisplayPackages()
        {
            dgvPkg.Columns.Clear();

            packages = PackageDB.GetPackageList();
            dgvPkg.DataSource = dgvPkgBinding;
            dgvPkgBinding.DataSource = packages;

            FormatPackageView();
        }

        private void FormatPackageView()
        {
            DataGridViewCellStyle btnModifyStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.Yellow,
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            DataGridViewCellStyle btnDeleteStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.Tomato,
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };

            DataGridViewButtonColumn btnModifyColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Text = "Modify",
                FlatStyle = FlatStyle.Popup,
                DefaultCellStyle = btnModifyStyle
            };
            dgvPkg.Columns.Add(btnModifyColumn);
            DataGridViewButtonColumn btnDeleteColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Text = "Delete",
                FlatStyle = FlatStyle.Popup,
                DefaultCellStyle = btnDeleteStyle
            };
            dgvPkg.Columns.Add(btnDeleteColumn);

            dgvPkg.RowHeadersWidth = 25;
            dgvPkg.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvPkg.EnableHeadersVisualStyles = false;
            dgvPkg.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;
            dgvPkg.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvPkg.Columns[0].HeaderText = "Package ID";

            dgvPkg.Columns[1].HeaderText = "Package Name";
            dgvPkg.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvPkg.Columns[1].Width = 130;

            dgvPkg.Columns[2].HeaderText = "Start Date";
            dgvPkg.Columns[2].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgvPkg.Columns[3].HeaderText = "End Date";
            dgvPkg.Columns[3].DefaultCellStyle.Format = "MM/dd/yyyy";

            dgvPkg.Columns[4].HeaderText = "Description";
            dgvPkg.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvPkg.Columns[4].Width = 310;

            dgvPkg.Columns[5].HeaderText = "Price";
            dgvPkg.Columns[5].DefaultCellStyle.Format = "c";
            dgvPkg.Columns[6].HeaderText = "Commission";
            dgvPkg.Columns[6].DefaultCellStyle.Format = "c";

            dgvPkg.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvPkg.Columns[7].Width = 100;
            dgvPkg.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvPkg.Columns[8].Width = 100;
        }

        private void dgvPkg_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex % 2 == 1)
            {
                if (e.ColumnIndex == modifyPkgIndex)
                {
                    e.CellStyle!.BackColor = Color.Yellow;
                }
                else if (e.ColumnIndex == deletePkgIndex)
                {
                    e.CellStyle!.BackColor = Color.Tomato;
                }
                else
                {
                    dgvPkg.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
                }
            }
        }

        private void btnAddPkg_Click(object sender, EventArgs e)
        {
            frmAddModifyPackages addPackage = new frmAddModifyPackages();
            addPackage.isNewPackage = true;
            addPackage.package = null!;

            DialogResult result = addPackage.ShowDialog();
            if (result == DialogResult.OK)
            {
                selectedPackage = addPackage.package;
                PackageDB.AddPackage(selectedPackage);
                MessageBox.Show($"{selectedPackage.PkgName} has been added successfully.");
                DisplayPackages();
            }
        }

        private void dgvPkg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == modifyPkgIndex || e.ColumnIndex == deletePkgIndex)
                {
                    DataGridViewCell packageIDCell = dgvPkg.Rows[e.RowIndex].Cells[0];
                    int packageID = Convert.ToInt32(packageIDCell.Value);
                    selectedPackage = PackageDB.FindPackage(packageID)!;
                }

                if (selectedPackage != null)
                {
                    if (e.ColumnIndex == modifyPkgIndex)
                    {
                        ModifyPackage();
                    }
                    else if (e.ColumnIndex == deletePkgIndex)
                    {
                        DeletePackage();
                    }
                }
            }
        }

        private void ModifyPackage()
        {
            frmAddModifyPackages modifyPackage = new frmAddModifyPackages();
            modifyPackage.isNewPackage = false;
            modifyPackage.package = selectedPackage!;

            DialogResult result = modifyPackage.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (selectedPackage != null)
                {
                    PackageDB.ModifyPackage(selectedPackage);
                    MessageBox.Show($"{selectedPackage.PkgName} has been edited successfully.");
                    DisplayPackages();
                }
            }
        }

        private void DeletePackage()
        {
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete {selectedPackage!.PkgName}?",
                "Confirm Package Deletion", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                PackageDB.DeletePackage(selectedPackage);
                MessageBox.Show("Package has been successfully deleted.");
                DisplayPackages();
            }
        }

        private void txtPkgSearch_TextChanged(object sender, EventArgs e)
        {
            string searchString = txtPkgSearch.Text;
            List<PackageDTO> filteredPackages = packages.Where(package =>
                package.PkgID.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                package.PkgName.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                package.PkgStart.ToString()!.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                package.PkgEnd.ToString()!.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                package.PkgDesc!.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                package.PkgPrice.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                package.PkgCommission.ToString()!.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                ).ToList();
            dgvPkg.Columns.Clear();
            dgvPkgBinding.DataSource = filteredPackages;
            FormatPackageView();
        }

        private void btnPkgExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisplayPackageProducts()
        {
            dgvPkgProducts.Columns.Clear();

            packageProducts = PackagesProductsSupplierDB.GetPackageProductsList();
            dgvPkgProducts.DataSource = dgvPkgProductsBinding;
            dgvPkgProductsBinding.DataSource = packageProducts;

            FormatPackageProductsView();
        }

        private void FormatPackageProductsView()
        {
            dgvPkgProducts.Columns["ProductSupId"].Visible = false;

            DataGridViewCellStyle btnModifyStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.Yellow,
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            DataGridViewCellStyle btnDeleteStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.Tomato,
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };

            DataGridViewButtonColumn btnModifyColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Text = "Modify",
                FlatStyle = FlatStyle.Popup,
                DefaultCellStyle = btnModifyStyle
            };
            dgvPkgProducts.Columns.Add(btnModifyColumn);
            DataGridViewButtonColumn btnDeleteColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Text = "Delete",
                FlatStyle = FlatStyle.Popup,
                DefaultCellStyle = btnDeleteStyle
            };
            dgvPkgProducts.Columns.Add(btnDeleteColumn);

            dgvPkgProducts.RowHeadersWidth = 25;
            dgvPkgProducts.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvPkgProducts.EnableHeadersVisualStyles = false;
            dgvPkgProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;
            dgvPkgProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvPkgProducts.Columns[0].HeaderText = "Package Product ID";
            dgvPkgProducts.Columns[0].Width = 180;
            dgvPkgProducts.Columns[1].HeaderText = "Package Name";
            dgvPkgProducts.Columns[1].Width = 223;
            dgvPkgProducts.Columns[3].HeaderText = "Product Name";
            dgvPkgProducts.Columns[3].Width = 223;
            dgvPkgProducts.Columns[4].HeaderText = "Supplier Name";
            dgvPkgProducts.Columns[4].Width = 223;

            dgvPkgProducts.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvPkgProducts.Columns[5].Width = 100;
            dgvPkgProducts.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvPkgProducts.Columns[6].Width = 100;
        }

        private void dgvPkgProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex % 2 == 1)
            {
                if (e.ColumnIndex == modifyPkgProductIndex)
                {
                    e.CellStyle!.BackColor = Color.Yellow;
                }
                else if (e.ColumnIndex == deletePkgProductIndex)
                {
                    e.CellStyle!.BackColor = Color.Tomato;
                }
                else
                {
                    dgvPkgProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
                }
            }
        }

        private void btnAddProductToPkg_Click(object sender, EventArgs e)
        {
            frmAddModifyPackagesProducts addPackageProducts = new frmAddModifyPackagesProducts();
            addPackageProducts.isNewPackageProduct = true;
            addPackageProducts.packageProduct = null!;

            DialogResult result = addPackageProducts.ShowDialog();
            if (result == DialogResult.OK)
            {
                selectedPackageProduct = addPackageProducts.packageProduct;
                PackagesProductsSupplierDB.AddPackageProduct(selectedPackageProduct);
                MessageBox.Show("Product successfully added to the package.");
                DisplayPackageProducts();
            }
        }

        private void dgvPkgProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == modifyPkgProductIndex || e.ColumnIndex == deletePkgProductIndex)
            {
                DataGridViewCell packageProductIDCell = dgvPkgProducts.Rows[e.RowIndex].Cells[0];
                int packageProductID = Convert.ToInt32(packageProductIDCell.Value);
                selectedPackageProduct = PackagesProductsSupplierDB.FindPackageProduct(packageProductID);

                if (selectedPackageProduct != null)
                {
                    if (e.ColumnIndex == modifyPkgProductIndex)
                    {
                        ModifyPackageProduct();
                    }
                    if (e.ColumnIndex == deletePkgProductIndex)
                    {
                        DeletePackageProduct();
                    }
                }
            }
        }

        private void ModifyPackageProduct()
        {
            frmAddModifyPackagesProducts modifyPackageProducts = new frmAddModifyPackagesProducts();
            modifyPackageProducts.isNewPackageProduct = false;
            modifyPackageProducts.packageProduct = selectedPackageProduct!;

            DialogResult result = modifyPackageProducts.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (selectedPackageProduct != null)
                {
                    PackagesProductsSupplierDB.ModifyPackageProduct(selectedPackageProduct);
                    MessageBox.Show($"Product added to package successfully.");
                    DisplayPackageProducts();
                }
            }
        }

        private void DeletePackageProduct()
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this product from this package?",
                "Confirm Package Product Deletion", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                PackagesProductsSupplierDB.DeletePackageProduct(selectedPackageProduct!);
                MessageBox.Show("Package product has been successfully deleted.");
                DisplayPackageProducts();
            }
        }

        private void txtPkgProductSearch_TextChanged(object sender, EventArgs e)
        {
            string searchString = txtPkgProductSearch.Text;
            List<PackagesProductsSupplierDTO> filteredPackageProducts = packageProducts.Where(packageProduct =>
                packageProduct.PkgProductSupID.ToString()!.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                packageProduct.PkgName!.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                packageProduct.ProductName.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                packageProduct.SupName.Contains(searchString, StringComparison.OrdinalIgnoreCase)
            ).ToList();
            dgvPkgProducts.Columns.Clear();
            dgvPkgProductsBinding.DataSource = filteredPackageProducts;
            FormatPackageProductsView();
        }

        private void btnPkgProductsExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
