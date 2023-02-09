using ApiCreateUserAndAssignPermissionsNotRole.Models;
using ApiCreateUserAndAssignPermissionsNotRole.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCreateUserAndAssignPermissionsNotRole.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController2 : ControllerBase
    {
        private readonly IAuthService _authService;


        public AuthenticationController2(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.RegisterAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost("token")]
        public async Task<IActionResult> GetTokenAsync([FromBody] TokenRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.GetTokenAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }
        [HttpPost("SetPermissionnn")]
        public async Task<IActionResult> SetPermissionn([FromBody] Permission model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _authService.AddPermissionAsync(model);
            return Ok(res);

        }

        [HttpPost("SetPermissionnn2")]
        public async Task<IActionResult> SetPermissionn2(string UserId)
        {
            if (UserId == null)
                return BadRequest();

            var res = await _authService.AddPermissionAsync2(UserId);
            return Ok(res);

        }
    }
}
    
