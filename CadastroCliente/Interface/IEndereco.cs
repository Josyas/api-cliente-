using CadastroCliente.Entites;

namespace CadastroCliente.Interface
{
    public interface IEndereco
    {
        void IncluirEndereco(Endereco endereco);
        void AlterarEndereco(Endereco endereco);
        void ExcluirEndereco(Endereco endereco);
        Task<Endereco> SelecionarEnderecoId(int id);
        Task<IEnumerable<Endereco>> SelecionarTodosEnderecos();
        Task<bool> Salvar();
    }
}
