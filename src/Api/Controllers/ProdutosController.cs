using Microsoft.AspNetCore.Mvc;

namespace capgemini_test.src.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {

        [HttpGet]
        public string valor() {
            return "teste";
        }
    }
}