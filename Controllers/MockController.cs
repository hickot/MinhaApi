using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;

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

        private Object ObterMockString()
        {
            var utils = new Utils();
            var jsonString = "{douglas}";

            var json = utils.GetFormatJson(jsonString);
            return json;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            string fileName = "mock.json";
            var json = await _utils.GetJson(fileName);

            if (json == null)
                return NotFound("Arquivo JSON não encontrado.");

            return Content(json, "application/json");
        }

        // [HttpGet("json")]
        // public IActionResult Get(){
        //     return Ok(ObterMock());
        // }

        // [HttpPost]
        // public IActionResult Post([FromBody] MockPost json)
        // {
        //     if (json == null)
        //     {
        //         return BadRequest("O JSON enviado é inválido ou está vazio.");
        //     }
        //     else
        //     {
        //         _logger.LogInformation("Body: " + json);
        //     }

        //     // Aqui você pode manipular o objeto recebido
        //     // exemplo: salvar no banco, validar, etc.

        //     return Ok(new
        //     {
        //         json.Nome,
        //         json.Idade,
        //         json.Email
        //     });
        // }

        [HttpPost]
        public IActionResult Post([FromBody] dynamic body)
        {

            try
            {
                string json = body.GetRawText(); // <- Pega o JSON original!
                _logger.LogInformation("Body recebido: " + json);

                //string est = body.GetProperty("Estado").NotFound();
                if (!json.Contains("Estado"))
                {
                    _logger.LogInformation("Aqui não existe Estado: ");

                    return BadRequest(new
                    {
                       message = "O campo (estado) deverá ser iniciado com a letra maiúscula, ficando assim: (Estado)" 
                    });
                }

                string estado = body.GetProperty("Estado").GetString();

                switch (estado)
                {
                    case "WELCOME":
                        return Ok(new
                        {
                            comando = estado
                        });

                    case "MENU_IDENTIFICACAO":
                        return Ok(new
                        {
                            comando = estado
                        });

                    default:
                        return Ok(new
                        {
                            comando = "NO_ESTADO"
                        });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error aqui: " + ex);
                return StatusCode(500, new 
                { 
                    erro = ex.ToString() 
                });
            }
        }
    }
}