using System;
using System.Collections;
using System.Collections.Generic;

namespace PermissionBasedAuthorizationIntDotNet5.Contants
{
    public static class Permissions
    {
        //take module and retrn all crud for this module
        public static List<string> GeneratePermissionsList(string module)
        {
            return new List<string>()
            {
                $"Permissions.{module}.View",
                $"Permissions.{module}.Create",
                $"Permissions.{module}.Edit",
                $"Permissions.{module}.Delete"
            };
        }

        public static List<string> GenerateAllPermissions()
        {
            var allPermissions = new List<string>();
            // modules is  =>   Products,  Stock,  Categories
            var modules = Enum.GetValues(typeof(Modules));

            foreach (var module in modules)
                allPermissions.AddRange(GeneratePermissionsList(module.ToString()));

            return allPermissions;
        }

        public static class Products
        {
            public const string View = "Permissions.Products.View";
            public const string Create = "Permissions.Products.Create";
            public const string Edit = "Permissions.Products.Edit";
            public const string Delete = "Permissions.Products.Delete";
        }
        public static class Stock
        {
            public const string View = "Permissions.Stock.View";
            public const string Create = "Permissions.Stock.Create";
            public const string Edit = "Permissions.Stock.Edit";
            public const string Delete = "Permissions.Stock.Delete";
        }
    }
}