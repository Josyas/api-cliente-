namespace CadastroCliente.Entites
{
    public class Endereco
    {
        public int Id { get; set; }
        public string? Cep { get; set; }
        public string? Logradouro { get; set;}
        public string? Cidade { get; set; }
        public string? NumeroCasa { get; set; }
        public string? Complemento { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente? Cliente { get; set; }
    }
}
