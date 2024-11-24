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
using TravelExpertsData;

namespace TravelExpertsGUI
{
    public partial class frmManagePackages : Form
    {
        List<PackageDTO> packages = new List<PackageDTO>();
        List<PackageProductsDTO> products = new List<PackageProductsDTO>();

        public frmManagePackages()
        {
            InitializeComponent();
        }

        private void btnAddPkg_Click(object sender, EventArgs e)
        {
            frmAddModifyPackages addPackage = new frmAddModifyPackages();
            addPackage.ShowDialog();
        }

        private void btnAddProductToPkg_Click(object sender, EventArgs e)
        {
            frmAddModifyPackagesProducts addProducts = new frmAddModifyPackagesProducts();
            addProducts.ShowDialog();
        }

        private void frmManagePackages_Load(object sender, EventArgs e)
        {
            DisplayPackages();
            DisplayProducts();
        }

        private void DisplayPackages()
        {
            dgvPkg.Columns.Clear();

            packages = PackageDB.GetPackageList();
            dgvPkg.DataSource = packages;
            DataGridViewButtonColumn btnModifyColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Text = "Modify"
            };
            dgvPkg.Columns.Add(btnModifyColumn);
            DataGridViewButtonColumn btnDeleteColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Text = "Delete"
            };
            dgvPkg.Columns.Add(btnDeleteColumn);

            dgvPkg.RowHeadersWidth = 25;
            dgvPkg.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;   
            dgvPkg.EnableHeadersVisualStyles = false;
            dgvPkg.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;
            dgvPkg.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvPkg.Columns[0].HeaderText = "Package ID";
            dgvPkg.Columns[1].HeaderText = "Package Name";
            dgvPkg.Columns[2].HeaderText = "Start Date";
            dgvPkg.Columns[3].HeaderText = "End Date";  
            dgvPkg.Columns[4].HeaderText = "Description";

            dgvPkg.Columns[5].HeaderText = "Price";
            dgvPkg.Columns[5].DefaultCellStyle.Format = "c";
            dgvPkg.Columns[6].HeaderText = "Commission";
            dgvPkg.Columns[6].DefaultCellStyle.Format = "c";

            dgvPkg.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvPkg.Columns[7].Width = 100;
            dgvPkg.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvPkg.Columns[8].Width = 100;
        }

        private void DisplayProducts()
        {
            dgvPkgProducts.Columns.Clear();

            products = PackageDB.GetPackageProductsList();
            dgvPkgProducts.DataSource = products;
            DataGridViewButtonColumn btnModifyColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Text = "Modify"
            };
            dgvPkgProducts.Columns.Add(btnModifyColumn);
            DataGridViewButtonColumn btnDeleteColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Text = "Delete"
            };
            dgvPkgProducts.Columns.Add(btnDeleteColumn);

            dgvPkgProducts.RowHeadersWidth = 25;
            dgvPkgProducts.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvPkgProducts.EnableHeadersVisualStyles = false;
            dgvPkgProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;
            dgvPkgProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvPkgProducts.Columns[0].HeaderText = "Package Product ID";
            dgvPkgProducts.Columns[1].HeaderText = "Package Name";
            dgvPkgProducts.Columns[2].HeaderText = "Product Name";
            dgvPkgProducts.Columns[3].HeaderText = "Supplier Name";

            dgvPkgProducts.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvPkgProducts.Columns[4].Width = 100;
            dgvPkgProducts.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvPkgProducts.Columns[5].Width = 100;
        }
    }
}
