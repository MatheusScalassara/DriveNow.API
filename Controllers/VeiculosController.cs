using DriveNow.Api.Models;
using DriveNow.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace DriveNow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VeiculoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post(Veiculo veiculo)
        {
            _context.Veiculos.Add(veiculo);
            _context.SaveChanges();

            return Ok(veiculo);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Veiculos.ToList());
        }
    }
}