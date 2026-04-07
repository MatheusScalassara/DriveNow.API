namespace DriveNow.API.DTOs
{
    public class CreateLocacaoRequest
    {
        public int ClienteId { get; set; }
        public int VeiculoId { get; set; }
        public DateTime DataRetirada { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}
