using Microsoft.AspNetCore.Mvc;

namespace ApiCreateUserAndAssignPermissionsNotRole.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        
        [Route("Product")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
