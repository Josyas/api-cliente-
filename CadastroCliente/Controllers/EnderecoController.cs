using AutoMapper;
using CadastroCliente.DTO;
using CadastroCliente.Entites;
using CadastroCliente.Interface;
using Microsoft.AspNetCore.Mvc;
using ViaCep;

namespace CadastroCliente.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : Controller
    {
        private readonly IEndereco _endereco;
        private readonly IMapper _mapper;

        public EnderecoController(IEndereco endereco, IMapper mapper)
        {
            _endereco = endereco;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarEndereco(Endereco enderecoCliente)
        {
            _endereco.IncluirEndereco(enderecoCliente);

            var cepCliente = new ViaCepClient().Search(enderecoCliente.Cep);

            enderecoCliente.Cep = cepCliente.ZipCode;
            enderecoCliente.Logradouro = cepCliente.Street;
            enderecoCliente.Cidade = cepCliente.City;
            enderecoCliente.Complemento = cepCliente.Complement;
            enderecoCliente.ClienteId = enderecoCliente.ClienteId;
            enderecoCliente.NumeroCasa = enderecoCliente.NumeroCasa;

            if (await _endereco.Salvar())
                return Ok("endereço cadastrado com sucesso.");

            return BadRequest("erro ao salvar endereço.");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Endereco>>> BuscarTodosContatos()
        {
            var contatos = await _endereco.SelecionarTodosEnderecos();

            if (contatos == null)
                return BadRequest("endereço não encontrado.");

            var contatoDTO = _mapper.Map<List<EnderecoDTO>>(contatos);

            return Ok(contatoDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> BuscarEnderecoId(int id)
        {
            var enderecoId = await _endereco.SelecionarEnderecoId(id);

            if (enderecoId == null)
                return NotFound("endereço não encontrado.");

            var enderecoDTO = _mapper.Map<EnderecoDTO>(enderecoId);

            return Ok(enderecoDTO);
        }

        [HttpPut]
        public async Task<ActionResult> AlterarCadastroContato(Endereco endereco)
        {
            _endereco.AlterarEndereco(endereco);

            if (await _endereco.Salvar())
                return Ok("endereço alterado com sucesso.");

            return BadRequest("erro ao salvar o endereço.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> ApagarEndereco(int id)
        {
            var excluiEndereco = await _endereco.SelecionarEnderecoId(id);

            if(excluiEndereco != null)
               _endereco.ExcluirEndereco(excluiEndereco);

            if (await _endereco.Salvar())
                return Ok("endereço apagado com sucesso.");

            return BadRequest("erro ao exluir endereço.");
        }
    }
}
