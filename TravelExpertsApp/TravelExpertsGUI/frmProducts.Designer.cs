namespace TravelExpertsGUI
{
    partial class frmProducts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            gpbProducts = new GroupBox();
            btnAddProduct = new Button();
            btnEditProduct = new Button();
            label2 = new Label();
            btnGetAllProducts = new Button();
            btnGetProduct = new Button();
            txtProductId = new TextBox();
            label1 = new Label();
            gpbSuppliers = new GroupBox();
            btnAddSupplier = new Button();
            btnEditSupplier = new Button();
            label3 = new Label();
            btnGetAllSuppliers = new Button();
            btnGetSupplier = new Button();
            txtSupplierId = new TextBox();
            label7 = new Label();
            productsSupplierBindingSource = new BindingSource(components);
            productsSupplierBindingSource1 = new BindingSource(components);
            gbVariable = new GroupBox();
            btnDelete = new Button();
            dgvVariable = new DataGridView();
            txtName = new TextBox();
            nameLabel = new Label();
            txtId = new TextBox();
            idLabel = new Label();
            btnCancel = new Button();
            btnOk = new Button();
            gpbProducts.SuspendLayout();
            gpbSuppliers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)productsSupplierBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productsSupplierBindingSource1).BeginInit();
            gbVariable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVariable).BeginInit();
            SuspendLayout();
            // 
            // gpbProducts
            // 
            gpbProducts.Controls.Add(btnAddProduct);
            gpbProducts.Controls.Add(btnEditProduct);
            gpbProducts.Controls.Add(label2);
            gpbProducts.Controls.Add(btnGetAllProducts);
            gpbProducts.Controls.Add(btnGetProduct);
            gpbProducts.Controls.Add(txtProductId);
            gpbProducts.Controls.Add(label1);
            gpbProducts.Location = new Point(12, 27);
            gpbProducts.Name = "gpbProducts";
            gpbProducts.Size = new Size(372, 227);
            gpbProducts.TabIndex = 0;
            gpbProducts.TabStop = false;
            gpbProducts.Text = "Manage Products";
            // 
            // btnAddProduct
            // 
            btnAddProduct.Location = new Point(223, 174);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(121, 29);
            btnAddProduct.TabIndex = 9;
            btnAddProduct.Text = "Add Product";
            btnAddProduct.UseVisualStyleBackColor = true;
            // 
            // btnEditProduct
            // 
            btnEditProduct.Location = new Point(245, 113);
            btnEditProduct.Name = "btnEditProduct";
            btnEditProduct.Size = new Size(121, 29);
            btnEditProduct.TabIndex = 8;
            btnEditProduct.Text = "Edit Product";
            btnEditProduct.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(288, 90);
            label2.Name = "label2";
            label2.Size = new Size(29, 20);
            label2.TabIndex = 7;
            label2.Text = "OR";
            // 
            // btnGetAllProducts
            // 
            btnGetAllProducts.Location = new Point(25, 174);
            btnGetAllProducts.Name = "btnGetAllProducts";
            btnGetAllProducts.Size = new Size(172, 29);
            btnGetAllProducts.TabIndex = 6;
            btnGetAllProducts.Text = "Get All Products";
            btnGetAllProducts.UseVisualStyleBackColor = true;
            // 
            // btnGetProduct
            // 
            btnGetProduct.Location = new Point(245, 58);
            btnGetProduct.Name = "btnGetProduct";
            btnGetProduct.Size = new Size(121, 29);
            btnGetProduct.TabIndex = 2;
            btnGetProduct.Text = "Get Product";
            btnGetProduct.UseVisualStyleBackColor = true;
            // 
            // txtProductId
            // 
            txtProductId.Location = new Point(100, 87);
            txtProductId.Name = "txtProductId";
            txtProductId.Size = new Size(125, 27);
            txtProductId.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 91);
            label1.Name = "label1";
            label1.Size = new Size(88, 20);
            label1.TabIndex = 0;
            label1.Text = "Product Id : ";
            // 
            // gpbSuppliers
            // 
            gpbSuppliers.Controls.Add(btnAddSupplier);
            gpbSuppliers.Controls.Add(btnEditSupplier);
            gpbSuppliers.Controls.Add(label3);
            gpbSuppliers.Controls.Add(btnGetAllSuppliers);
            gpbSuppliers.Controls.Add(btnGetSupplier);
            gpbSuppliers.Controls.Add(txtSupplierId);
            gpbSuppliers.Controls.Add(label7);
            gpbSuppliers.Location = new Point(403, 27);
            gpbSuppliers.Name = "gpbSuppliers";
            gpbSuppliers.Size = new Size(379, 227);
            gpbSuppliers.TabIndex = 7;
            gpbSuppliers.TabStop = false;
            gpbSuppliers.Text = "Manage Suppliers";
            // 
            // btnAddSupplier
            // 
            btnAddSupplier.Location = new Point(225, 174);
            btnAddSupplier.Name = "btnAddSupplier";
            btnAddSupplier.Size = new Size(121, 29);
            btnAddSupplier.TabIndex = 10;
            btnAddSupplier.Text = "Add Supplier";
            btnAddSupplier.UseVisualStyleBackColor = true;
            // 
            // btnEditSupplier
            // 
            btnEditSupplier.Location = new Point(240, 114);
            btnEditSupplier.Name = "btnEditSupplier";
            btnEditSupplier.Size = new Size(121, 29);
            btnEditSupplier.TabIndex = 9;
            btnEditSupplier.Text = "Edit Supplier";
            btnEditSupplier.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(284, 91);
            label3.Name = "label3";
            label3.Size = new Size(29, 20);
            label3.TabIndex = 8;
            label3.Text = "OR";
            // 
            // btnGetAllSuppliers
            // 
            btnGetAllSuppliers.Location = new Point(26, 174);
            btnGetAllSuppliers.Name = "btnGetAllSuppliers";
            btnGetAllSuppliers.Size = new Size(172, 29);
            btnGetAllSuppliers.TabIndex = 6;
            btnGetAllSuppliers.Text = "Get All Suppliers";
            btnGetAllSuppliers.UseVisualStyleBackColor = true;
            // 
            // btnGetSupplier
            // 
            btnGetSupplier.Location = new Point(240, 58);
            btnGetSupplier.Name = "btnGetSupplier";
            btnGetSupplier.Size = new Size(121, 29);
            btnGetSupplier.TabIndex = 2;
            btnGetSupplier.Text = "Get Supplier";
            btnGetSupplier.UseVisualStyleBackColor = true;
            // 
            // txtSupplierId
            // 
            txtSupplierId.Location = new Point(100, 87);
            txtSupplierId.Name = "txtSupplierId";
            txtSupplierId.Size = new Size(125, 27);
            txtSupplierId.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 90);
            label7.Name = "label7";
            label7.Size = new Size(92, 20);
            label7.TabIndex = 0;
            label7.Text = "Supplier Id : ";
            // 
            // productsSupplierBindingSource
            // 
            productsSupplierBindingSource.DataSource = typeof(TravelExpertsData.ProductsSupplier);
            // 
            // productsSupplierBindingSource1
            // 
            productsSupplierBindingSource1.DataSource = typeof(TravelExpertsData.ProductsSupplier);
            // 
            // gbVariable
            // 
            gbVariable.Controls.Add(btnDelete);
            gbVariable.Controls.Add(dgvVariable);
            gbVariable.Controls.Add(txtName);
            gbVariable.Controls.Add(nameLabel);
            gbVariable.Controls.Add(txtId);
            gbVariable.Controls.Add(idLabel);
            gbVariable.Controls.Add(btnCancel);
            gbVariable.Controls.Add(btnOk);
            gbVariable.Location = new Point(12, 269);
            gbVariable.Name = "gbVariable";
            gbVariable.Size = new Size(770, 297);
            gbVariable.TabIndex = 8;
            gbVariable.TabStop = false;
            gbVariable.Text = "gbVariable";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(327, 253);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(121, 29);
            btnDelete.TabIndex = 17;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // dgvVariable
            // 
            dgvVariable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVariable.Location = new Point(6, 38);
            dgvVariable.Name = "dgvVariable";
            dgvVariable.RowHeadersWidth = 51;
            dgvVariable.Size = new Size(758, 194);
            dgvVariable.TabIndex = 16;
            dgvVariable.Visible = false;
            // 
            // txtName
            // 
            txtName.Location = new Point(518, 101);
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 27);
            txtName.TabIndex = 15;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(424, 108);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(82, 20);
            nameLabel.TabIndex = 14;
            nameLabel.Text = "nameLabel";
            // 
            // txtId
            // 
            txtId.Location = new Point(181, 101);
            txtId.Name = "txtId";
            txtId.Size = new Size(125, 27);
            txtId.TabIndex = 13;
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(87, 108);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(58, 20);
            idLabel.TabIndex = 12;
            idLabel.Text = "idLabel";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(495, 253);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(121, 29);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(151, 253);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(121, 29);
            btnOk.TabIndex = 9;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // frmProducts
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(792, 578);
            Controls.Add(gbVariable);
            Controls.Add(gpbSuppliers);
            Controls.Add(gpbProducts);
            Name = "frmProducts";
            Text = "frmProducts";
            gpbProducts.ResumeLayout(false);
            gpbProducts.PerformLayout();
            gpbSuppliers.ResumeLayout(false);
            gpbSuppliers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)productsSupplierBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)productsSupplierBindingSource1).EndInit();
            gbVariable.ResumeLayout(false);
            gbVariable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVariable).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gpbProducts;
        private TextBox txtProductId;
        private Label label1;
        private Button btnGetProduct;
        private Button btnGetAllProducts;
        private GroupBox gpbSuppliers;
        private Button btnGetAllSuppliers;
        private Button btnGetSupplier;
        private TextBox txtSupplierId;
        private Label label7;
        private BindingSource productsSupplierBindingSource;
        private BindingSource productsSupplierBindingSource1;
        private Button btnEditProduct;
        private Label label2;
        private Button btnEditSupplier;
        private Label label3;
        private GroupBox gbVariable;
        private Button btnAddProduct;
        private Button btnAddSupplier;
        private Button btnCancel;
        private Button btnOk;
        private DataGridView dgvVariable;
        private TextBox txtName;
        private Label nameLabel;
        private TextBox txtId;
        private Label idLabel;
        private Button btnDelete;
    }
}