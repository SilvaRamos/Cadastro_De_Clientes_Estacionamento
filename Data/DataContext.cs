using Cadastro_De_Clientes_Estacionamento.Models;
using Microsoft.EntityFrameworkCore;

namespace Locadora_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
    }
}
