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
            btnPkgSearch = new Button();
            txtPkgSearch = new TextBox();
            tabPkgProductPage = new TabPage();
            btnPkgProductSearch = new Button();
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
            dgvPkg.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgvPkg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPkg.Location = new Point(0, 35);
            dgvPkg.Name = "dgvPkg";
            dgvPkg.Size = new Size(1009, 262);
            dgvPkg.TabIndex = 2;
            // 
            // btnPkgExit
            // 
            btnPkgExit.Location = new Point(928, 319);
            btnPkgExit.Name = "btnPkgExit";
            btnPkgExit.Size = new Size(75, 23);
            btnPkgExit.TabIndex = 3;
            btnPkgExit.Text = "Exit";
            btnPkgExit.UseVisualStyleBackColor = true;
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
            tbcPkgPage.Size = new Size(1017, 376);
            tbcPkgPage.TabIndex = 5;
            // 
            // tabPackages
            // 
            tabPackages.BackColor = Color.Gainsboro;
            tabPackages.Controls.Add(btnPkgSearch);
            tabPackages.Controls.Add(txtPkgSearch);
            tabPackages.Controls.Add(dgvPkg);
            tabPackages.Controls.Add(btnAddPkg);
            tabPackages.Controls.Add(btnPkgExit);
            tabPackages.Location = new Point(4, 24);
            tabPackages.Name = "tabPackages";
            tabPackages.Padding = new Padding(3);
            tabPackages.Size = new Size(1009, 348);
            tabPackages.TabIndex = 0;
            tabPackages.Text = "Packages";
            // 
            // btnPkgSearch
            // 
            btnPkgSearch.Location = new Point(928, 6);
            btnPkgSearch.Name = "btnPkgSearch";
            btnPkgSearch.Size = new Size(75, 23);
            btnPkgSearch.TabIndex = 5;
            btnPkgSearch.Text = "Search";
            btnPkgSearch.UseVisualStyleBackColor = true;
            // 
            // txtPkgSearch
            // 
            txtPkgSearch.Location = new Point(777, 6);
            txtPkgSearch.Name = "txtPkgSearch";
            txtPkgSearch.PlaceholderText = "Enter Package ID or Name";
            txtPkgSearch.Size = new Size(145, 23);
            txtPkgSearch.TabIndex = 4;
            // 
            // tabPkgProductPage
            // 
            tabPkgProductPage.BackColor = Color.Gainsboro;
            tabPkgProductPage.Controls.Add(btnPkgProductSearch);
            tabPkgProductPage.Controls.Add(txtPkgProductSearch);
            tabPkgProductPage.Controls.Add(dgvPkgProducts);
            tabPkgProductPage.Controls.Add(btnPkgProductsExit);
            tabPkgProductPage.Controls.Add(btnAddProductToPkg);
            tabPkgProductPage.Location = new Point(4, 24);
            tabPkgProductPage.Name = "tabPkgProductPage";
            tabPkgProductPage.Padding = new Padding(3);
            tabPkgProductPage.Size = new Size(1009, 348);
            tabPkgProductPage.TabIndex = 1;
            tabPkgProductPage.Text = "Package Products";
            // 
            // btnPkgProductSearch
            // 
            btnPkgProductSearch.Location = new Point(928, 6);
            btnPkgProductSearch.Name = "btnPkgProductSearch";
            btnPkgProductSearch.Size = new Size(75, 23);
            btnPkgProductSearch.TabIndex = 8;
            btnPkgProductSearch.Text = "Search";
            btnPkgProductSearch.UseVisualStyleBackColor = true;
            // 
            // txtPkgProductSearch
            // 
            txtPkgProductSearch.Location = new Point(777, 6);
            txtPkgProductSearch.Name = "txtPkgProductSearch";
            txtPkgProductSearch.PlaceholderText = "Enter Package ID or Name";
            txtPkgProductSearch.Size = new Size(145, 23);
            txtPkgProductSearch.TabIndex = 7;
            // 
            // dgvPkgProducts
            // 
            dgvPkgProducts.AllowUserToResizeColumns = false;
            dgvPkgProducts.AllowUserToResizeRows = false;
            dgvPkgProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPkgProducts.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvPkgProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPkgProducts.Location = new Point(0, 35);
            dgvPkgProducts.Name = "dgvPkgProducts";
            dgvPkgProducts.Size = new Size(1009, 262);
            dgvPkgProducts.TabIndex = 6;
            // 
            // btnPkgProductsExit
            // 
            btnPkgProductsExit.Location = new Point(928, 319);
            btnPkgProductsExit.Name = "btnPkgProductsExit";
            btnPkgProductsExit.Size = new Size(75, 23);
            btnPkgProductsExit.TabIndex = 5;
            btnPkgProductsExit.Text = "Exit";
            btnPkgProductsExit.UseVisualStyleBackColor = true;
            // 
            // frmManagePackages
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(1041, 400);
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
        private Button btnPkgSearch;
        private DataGridView dgvPkgProducts;
        private Button btnPkgProductSearch;
        private TextBox txtPkgProductSearch;
    }
}