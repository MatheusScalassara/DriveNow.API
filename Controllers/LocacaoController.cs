using DriveNow.Api.Models;
using DriveNow.API.Data;
using DriveNow.API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DriveNow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LocacaoController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Post(CreateLocacaoRequest request)
        {
            // VEÍCULO OCUPADO?
            var conflito = _context.Locacaos.Any(l =>
                l.VeiculoId == request.VeiculoId &&
                DateTime.Now >= l.DataRetirada &&
                DateTime.Now <= l.DataDevolucao
            );

            if (conflito)
                return BadRequest("Veículo indisponível");

            var veiculo = _context.Veiculos.Find(request.VeiculoId);

            if (veiculo == null)
                return NotFound("Veículo não encontrado");

            var dias = (request.DataDevolucao - request.DataRetirada).Days;

            var valorTotal = dias * veiculo.ValorDiaria;

            var locacao = new Locacao
            {
                ClienteId = request.ClienteId,
                VeiculoId = request.VeiculoId,
                DataRetirada = request.DataRetirada,
                DataDevolucao = request.DataDevolucao,
                ValorTotal = valorTotal
            };

            _context.Locacaos.Add(locacao);
            _context.SaveChanges();

            return Ok(locacao);
        }
    }
}