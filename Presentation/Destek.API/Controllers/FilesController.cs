using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Destek.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController(IConfiguration configuration) : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult GetBaseStorageUrl()
        {
            return Ok(new
            {
                Url = configuration["BaseStorageUrl"]
            });
        }
    }
}
