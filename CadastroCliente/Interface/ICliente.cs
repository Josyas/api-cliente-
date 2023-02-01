using CadastroCliente.Entites;

namespace CadastroCliente.Interface
{
    public interface ICliente
    {
        void IncluirCliente(Cliente cliente);
        void AlterarCliente(Cliente cliente);
        Task<Cliente> SelecionarClienteId(int id);
        Task<IEnumerable<Cliente>> SelecionarTodosClientes();
        void ExcluirCliente(Cliente cliente);
        Task<bool> Salvar();
     }
}
