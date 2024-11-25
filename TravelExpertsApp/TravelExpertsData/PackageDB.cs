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

        public static List<Package> GetPackage()
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                return db.Packages
                    .OrderBy(p => p.PkgName).ToList();
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
    }
}
