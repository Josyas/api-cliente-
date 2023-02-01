using CadastroCliente.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroCliente.Mappings
{
    public class ClienteMap
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("VARCHAR")
                .HasMaxLength(250);

            builder.Property(x => x.DataCadastro)
                .HasColumnType("VARCHAR")
                .HasMaxLength(30);
        }
    }
}
