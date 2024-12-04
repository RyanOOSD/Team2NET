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
        // Create package and package product objects to be used within the form
        TravelExpertsData.Package? selectedPackage = null;
        PackagesProductsSupplier? selectedPackageProduct = null;

        // Create lists and binding sources to be used for each datagridview
        List<PackageDTO> packages = new List<PackageDTO>();
        BindingSource pkgBinding = new BindingSource();
        List<PackagesProductsSupplierDTO> packageProducts = new List<PackagesProductsSupplierDTO>();
        BindingSource pkgProductsBinding = new BindingSource();

        // Define the column indexes for the modify/delete buttons in each datagridview
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
            // On form load, display the packages and package products
            DisplayPackages();
            DisplayPackageProducts();
        }

        private void tbcPkgPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            // On tab change, refresh the datagridviews
            DisplayPackages();
            DisplayPackageProducts();
        }

        private void DisplayPackages()
        {
            // Clear the datagridview
            dgvPkg.Columns.Clear();

            // Get the list of packages
            packages = PackageDB.GetPackageList();

            // Set the datagridview datasource, assign the bindingsource to the list, and format the datagridview
            dgvPkg.DataSource = pkgBinding;
            pkgBinding.DataSource = packages;
            FormatPackageView();
        }

        private void FormatPackageView()
        {
            // Define styles for the modify/delete buttons to give them different colours
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

            // Add the columns for the modify/delete buttons
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

            // Disable resizing of row selection column and style the column headers
            dgvPkg.RowHeadersWidth = 25;
            dgvPkg.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvPkg.EnableHeadersVisualStyles = false;
            dgvPkg.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;
            dgvPkg.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Set column names, set sizes, and format the cell contents
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

            // Disable auto-sizing for the modify/delete button columns and manually set size
            dgvPkg.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvPkg.Columns[7].Width = 100;
            dgvPkg.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvPkg.Columns[8].Width = 100;
        }

        private void dgvPkg_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex % 2 == 1)
            {
                // Override the alternating row coloring for the add/modify buttons
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
            // Create a new Add/Modify package form, passing the flag and setting the form's package object to null
            frmAddModifyPackages addPackage = new frmAddModifyPackages();
            addPackage.isNewPackage = true;
            addPackage.package = null!;

            // Display the forms
            DialogResult result = addPackage.ShowDialog();
            if (result == DialogResult.OK)
            {
                // Pass the new package object from the Add/Modify form
                selectedPackage = addPackage.package;

                // Call the method to add the package to the database and refresh the datagridview
                PackageDB.AddPackage(selectedPackage);
                MessageBox.Show($"{selectedPackage.PkgName} has been added successfully.");
                DisplayPackages();
            }
        }

        private void dgvPkg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure a valid row is selected
            if (e.RowIndex > -1)
            {
                // Check if the user is clicking on either of the columns for the Modify/Delete buttons
                if (e.ColumnIndex == modifyPkgIndex || e.ColumnIndex == deletePkgIndex)
                {
                    // Find the package corresponding to the selected row and store it
                    DataGridViewCell packageIDCell = dgvPkg.Rows[e.RowIndex].Cells[0];
                    int packageID = Convert.ToInt32(packageIDCell.Value);
                    selectedPackage = PackageDB.FindPackage(packageID)!;
                }

                if (selectedPackage != null)
                {
                    // If the modify button is clicked, call the modify method
                    if (e.ColumnIndex == modifyPkgIndex)
                    {
                        ModifyPackage();
                    }
                    // If the delete button is clicked, call the delete method
                    else if (e.ColumnIndex == deletePkgIndex)
                    {
                        DeletePackage();
                    }
                }
            }
        }

        private void ModifyPackage()
        {
            // Create a new Add/Modify package form, passing the flag and package object
            frmAddModifyPackages modifyPackage = new frmAddModifyPackages();
            modifyPackage.isNewPackage = false;
            modifyPackage.package = selectedPackage!;

            // Display the form and confirm that the returned package object is not null
            DialogResult result = modifyPackage.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (selectedPackage != null)
                {
                    // Call the method to update the package with new values and refresh the datagridview
                    PackageDB.ModifyPackage(selectedPackage);
                    MessageBox.Show($"{selectedPackage.PkgName} has been edited successfully.");
                    DisplayPackages();
                }
            }
        }

        private void DeletePackage()
        {
            // Show a confirmation message to delete the package
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete {selectedPackage!.PkgName}?",
                "Confirm Package Deletion", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            // If "Yes" is clicked, call the method to delete the package from the database
            if (result == DialogResult.Yes)
            {
                PackageDB.DeletePackage(selectedPackage);
                MessageBox.Show("Package has been successfully deleted.");
                DisplayPackages();
            }
        }

        private void txtPkgSearch_TextChanged(object sender, EventArgs e)
        {
            // When the text in the search textbox changes, store that text in a variable
            string searchString = txtPkgSearch.Text;

            // Create a new filtered list of PackageDTO where each object's attributes contain the search text
            List<PackageDTO> filteredPackages = packages.Where(package =>
                package.PkgID.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                package.PkgName.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                package.PkgStart.ToString()!.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                package.PkgEnd.ToString()!.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                package.PkgDesc!.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                package.PkgPrice.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                package.PkgCommission.ToString()!.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                ).ToList();

            // Then clear the datagridview, re-assign the binding source to the filtered list and re-format the datagridview
            dgvPkg.Columns.Clear();
            pkgBinding.DataSource = filteredPackages;
            FormatPackageView();
        }

        // Close the window from the packages tab
        private void btnPkgExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisplayPackageProducts()
        {
            // Clear the datagridview
            dgvPkgProducts.Columns.Clear();

            // Get the list of package products
            packageProducts = PackagesProductsSupplierDB.GetPackageProductsList();

            // Set the datagridview datasource, assign the bindingsource to the list, and format the datagridview
            dgvPkgProducts.DataSource = pkgProductsBinding;
            pkgProductsBinding.DataSource = packageProducts;
            FormatPackageProductsView();
        }

        private void FormatPackageProductsView()
        {
            // Hide the ProductSupId column
            dgvPkgProducts.Columns["ProductSupId"].Visible = false;

            // Define styles for the modify/delete buttons to give them different colours
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

            // Add the columns for the modify/delete buttons
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

            // Disable resizing of row selection column and style the column headers
            dgvPkgProducts.RowHeadersWidth = 25;
            dgvPkgProducts.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvPkgProducts.EnableHeadersVisualStyles = false;
            dgvPkgProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;
            dgvPkgProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Set column names and sizes
            dgvPkgProducts.Columns[0].HeaderText = "Package Product ID";
            dgvPkgProducts.Columns[0].Width = 180;
            dgvPkgProducts.Columns[1].HeaderText = "Package Name";
            dgvPkgProducts.Columns[1].Width = 223;
            dgvPkgProducts.Columns[3].HeaderText = "Product Name";
            dgvPkgProducts.Columns[3].Width = 223;
            dgvPkgProducts.Columns[4].HeaderText = "Supplier Name";
            dgvPkgProducts.Columns[4].Width = 223;

            // Disable auto-sizing for the modify/delete button columns and manually set size
            dgvPkgProducts.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvPkgProducts.Columns[5].Width = 100;
            dgvPkgProducts.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvPkgProducts.Columns[6].Width = 100;
        }

        private void dgvPkgProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex % 2 == 1)
            {
                // Override the alternating row coloring for the add/modify buttons
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
            // Create a new Add/Modify package product form, passing the flag and setting the form's package product object to null
            frmAddModifyPackagesProducts addPackageProducts = new frmAddModifyPackagesProducts();
            addPackageProducts.isNewPackageProduct = true;
            addPackageProducts.packageProduct = null!;

            // Display the form
            DialogResult result = addPackageProducts.ShowDialog();
            if (result == DialogResult.OK)
            {
                // Pass the new package product object from the Add/Modify form
                selectedPackageProduct = addPackageProducts.packageProduct;

                // Verify that the selected combination of package and package product does not already exist
                if (!PackagesProductsSupplierDB.CheckDuplicatePackageProduct(selectedPackageProduct))
                {
                    // Call the method to add the package product to the database and refresh the datagridview
                    PackagesProductsSupplierDB.AddPackageProduct(selectedPackageProduct);
                    MessageBox.Show("Product successfully added to the package.");
                    DisplayPackageProducts();
                }
                else
                {
                    // If the addition is a duplicate, show an error message instead
                    MessageBox.Show(
                        "This product has already been added to this package.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void dgvPkgProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure a valid row is selected
            if (e.RowIndex > -1)
            {
                // Check if the user is clicking on either of the columns for the Modify/Delete buttons
                if (e.ColumnIndex == modifyPkgProductIndex || e.ColumnIndex == deletePkgProductIndex)
                {
                    // Find the package product corresponding to the selected row and store it
                    DataGridViewCell packageProductIDCell = dgvPkgProducts.Rows[e.RowIndex].Cells[0];
                    int packageProductID = Convert.ToInt32(packageProductIDCell.Value);
                    selectedPackageProduct = PackagesProductsSupplierDB.FindPackageProduct(packageProductID);

                    if (selectedPackageProduct != null)
                    {
                        // If the modify button is clicked, call the modify method
                        if (e.ColumnIndex == modifyPkgProductIndex)
                        {
                            ModifyPackageProduct();
                        }
                        // If the delete button is clicked, call the delete method
                        if (e.ColumnIndex == deletePkgProductIndex)
                        {
                            DeletePackageProduct();
                        }
                    }
                }
            }
        }

        private void ModifyPackageProduct()
        {
            // Create a new Add/Modify package product form, passing the flag and package product object
            frmAddModifyPackagesProducts modifyPackageProducts = new frmAddModifyPackagesProducts();
            modifyPackageProducts.isNewPackageProduct = false;
            modifyPackageProducts.packageProduct = selectedPackageProduct!;

            // Display the form and confirm that the returned package product object is not null
            DialogResult result = modifyPackageProducts.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (selectedPackageProduct != null)
                {
                    // Verify that the selected combination of package and package product does not already exist
                    if (!PackagesProductsSupplierDB.CheckDuplicatePackageProduct(selectedPackageProduct))
                    {
                        // Call the method to update the package product with new values and refresh the datagridview
                        PackagesProductsSupplierDB.ModifyPackageProduct(selectedPackageProduct);
                        MessageBox.Show($"Product added to package successfully.");
                        DisplayPackageProducts();
                    }
                    else
                    {
                        // If modified to be a duplicate, show an error message instead
                        MessageBox.Show(
                            "This product has already been added to this package.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        
        private void DeletePackageProduct()
        {
            // Show a confirmation message to delete the package product
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this product from this package?",
                "Confirm Package Product Deletion", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            // If "Yes" is clicked, then call the method to delete the package product from the database
            if (result == DialogResult.Yes)
            {
                PackagesProductsSupplierDB.DeletePackageProduct(selectedPackageProduct!);
                MessageBox.Show("Package product has been successfully deleted.");
                DisplayPackageProducts();
            }
        }

        private void txtPkgProductSearch_TextChanged(object sender, EventArgs e)
        {
            // When the text in the search textbox changes, store that text in a variable
            string searchString = txtPkgProductSearch.Text;

            // Create a new filtered list of PackageProductsSupplierDTO where each object's attributes contain the search text
            List<PackagesProductsSupplierDTO> filteredPackageProducts = packageProducts.Where(packageProduct =>
                packageProduct.PkgProductSupID.ToString()!.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                packageProduct.PkgName!.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                packageProduct.ProductName.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                packageProduct.SupName.Contains(searchString, StringComparison.OrdinalIgnoreCase)
            ).ToList();

            // Then clear the datagridview, re-assign the binding source to the filtered list and re-format the datagridview
            dgvPkgProducts.Columns.Clear();
            pkgProductsBinding.DataSource = filteredPackageProducts;
            FormatPackageProductsView();
        }

        // Closes the window from the package products tab
        private void btnPkgProductsExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
