using ApiCreateUserAndAssignPermissionsNotRole.Models;
using System.Threading.Tasks;
using ApiCreateUserAndAssignPermissionsNotRole.Models;
using PermissionBasedAuthorizationIntDotNet5.Models;

namespace ApiCreateUserAndAssignPermissionsNotRole.Services
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> GetTokenAsync(TokenRequestModel model);

        Task<string> AddPermissionAsync(Permission model);

        Task<string> AddPermissionAsync2(SetPermissions model);


    }
}
