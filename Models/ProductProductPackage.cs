using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldServiceOrganization.Models
{
    public class ProductProductPackage
    {

        public tblProductPackage ProductPackage { get; set; }
        public tblProductPackageProduct ProductPackageProduct { get; set; }
        public tblProduct Product { get; set; }
    }
}