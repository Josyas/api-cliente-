using CadastroCliente.Entites;

namespace CadastroCliente.Interface
{
    public interface IContato
    {
        void IncluirContato(Contato contato);
        void AlterarContato(Contato contato);
        void ExcluirContato(Contato contato);
        Task<Contato> SelecionarContatoId(int id);
        Task<IEnumerable<Contato>> SelecionarTodosContatos();
        Task<bool> Salvar();
    }
}
