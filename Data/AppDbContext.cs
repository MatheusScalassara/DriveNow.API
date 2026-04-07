using Microsoft.EntityFrameworkCore;
using DriveNow.API.Models;
using DriveNow.Api.Models;

namespace DriveNow.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Agencia> Agencias { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Locacao> Locacaos { get; set; }
    }
}
