using Entidades;
using McOliveiraAPI_.Repositorio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace McOliveiraAPI_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPagamentoController : ControllerBase
    {
        private readonly ITipoPagamentoRepositorio _tiposPagamentoRepositorio;

        public TipoPagamentoController(ITipoPagamentoRepositorio tiposPagamentoRepositorio)
        {
            _tiposPagamentoRepositorio = tiposPagamentoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoPagamento>>> GetAll()
        {
            List<TipoPagamento> tiposPagamento = await _tiposPagamentoRepositorio.GetAll();
            return Ok(tiposPagamento);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoPagamento>> GetById(int id)
        {
            TipoPagamento tipoPagamento = await _tiposPagamentoRepositorio.GetById(id);
            if (tipoPagamento == null)
            {
                return NotFound($"Tipo de Pagamento com Id = {id} não encontrado");
            }
            return Ok(tipoPagamento);
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<TipoPagamento>> Cadastrar([FromBody] TipoPagamento tipoPagamento)
        {
            tipoPagamento = await _tiposPagamentoRepositorio.Add(tipoPagamento);
            return Ok(tipoPagamento);
        }

        [HttpGet("delete/{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            bool deleted = await _tiposPagamentoRepositorio.Delete(id);
            if (!deleted)
            {
                return NotFound($"Tipo de Pagamento com Id = {id} não encontrado");
            }
            return Ok(deleted);
        }

        [HttpGet("inativar/{id}")]
        public async Task<ActionResult<bool>> Inativar(int id)
        {
            bool inativado = await _tiposPagamentoRepositorio.Inativar(id);
            if (!inativado)
            {
                return NotFound($"Tipo de Pagamento com Id = {id} não encontrado");
            }
            return Ok(inativado);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<TipoPagamento>> Update([FromBody] TipoPagamento tipoPagamento)
        {
            tipoPagamento = await _tiposPagamentoRepositorio.Update(tipoPagamento);
            return Ok(tipoPagamento);
        }
    }
}
