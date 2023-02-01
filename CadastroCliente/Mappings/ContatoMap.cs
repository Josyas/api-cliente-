using CadastroCliente.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroCliente.Mappings
{
    public class ContatoMap
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.ToTable("Contato");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Tipo)
                .HasColumnType("VARCHAR")
                .HasMaxLength(150);

            builder.Property(x => x.Texto)
                .HasColumnType("VARCHAR")
                .HasMaxLength(150);

            builder.HasOne(x => x.Cliente)
                 .WithOne(x => x.Contato)
                 .HasConstraintName("FK_Contatos_ClienteId")
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
