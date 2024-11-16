using Entidades;
using McOliveiraAPI_.Repositorio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace McOliveiraAPI_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoLinhaController : ControllerBase
    {
        private readonly IPedidoLinhaRepositorio _pedidoLinhaRepositorio;
        public PedidoLinhaController(IPedidoLinhaRepositorio pedidoLinhaRepositorio)
        {
            _pedidoLinhaRepositorio = pedidoLinhaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<PedidoLinha>>> GetAll()
        {
            List<PedidoLinha> pedidoLinhas = await _pedidoLinhaRepositorio.GetAll();
            return Ok(pedidoLinhas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoLinha>> GetById(int id)
        {
            PedidoLinha pedidoLinha = await _pedidoLinhaRepositorio.GetById(id);
            if (pedidoLinha == null)
            {
                return NotFound($"PedidoLinha com Id = {id} não encontrado");
            }
            return Ok(pedidoLinha);
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<PedidoLinha>> Cadastrar([FromBody] PedidoLinha pedidoLinha)
        {
            pedidoLinha = await _pedidoLinhaRepositorio.Add(pedidoLinha);
            return Ok(pedidoLinha);
        }

        [HttpGet("delete/{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            bool deleted = await _pedidoLinhaRepositorio.Delete(id);
            if (!deleted)
            {
                return NotFound($"PedidoLinha com Id = {id} não encontrado");
            }
            return Ok(deleted);
        }

        [HttpGet("inativar/{id}")]
        public async Task<ActionResult<bool>> Inativar(int id)
        {
            bool inativado = await _pedidoLinhaRepositorio.Inativar(id);
            if (!inativado)
            {
                return NotFound($"PedidoLinha com Id = {id} não encontrado");
            }
            return Ok(inativado);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<PedidoLinha>> Update([FromBody] PedidoLinha pedidoLinha)
        {
            pedidoLinha = await _pedidoLinhaRepositorio.Update(pedidoLinha);
            return Ok(pedidoLinha);
        }
    }
}
