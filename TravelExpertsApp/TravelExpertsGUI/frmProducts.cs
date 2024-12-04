using Microsoft.EntityFrameworkCore;
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
    public partial class frmProducts : Form
    {
        private TravelExpertsContext _context = new TravelExpertsContext();
        public frmProducts()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            gbVariable.Visible = false;
            DisableButtons();
            EnableInitialButtons();
            AttachEventHandlers();
        }

        private void DisableButtons()
        {
            btnGetProduct.Enabled = false;
            btnGetSupplier.Enabled = false;
            btnEditProduct.Enabled = false;
            btnEditSupplier.Enabled = false;
        }

        private void EnableInitialButtons()
        {
            btnGetAllProducts.Enabled = true;
            btnGetAllSuppliers.Enabled = true;
            btnAddProduct.Enabled = true;
            btnAddSupplier.Enabled = true;
        }
        private void AttachEventHandlers()
        {
            txtProductId.TextChanged += TxtId_TextChanged;
            txtSupplierId.TextChanged += TxtId_TextChanged;

            btnGetProduct.Click += BtnGet_Click;
            btnGetSupplier.Click += BtnGet_Click;
            btnAddProduct.Click += BtnAdd_Click;
            btnAddSupplier.Click += BtnAdd_Click;
            btnEditProduct.Click += BtnEdit_Click;
            btnEditSupplier.Click += BtnEdit_Click;
            btnGetAllProducts.Click += BtnGetAll_Click;
            btnGetAllSuppliers.Click += BtnGetAll_Click;

            btnOk.Click += BtnOk_Click;
            btnCancel.Click += BtnCancel_Click;
            btnDelete.Click += BtnDelete_Click;
        }

        private void TxtId_TextChanged(object sender, EventArgs e)
        {
            bool hasText = !string.IsNullOrEmpty(txtProductId.Text) || !string.IsNullOrEmpty(txtSupplierId.Text);
            btnGetProduct.Enabled = hasText;
            btnGetSupplier.Enabled = hasText;
            btnEditProduct.Enabled = hasText;
            btnEditSupplier.Enabled = hasText;
        }

        private void BtnGet_Click(object sender, EventArgs e)
        {
            ShowGbVariable((Button)sender);
            FetchData();
            SetFieldsReadOnly(true);
            btnDelete.Visible = true;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ShowGbVariable((Button)sender);
            ClearFields();
            SetFieldsReadOnly(false);
            btnDelete.Visible = false;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            ShowGbVariable((Button)sender);
            FetchData();
            SetFieldsReadOnly(false);
            btnDelete.Visible = false;
        }

        private void BtnGetAll_Click(object sender, EventArgs e)
        {
            ShowGbVariable((Button)sender);
            dgvVariable.Visible = true;
            PopulateDataGridView((Button)sender);
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm operation?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                PerformDatabaseOperation();
                MessageBox.Show("Operation completed successfully.");
                gbVariable.Visible = false;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cancel operation?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                gbVariable.Visible = false;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete this item?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DeleteItem();
                MessageBox.Show("Item deleted successfully.");
                gbVariable.Visible = false;
            }
        }

        private void ShowGbVariable(Button sender)
        {
            gbVariable.Visible = true;
            gbVariable.Text = sender.Text;
            dgvVariable.Visible = sender.Name.Contains("GetAll");
            SetLabels(sender.Name.Contains("Product"));
        }

        private void SetLabels(bool isProduct)
        {
            idLabel.Text = isProduct ? "Product Id:" : "Supplier Id:";
            nameLabel.Text = isProduct ? "Product Name:" : "Supplier Name:";
        }

        private void FetchData()
        {
            if (gbVariable.Text.Contains("Product"))
            {
                var product = _context.Products.Find(int.Parse(txtProductId.Text));
                if (product != null)
                {
                    txtId.Text = product.ProductId.ToString();
                    txtName.Text = product.ProdName;
                }
            }
            else
            {
                var supplier = _context.Suppliers.Find(int.Parse(txtSupplierId.Text));
                if (supplier != null)
                {
                    txtId.Text = supplier.SupplierId.ToString();
                    txtName.Text = supplier.SupName;
                }
            }
        }

        private void ClearFields()
        {
            txtId.Clear();
            txtName.Clear();
        }

        private void SetFieldsReadOnly(bool readOnly)
        {
            txtId.ReadOnly = readOnly;
            txtName.ReadOnly = readOnly;
        }

        private void PopulateDataGridView(Button sender)
        {
            if (sender.Name.Contains("Product"))
            {
                dgvVariable.DataSource = _context.Products.ToList();
            }
            else
            {
                dgvVariable.DataSource = _context.Suppliers.ToList();
            }
        }

        private void PerformDatabaseOperation()
        {
            if (gbVariable.Text.Contains("Add"))
            {
                if (gbVariable.Text.Contains("Product"))
                {
                    _context.Products.Add(new Product { ProdName = txtName.Text });
                }
                else
                {
                    _context.Suppliers.Add(new Supplier { SupName = txtName.Text });
                }
            }
            else if (gbVariable.Text.Contains("Edit"))
            {
                if (gbVariable.Text.Contains("Product"))
                {
                    var product = _context.Products.Find(int.Parse(txtId.Text));
                    if (product != null)
                    {
                        product.ProdName = txtName.Text;
                    }
                }
                else
                {
                    var supplier = _context.Suppliers.Find(int.Parse(txtId.Text));
                    if (supplier != null)
                    {
                        supplier.SupName = txtName.Text;
                    }
                }
            }
            _context.SaveChanges();
        }

        private void DeleteItem()
        {
            if (gbVariable.Text.Contains("Product"))
            {
                var product = _context.Products.Find(int.Parse(txtId.Text));
                if (product != null)
                {
                    _context.Products.Remove(product);
                }
            }
            else
            {
                var supplier = _context.Suppliers.Find(int.Parse(txtId.Text));
                if (supplier != null)
                {
                    _context.Suppliers.Remove(supplier);
                }
            }
            _context.SaveChanges();
        }
    }
}
