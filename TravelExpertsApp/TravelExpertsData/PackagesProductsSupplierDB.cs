using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public class PackagesProductsSupplierDB
    {
        /// <summary>
        /// Creates a list of package products as PackageProductsSupplierDTO objects
        /// and sorts by PackageProductSupplierID.
        /// Joins PackagesProductsSuppliers, Packages, ProductSuppliers,
        /// Products and Suppliers tables to show complete information about the package product.
        /// </summary>
        /// <returns></returns>
        public static List<PackagesProductsSupplierDTO> GetPackageProductsList()
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                List<PackagesProductsSupplierDTO> packageProducts = db.PackagesProductsSuppliers
                    .Join(
                        db.Packages,
                        pkgProdA => pkgProdA.PackageId,
                        pkg => pkg.PackageId,
                        (pkgProdA, pkg) => new { pkgProdA, pkg })
                    .Join(
                        db.ProductsSuppliers,
                        pkgProdB => pkgProdB.pkgProdA.ProductSupplierId,
                        prodSupA => prodSupA.ProductSupplierId,
                        (pkgProdB, prodSupA) => new { pkgProdB, prodSupA })
                    .Join(
                        db.Products,
                        prodSupB => prodSupB.prodSupA.ProductId,
                        prod => prod.ProductId,
                        (prodSupB, prod) => new { prodSupB, prod })
                    .Join(
                        db.Suppliers,
                        prodSupC => prodSupC.prodSupB.prodSupA.SupplierId,
                        sup => sup.SupplierId,
                        (prodSupC, sup) => new { prodSupC, sup })
                    .Select(p => new PackagesProductsSupplierDTO
                    {
                        PkgProductSupID = p.prodSupC.prodSupB.pkgProdB.pkgProdA.PackageProductSupplierId,
                        PkgName = p.prodSupC.prodSupB.pkgProdB.pkg.PkgName,
                        ProductName = p.prodSupC.prod.ProdName,
                        SupName = p.sup.SupName!
                    }).OrderBy(p => p.PkgProductSupID).ToList();
                return packageProducts;
            }
        }

        /// <summary>
        /// Creates a list of package products as PackageProductsSupplierDTO objects.
        /// Joins the ProductsSuppliers, Products, and Suppliers tables to show
        /// additional information about the package product.
        /// </summary>
        /// <returns></returns>
        public static List<PackagesProductsSupplierDTO> GetPackageProductsCombobox()
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                List<PackagesProductsSupplierDTO> productsSuppliers = db.ProductsSuppliers
                    .Join(
                        db.Products,
                        prodSupA => prodSupA.ProductId,
                        prod => prod.ProductId,
                        (prodSupA, prod) => new { prodSupA, prod })
                    .Join(
                        db.Suppliers,
                        prodSupB => prodSupB.prodSupA.SupplierId,
                        sup => sup.SupplierId,
                        (prodSupB, sup) => new { prodSupB, sup })
                    .Select(p => new PackagesProductsSupplierDTO
                    {
                        ProductSupId = p.prodSupB.prodSupA.ProductSupplierId,
                        ProductName = p.prodSupB.prod.ProdName,
                        SupName = p.sup.SupName!
                    }).ToList();
                return productsSuppliers;
            }
        }

        /// <summary>
        /// Finds a package product by PackageProductSupplierID, the PK of the table
        /// and returns it as an object
        /// </summary>
        /// <param name="packageProductID">PackageProductSupplierID to search with</param>
        /// <returns>Package product object with matching ID</returns>
        public static PackagesProductsSupplier FindPackageProduct(int packageProductID)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                return db.PackagesProductsSuppliers.Find(packageProductID)!;
            }
        }

        /// <summary>
        /// Checks the database for a duplicate package product
        /// based on selected package and selected product
        /// </summary>
        /// <param name="checkPackageProduct">Package product to be checked</param>
        /// <returns>True if the package product already exists, false if not</returns>
        public static bool CheckDuplicatePackageProduct(PackagesProductsSupplier checkPackageProduct)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                return db.PackagesProductsSuppliers
                    .Where(packageProduct =>
                        packageProduct.PackageId == checkPackageProduct.PackageId &&
                        packageProduct.ProductSupplierId == checkPackageProduct.ProductSupplierId)
                    .Any();
            }
        }

        /// <summary>
        /// Adds the passed-in package product to the database
        /// </summary>
        /// <param name="packageProduct">New package product to add</param>
        public static void AddPackageProduct(PackagesProductsSupplier packageProduct)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                if (packageProduct != null)
                {
                    db.PackagesProductsSuppliers.Add(packageProduct);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Finds a matching package product by PackageProductSupplierID in the database
        /// and updates the record with the attribute values of the passed-in package product object
        /// </summary>
        /// <param name="selectedPackageProduct">Package product with updated values</param>
        public static void ModifyPackageProduct(PackagesProductsSupplier selectedPackageProduct)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                PackagesProductsSupplier? packageProductToModify = db.PackagesProductsSuppliers.Find(selectedPackageProduct.PackageProductSupplierId);
                if (packageProductToModify != null)
                {
                    packageProductToModify.PackageId = selectedPackageProduct.PackageId;
                    packageProductToModify.ProductSupplierId = selectedPackageProduct.ProductSupplierId;
                }
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Finds a matching package product by PackageProductSupplierID in the database and deletes it
        /// </summary>
        /// <param name="selectedPackageProduct">Package product to delete</param>
        public static void DeletePackageProduct(PackagesProductsSupplier selectedPackageProduct)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                PackagesProductsSupplier? packageProductToDelete = db.PackagesProductsSuppliers.Find(selectedPackageProduct.PackageProductSupplierId);
                if (packageProductToDelete != null)
                {
                    db.PackagesProductsSuppliers.Remove(packageProductToDelete);
                    db.SaveChanges();
                }
            }
        }
    }
}
