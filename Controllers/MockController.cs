using Microsoft.AspNetCore.Mvc;

namespace MinhaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MockController : ControllerBase
    {
        private readonly Utils _utils = new Utils();
        private readonly ILogger<MockController> _logger;

        public MockController(ILogger<MockController> logger)
        {
            _logger = logger;
        }

        private object ObterMock()
        {

            _logger.LogInformation("Iniciou Montagem da Mock...");
            var mock = new
            {
                nome = "Douglas Alvares do Nascimento",
                idade = 34,
                dataNascimento = "07/02/1991",
                telefone = "+5521984263016",
                endereco = new
                {
                    cidade = "São Gonçalo",
                    estado = "Rio de Janeiro"
                }
            };

            return mock;
        }

        private Object ObterMockString ()
        {
            var utils = new Utils();
            var jsonString = "{douglas}";

            var json = utils.GetFormatJson(jsonString);
            return json;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var json = await _utils.GetJson();

            if (json == null)
            return NotFound("Arquivo JSON não encontrado.");

            return Content(json, "application/json");
        }
         
        // [HttpGet("json")]
        // public IActionResult Get(){
        //     return Ok(ObterMock());
        // }
    }
}