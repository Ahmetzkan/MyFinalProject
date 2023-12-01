using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constans
{
    //Newlenmemesi için static ekledik.
    //Publicler PascalCase şeklinde yazılır.
    public static class Messages
    {
        public static string ProductAdded = "Product Added";
        public static string ProductNameInvalid = "Product name is invalid";
        public static string MaintenanceTime = "System is under maintenance";
        public static string ProductsListed = "Products listed";

        public static string UnitPriceInvalid = "UnitPrice name is invalid";
        public static string UnitPriceListed = "UnitPrice listed";

    }
}
