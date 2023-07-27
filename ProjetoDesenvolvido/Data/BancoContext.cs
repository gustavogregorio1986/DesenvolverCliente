using Microsoft.EntityFrameworkCore;
using ProjetoDesenvolvido.Models;

namespace ProjetoDesenvolvido.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<ClienteModel> Clientes { get; set; }
    }
}
