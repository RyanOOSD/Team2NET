using Microsoft.EntityFrameworkCore;
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
            ConfigureAddNewRelatioshipDgv();
            InitializeSearchBox();
            comboBxProducts.SelectedIndex = 3;
        }

        // UI initialization functions
        /// <summary>
        /// Sets up the initial state of the UI components.
        /// </summary>
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

            comboBxProducts.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBxSuppliers.DropDownStyle = ComboBoxStyle.DropDownList;

            // Hide textboxes and labels initially
            txtProduct.Visible = false;
            txtSupplier.Visible = false;
            lblProduct.Visible = false;
            lblSuppler.Visible = false;
            dgvAddRelationship.Visible = false;

            txtSearchSuppliers.TextChanged += txtSearch_Changed;
            txtSearchProdSup.TextChanged += txtSearch_Changed;

            btnCancelSearchProdSup.Visible = false;
            btnCancelSearchSuppliers.Visible = false;
            btnCancelSearchProducts.Visible = false;
            btnCancelSearchProducts.Click += Cancel_Click;
            btnCancelSearchSuppliers.Click += Cancel_Click;
            btnCancelSearchProdSup.Click += Cancel_Click;
        }

        /// <summary>
        /// Configures the DataGridView for adding new product-supplier relationships.
        /// </summary>
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
            }
        }

        /// <summary>
        /// Initializes the search box with rounded corners and event handlers.
        /// </summary>
        private void InitializeSearchBox()
        {
            List<Panel> searchBoxList = new List<Panel> { panelSearchProducts, panelSearchSupplier, panelSearchProdSup };

            foreach (var searchBox in searchBoxList)
            {
                searchBox.Paint += (sender, e) =>
                {
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                    using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                    {
                        int radius = 25;
                        Rectangle rect = new Rectangle(0, 0, panelSearchProducts.Width - 1, panelSearchProducts.Height - 1);
                        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                        path.CloseFigure();

                        using (Brush brush = new SolidBrush(panelSearchProducts.BackColor))
                        {
                            e.Graphics.FillPath(brush, path);
                        }

                        using (Pen pen = new Pen(Color.Gray, 2))
                        {
                            e.Graphics.DrawPath(pen, path);
                        }
                    }
                };
            }
        }


        // Event handlers and utility functions
        /// <summary>
        /// Handles the search text change event and applies the appropriate filter.
        /// </summary>
        

        private TabPage FindParentTabPage(Control control)
        {
            while (control != null)
            {
                if (control is TabPage tabPage)
                    return tabPage;
                control = control.Parent;
            }
            return null;
        }

        private void txtSearch_Changed(object sender, EventArgs e)
        {
            TextBox searchBox = sender as TextBox;
            TabPage parentTab = FindParentTabPage(searchBox);
            var CancelBtn = parentTab.Controls.OfType<Panel>().FirstOrDefault().Controls.OfType<PictureBox>() // Filter for Buttons only
           .FirstOrDefault(tb => tb.Name.Contains("cancel", StringComparison.OrdinalIgnoreCase));

            if (searchBox.Text.Length > 0)
            {
                CancelBtn.Visible = true;
            }
            else
            {
                CancelBtn.Visible = false;
            }

            Debug.WriteLine(parentTab.Name);

            if (parentTab.Name == tabProducts.Name)
            {
                comboBxProducts.SelectedIndex = 3;
                ApplySearchFilter(txtSearchProducts.Text, dgvProducts, searchBox, parentTab);
            }
            else if (parentTab.Name == tabSuppliers.Name)
            {
                comboBxSuppliers.SelectedIndex = 3;
                ApplySearchFilter(txtSearchSuppliers.Text, dgvSuppliers, searchBox, parentTab);
            }
            else if (parentTab.Name == tabProductSuppliers.Name)
            {
                ApplySearchFilter(txtSearchProdSup.Text, dgvProductSuppliers, searchBox, parentTab);
            }

        }

        private void ApplySearchFilter(string searchText, DataGridView dgv, TextBox searchBox, TabPage parentTab)
        {
            // Filter the data source using LINQ based on the search text

            IEnumerable<dynamic>? filterData = null;

            if (dgv.Name == dgvProducts.Name)
            {
                filterData = _context.Products
                    .AsEnumerable() // Switch to client-side evaluation
                    .Where(item =>
                        (item.ProdName != null && item.ProdName.Contains(searchText, StringComparison.OrdinalIgnoreCase)) ||
                        (item.ProductId.ToString().Contains(searchText, StringComparison.OrdinalIgnoreCase))
                    );
            }
            else if (dgv.Name == dgvSuppliers.Name)
            {
                filterData = _context.Suppliers
                    .AsEnumerable() // Switch to client-side evaluation
                    .Where(item =>
                        (item.SupName != null && item.SupName.Contains(searchText, StringComparison.OrdinalIgnoreCase)) ||
                        (item.SupplierId.ToString().Contains(searchText, StringComparison.OrdinalIgnoreCase))
                    );
            }
            else if (dgv.Name == dgvProductSuppliers.Name)
            {
                filterData = _context.ProductsSuppliers
                        .Select(ps => new
                        {
                            ps.ProductSupplierId,
                            Product = ps.Product == null
                                ? new Product { ProdName = "N/A", ProductId = Convert.ToInt32(null) }
                                : new Product
                                {
                                    ProdName = string.IsNullOrEmpty(ps.Product.ProdName) ? "N/A" : ps.Product.ProdName,
                                    ProductId = ps.Product.ProductId
                                },
                            Supplier = ps.Supplier == null
                                ? new Supplier { SupName = "N/A", SupplierId = Convert.ToInt32(null) }
                                : new Supplier
                                {
                                    SupName = string.IsNullOrEmpty(ps.Supplier.SupName) ? "N/A" : ps.Supplier.SupName,
                                    SupplierId = ps.Supplier.SupplierId
                                },
                        })
                    .AsEnumerable() // Switch to client-side evaluation
                    .Where(item =>
                        (item.Product.ProdName != null && item.Product.ProdName.Contains(searchText, StringComparison.OrdinalIgnoreCase)) ||
                        (item.Supplier.SupName != null && item.Supplier.SupName.Contains(searchText, StringComparison.OrdinalIgnoreCase)) ||
                        (item.ProductSupplierId.ToString().Contains(searchText))
                    );
            }

            if (filterData.Any()) {
                PopulateDataGridView(parentTab, dgv, filterData);
            }
            else
            {
                MessageBox.Show("No results to display", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                searchBox.Text = "";
            }
        }

        // Generates a new DataGridViewRow for the Add/Edit relationship DataGridView
        private DataGridViewRow generateNewRow(int displayId, int? prodId, int? suppId)
        {
            grpBoxStatus.Text = (isEdit ? "Editing Relationship " : "Adding Relationship ") + $"Id - {displayId}";

            // Creating a new row and populate the cells
            DataGridViewRow newRow = new DataGridViewRow();
            int newId = displayId;

            DataGridViewTextBoxCell idCell = new DataGridViewTextBoxCell { Value = newId };
            idCell.ReadOnly = true;
            newRow.Cells.Add(idCell);

            DataGridViewComboBoxCell productComboBoxCell = new DataGridViewComboBoxCell
            {
                DataSource = _context.Products.ToList(),
                DisplayMember = "ProdName",
                ValueMember = "ProductId",
                Value = prodId
            };
            newRow.Cells.Add(productComboBoxCell);

            DataGridViewComboBoxCell supplierComboBoxCell = new DataGridViewComboBoxCell
            {
                DataSource = _context.Suppliers.ToList(),
                DisplayMember = "SupName",
                ValueMember = "SupplierId",
                Value = suppId
            };
            newRow.Cells.Add(supplierComboBoxCell);

            DataGridViewButtonCell applyButtonCell = new DataGridViewButtonCell { Value = "Apply" };
            applyButtonCell.Style.BackColor = Color.Green;
            newRow.Cells.Add(applyButtonCell);

            DataGridViewButtonCell discardButtonCell = new DataGridViewButtonCell { Value = "Discard" };
            discardButtonCell.Style.BackColor = Color.Red;
            newRow.Cells.Add(discardButtonCell);

            return newRow;
        }

        /// <summary>
        /// CORE FUNCTIONALITY UI HANDLERS
        /// </summary>

        // Handles "Add New Relationship" button click, generates a new relationship row for editing
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

        // Handles cell clicks in the Add/Edit relationship DataGridView
        private void dgvAddRelationship_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string columnName = dgvAddRelationship.Columns[e.ColumnIndex].Name;

                if (columnName == "ApplyButton")
                {
                    DataGridViewRow row = dgvAddRelationship.Rows[e.RowIndex];

                    if (string.IsNullOrEmpty(Convert.ToString(row.Cells[1].Value)) && string.IsNullOrEmpty(Convert.ToString(row.Cells[2].Value)))
                    {
                        MessageBox.Show("New added Relationship can't be empty");
                        return;
                    }
                    else
                    {
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
                            ProdName = string.IsNullOrEmpty(ps.Product.ProdName) ? "N/A" : ps.Product.ProdName,
                            SuppName = string.IsNullOrEmpty(ps.Supplier.SupName) ? "N/A" : ps.Supplier.SupName,
                        }).ToList();

                        dgvProductSuppliers.DataSource = updatedData;

                        dgvProductSuppliers.Refresh();

                        MessageBox.Show($"Relationship {(isEdit ? "edited" : "added")} successfully!");

                        dgvAddRelationship.Rows.RemoveAt(e.RowIndex);
                        isEdit = false;
                        dgvAddRelationship.Visible = false;
                        btnAddNewRelationship.Visible = true;
                    }
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

        // Handles "Execute Products" button click for product operations (Add, Edit, Get)
        private void btnExecuteProducts_Click(object sender, EventArgs e)
        {
            ExecuteOperation(tabProducts, comboBxProducts, txtProduct);
        }

        private void btnExecuteSuppliers_Click(object sender, EventArgs e)
        {
            ExecuteOperation(tabSuppliers, comboBxSuppliers, txtSupplier);
        }

        // Handles tab control selection change and updates the UI accordingly
        private void tabControl_Changed(object sender, EventArgs e)
        {
            Debug.WriteLine(sender);
            TabControl tabControl = sender as TabControl;

            if (tabControl.SelectedTab.Name == tabSuppliers.Name)
            {
                comboBxSuppliers.SelectedIndex = 3;
            }
            else if (tabControl.SelectedTab.Name == tabProductSuppliers.Name)
            {
                PopulateDataGridView(tabProductSuppliers, dgvProductSuppliers, _context.ProductsSuppliers);
            }

        }

        // Handles the Clear Search Funtionality
        private void Cancel_Click(object sender, EventArgs e)
        {
            TabPage ParentTab = FindParentTabPage(sender as Control);
            TextBox? txtSearch = ParentTab.Controls.OfType<Panel>().FirstOrDefault().Controls.
                OfType<TextBox>()
                .FirstOrDefault(tb => tb.Name.Contains("search", StringComparison.OrdinalIgnoreCase));

            if (txtSearch != null)
            {
                txtSearch.Text = "";
                PictureBox senderObj = sender as PictureBox;
                senderObj.Visible = false;
            }

        }

        /// <summary>
        /// Click HANDLERS FOR UI AND DGV
        /// </summary>

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
                if (itemType == "Product")
                {
                    PopulateDataGridView(tabProducts, dgv, _context.Products);

                }
                else
                {
                    PopulateDataGridView(tabSuppliers, dgv, _context.Products);
                }
            }
        }

        private void dgvProductSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (disableButtons)
            {
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
                    PopulateDataGridView(tab, dgv, tab == tabProducts ? _context.Products : _context.Suppliers);
                    break;
            }
        }


        private void PopulateDataGridView(TabPage tab, DataGridView dgv, IEnumerable<dynamic> tableData)
        {
            if (tab == tabProducts)
            {
                var products = tableData.Select(p => new { p.ProductId, p.ProdName }).ToList();
                dgv.DataSource = products;
            }
            else if (tab == tabSuppliers)
            {
                var suppliers = tableData.Select(s => new { s.SupplierId, s.SupName }).ToList();
                dgv.DataSource = suppliers;
            }
            else if (tab == tabProductSuppliers)
            {
                var relations = tableData
                        .Select(ps => new
                        {
                            ps.ProductSupplierId,
                            ProdName = ps.Product == null || string.IsNullOrEmpty(ps.Product?.ProdName) ? "N/A" : ps.Product.ProdName,
                            SuppName = ps.Supplier == null || string.IsNullOrEmpty(ps.Supplier?.SupName) ? "N/A" : ps.Supplier.SupName,
                        })
                        .ToList();
                dgv.DataSource = relations;

                // Add Edit button
                if (!dgv.Columns.Contains("EditButton"))
                {
                    DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
                    editButton.FlatStyle = FlatStyle.Flat;
                    editButton.Name = "EditButton";
                    editButton.Text = "Edit";
                    editButton.UseColumnTextForButtonValue = true;
                    editButton.HeaderText = string.Empty;

                    editButton.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#66c7ff");
                    editButton.DefaultCellStyle.ForeColor = Color.White;

                    dgv.Columns.Add(editButton);
                }
            }

            // Add delete button column
            if (!dgv.Columns.Contains("DeleteButton"))
            {
                DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
                deleteButton.FlatStyle = FlatStyle.Flat;
                deleteButton.Name = "DeleteButton";
                deleteButton.Text = "Delete";
                deleteButton.UseColumnTextForButtonValue = true;
                deleteButton.HeaderText = string.Empty;

                deleteButton.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#ff251a");
                deleteButton.DefaultCellStyle.ForeColor = Color.White;

                dgv.Columns.Add(deleteButton);
            }

            if(!(tab == tabProductSuppliers))
            {
                int columnWidth = dgv.Width / 3;
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    Debug.WriteLine(Convert.ToString(column.Width) + column, Convert.ToString(columnWidth));
                    column.Width = columnWidth;
                }
            }
            else
            {
                int columnWidth = (dgv.Width - 55) / 5;
                Debug.WriteLine(Convert.ToString(dgv.Width));
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    Debug.WriteLine(Convert.ToString(column.Width) + column, Convert.ToString(columnWidth));
                    column.Width = columnWidth;
                }
            }

            DataGridViewButtonColumn? deleteColumn = dgv.Columns["DeleteButton"] as DataGridViewButtonColumn;
            if (deleteColumn != null)
            {
                deleteColumn.DefaultCellStyle.Padding = new Padding(0);
            }
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSuppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Executes the operation (Add, Edit, Get) based on the selected item in the ComboBox
        private void ExecuteOperation(TabPage tab, ComboBox comboBox, TextBox textBox)
        {

            string operation = comboBox.SelectedItem.ToString();
            string itemType = tab == tabProducts ? "Product" : "Supplier";


            if (MessageBox.Show($"Are you sure you want to {operation}?", "Confirm Operation", MessageBoxButtons.YesNo) == DialogResult.Yes && ValidatorUtils.IsTextBoxNotEmpty(textBox, $"{comboBox.Items[comboBox.SelectedIndex].ToString().Split(' ')[0]} - {itemType} cannot be empty. Please try again with some value...."))
            {
                switch (comboBox.SelectedIndex)
                {
                    case 0: // Add
                        if (itemType == "Product")
                        {
                            var newProduct = new Product { ProdName = textBox.Text.Trim() };
                            _context.Products.Add(newProduct);
                        }
                        else
                        {
                            var newSupplier = new Supplier { SupName = textBox.Text.Trim() };
                            _context.Suppliers.Add(newSupplier);
                        }
                        break;
                    case 1: // Edit
                        if (int.TryParse(textBox.Text.Trim(), out int id))
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
                        if (int.TryParse(textBox.Text.Trim(), out int getId))
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

        // Edits an existing product-supplier relationship and prepares it for update
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

        // Deletes a product-supplier relationship and updates the DataGridView
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
                        ProdName = string.IsNullOrEmpty(ps.Product.ProdName) ? "N/A" : ps.Product.ProdName,
                        SuppName = string.IsNullOrEmpty(ps.Supplier.SupName) ? "N/A" : ps.Supplier.SupName,
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

        // Updates the UI elements based on the current operation and selected tab
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
