using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [ApiController]
    [Route("/")]
    public class DefaultController : ControllerBase
    {
        [HttpGet]

        public string Index()
        {
            return "Microservicio Corriendo ...";
        }
    }
}
