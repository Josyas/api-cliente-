using CadastroCliente.Entites;

namespace CadastroCliente.DTO
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? DataCadastro { get; set; }
    }
}
