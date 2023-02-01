using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CadastroCliente.Entites;

namespace CadastroCliente.Mappings
{
    public class EnderecoMap
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Cep)
                .HasColumnType("VARCHAR")
                .HasMaxLength(15);

            builder.Property(x => x.Logradouro)
                .HasColumnType("VARCHAR")
                .HasMaxLength(250);

            builder.Property(x => x.Cidade)
                .HasColumnType("VARCHAR")
                .HasMaxLength(150);

            builder.Property(x => x.NumeroCasa)
                .HasColumnType("VARCHAR")
                .HasMaxLength(10);

            builder.Property(x => x.Complemento)
                .HasColumnType("VARCHAR")
                .HasMaxLength(250);

            builder.HasOne(x => x.Cliente)
                .WithOne(x => x.Endereco)
                .HasConstraintName("FK_Endereco_IdCliente")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
