using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using System.Collections.Generic;

namespace PermissionBasedAuthorizationIntDotNet5.Models
{
    public class SetPermissions
    {
        public string UserId { get; set; }
        public List<string> Calims { get; set; }
    }
}
