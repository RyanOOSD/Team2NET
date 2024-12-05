using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public class PackagesProductsSupplierDTO
    {
        public int? PkgProductSupID { get; set; }

        public string? PkgName { get; set; }

        public int? ProductSupId { get; set; }

        public string ProductName { get; set; }

        public string SupName { get; set; }
    }
}
