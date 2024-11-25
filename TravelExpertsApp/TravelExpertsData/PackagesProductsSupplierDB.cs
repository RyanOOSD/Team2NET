using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public class PackagesProductsSupplierDB
    {
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
                        SupName = p.sup.SupName
                    }).OrderBy(p => p.PkgProductSupID).ToList();
                return packageProducts;
            }
        }

        public static List<PackagesProductsSupplierDTO> GetPackageProducts()
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
                        SupName = p.sup.SupName
                    }).ToList();
                return productsSuppliers;
            }
        }

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
    }
}
