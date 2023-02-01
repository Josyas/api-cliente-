using AutoMapper;
using CadastroCliente.DTO;
using CadastroCliente.Entites;
using CadastroCliente.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CadastroCliente.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContatoController : Controller
    {
        private readonly IContato _contato;
        private readonly IMapper _mapper;

        public ContatoController(IContato contato, IMapper mapper)
        {
            _contato = contato;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarContato(Contato contato)
        {
            _contato?.IncluirContato(contato);

            if (await _contato?.Salvar())
                return Ok("contato salvo com sucesso.");

            return BadRequest("ocorreu um erro ao salvar o contato.");
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Contato>>> BuscarTodosContatos()
        {
            var contatoSelecionado = await _contato.SelecionarTodosContatos();

            if (contatoSelecionado == null)
                return NotFound("lista de contato não encontrado.");

            var contatoDTO = _mapper.Map<List<ContatoDTO>>(contatoSelecionado);

            return Ok(contatoDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> BuscarContatoId(int id)
        {
            var contatoId = await _contato.SelecionarContatoId(id);

            if (contatoId == null)
                return NotFound("contato não encontrado.");

            var contatoDTO = _mapper.Map<ContatoDTO>(contatoId);

            return Ok(contatoDTO);
        }

        [HttpPut]
        public async Task<ActionResult> AlterarCadastroContato(Contato contato)
        {
            _contato.AlterarContato(contato);

            if (await _contato.Salvar())
                return Ok("contato alterado com sucesso.");

            return BadRequest("erro ao salvar o contato.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> ApagarContatoCliente(int id)
        {
            var excluiContato = await _contato.SelecionarContatoId(id);

            if (excluiContato == null)
                return NotFound("contato não encontrado.");

            _contato.ExcluirContato(excluiContato);

            if (await _contato.Salvar())
                return Ok("contato apagado com sucesso.");

            return BadRequest("ocorreu um erro ao apagar o contato.");
        }
    }

}
