using DriveNow.API.Models;

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
    }
}