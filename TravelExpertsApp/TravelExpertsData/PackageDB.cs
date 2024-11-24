using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public class PackageDB
    {
        public static List<PackageDTO> GetPackageList()
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                List<PackageDTO> packages = db.Packages
                    .Select(p => new PackageDTO
                        {
                            PkgID = p.PackageId,
                            PkgName = p.PkgName,
                            PkgStart = p.PkgStartDate,
                            PkgEnd = p.PkgEndDate,
                            PkgDesc = p.PkgDesc,
                            PkgPrice = p.PkgBasePrice,
                            PkgCommission = p.PkgAgencyCommission
                        }).ToList();
                return packages;
            }
        }

        public static List<PackageProductsDTO> GetPackageProductsList()
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                List<PackageProductsDTO> packageProducts = db.PackagesProductsSuppliers
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
                        (prodSupB, prod) => new { prodSupB, prod})
                    .Join(
                        db.Suppliers,
                        prodSupC => prodSupC.prodSupB.prodSupA.SupplierId,
                        sup => sup.SupplierId,
                        (prodSupC, sup) => new { prodSupC, sup })
                    .Select(p => new PackageProductsDTO
                    {
                        PkgProductSupID = p.prodSupC.prodSupB.pkgProdB.pkgProdA.PackageProductSupplierId,
                        PkgName = p.prodSupC.prodSupB.pkgProdB.pkg.PkgName,
                        ProductName = p.prodSupC.prod.ProdName,
                        SupName = p.sup.SupName
                    }).ToList();
                return packageProducts;
            }
        }
    }
}
