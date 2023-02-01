using AutoMapper;
using CadastroCliente.Data;
using CadastroCliente.DTO;
using CadastroCliente.Entites;
using CadastroCliente.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CadastroCliente.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly ICliente? _cliente;
        private readonly IMapper? _mapper;

        public ClienteController(ICliente? cliente, IMapper? mapper)
        {
            _cliente = cliente;
            _mapper = mapper; 
        }

        [HttpPost]
        public async Task<IActionResult> CadastraCliente(Cliente cliente)
        {
            _cliente?.IncluirCliente(cliente);

            if (await _cliente.Salvar())
                return Ok("cliente salvo com sucesso.");
            
            return BadRequest("ocorreu um erro ao salvar o cadastro.");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> ListarTodosClientes()
        {
            var listaCliente = await _cliente.SelecionarTodosClientes();

            if (listaCliente == null)
                return NotFound("lista de cliente não encontrada");

            var ClienteDTO = _mapper.Map<List<ClienteDTO>>(listaCliente);

            return Ok(ClienteDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> BuscarClienteId(int id)
        {
            var selecionarClienteId = await _cliente.SelecionarClienteId(id);

            if (selecionarClienteId == null)
                return NotFound("cliente não encontrado.");

            var clienteDTO = _mapper.Map<ClienteDTO>(selecionarClienteId);

            return Ok(clienteDTO);
        }

        [HttpPut]
        public async Task<ActionResult> AlterarCadastroCliente(Cliente cliente)
        {
             _cliente.AlterarCliente(cliente);

            if (await _cliente.Salvar())
                return Ok("cadastro de cliente alterado com sucesso.");

            return BadRequest("Erro ao salvar.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> ApagarCadastroCliente(int id)
        {
            var cliente = await _cliente.SelecionarClienteId(id);
            
            if(cliente == null)
                return NotFound("cliente não encontrado.");

            _cliente.ExcluirCliente(cliente);

            if (await _cliente.Salvar())
                return Ok("cadastro do cliente apagado com sucesso.");


            return BadRequest("ocorreu um erro ao apagar o cadastro do cliente.");
        }
    }
}
