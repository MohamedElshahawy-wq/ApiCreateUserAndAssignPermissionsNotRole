using ApiCreateUserAndAssignPermissionsNotRole.Models;
using ApiCreateUserAndAssignPermissionsNotRole.Seeds;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using PermissionBasedAuthorizationIntDotNet5.Contants;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiCreateUserAndAssignPermissionsNotRole.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        public AuthenticationController(UserManager<IdentityUser> userManager, IConfiguration configuration, ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
        }

        [Route("Books")]
        [HttpGet]
        public List<string> GetList()
        {
            string[] Books = { "Math", "English", "Arabic" };
            return Books.ToList();
        }

        [HttpPost]
        [Route("CreateUser")]
        //public async Task<IActionResult> CreateUser([FromBody] RegisterModel model, [FromBody] IEnumerable<Permissions> SeedPermissions)
        public async Task<IActionResult> CreateUser([FromBody] RegisterModel model)

        {
            //var emailExists = await _userManager.FindByEmailAsync(model.Email);
            var emailExists = await _userManager.FindByEmailAsync(model.Email);

            if (emailExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Email already exists!" });


            IdentityUser user = new()
            {
                Email = model.Email,
                UserName = model.UserName,
                //SecurityStamp = Guid.NewGuid().ToString(),

            };
            var result = await _userManager.CreateAsync(user, model.Password);
            //  await _userManager.AddClaimAsync(user, new Claim("Permissions", Permissions.Products.View));
            //  await _userManager.AddClaimsAsync(user, (IEnumerable<Claim>)SeedPermissions);



            return StatusCode(StatusCodes.Status200OK,
            new Response { Status = "Success", Message = "Login Succefully" });
        }



        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                // var userRole = await _userManager.GetRolesAsync(user);
                //var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),


                    // Jti => it is a standard claim meant to uniquely identify a token
                    // Jti => used to prevent replay attacks by preventing the same JWT from being replayed.
                };

                //foreach (var Role in userRole)
                //{
                //    authClaims.Add(new Claim(ClaimTypes.Role, Role));
                //}

                var token = GetToken(authClaims);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            // SymmetricSecurityKey => Represents the abstract base class for all keys that are generated using symmetric algorithms.

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }


        //assign permissins
        [HttpPost]
        [Route("AssignPermissions")]
        public async Task<string> AssignPermissions(Permission model)
        {
           var user = await _userManager.FindByIdAsync(model.UserId);
            if(user == null)
            {
                return "Invalid userId";
            }
            await _userManager.AddClaimAsync(user, new Claim("Permissionss", "ViewProduct"));

                return "succedd ..........";
        }
    }
}