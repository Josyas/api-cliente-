using CadastroCliente.Data;
using CadastroCliente.Entites;
using CadastroCliente.Interface;
using Microsoft.EntityFrameworkCore;

namespace CadastroCliente.Repository
{
    public class EnderecoRepositorio : IEndereco
    {
        private readonly AppDbContextCadastro _appDbContextCadastro;

        public EnderecoRepositorio(AppDbContextCadastro appDbContextCadastro)
        {
            _appDbContextCadastro = appDbContextCadastro;
        }

        public void AlterarEndereco(Endereco endereco)
        {
            _appDbContextCadastro.Entry(endereco).State = EntityState.Modified;
        }

        public void ExcluirEndereco(Endereco endereco)
        {
            _appDbContextCadastro.Remove(endereco);
        }

        public void IncluirEndereco(Endereco endereco)
        {
            _appDbContextCadastro.Add(endereco);
        }

        public async Task<bool> Salvar()
        {
            return await _appDbContextCadastro.SaveChangesAsync() > 0;
        }

        public async Task<Endereco> SelecionarEnderecoId(int id)
        {
            return await _appDbContextCadastro.Enderecos.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Endereco>> SelecionarTodosEnderecos()
        {
            return await _appDbContextCadastro.Enderecos.ToListAsync();
        }
    }
}
