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
        /// <summary>
        /// Creates a list of PackageDTO objects to be displayed in the DataGridView
        /// with selected columns from the Packages table
        /// </summary>
        /// <returns>List of packages as PackageDTO objects</returns>
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

        /// <summary>
        /// Gets a list of packages from the database, sorted by name
        /// </summary>
        /// <returns>List of packages</returns>
        public static List<Package> GetPackageCombobox()
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                return db.Packages
                    .OrderBy(p => p.PkgName).ToList();
            }
        }

        /// <summary>
        /// Finds a package by PackageID in the database, the PK of the table and returns it as an object
        /// </summary>
        /// <param name="packageID">PackageID to search with</param>
        /// <returns>Package object with matching PackageID</returns>
        public static Package FindPackage(int packageID)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                return db.Packages.Find(packageID)!;
            }
        }

        /// <summary>
        /// Adds the passed-in package to the database
        /// </summary>
        /// <param name="package">New package to add</param>
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

        /// <summary>
        /// Finds a matching package by PackageID in the database
        /// and updates the record with the attribute values of the passed-in package object
        /// </summary>
        /// <param name="selectedPackage">Package with updated values</param>
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

        /// <summary>
        /// Finds a matching package by PackageID in the database and deletes it from the database
        /// </summary>
        /// <param name="selectedPackage">Package to delete</param>
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
