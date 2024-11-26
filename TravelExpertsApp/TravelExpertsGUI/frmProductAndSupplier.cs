using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelExpertsData;

namespace TravelExpertsGUI
{
    public partial class frmProductAndSupplier : Form
    {
        private TravelExpertsContext _context;
        private bool isEdit = false;
        private bool disableButtons = false;
        public frmProductAndSupplier()
        {
            _context = new TravelExpertsContext();
            InitializeComponent();
            SetUpInitialState();
            LoadProductSupplierRelationships();
            ConfigureAddNewRelatioshipDgv();

            comboBxProducts.SelectedIndex = 3;
        }

        private void SetUpInitialState()
        {
            dgvProducts.Visible = false;
            dgvSuppliers.Visible = false;
            btnExecuteProducts.Visible = false;
            btnExecuteSuppliers.Visible = false;
            btnClearProducts.Visible = false;
            btnClearSuppliers.Visible = false;
            grpBoxProducts.Visible = false;
            grpBoxSuppliers.Visible = false;
            grpBoxStatus.Text = "Add New Relationship";
            dgvProductSuppliers.ReadOnly = true;
            dgvAddRelationship.Rows.Clear();

            // Hide textboxes and labels initially
            txtProduct.Visible = false;
            txtSupplier.Visible = false;
            lblProduct.Visible = false;
            lblSuppler.Visible = false;
            dgvAddRelationship.Visible = false;
        }

        private void ConfigureAddNewRelatioshipDgv()
        {
            if (dgvAddRelationship.Columns.Count == 0)
            {
                dgvAddRelationship.Columns.Add("ProductSupplierId", "ProductSupplierId");

                DataGridViewComboBoxColumn productComboBoxColumn = new DataGridViewComboBoxColumn
                {
                    Name = "ProductId",
                    HeaderText = "Product",
                    DataSource = _context.Products.ToList(),
                    DisplayMember = "ProductId",
                    ValueMember = "ProductId"
                };
                dgvAddRelationship.Columns.Add(productComboBoxColumn);

                DataGridViewComboBoxColumn supplierComboBoxColumn = new DataGridViewComboBoxColumn
                {
                    Name = "SupplierId",
                    HeaderText = "Supplier",
                    DataSource = _context.Suppliers.ToList(),
                    DisplayMember = "SupplierId",
                    ValueMember = "SupplierId"
                };
                dgvAddRelationship.Columns.Add(supplierComboBoxColumn);

                DataGridViewButtonColumn addButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "ApplyButton",
                    Text = "Apply",
                    UseColumnTextForButtonValue = true
                };
                dgvAddRelationship.Columns.Add(addButtonColumn);

                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "DiscardButton",
                    Text = "Discard",
                    UseColumnTextForButtonValue = true
                };
                dgvAddRelationship.Columns.Add(deleteButtonColumn);

