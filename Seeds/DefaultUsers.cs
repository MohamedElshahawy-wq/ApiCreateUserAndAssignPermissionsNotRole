using Microsoft.AspNetCore.Identity;
using PermissionBasedAuthorizationIntDotNet5.Contants;
//using ApiCreateUserAndAssignPermissionsNotRole.Constant;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ApiCreateUserAndAssignPermissionsNotRole.Seeds
{
    public static class DefaultUsers
    {
        //create user Basic
        public static async Task SeedBasicUserAsync(UserManager<IdentityUser> userManager)
        {
            var defaultUser = new IdentityUser
            {
                UserName = "basicuser@domain.com",
                Email = "basicuser@domain.com",
                EmailConfirmed = true
            };

            var user = await userManager.FindByEmailAsync(defaultUser.Email);

            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "P@ssword123");
                // await userManager.AddToRolesAsync()
                await userManager.AddClaimAsync(defaultUser, new Claim("Permissions",Permissions.Products.View));
            }
        } 
        //create user Super Admin
        public static async Task SeedSuperAdminUserAsync(UserManager<IdentityUser> userManager)
        {
            var defaultUser = new IdentityUser
            {
                UserName = "superadmin@domain.com",
                Email = "superadmin@domain.com",
                EmailConfirmed = true
            };

            var user = await userManager.FindByEmailAsync(defaultUser.Email);

            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "P@ssword123");
                // await userManager.AddToRolesAsync(defaultUser, new List<string> { Roles.Basic.ToString(), Roles.Admin.ToString(), Roles.SuperAdmin.ToString() });
                await userManager.AddClaimAsync(defaultUser, new Claim("Permissions", Permissions.Products.Create));

            }

            // await roleManger.SeedClaimsForSuperUser();
        }





        //#######################
        //private static async Task SeedClaimsForSuperUser(this RoleManager<IdentityRole> roleManager)
        //{
        //    var adminRole = await roleManager.FindByNameAsync(Roles.SuperAdmin.ToString());
        //    //after catch role add permissions
        //    await roleManager.AddPermissionClaims(adminRole, "PrSeedBasicUserAsyncoducts");
        //}





        //genere list permission(crud for any module) which assign to role super admin
        //public static async Task AddPermissionClaims(this RoleManager<IdentityRole> roleManager, IdentityRole role, string module)
          public static async Task AddPermissionClaims(this UserManager<IdentityUser> _userManger  ,string userName   ,string Permissions)
             
          {
            //var allClaims = await roleManager.GetClaimsAsync(role);

            var user = await _userManger.FindByNameAsync(userName);
            await _userManger.AddClaimAsync(user, new Claim("Permissions", Permissions));
            //Permissions.GeneratePermissionsList() Func =>  in folder constant/permission 
           
            
            //var allPermissions = Permissions.GeneratePermissionsList(module);

            //foreach (var permission in allPermissions)
            //{
            //    if (!allClaims.Any(c => c.Type == "Permission" && c.Value == permission))
            //        await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
            //}


        }
    }
}