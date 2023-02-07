using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCreateUserAndAssignPermissionsNotRole.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [Route("Books")]
        [HttpGet]
        public List<string> GetList()
        {
            string[] Books = { "Math", "English", "Arabic" };
            return Books.ToList();
        }

    }
}
