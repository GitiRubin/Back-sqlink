using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using Common;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Service.Interface;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelFileController : ControllerBase
        
    {
        private readonly IPersonService personService;

        public ExcelFileController(IPersonService personService)
        {
            this.personService = personService;
        }
    // GET: api/<ExcelFile>
    [HttpGet]
    public string Get()
    {

        return "";
    }

    // GET api/<ExcelFile>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<ExcelFile>
    [HttpPost]
    public async Task<ListsOfPeople> Post(IFormFile formFile, CancellationToken cancellationToken)
    {
        //var forms = await Request.ReadFormAsync();

        ExcelPackage.LicenseContext = LicenseContext.Commercial;
        
        using (var stream = new MemoryStream())
        {
            await formFile.CopyToAsync(stream, cancellationToken);
            using (var package = new ExcelPackage(stream))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension.Rows;

                for (int i = 2; i < rowCount; i++)
                {
                        personService.Add(new PersonDTO
                        {
                            FirstName = worksheet.Cells[i, 1].Value.ToString().Trim(),
                            LastName = worksheet.Cells[i, 2].Value.ToString().Trim(),
                            Id = int.Parse(worksheet.Cells[i, 3].Value.ToString().Trim()),
                            Age = int.Parse(worksheet.Cells[i, 4].Value.ToString().Trim())
                        });
                }
            }
        }
        
         return   personService.GetLists();

    }

    // PUT api/<ExcelFile>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<ExcelFile>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
}
