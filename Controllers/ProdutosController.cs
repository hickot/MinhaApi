using Microsoft.AspNetCore.Mvc;

namespace MinhaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {

        private readonly ILogger<ProdutosController> _logger;

        private static readonly List<string> Produtos = new() { "Teclado", "Mouse", "Monitor" };

        public ProdutosController(ILogger<ProdutosController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get() => Ok(Produtos);

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id < 0 || id >= Produtos.Count)
                return NotFound();

            return Ok(Produtos[id]);
        }

        [HttpPost]
        public IActionResult Post([FromBody] string nome)
        {
            _logger.LogInformation("FromBody: " + nome);
            Produtos.Add(nome);
            return CreatedAtAction(nameof(Get), new { id = Produtos.Count - 1 }, nome);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= Produtos.Count)
                return NotFound();

            Produtos.RemoveAt(id);
            return NoContent();
        }
    }
}
