namespace CadastroCliente.Entites
{
    public class Cliente
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? DataCadastro { get; set; }
        public Contato? Contato { get; set; }
        public Endereco? Endereco { get; set; }
    }
}
