using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public class PackageDTO
    {
        public int PkgID { get; set; }

        public string PkgName { get; set; }

        public DateTime? PkgStart { get; set; }

        public DateTime? PkgEnd { get; set; }

        public string? PkgDesc { get; set; }

        public decimal PkgPrice { get; set; }

        public decimal? PkgCommission { get; set; }
    }
}
