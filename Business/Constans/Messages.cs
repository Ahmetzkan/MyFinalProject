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
        public static string MaintenanceTime = "System is under maintenance";
        
        //Product
        public static string ProductAdded = "Product Added";
        public static string ProductUpdated = "Product Updated";
        public static string ProductDeleted = "Product Deleted";
        public static string ProductNameInvalid = "Product name is invalid";
        public static string ProductsListed = "Products listed";
        public static string ProductCountOfCategoryError = "Products limit reached";
        
        //UnitPrice
        public static string UnitPriceInvalid = "UnitPrice name is invalid";
        public static string UnitPriceListed = "UnitPrice listed";

        //Category
        public static string CategoryLimitExceded = "Category Limit is exceded";

    }
}
