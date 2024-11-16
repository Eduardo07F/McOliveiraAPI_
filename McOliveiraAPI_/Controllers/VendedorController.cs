using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Entidades;
using McOliveiraAPI_.Repositorio;
using McOliveiraAPI_.Repositorio.Interfaces;

namespace McOliveiraAPI_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : ControllerBase
    {
        private readonly IVendedorRepositorio _vendedorRepositorio;

        public VendedorController(IVendedorRepositorio vendedorRepositorio)
        {
            _vendedorRepositorio = vendedorRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Vendedor>>> GetAll()
        {
            List<Vendedor> Vendedor = await _vendedorRepositorio.GetAll();
            return Ok(Vendedor);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vendedor>> GetById(int id)
        {
            Vendedor Vendedor = await _vendedorRepositorio.GetById(id);
            return Ok(Vendedor);
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<Vendedor>> Cadastrar([FromBody] Vendedor vendedor)
        {
            vendedor = await _vendedorRepositorio.Add(vendedor);

            return Ok(vendedor);
        }

        [HttpGet("delete/{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            bool deleted = await _vendedorRepositorio.Delete(id);
            return Ok(deleted);
        }

        [HttpGet("inativar/{id}")]
        public async Task<ActionResult<bool>> inativar(int id)
        {
            bool deleted = await _vendedorRepositorio.Inativar(id);
            return Ok(deleted);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<Vendedor>> Update([FromBody] Vendedor vendedor)
        {
            vendedor = await _vendedorRepositorio.Update(vendedor);

            return Ok(vendedor);
        }
    }
}
