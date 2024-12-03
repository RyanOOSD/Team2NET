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

        public static List<Package> GetPackageCombobox()
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                return db.Packages
                    .OrderBy(p => p.PkgName).ToList();
            }
        }

        public static Package? FindPackage(int packageID)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                return db.Packages.Find(packageID);
            }
        }

        public static void AddPackage(Package package)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                if (package != null)
                {
                    db.Packages.Add(package);
                    db.SaveChanges();
                }
            }
        }

        public static void ModifyPackage(Package selectedPackage)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                Package? packageToModify = db.Packages.Find(selectedPackage.PackageId);
                if (packageToModify != null)
                {
                    packageToModify.PkgName = selectedPackage.PkgName;
                    packageToModify.PkgStartDate = selectedPackage.PkgStartDate;
                    packageToModify.PkgEndDate = selectedPackage.PkgEndDate;
                    packageToModify.PkgDesc = selectedPackage.PkgDesc;
                    packageToModify.PkgBasePrice = selectedPackage.PkgBasePrice;
                    packageToModify.PkgAgencyCommission = selectedPackage.PkgAgencyCommission;
                }
                db.SaveChanges();
            }
        }

        public static void DeletePackage(Package selectedPackage)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                Package? packageToDelete = db.Packages.Find(selectedPackage.PackageId);
                if (packageToDelete != null)
                {
                    db.Packages.Remove(packageToDelete);
                    db.SaveChanges();
                }
            }
        }
    }
}
