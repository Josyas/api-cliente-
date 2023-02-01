using CadastroCliente.Data;
using CadastroCliente.Entites;
using CadastroCliente.Interface;
using Microsoft.EntityFrameworkCore;

namespace CadastroCliente.Repository
{
    public class ClienteRepositorio : ICliente
    {
        private readonly AppDbContextCadastro _appDbContextCadastro;

        public ClienteRepositorio(AppDbContextCadastro appDbContextCadastro)
        {
            _appDbContextCadastro = appDbContextCadastro;
        }

        public void AlterarCliente(Cliente cliente)
        {
            _appDbContextCadastro.Entry(cliente).State = EntityState.Modified;
        }

        public void ExcluirCliente(Cliente cliente)
        {
            _appDbContextCadastro.Remove(cliente);
        }

        public void IncluirCliente(Cliente cliente)
        {
            _appDbContextCadastro.Add(cliente);
        }
        
        public async Task<bool> Salvar()
        {
            return await _appDbContextCadastro.SaveChangesAsync() > 0;
        }

        public async Task<Cliente> SelecionarClienteId(int id)
        {
            return await _appDbContextCadastro.Clientes.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Cliente>> SelecionarTodosClientes()
        {
            return await _appDbContextCadastro.Clientes.ToListAsync();
        }
    }
}
