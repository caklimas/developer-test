using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Infrastructure
{
    public static class RoleConstants
    {
        public const string Buyer = "Buyer";
        public const string Seller = "Seller";

        public static string[] Roles = new[]
        {
            Buyer,
            Seller
        };
    }
}