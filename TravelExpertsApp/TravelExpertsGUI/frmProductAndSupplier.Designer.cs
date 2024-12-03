namespace TravelExpertsGUI
{
    partial class frmProductAndSupplier
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
            tabControl = new TabControl();
            tabProducts = new TabPage();
            panelSearchProducts = new Panel();
            btnCancelSearchProducts = new PictureBox();
            picBoxSearch = new PictureBox();
            txtSearchProducts = new TextBox();
            grpBoxProducts = new GroupBox();
            btnClearProducts = new Button();
            lblProduct = new Label();
            btnExecuteProducts = new Button();
            txtProduct = new TextBox();
            dgvProducts = new DataGridView();
            comboBxProducts = new ComboBox();
            tabSuppliers = new TabPage();
            panelSearchSupplier = new Panel();
            btnCancelSearchSuppliers = new PictureBox();
            pictureBox1 = new PictureBox();
            txtSearchSuppliers = new TextBox();
            grpBoxSuppliers = new GroupBox();
            btnClearSuppliers = new Button();
            txtSupplier = new TextBox();
            btnExecuteSuppliers = new Button();
            lblSuppler = new Label();
            dgvSuppliers = new DataGridView();
            comboBxSuppliers = new ComboBox();
            tabProductSuppliers = new TabPage();
            panelSearchProdSup = new Panel();
            btnCancelSearchProdSup = new PictureBox();
            pictureBox2 = new PictureBox();
            txtSearchProdSup = new TextBox();
            grpBoxProductSuppliers = new GroupBox();
            dgvProductSuppliers = new DataGridView();
            grpBoxStatus = new GroupBox();
            btnAddNewRelationship = new Button();
            dgvAddRelationship = new DataGridView();
            productsSupplierBindingSource = new BindingSource(components);
            tabControl.SuspendLayout();
            tabProducts.SuspendLayout();
            panelSearchProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnCancelSearchProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBoxSearch).BeginInit();
            grpBoxProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            tabSuppliers.SuspendLayout();
            panelSearchSupplier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnCancelSearchSuppliers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            grpBoxSuppliers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSuppliers).BeginInit();
            tabProductSuppliers.SuspendLayout();
            panelSearchProdSup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnCancelSearchProdSup).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            grpBoxProductSuppliers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductSuppliers).BeginInit();
            grpBoxStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAddRelationship).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productsSupplierBindingSource).BeginInit();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabProducts);
            tabControl.Controls.Add(tabSuppliers);
            tabControl.Controls.Add(tabProductSuppliers);
            tabControl.Location = new Point(15, 3);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(785, 485);
            tabControl.TabIndex = 0;
            tabControl.SelectedIndexChanged += tabControl_Changed;
            // 
            // tabProducts
            // 
            tabProducts.Controls.Add(panelSearchProducts);
            tabProducts.Controls.Add(grpBoxProducts);
            tabProducts.Controls.Add(comboBxProducts);
            tabProducts.Location = new Point(4, 29);
            tabProducts.Name = "tabProducts";
            tabProducts.Padding = new Padding(3);
            tabProducts.Size = new Size(777, 452);
            tabProducts.TabIndex = 0;
            tabProducts.Text = "Products";
            tabProducts.UseVisualStyleBackColor = true;
            // 
            // panelSearchProducts
            // 
            panelSearchProducts.Controls.Add(btnCancelSearchProducts);
            panelSearchProducts.Controls.Add(picBoxSearch);
            panelSearchProducts.Controls.Add(txtSearchProducts);
            panelSearchProducts.Location = new Point(548, 16);
            panelSearchProducts.Name = "panelSearchProducts";
            panelSearchProducts.Size = new Size(208, 31);
            panelSearchProducts.TabIndex = 4;
            // 
            // btnCancelSearchProducts
            // 
            btnCancelSearchProducts.Cursor = Cursors.Hand;
            btnCancelSearchProducts.Image = Properties.Resources.Cancel;
            btnCancelSearchProducts.Location = new Point(181, 6);
            btnCancelSearchProducts.Name = "btnCancelSearchProducts";
            btnCancelSearchProducts.Size = new Size(24, 18);
            btnCancelSearchProducts.SizeMode = PictureBoxSizeMode.Zoom;
            btnCancelSearchProducts.TabIndex = 6;
            btnCancelSearchProducts.TabStop = false;
            // 
            // picBoxSearch
            // 
            picBoxSearch.Image = Properties.Resources.search;
            picBoxSearch.Location = new Point(3, 3);
            picBoxSearch.Name = "picBoxSearch";
            picBoxSearch.Size = new Size(29, 24);
            picBoxSearch.SizeMode = PictureBoxSizeMode.Zoom;
            picBoxSearch.TabIndex = 5;
            picBoxSearch.TabStop = false;
            // 
            // txtSearchProducts
            // 
            txtSearchProducts.BorderStyle = BorderStyle.None;
            txtSearchProducts.Location = new Point(35, 4);
            txtSearchProducts.Name = "txtSearchProducts";
            txtSearchProducts.PlaceholderText = "Search...";
            txtSearchProducts.Size = new Size(143, 20);
            txtSearchProducts.TabIndex = 3;
            txtSearchProducts.TextChanged += txtSearch_Changed;
            // 
            // grpBoxProducts
            // 
            grpBoxProducts.Controls.Add(btnClearProducts);
            grpBoxProducts.Controls.Add(lblProduct);
            grpBoxProducts.Controls.Add(btnExecuteProducts);
            grpBoxProducts.Controls.Add(txtProduct);
            grpBoxProducts.Controls.Add(dgvProducts);
            grpBoxProducts.Location = new Point(21, 76);
            grpBoxProducts.Name = "grpBoxProducts";
            grpBoxProducts.Size = new Size(735, 305);
            grpBoxProducts.TabIndex = 2;
            grpBoxProducts.TabStop = false;
            grpBoxProducts.Text = "groupBox1";
            grpBoxProducts.Visible = false;
            // 
            // btnClearProducts
            // 
            btnClearProducts.Location = new Point(417, 160);
            btnClearProducts.Name = "btnClearProducts";
            btnClearProducts.Size = new Size(126, 28);
            btnClearProducts.TabIndex = 3;
            btnClearProducts.Text = "Clear";
            btnClearProducts.UseVisualStyleBackColor = true;
            btnClearProducts.Visible = false;
            btnClearProducts.Click += btnClearProducts_Click;
            // 
            // lblProduct
            // 
            lblProduct.AutoSize = true;
            lblProduct.Location = new Point(248, 112);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(50, 20);
            lblProduct.TabIndex = 2;
            lblProduct.Text = "label1";
            lblProduct.Visible = false;
            // 
            // btnExecuteProducts
            // 
            btnExecuteProducts.Location = new Point(275, 160);
            btnExecuteProducts.Name = "btnExecuteProducts";
            btnExecuteProducts.Size = new Size(126, 28);
            btnExecuteProducts.TabIndex = 1;
            btnExecuteProducts.Text = "Execute";
            btnExecuteProducts.UseVisualStyleBackColor = true;
            btnExecuteProducts.Click += btnExecuteProducts_Click;
            // 
            // txtProduct
            // 
            txtProduct.Location = new Point(363, 109);
            txtProduct.Name = "txtProduct";
            txtProduct.Size = new Size(154, 27);
            txtProduct.TabIndex = 1;
            txtProduct.Visible = false;
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(19, 26);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.Size = new Size(698, 258);
            dgvProducts.TabIndex = 0;
            dgvProducts.Visible = false;
            dgvProducts.CellClick += dgvProducts_CellClick;
            // 
            // comboBxProducts
            // 
            comboBxProducts.FormattingEnabled = true;
            comboBxProducts.Items.AddRange(new object[] { "Add Product", "Edit Product", "Get Product", "Get All Products" });
            comboBxProducts.Location = new Point(21, 16);
            comboBxProducts.Name = "comboBxProducts";
            comboBxProducts.Size = new Size(179, 28);
            comboBxProducts.TabIndex = 0;
            comboBxProducts.SelectedIndexChanged += comboBxProducts_SelectedIndexChanged;
            // 
            // tabSuppliers
            // 
            tabSuppliers.Controls.Add(panelSearchSupplier);
            tabSuppliers.Controls.Add(grpBoxSuppliers);
            tabSuppliers.Controls.Add(comboBxSuppliers);
            tabSuppliers.Location = new Point(4, 29);
            tabSuppliers.Name = "tabSuppliers";
            tabSuppliers.Padding = new Padding(3);
            tabSuppliers.Size = new Size(777, 452);
            tabSuppliers.TabIndex = 1;
            tabSuppliers.Text = "Suppliers";
            tabSuppliers.UseVisualStyleBackColor = true;
            // 
            // panelSearchSupplier
            // 
            panelSearchSupplier.Controls.Add(btnCancelSearchSuppliers);
            panelSearchSupplier.Controls.Add(pictureBox1);
            panelSearchSupplier.Controls.Add(txtSearchSuppliers);
            panelSearchSupplier.Location = new Point(543, 15);
            panelSearchSupplier.Name = "panelSearchSupplier";
            panelSearchSupplier.Size = new Size(211, 31);
            panelSearchSupplier.TabIndex = 5;
            // 
            // btnCancelSearchSuppliers
            // 
            btnCancelSearchSuppliers.Cursor = Cursors.Hand;
            btnCancelSearchSuppliers.Image = Properties.Resources.Cancel;
            btnCancelSearchSuppliers.Location = new Point(184, 6);
            btnCancelSearchSuppliers.Name = "btnCancelSearchSuppliers";
            btnCancelSearchSuppliers.Size = new Size(24, 18);
            btnCancelSearchSuppliers.SizeMode = PictureBoxSizeMode.Zoom;
            btnCancelSearchSuppliers.TabIndex = 7;
            btnCancelSearchSuppliers.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.search;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(29, 24);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // txtSearchSuppliers
            // 
            txtSearchSuppliers.BorderStyle = BorderStyle.None;
            txtSearchSuppliers.Location = new Point(35, 4);
            txtSearchSuppliers.Name = "txtSearchSuppliers";
            txtSearchSuppliers.PlaceholderText = "Search...";
            txtSearchSuppliers.Size = new Size(143, 20);
            txtSearchSuppliers.TabIndex = 3;
            // 
            // grpBoxSuppliers
            // 
            grpBoxSuppliers.Controls.Add(btnClearSuppliers);
            grpBoxSuppliers.Controls.Add(txtSupplier);
            grpBoxSuppliers.Controls.Add(btnExecuteSuppliers);
            grpBoxSuppliers.Controls.Add(lblSuppler);
            grpBoxSuppliers.Controls.Add(dgvSuppliers);
            grpBoxSuppliers.Location = new Point(27, 74);
            grpBoxSuppliers.Name = "grpBoxSuppliers";
            grpBoxSuppliers.Size = new Size(727, 307);
            grpBoxSuppliers.TabIndex = 2;
            grpBoxSuppliers.TabStop = false;
            grpBoxSuppliers.Text = "groupBox1";
            grpBoxSuppliers.Visible = false;
            // 
            // btnClearSuppliers
            // 
            btnClearSuppliers.Location = new Point(345, 176);
            btnClearSuppliers.Name = "btnClearSuppliers";
            btnClearSuppliers.Size = new Size(126, 28);
            btnClearSuppliers.TabIndex = 3;
            btnClearSuppliers.Text = "Clear";
            btnClearSuppliers.UseVisualStyleBackColor = true;
            btnClearSuppliers.Visible = false;
            btnClearSuppliers.Click += btnClearSuppliers_Click;
            // 
            // txtSupplier
            // 
            txtSupplier.Location = new Point(305, 129);
            txtSupplier.Name = "txtSupplier";
            txtSupplier.Size = new Size(125, 27);
            txtSupplier.TabIndex = 2;
            txtSupplier.Visible = false;
            // 
            // btnExecuteSuppliers
            // 
            btnExecuteSuppliers.Location = new Point(210, 176);
            btnExecuteSuppliers.Name = "btnExecuteSuppliers";
            btnExecuteSuppliers.Size = new Size(129, 26);
            btnExecuteSuppliers.TabIndex = 1;
            btnExecuteSuppliers.Text = "Execute";
            btnExecuteSuppliers.UseVisualStyleBackColor = true;
            btnExecuteSuppliers.Click += btnExecuteSuppliers_Click;
            // 
            // lblSuppler
            // 
            lblSuppler.AutoSize = true;
            lblSuppler.Location = new Point(222, 132);
            lblSuppler.Name = "lblSuppler";
            lblSuppler.Size = new Size(50, 20);
            lblSuppler.TabIndex = 1;
            lblSuppler.Text = "label1";
            lblSuppler.Visible = false;
            // 
            // dgvSuppliers
            // 
            dgvSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSuppliers.Location = new Point(16, 26);
            dgvSuppliers.Name = "dgvSuppliers";
            dgvSuppliers.RowHeadersWidth = 51;
            dgvSuppliers.Size = new Size(692, 264);
            dgvSuppliers.TabIndex = 0;
            dgvSuppliers.Visible = false;
            dgvSuppliers.CellClick += dgvSuppliers_CellClick;
            // 
            // comboBxSuppliers
            // 
            comboBxSuppliers.FormattingEnabled = true;
            comboBxSuppliers.Items.AddRange(new object[] { "Add Supplier", "Edit Suppier", "Get Supplier", "Get All Suppliers" });
            comboBxSuppliers.Location = new Point(22, 15);
            comboBxSuppliers.Name = "comboBxSuppliers";
            comboBxSuppliers.Size = new Size(182, 28);
            comboBxSuppliers.TabIndex = 0;
            comboBxSuppliers.SelectedIndexChanged += comboBxSuppliers_SelectedIndexChanged;
            // 
            // tabProductSuppliers
            // 
            tabProductSuppliers.Controls.Add(panelSearchProdSup);
            tabProductSuppliers.Controls.Add(grpBoxProductSuppliers);
            tabProductSuppliers.Location = new Point(4, 29);
            tabProductSuppliers.Name = "tabProductSuppliers";
            tabProductSuppliers.Padding = new Padding(3);
            tabProductSuppliers.Size = new Size(777, 452);
            tabProductSuppliers.TabIndex = 2;
            tabProductSuppliers.Text = "Product-Supplier relationships";
            tabProductSuppliers.UseVisualStyleBackColor = true;
            // 
            // panelSearchProdSup
            // 
            panelSearchProdSup.Controls.Add(btnCancelSearchProdSup);
            panelSearchProdSup.Controls.Add(pictureBox2);
            panelSearchProdSup.Controls.Add(txtSearchProdSup);
            panelSearchProdSup.Location = new Point(279, 16);
            panelSearchProdSup.Name = "panelSearchProdSup";
            panelSearchProdSup.Size = new Size(209, 31);
            panelSearchProdSup.TabIndex = 5;
            // 
            // btnCancelSearchProdSup
            // 
            btnCancelSearchProdSup.Cursor = Cursors.Hand;
            btnCancelSearchProdSup.Image = Properties.Resources.Cancel;
            btnCancelSearchProdSup.Location = new Point(182, 6);
            btnCancelSearchProdSup.Name = "btnCancelSearchProdSup";
            btnCancelSearchProdSup.Size = new Size(24, 18);
            btnCancelSearchProdSup.SizeMode = PictureBoxSizeMode.Zoom;
            btnCancelSearchProdSup.TabIndex = 7;
            btnCancelSearchProdSup.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.search;
            pictureBox2.Location = new Point(3, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(29, 24);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // txtSearchProdSup
            // 
            txtSearchProdSup.BorderStyle = BorderStyle.None;
            txtSearchProdSup.Location = new Point(38, 4);
            txtSearchProdSup.Name = "txtSearchProdSup";
            txtSearchProdSup.PlaceholderText = "Search...";
            txtSearchProdSup.Size = new Size(143, 20);
            txtSearchProdSup.TabIndex = 3;
            // 
            // grpBoxProductSuppliers
            // 
            grpBoxProductSuppliers.Controls.Add(dgvProductSuppliers);
            grpBoxProductSuppliers.Controls.Add(grpBoxStatus);
            grpBoxProductSuppliers.Location = new Point(19, 53);
            grpBoxProductSuppliers.Name = "grpBoxProductSuppliers";
            grpBoxProductSuppliers.Size = new Size(739, 393);
            grpBoxProductSuppliers.TabIndex = 1;
            grpBoxProductSuppliers.TabStop = false;
            grpBoxProductSuppliers.Text = "Relationships";
            // 
            // dgvProductSuppliers
            // 
            dgvProductSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductSuppliers.Location = new Point(15, 26);
            dgvProductSuppliers.Name = "dgvProductSuppliers";
            dgvProductSuppliers.RowHeadersWidth = 51;
            dgvProductSuppliers.Size = new Size(709, 262);
            dgvProductSuppliers.TabIndex = 0;
            dgvProductSuppliers.CellClick += dgvProductSuppliers_CellClick;
            // 
            // grpBoxStatus
            // 
            grpBoxStatus.Controls.Add(btnAddNewRelationship);
            grpBoxStatus.Controls.Add(dgvAddRelationship);
            grpBoxStatus.Location = new Point(6, 294);
            grpBoxStatus.Name = "grpBoxStatus";
            grpBoxStatus.Size = new Size(727, 90);
            grpBoxStatus.TabIndex = 3;
            grpBoxStatus.TabStop = false;
            grpBoxStatus.Text = "groupBox1";
            // 
            // btnAddNewRelationship
            // 
            btnAddNewRelationship.Location = new Point(219, 39);
            btnAddNewRelationship.Name = "btnAddNewRelationship";
            btnAddNewRelationship.Size = new Size(288, 29);
            btnAddNewRelationship.TabIndex = 1;
            btnAddNewRelationship.Text = "Add new Relationship";
            btnAddNewRelationship.UseVisualStyleBackColor = true;
            btnAddNewRelationship.Click += btnAddNewRelationship_Click;
            // 
            // dgvAddRelationship
            // 
            dgvAddRelationship.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAddRelationship.Location = new Point(9, 25);
            dgvAddRelationship.Name = "dgvAddRelationship";
            dgvAddRelationship.RowHeadersWidth = 51;
            dgvAddRelationship.Size = new Size(709, 59);
            dgvAddRelationship.TabIndex = 2;
            // 
            // productsSupplierBindingSource
            // 
            productsSupplierBindingSource.DataSource = typeof(TravelExpertsData.ProductsSupplier);
            // 
            // frmProductAndSupplier
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(804, 490);
            Controls.Add(tabControl);
            Name = "frmProductAndSupplier";
            Text = "frmProductAndSupplier";
            tabControl.ResumeLayout(false);
            tabProducts.ResumeLayout(false);
            panelSearchProducts.ResumeLayout(false);
            panelSearchProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnCancelSearchProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBoxSearch).EndInit();
            grpBoxProducts.ResumeLayout(false);
            grpBoxProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            tabSuppliers.ResumeLayout(false);
            panelSearchSupplier.ResumeLayout(false);
            panelSearchSupplier.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnCancelSearchSuppliers).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            grpBoxSuppliers.ResumeLayout(false);
            grpBoxSuppliers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSuppliers).EndInit();
            tabProductSuppliers.ResumeLayout(false);
            panelSearchProdSup.ResumeLayout(false);
            panelSearchProdSup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnCancelSearchProdSup).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            grpBoxProductSuppliers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProductSuppliers).EndInit();
            grpBoxStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAddRelationship).EndInit();
            ((System.ComponentModel.ISupportInitialize)productsSupplierBindingSource).EndInit();
            ResumeLayout(false);
        }

        private void DgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnExecuteProducts_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnExecuteSuppliers_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnClearProducts_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ComboBxSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private TabControl tabControl;
        private TabPage tabProducts;
        private TabPage tabSuppliers;
        private Button btnExecuteProducts;
        private ComboBox comboBxProducts;
        private Button btnExecuteSuppliers;
        private ComboBox comboBxSuppliers;
        private GroupBox grpBoxSuppliers;
        private DataGridView dgvSuppliers;
        private BindingSource productsSupplierBindingSource;
        private GroupBox grpBoxProducts;
        private DataGridView dgvProducts;
        private Label lblProduct;
        private TextBox txtProduct;
        private TextBox txtSupplier;
        private Label lblSuppler;
        private Button btnClearProducts;
        private Button btnClearSuppliers;
        private TabPage tabProductSuppliers;
        private GroupBox grpBoxProductSuppliers;
        private DataGridView dgvProductSuppliers;
        private Button btnAddNewRelationship;
        private DataGridView dgvAddRelationship;
        private GroupBox grpBoxStatus;
        private TextBox txtSearchProducts;
        private Panel panelSearchProducts;
        private PictureBox picBoxSearch;
        private Panel panelSearchSupplier;
        private PictureBox pictureBox1;
        private TextBox txtSearchSuppliers;
        private Panel panelSearchProdSup;
        private PictureBox pictureBox2;
        private TextBox txtSearchProdSup;
        private PictureBox btnCancelSearchProducts;
        private PictureBox btnCancelSearchSuppliers;
        private PictureBox btnCancelSearchProdSup;
    }
}