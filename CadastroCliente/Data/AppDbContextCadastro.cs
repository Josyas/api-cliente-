using CadastroCliente.Entites;
using Microsoft.EntityFrameworkCore;

namespace CadastroCliente.Data
{
    public class AppDbContextCadastro : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
          => options.UseSqlServer(@"");
    }
}
