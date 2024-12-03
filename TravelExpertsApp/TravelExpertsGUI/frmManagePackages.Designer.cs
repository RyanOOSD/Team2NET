namespace TravelExpertsGUI
{
    partial class frmManagePackages
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
            btnAddPkg = new Button();
            dgvPkg = new DataGridView();
            btnPkgExit = new Button();
            btnAddProductToPkg = new Button();
            tbcPkgPage = new TabControl();
            tabPackages = new TabPage();
            txtPkgSearch = new TextBox();
            tabPkgProductPage = new TabPage();
            txtPkgProductSearch = new TextBox();
            dgvPkgProducts = new DataGridView();
            btnPkgProductsExit = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPkg).BeginInit();
            tbcPkgPage.SuspendLayout();
            tabPackages.SuspendLayout();
            tabPkgProductPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPkgProducts).BeginInit();
            SuspendLayout();
            // 
            // btnAddPkg
            // 
            btnAddPkg.Location = new Point(6, 319);
            btnAddPkg.Name = "btnAddPkg";
            btnAddPkg.Size = new Size(85, 23);
            btnAddPkg.TabIndex = 1;
            btnAddPkg.Text = "Add Package";
            btnAddPkg.UseVisualStyleBackColor = true;
            btnAddPkg.Click += btnAddPkg_Click;
            // 
            // dgvPkg
            // 
            dgvPkg.AllowUserToResizeColumns = false;
            dgvPkg.AllowUserToResizeRows = false;
            dgvPkg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvPkg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPkg.Location = new Point(0, 35);
            dgvPkg.Name = "dgvPkg";
            dgvPkg.ReadOnly = true;
            dgvPkg.Size = new Size(1026, 262);
            dgvPkg.TabIndex = 2;
            dgvPkg.CellClick += dgvPkg_CellClick;
            dgvPkg.CellFormatting += dgvPkg_CellFormatting;
            // 
            // btnPkgExit
            // 
            btnPkgExit.Location = new Point(945, 319);
            btnPkgExit.Name = "btnPkgExit";
            btnPkgExit.Size = new Size(75, 23);
            btnPkgExit.TabIndex = 3;
            btnPkgExit.Text = "Exit";
            btnPkgExit.UseVisualStyleBackColor = true;
            btnPkgExit.Click += btnPkgExit_Click;
            // 
            // btnAddProductToPkg
            // 
            btnAddProductToPkg.Location = new Point(6, 319);
            btnAddProductToPkg.Name = "btnAddProductToPkg";
            btnAddProductToPkg.Size = new Size(148, 23);
            btnAddProductToPkg.TabIndex = 4;
            btnAddProductToPkg.Text = "Add Products to Package";
            btnAddProductToPkg.UseVisualStyleBackColor = true;
            btnAddProductToPkg.Click += btnAddProductToPkg_Click;
            // 
            // tbcPkgPage
            // 
            tbcPkgPage.Controls.Add(tabPackages);
            tbcPkgPage.Controls.Add(tabPkgProductPage);
            tbcPkgPage.Location = new Point(12, 12);
            tbcPkgPage.Name = "tbcPkgPage";
            tbcPkgPage.SelectedIndex = 0;
            tbcPkgPage.Size = new Size(1034, 376);
            tbcPkgPage.TabIndex = 5;
            tbcPkgPage.SelectedIndexChanged += tbcPkgPage_SelectedIndexChanged;
            // 
            // tabPackages
            // 
            tabPackages.BackColor = Color.Gainsboro;
            tabPackages.Controls.Add(txtPkgSearch);
            tabPackages.Controls.Add(dgvPkg);
            tabPackages.Controls.Add(btnAddPkg);
            tabPackages.Controls.Add(btnPkgExit);
            tabPackages.Location = new Point(4, 24);
            tabPackages.Name = "tabPackages";
            tabPackages.Padding = new Padding(3);
            tabPackages.Size = new Size(1026, 348);
            tabPackages.TabIndex = 0;
            tabPackages.Text = "Packages";
            // 
            // txtPkgSearch
            // 
            txtPkgSearch.Location = new Point(794, 6);
            txtPkgSearch.Name = "txtPkgSearch";
            txtPkgSearch.PlaceholderText = "Enter your search term...";
            txtPkgSearch.Size = new Size(226, 23);
            txtPkgSearch.TabIndex = 4;
            txtPkgSearch.KeyDown += txtPkgSearch_KeyDown;
            // 
            // tabPkgProductPage
            // 
            tabPkgProductPage.BackColor = Color.Gainsboro;
            tabPkgProductPage.Controls.Add(txtPkgProductSearch);
            tabPkgProductPage.Controls.Add(dgvPkgProducts);
            tabPkgProductPage.Controls.Add(btnPkgProductsExit);
            tabPkgProductPage.Controls.Add(btnAddProductToPkg);
            tabPkgProductPage.Location = new Point(4, 24);
            tabPkgProductPage.Name = "tabPkgProductPage";
            tabPkgProductPage.Padding = new Padding(3);
            tabPkgProductPage.Size = new Size(1026, 348);
            tabPkgProductPage.TabIndex = 1;
            tabPkgProductPage.Text = "Package Products";
            // 
            // txtPkgProductSearch
            // 
            txtPkgProductSearch.Location = new Point(794, 6);
            txtPkgProductSearch.Name = "txtPkgProductSearch";
            txtPkgProductSearch.PlaceholderText = "Enter your search term...";
            txtPkgProductSearch.Size = new Size(226, 23);
            txtPkgProductSearch.TabIndex = 7;
            // 
            // dgvPkgProducts
            // 
            dgvPkgProducts.AllowUserToResizeColumns = false;
            dgvPkgProducts.AllowUserToResizeRows = false;
            dgvPkgProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPkgProducts.Location = new Point(0, 35);
            dgvPkgProducts.Name = "dgvPkgProducts";
            dgvPkgProducts.ReadOnly = true;
            dgvPkgProducts.Size = new Size(1026, 262);
            dgvPkgProducts.TabIndex = 6;
            dgvPkgProducts.CellClick += dgvPkgProducts_CellClick;
            dgvPkgProducts.CellFormatting += dgvPkgProducts_CellFormatting;
            // 
            // btnPkgProductsExit
            // 
            btnPkgProductsExit.Location = new Point(945, 319);
            btnPkgProductsExit.Name = "btnPkgProductsExit";
            btnPkgProductsExit.Size = new Size(75, 23);
            btnPkgProductsExit.TabIndex = 5;
            btnPkgProductsExit.Text = "Exit";
            btnPkgProductsExit.UseVisualStyleBackColor = true;
            btnPkgProductsExit.Click += btnPkgProductsExit_Click;
            // 
            // frmManagePackages
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(1058, 400);
            Controls.Add(tbcPkgPage);
            Name = "frmManagePackages";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage Packages";
            Load += frmManagePackages_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPkg).EndInit();
            tbcPkgPage.ResumeLayout(false);
            tabPackages.ResumeLayout(false);
            tabPackages.PerformLayout();
            tabPkgProductPage.ResumeLayout(false);
            tabPkgProductPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPkgProducts).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnAddPkg;
        private DataGridView dgvPkg;
        private Button btnPkgExit;
        private Button btnAddProductToPkg;
        private TabControl tbcPkgPage;
        private TabPage tabPackages;
        private TabPage tabPkgProductPage;
        private Button btnPkgProductsExit;
        private TextBox txtPkgSearch;
        private DataGridView dgvPkgProducts;
        private TextBox txtPkgProductSearch;
    }
}