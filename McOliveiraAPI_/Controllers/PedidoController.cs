using Entidades;
using McOliveiraAPI_.Repositorio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace McOliveiraAPI_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;

        public PedidoController(IPedidoRepositorio pedidoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pedido>>> GetAll()
        {
            List<Pedido> pedidos = await _pedidoRepositorio.GetAll();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetById(int id)
        {
            Pedido pedido = await _pedidoRepositorio.GetById(id);
            if (pedido == null)
            {
                return NotFound($"Pedido com Id = {id} não encontrado");
            }
            return Ok(pedido);
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<Pedido>> Cadastrar([FromBody] Pedido pedido)
        {
            pedido = await _pedidoRepositorio.Add(pedido);
            return Ok(pedido);
        }

        [HttpGet("delete/{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            bool deleted = await _pedidoRepositorio.Delete(id);
            if (!deleted)
            {
                return NotFound($"Pedido com Id = {id} não encontrado");
            }
            return Ok(deleted);
        }

        [HttpGet("inativar/{id}")]
        public async Task<ActionResult<bool>> Inativar(int id)
        {
            bool inativado = await _pedidoRepositorio.Inativar(id);
            if (!inativado)
            {
                return NotFound($"Pedido com Id = {id} não encontrado");
            }
            return Ok(inativado);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<Pedido>> Update([FromBody] Pedido pedido)
        {
            pedido = await _pedidoRepositorio.Update(pedido);
            return Ok(pedido);
        }
    }
}
