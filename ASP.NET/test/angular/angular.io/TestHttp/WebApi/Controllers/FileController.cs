using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> OnPostUploadAsync(List<IFormFile> files)
        {
            var size = files.Sum(f => f.Length);

            foreach (var formFile in files.Where(formFile => formFile.Length > 0))
            {
                await using var stream = new MemoryStream();
                await formFile.CopyToAsync(stream);
                stream.Position = 0;
                using var streamReader = new StreamReader(stream);
                var content = await streamReader.ReadToEndAsync();
            }

            return Ok(new { count = files.Count, size });
        }
    }
}
