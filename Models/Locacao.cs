using System.ComponentModel.DataAnnotations.Schema;

namespace DriveNow.Api.Models
{
    public class Locacao
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }
        public int VeiculoId { get; set; }

        public DateTime DataRetirada { get; set; }
        public DateTime DataDevolucao { get; set; }
        [Column(TypeName = "decimal(18,2)")]

        public decimal ValorTotal { get; set; }
    }
}