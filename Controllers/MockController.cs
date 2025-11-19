using Microsoft.AspNetCore.Mvc;

namespace MinhaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MockController : ControllerBase
    {
        private readonly ILogger<MockController> _logger;

        public MockController(ILogger<MockController> logger)
        {
            _logger = logger;
        }

        private object ObterMock()
        {

            _logger.LogInformation("Inicia Montagem da Mock...");
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
        public IActionResult Get() => Ok(ObterMock());
    }
}