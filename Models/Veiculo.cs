using DriveNow.API.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace DriveNow.Api.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public decimal ValorDiaria { get; set; }
        public int AgenciaId { get; set; }
        public Agencia? Agencia { get; set; }
        public string? FotoUrl { get; set; }
        [NotMapped]
        public IFormFile FotoUpload { get; set; }
    }
}