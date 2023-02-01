using CadastroCliente.Data;
using CadastroCliente.Entites;
using CadastroCliente.Interface;
using Microsoft.EntityFrameworkCore;

namespace CadastroCliente.Repository
{
    public class ContatoRepositorio : IContato
    {
        private readonly AppDbContextCadastro _appDbContextCadastro;

        public ContatoRepositorio(AppDbContextCadastro appDbContextCadastro)
        {
            _appDbContextCadastro = appDbContextCadastro;
        }

        public void AlterarContato(Contato contato)
        {
            _appDbContextCadastro.Entry(contato).State = EntityState.Modified;
        }

        public void ExcluirContato(Contato contato)
        {
            _appDbContextCadastro.Remove(contato);
        }

        public void IncluirContato(Contato contato)
        {
            _appDbContextCadastro.Add(contato);
        }

        public async Task<bool> Salvar()
        {
            return await _appDbContextCadastro.SaveChangesAsync() > 0;
        }

        public async Task<Contato> SelecionarContatoId(int id)
        {
            return await _appDbContextCadastro.Contatos.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Contato>> SelecionarTodosContatos()
        {
           return await _appDbContextCadastro.Contatos.ToListAsync();
        }
    }
}
