using ApiCreateUserAndAssignPermissionsNotRole.Models;
using ApiCreateUserAndAssignPermissionsNotRole.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ApiCreateUserAndAssignPermissionsNotRole.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UplaodExcelAndSaveItInDbController : ControllerBase
    {
        private readonly IUploadExcelAndSaveItInDbService _IUploadExcel;


        public UplaodExcelAndSaveItInDbController(IUploadExcelAndSaveItInDbService IUploadExcel)
        {
            _IUploadExcel = IUploadExcel;
        }


        [HttpPost("UploadExcelll")]
        public async Task<IActionResult> UploadExcelAndSaveItInDb(IFormFile file)
        {
            //if (file == null)
              
            //return BadRequest();

          var result=  await _IUploadExcel.UploadExcelAndSaveItInDb(file);

            StringBuilder sb = new StringBuilder();
            sb.Append("<table border=1>");
            sb.Append("<tr>");
            
            return Ok(result);
           // return (IActionResult)file;
        }
    }
}
