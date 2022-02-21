using Microsoft.AspNetCore.Mvc;
using Webmotors.Domain.Entities;

namespace Webmotors.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfosController : ControllerBase
    {
        public InfosController() { }

        [HttpGet]
        public JsonResult Get()
        {
            Info info = new Info()
            {
                Company = "Webmotors",
                Type = "API",
                Version = "v1.0"
            };

            return new JsonResult(info);
        }
    }
}
