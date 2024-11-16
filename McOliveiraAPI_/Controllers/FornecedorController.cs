using Entidades;
using McOliveiraAPI_.Repositorio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace McOliveiraAPI_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorRepositorio _fornecedorRepositorio;

        public FornecedorController(IFornecedorRepositorio fornecedorRepositorio)
        {
            _fornecedorRepositorio = fornecedorRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Fornecedor>>> GetAll()
        {
            List<Fornecedor> fornecedor = await _fornecedorRepositorio.GetAll();
            return Ok(fornecedor);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Fornecedor>> GetById(int id)
        {
            Fornecedor fornecedor = await _fornecedorRepositorio.GetById(id);
            return Ok(fornecedor);
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<Fornecedor>> Cadastrar([FromBody] Fornecedor fornecedor)
        {
            fornecedor = await _fornecedorRepositorio.Add(fornecedor);

            return Ok(fornecedor);
        }

        [HttpGet("delete/{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            bool deleted = await _fornecedorRepositorio.Delete(id);
            return Ok(deleted);
        }

        [HttpGet("inativar/{id}")]
        public async Task<ActionResult<bool>> inativar(int id)
        {
            bool deleted = await _fornecedorRepositorio.Inativar(id);
            return Ok(deleted);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<Fornecedor>> Update([FromBody] Fornecedor fornecedor)
        {
            fornecedor = await _fornecedorRepositorio.Update(fornecedor);

            return Ok(fornecedor);
        }
    }
}
