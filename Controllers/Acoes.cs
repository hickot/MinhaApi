using Microsoft.AspNetCore.Mvc;

namespace MinhaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcoesController : ControllerBase
    {
        private readonly Utils _utils = new Utils();
        private readonly ILogger<AcoesController> _logger;

        public AcoesController(ILogger<AcoesController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] dynamic body)
        {
             string json = body.GetRawText(); // <- Pega o JSON original!
            _logger.LogInformation("Body recebido: " + json);

            string fileName = "acoes.json";
            var jsonMock = await _utils.GetJson(fileName);

            if (jsonMock == null)
                return NotFound("Arquivo JSON não encontrado.");

            return Content(jsonMock, "application/json");
        }
    }
}