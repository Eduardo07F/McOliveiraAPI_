using McOliveiraAPI_.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Entidades;
using Microsoft.AspNetCore.Http;
using McOliveiraAPI_.Repositorio;

namespace McOliveiraAPI_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        public ProdutoController (IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> GetAll()
        {
            List<Produto> Produto = await _produtoRepositorio.GetAll();
            return Ok(Produto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetById(int id)
        {
            Produto Produto = await _produtoRepositorio.GetById(id);
            return Ok(Produto);
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<Produto>> Cadastrar([FromBody] Produto Produto)
        {
            Produto = await _produtoRepositorio.Add(Produto);

            return Ok(Produto);
        }

        [HttpGet("delete/{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            bool deleted = await _produtoRepositorio.Delete(id);
            return Ok(deleted);
        }

        [HttpGet("inativar/{id}")]
        public async Task<ActionResult<bool>> inativar(int id)
        {
            bool deleted = await _produtoRepositorio.Inativar(id);
            return Ok(deleted);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<Produto>> Update([FromBody] Produto Produto)
        {
            Produto = await _produtoRepositorio.Update(Produto);

            return Ok(Produto);
        }

    }
}