                dgvAddRelationship.CellContentClick += dgvAddRelationship_CellContentClick;
                //dgvAddRelationship.Rows.RemoveAt(0);
            }
        }

        private void LoadProductSupplierRelationships()
        {
            using (var context = new TravelExpertsContext())
            {
                var relationships = context.ProductsSuppliers
                    .Select(ps => new {
                        ps.ProductSupplierId,
                        ps.ProductId,
                        ps.SupplierId
                    })
                    .ToList();

                dgvProductSuppliers.DataSource = relationships;
            }

            // Add Edit and Delete buttons
            if (!dgvProductSuppliers.Columns.Contains("EditButton"))
            {
                DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
                editButton.Name = "EditButton";
                editButton.Text = "Edit";
                editButton.UseColumnTextForButtonValue = true;
                dgvProductSuppliers.Columns.Add(editButton);
            }

            if (!dgvProductSuppliers.Columns.Contains("DeleteButton"))
            {
                DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
                deleteButton.Name = "DeleteButton";
                deleteButton.Text = "Delete";
                deleteButton.UseColumnTextForButtonValue = true;
                dgvProductSuppliers.Columns.Add(deleteButton);
            }
        }

        private void comboBxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUIBasedOnSelection(tabProducts, grpBoxProducts, comboBxProducts, dgvProducts, txtProduct, lblProduct, btnExecuteProducts, btnClearProducts);
        }

        private void comboBxSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUIBasedOnSelection(tabSuppliers, grpBoxSuppliers, comboBxSuppliers, dgvSuppliers, txtSupplier, lblSuppler, btnExecuteSuppliers, btnClearSuppliers);
        }

        private void UpdateUIBasedOnSelection(TabPage tab, GroupBox groupBox, ComboBox comboBox, DataGridView dgv, TextBox textBox, Label label, Button executeButton, Button clearButton)
        {
            groupBox.Visible = true;
            groupBox.Text = comboBox.SelectedItem.ToString();

            switch (comboBox.SelectedIndex)
            {
                case 0: // Add
                case 1: // Edit
                case 2: // Get
                    textBox.Visible = true;
                    label.Visible = true;
                    executeButton.Visible = true;
                    clearButton.Visible = true;
                    dgv.Visible = false;
                    label.Text = comboBox.SelectedIndex == 0 ?
                        (tab == tabProducts ? "Product Name:" : "Supplier Name:") :
                        (tab == tabProducts ? "Product ID:" : "Supplier ID:");
                    break;
                case 3: // Get All
                    textBox.Visible = false;
                    label.Visible = false;
                    executeButton.Visible = false;
                    clearButton.Visible = false;
                    dgv.Visible = true;
                    PopulateDataGridView(tab, dgv);
                    break;
            }
        }

        private void PopulateDataGridView(TabPage tab, DataGridView dgv)
        {
            if (tab == tabProducts)
            {
                var products = _context.Products.Select(p => new { p.ProductId, p.ProdName }).ToList();
                dgv.DataSource = products;
            }
            else if (tab == tabSuppliers)
            {
                var suppliers = _context.Suppliers.Select(s => new { s.SupplierId, s.SupName }).ToList();
                dgv.DataSource = suppliers;
            }
            else if (tab == tabProductSuppliers)
            {
                var relations = _context.ProductsSuppliers
                        .Select(ps => new
                        {
                            ps.ProductSupplierId,
                            ps.ProductId,
                            ps.SupplierId,
                        })
                        .ToList();
                dgv.DataSource = relations;

                // Add Edit button
                if (!dgv.Columns.Contains("EditButton"))
                {
                    DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
                    editButton.Name = "EditButton";
                    editButton.Text = "Edit";
                    editButton.UseColumnTextForButtonValue = true;
                    editButton.HeaderText = string.Empty;
                    dgv.Columns.Add(editButton);
                }
            }

            // Add delete button column
            if (!dgv.Columns.Contains("DeleteButton"))
            {
                DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
                deleteButton.Name = "DeleteButton";
                deleteButton.Text = "Delete";
                deleteButton.UseColumnTextForButtonValue = true;
                deleteButton.HeaderText = string.Empty; 
                dgv.Columns.Add(deleteButton);
            }

            int columnWidth = dgv.Width / 3;
            Debug.WriteLine(dgv.Columns,"fdfdfdfdf");
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                Debug.WriteLine(Convert.ToString(column.Width) + column ,Convert.ToString(columnWidth));
                column.Width = columnWidth;
            }

            DataGridViewButtonColumn? deleteColumn = dgv.Columns["DeleteButton"] as DataGridViewButtonColumn;
            if (deleteColumn != null)
            {
                deleteColumn.DefaultCellStyle.Padding = new Padding(0);
            }
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSuppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnClearProducts_Click(object sender, EventArgs e)
        {
            txtProduct.Clear();
        }

        private void btnClearSuppliers_Click(object sender, EventArgs e)
        {
            txtSupplier.Clear();
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HandleDataGridViewCellClick(dgvProducts, e, "Product");
        }

        private void dgvSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HandleDataGridViewCellClick(dgvSuppliers, e, "Supplier");
        }

        private void HandleDataGridViewCellClick(DataGridView dgv, DataGridViewCellEventArgs e, string itemType)
        {
            if (e.ColumnIndex == dgv.Columns["DeleteButton"].Index && e.RowIndex >= 0)
            {
                if (MessageBox.Show($"Are you sure you want to delete this {itemType}?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (itemType == "Product")
                    {
                        int productId = (int)dgv.Rows[e.RowIndex].Cells["ProductId"].Value;
                        var product = _context.Products.Find(productId);
                        if (product != null)
                        {
                            _context.Products.Remove(product);
                            MessageBox.Show($"{itemType} deleted successfully.", "Delete Successful", MessageBoxButtons.OK);
                            _context.SaveChanges();
                        }
                    }
                    else // Supplier
                    {
                        int supplierId = (int)dgv.Rows[e.RowIndex].Cells["SupplierId"].Value;
                        var supplier = _context.Suppliers.Find(supplierId);
                        if (supplier != null)
                        {
                            _context.Suppliers.Remove(supplier);
                            MessageBox.Show($"{itemType} deleted successfully.", "Delete Successful", MessageBoxButtons.OK);
                            _context.SaveChanges();
                        }
                    }
                }
                PopulateDataGridView(itemType == "Product" ? tabProducts : tabSuppliers, dgv);
            }
        }

        private void dgvProductSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (disableButtons) {
                MessageBox.Show("Operation not allowed - Discard previous operation", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            if (e.ColumnIndex == dgvProductSuppliers.Columns["EditButton"].Index)
            {
                disableButtons = true;
                EditRelationship(e.RowIndex);
            }
            else if (e.ColumnIndex == dgvProductSuppliers.Columns["DeleteButton"].Index)
            {
                DeleteRelationship(e.RowIndex);
            }
        }

        private DataGridViewRow generateNewRow(int displayId, int ?prodId, int ?suppId)
        {
            grpBoxStatus.Text = (isEdit ? "Editing Relationship " : "Adding Relationship ") + $"Id - {displayId}";

            // Creating a new row and populate the cells
            DataGridViewRow newRow = new DataGridViewRow();
            int newId = displayId;

            DataGridViewTextBoxCell idCell = new DataGridViewTextBoxCell { Value = newId };
            newRow.Cells.Add(idCell);

            DataGridViewComboBoxCell productComboBoxCell = new DataGridViewComboBoxCell
            {
                DataSource = _context.Products.ToList(),
                DisplayMember = "ProductId",
                ValueMember = "ProductId",
                Value = prodId
            };
            newRow.Cells.Add(productComboBoxCell);

            DataGridViewComboBoxCell supplierComboBoxCell = new DataGridViewComboBoxCell
            {
                DataSource = _context.Suppliers.ToList(),
                DisplayMember = "SupplierId",
                ValueMember = "SupplierId",
                Value = suppId
            };
            newRow.Cells.Add(supplierComboBoxCell);

            DataGridViewButtonCell applyButtonCell = new DataGridViewButtonCell { Value = "Apply" };
            newRow.Cells.Add(applyButtonCell);

            DataGridViewButtonCell discardButtonCell = new DataGridViewButtonCell { Value = "Discard" };
            newRow.Cells.Add(discardButtonCell);

            return newRow;
        }

        private void btnAddNewRelationship_Click(object sender, EventArgs e)
        {
            DataGridViewRow newRow = generateNewRow(_context.ProductsSuppliers.Any()
                ? _context.ProductsSuppliers.Max(ps => ps.ProductSupplierId) + 1
                : 1, null, null);

            dgvAddRelationship.Rows.Add(newRow);

            disableButtons = true;
            dgvAddRelationship.Visible = true;
            btnAddNewRelationship.Visible = false;
        }

        private void dgvAddRelationship_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {   
            if (e.RowIndex >= 0)
            {
                string columnName = dgvAddRelationship.Columns[e.ColumnIndex].Name;

                if (columnName == "ApplyButton")
                {
                    DataGridViewRow row = dgvAddRelationship.Rows[e.RowIndex];
                    int productSupplierId = (int)row.Cells[0].Value;
                    int productId = (int)row.Cells[1].Value;
                    int supplierId = (int)row.Cells[2].Value;

                    if (isEdit)
                    {
                        ProductsSupplier? relationship = _context.ProductsSuppliers.FirstOrDefault(ps => ps.ProductSupplierId == productSupplierId);
                        if (relationship != null)
                        {
                            relationship.ProductId = productId;
                            relationship.SupplierId = supplierId;
                        }
                    }
                    else
                    {
                        // Add new relationship to database
                        var newRelationship = new ProductsSupplier
                        {
                            ProductId = productId,
                            SupplierId = supplierId
                        };
                        _context.ProductsSuppliers.Add(newRelationship);
                    }

                    _context.SaveChanges();

                    var updatedData = _context.ProductsSuppliers
                    .Select(ps => new
                    {
                        ps.ProductSupplierId,
                        ps.ProductId,
                        ps.SupplierId
                    }).ToList();

                    dgvProductSuppliers.DataSource = updatedData;

                    dgvProductSuppliers.Refresh();

                    MessageBox.Show($"Relationship {(isEdit ? "edited" : "added")} successfully!");

                    dgvAddRelationship.Rows.RemoveAt(e.RowIndex);
                    isEdit = false;
                    dgvAddRelationship.Visible = false;
                    btnAddNewRelationship.Visible = true;
                }
                else if (columnName == "DiscardButton")
                {
                    // "Discard" button clicked
                    dgvAddRelationship.Rows.RemoveAt(e.RowIndex);
                    MessageBox.Show("Row discarded successfully!");

                    isEdit = false;
                    dgvAddRelationship.Visible = false;
                    btnAddNewRelationship.Visible = true;
                }

                disableButtons = false;
                grpBoxStatus.Text = "Add New Relationship";
            }
        }


        private void btnExecuteProducts_Click(object sender, EventArgs e)
        {
            ExecuteOperation(tabProducts, comboBxProducts, txtProduct);
        }

        private void btnExecuteSuppliers_Click(object sender, EventArgs e)
        {
            ExecuteOperation(tabSuppliers, comboBxSuppliers, txtSupplier);
        }

        private void ExecuteOperation(TabPage tab, ComboBox comboBox, TextBox textBox)
        {
           
            string operation = comboBox.SelectedItem.ToString();
            string itemType = tab == tabProducts ? "Product" : "Supplier";


            if (MessageBox.Show($"Are you sure you want to {operation}?", "Confirm Operation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                switch (comboBox.SelectedIndex)
                {
                    case 0: // Add
                        if (itemType == "Product")
                        {
                            var newProduct = new Product { ProdName = textBox.Text };
                            _context.Products.Add(newProduct);
                        }
                        else
                        {
                            var newSupplier = new Supplier { SupName = textBox.Text };
                            _context.Suppliers.Add(newSupplier);
                        }
                        break;
                    case 1: // Edit
                        if (int.TryParse(textBox.Text, out int id))
                        {
                            if (itemType == "Product")
                            {
                                var product = _context.Products.Find(id);
                                if (product != null)
                                {
                                    string newName = Microsoft.VisualBasic.Interaction.InputBox("Enter new product name:", "Edit Product", product.ProdName);
                                    if (!string.IsNullOrEmpty(newName))
                                    {
                                        product.ProdName = newName;
                                    }
                                }
                            }
                            else
                            {
                                var supplier = _context.Suppliers.Find(id);
                                if (supplier != null)
                                {
                                    string newName = Microsoft.VisualBasic.Interaction.InputBox("Enter new supplier name:", "Edit Supplier", supplier.SupName);
                                    if (!string.IsNullOrEmpty(newName))
                                    {
                                        supplier.SupName = newName;
                                    }
                                }
                            }
                        }
                        break;
                    case 2: // Get
                        if (int.TryParse(textBox.Text, out int getId))
                        {
                            if (itemType == "Product")
                            {
                                var product = _context.Products.Find(getId);
                                if (product != null)
                                {
                                    MessageBox.Show($"Product ID: {product.ProductId}\nProduct Name: {product.ProdName}", "Product Details");
                                }
                                else
                                {
                                    MessageBox.Show("Product not found.", "Error");
                                }
                            }
                            else
                            {
                                var supplier = _context.Suppliers.Find(getId);
                                if (supplier != null)
                                {
                                    MessageBox.Show($"Supplier ID: {supplier.SupplierId}\nSupplier Name: {supplier.SupName}", "Supplier Details");
                                }
                                else
                                {
                                    MessageBox.Show("Supplier not found.", "Error");
                                }
                            }
                        }
                        return; // Don't save changes or reset UI for Get operation
                }

                _context.SaveChanges();

                MessageBox.Show($"{operation} completed successfully.", "Operation Successful", MessageBoxButtons.OK);

                comboBox.SelectedIndex = 3;
                ResetUI(tab);
            }
        }

        private void EditRelationship(int rowIndex)
        {
            isEdit = true;
            // Implement edit functionality
            int productSupplierId = (int)dgvProductSuppliers.Rows[rowIndex].Cells["ProductSupplierId"].Value;

            var relationship = _context.ProductsSuppliers.FirstOrDefault(ps => ps.ProductSupplierId == productSupplierId);

            if (relationship == null)
            {
                MessageBox.Show("Relationship not found.");
                return;
            }

            //Debug.WriteLine(relationship.ProductSupplierId, Convert.ToString(relationship.ProductId));

            DataGridViewRow newRow = generateNewRow(relationship.ProductSupplierId, relationship.ProductId, relationship.SupplierId);

            dgvAddRelationship.Visible = true;
            btnAddNewRelationship.Visible = false;
       
            dgvAddRelationship.Rows.Add(newRow);
        }

        private void DeleteRelationship(int rowIndex)
        {
            int productSupplierId = (int)dgvProductSuppliers.Rows[rowIndex].Cells["ProductSupplierId"].Value;

            DialogResult confirmResult = MessageBox.Show("Are you sure you want to delete this relationship?",
                                                "Confirm Delete",
                                                MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                // Delete from database
                var relationship = _context.ProductsSuppliers.FirstOrDefault(ps => ps.ProductSupplierId == productSupplierId);
                if (relationship != null)
                {
                    _context.ProductsSuppliers.Remove(relationship);
                    _context.SaveChanges();

                    var updatedData = _context.ProductsSuppliers
                    .Select(ps => new
                    {
                        ps.ProductSupplierId,
                        ps.ProductId,
                        ps.SupplierId
                    }).ToList();

                    dgvProductSuppliers.DataSource = updatedData;

                    dgvProductSuppliers.Refresh();
                    MessageBox.Show("Relationship deleted successfully.");
                }
                else
                {
                    MessageBox.Show("Relationship not found.");
                }
            }
        }

        private void ResetUI(TabPage tab)
        {
            ComboBox comboBox = tab == tabProducts ? comboBxProducts : comboBxSuppliers;
            TextBox textBox = tab == tabProducts ? txtProduct : txtSupplier;

            textBox.Clear();

            UpdateUIBasedOnSelection(tab,
                tab == tabProducts ? grpBoxProducts : grpBoxSuppliers,
                comboBox,
                tab == tabProducts ? dgvProducts : dgvSuppliers,
                textBox,
                tab == tabProducts ? lblProduct : lblSuppler,
                tab == tabProducts ? btnExecuteProducts : btnExecuteSuppliers,
                tab == tabProducts ? btnClearProducts : btnClearSuppliers);
        }
    }
}
