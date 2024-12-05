namespace TravelExpertsGUI
{
    partial class HomeDashboard
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
            btnAgentsAndAgencies = new Button();
            btnProductsAndSuppliers = new Button();
            btnPackages = new Button();
            SuspendLayout();
            // 
            // btnAgentsAndAgencies
            // 
            btnAgentsAndAgencies.Location = new Point(270, 324);
            btnAgentsAndAgencies.Name = "btnAgentsAndAgencies";
            btnAgentsAndAgencies.Size = new Size(235, 47);
            btnAgentsAndAgencies.TabIndex = 0;
            btnAgentsAndAgencies.Text = "Manage Agents and Agencies";
            btnAgentsAndAgencies.UseVisualStyleBackColor = true;
            btnAgentsAndAgencies.Click += btnAgentsAndAgencies_Click;
            // 
            // btnProductsAndSuppliers
            // 
            btnProductsAndSuppliers.Location = new Point(270, 215);
            btnProductsAndSuppliers.Name = "btnProductsAndSuppliers";
            btnProductsAndSuppliers.Size = new Size(235, 47);
            btnProductsAndSuppliers.TabIndex = 1;
            btnProductsAndSuppliers.Text = "Manage Products And Suppliers";
            btnProductsAndSuppliers.UseVisualStyleBackColor = true;
            btnProductsAndSuppliers.Click += btnProductsAndSuppliers_Click;
            // 
            // btnPackages
            // 
            btnPackages.Location = new Point(270, 104);
            btnPackages.Name = "btnPackages";
            btnPackages.Size = new Size(235, 47);
            btnPackages.TabIndex = 2;
            btnPackages.Text = "Manage Packages";
            btnPackages.UseVisualStyleBackColor = true;
            btnPackages.Click += btnPackages_Click;
            // 
            // HomeDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnPackages);
            Controls.Add(btnProductsAndSuppliers);
            Controls.Add(btnAgentsAndAgencies);
            Name = "HomeDashboard";
            Text = "HomeDashboard";
            ResumeLayout(false);
        }

        #endregion

        private Button btnAgentsAndAgencies;
        private Button btnProductsAndSuppliers;
        private Button btnPackages;
    }
}