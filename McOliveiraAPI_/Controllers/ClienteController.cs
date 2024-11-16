using Entidades;
using McOliveiraAPI_.Repositorio.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace McOliveiraAPI_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepositorio _clienteRepositorio;

       public ClienteController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }   

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> GetAll() {
            List<Cliente> cliente = await _clienteRepositorio.GetAll();
            return Ok(cliente);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetById(int id )
        {
            Cliente cliente = await _clienteRepositorio.GetById(id);
            return Ok(cliente);
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<Cliente>> Cadastrar([FromBody] Cliente cliente)
        {
            cliente = await _clienteRepositorio.Add(cliente);

            return Ok(cliente);
        }

        [HttpGet("delete/{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            bool deleted = await _clienteRepositorio.Delete(id);
            return Ok(deleted);
        }

        [HttpGet("inativar/{id}")]
        public async Task<ActionResult<bool>> inativar(int id)
        {
            bool deleted = await _clienteRepositorio.Inativar(id);
            return Ok(deleted);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<Cliente>> Update([FromBody] Cliente cliente)
        {
            cliente = await _clienteRepositorio.Update(cliente);

            return Ok(cliente);
        }
    }
}
