using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiCreateUserAndAssignPermissionsNotRole.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
      
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
