using ApiCreateUserAndAssignPermissionsNotRole.Models;
using ExcelDataReader;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using PdfSharp.Pdf;
using System.Data;
using System.Text;

namespace ApiCreateUserAndAssignPermissionsNotRole.Services
{
    public class UploadExcelAndSaveItInDbService : IUploadExcelAndSaveItInDbService
    {
        IConfiguration configuration;
        IWebHostEnvironment hostEnvironment;
        ApplicationDbContext _context;
        IExcelDataReader reader;
        public UploadExcelAndSaveItInDbService(ApplicationDbContext context,IConfiguration configuration, IWebHostEnvironment hostEnvironment)
        {

            this.configuration = configuration;
            this.hostEnvironment = hostEnvironment;
            this._context = context;
        }

        //public async Task<IActionResult> UploadExcelAndSaveItInDb()
        //  {

        //  }



        async Task<StudentData> IUploadExcelAndSaveItInDbService.UploadExcelAndSaveItInDb(IFormFile file)
        {
            ////Create the Directory(folder) if it is not exist *****************************************************************************
            //string dirPath = Path.Combine(path1: hostEnvironment.WebRootPath, path2:"ReceivedExcel");


            ////if (!Directory.Exists(dirPath))
            //if (!Directory.Exists(dirPath))

            //{
            //    Directory.CreateDirectory(dirPath);
            //}

            ////MAke sure that only Excel file is used
            //string dataFileName = Path.GetFileName(file.FileName);

            //string extension = Path.GetExtension(dataFileName);


            // Make a Copy of the Posted File from the Received HTTP Request
            // string saveToPath = Path.Combine(dirPath, dataFileName);//name + folder inside it

            List<string> NameList = new List<string> { };
            List<string> NIdList = new List<string> { };

            DataTable serviceDetails;

            var ExcelFileName = "C:\\Users\\m.elshehawy\\source\\repos\\ApiCreateUserAndAssignPermissionsNotRole\\wwwroot\\StudentData.xlsx";
            string extension = Path.GetExtension(ExcelFileName);
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            //to read content of the file
            //****************************************************************************************************
            FileStream stream = new FileStream(ExcelFileName, FileMode.Open);
            if (extension == ".xls")

                reader = ExcelReaderFactory.CreateBinaryReader(stream);
            else
                reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            //****************************************************************************************************
            DataSet ds = new DataSet();
            ds = reader.AsDataSet();
            reader.Close();

            string contents = string.Empty;

            using (var ms = new MemoryStream())
            {
                file.OpenReadStream();

                contents = new StreamReader(ms).ReadToEnd();
            }

            if (ds != null && ds.Tables.Count > 0)
            {
                // Read the the Table
                 serviceDetails = ds.Tables[0];
                for (int i = 1; i < serviceDetails.Rows.Count; i++)
                {
                    StudentData details = new StudentData();
                    details.Name = (string)serviceDetails.Rows[i][0];
                    details.NatioanlId = serviceDetails.Rows[i][1].ToString();

                    NameList.Add(details.Name);
                    NIdList.Add(details.NatioanlId);


                    // Add the record in Database
                    var result = _context.StudentsData.AddAsync(details);
                    _context.SaveChangesAsync();
                }

            }

            var document = new PdfDocument();
            PdfPage page = document.AddPage();

            document.AddPage();

            StringBuilder Sb = new StringBuilder();


            string htmlcontent=string.Empty;
            htmlcontent += "<table style ='width:100%; border: 1px solid #000'>";
            htmlcontent += "<thead style='font-weight:bold'>";
            htmlcontent += "<tr>";
            htmlcontent += "<td style='border:1px solid #000'> Name </td>";
            htmlcontent += "<td style='border:1px solid #000'> NationalId </td>";
            htmlcontent += "</tr>";
            htmlcontent += "</thead >";
            htmlcontent += "<tbody>";

            //NameList.ForEach(item =>
            //{
            //    htmlcontent += "<tr>";
            //    htmlcontent += "<td>" + + "</td>";
            //    htmlcontent += "<td>" + item.ProductName + "</td>";
            //    htmlcontent += "<td>" + item.Qty + "</td >";
            //    htmlcontent += "<td>" + item.SalesPrice + "</td>";
            //    htmlcontent += "<td> " + item.Total + "</td >";
            //    htmlcontent += "</tr>";
            //});


            htmlcontent += "</tbody>";

            htmlcontent += "</table>";
            htmlcontent += "</div>";


            document.Save("D:\\rrr.html");

            return new StudentData
            {
                Name = "saved",
                NatioanlId = "saved"
            };


        }
    }
}
