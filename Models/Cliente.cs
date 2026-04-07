using System.ComponentModel.DataAnnotations;

namespace DriveNow.API.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required, StringLength(11, MinimumLength = 11, ErrorMessage = "CPF deve conter exatamente 11 dígitos.")]
        public string Cpf { get; set; }
    }
}
