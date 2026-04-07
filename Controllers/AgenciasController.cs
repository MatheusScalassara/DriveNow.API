using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DriveNow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgenciasController : ControllerBase
    {
        private readonly Services.ViaCepService _viaCepService;
        private readonly Data.AppDbContext _context;

        public AgenciasController(Services.ViaCepService viaCepService, Data.AppDbContext context)
        {
            _viaCepService = viaCepService;
            _context = context;
        }

        [HttpGet("{cep}")]
        public IActionResult Index()
        {
            var agencias = _context.Agencias.ToList();
            return Ok(agencias);
        }

        [HttpPost("{cep}")]
        public async Task<IActionResult> Create(string cep)
        {
            var endereco = await _viaCepService.BuscarEnderecoAsync(cep);
            if (endereco == null)
            {
                return NotFound("CEP não encontrado.");
            }
            var agencia = new Models.Agencia
            {
                Cep = cep,
                Logradouro = endereco.logradouro,
                Bairro = endereco.bairro,
                Localidade = endereco.localidade,
                Uf = endereco.uf
            };
            _context.Agencias.Add(agencia);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Index), new { id = agencia.Id }, agencia);
        }
    }
}
