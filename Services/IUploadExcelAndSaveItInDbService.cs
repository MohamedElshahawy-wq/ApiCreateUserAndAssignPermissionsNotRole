using ApiCreateUserAndAssignPermissionsNotRole.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiCreateUserAndAssignPermissionsNotRole.Services
{
    public interface IUploadExcelAndSaveItInDbService
    {
        Task<StudentData> UploadExcelAndSaveItInDb(IFormFile file);
    }
}
