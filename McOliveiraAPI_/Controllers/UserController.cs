using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entidades;
using McOliveiraAPI_.Repositorio;
using McOliveiraAPI_.Repositorio.Interfaces;

namespace McOliveiraAPI_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepositorio _userRepositorio;
        public UserController(IUserRepositorio userRepositorio) {
            _userRepositorio= userRepositorio; 
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            List<User> User = await _userRepositorio.GetAll();
            return Ok(User);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            User User = await _userRepositorio.GetById(id);
            return Ok(User);
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<User>> Cadastrar([FromBody] User user)
        {
            user = await _userRepositorio.Add(user);

            return Ok(user);
        }

        [HttpGet("delete/{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            bool deleted = await _userRepositorio.Delete(id);
            return Ok(deleted);
        }

        [HttpGet("inativar/{id}")]
        public async Task<ActionResult<bool>> inativar(int id)
        {
            bool deleted = await _userRepositorio.Inativar(id);
            return Ok(deleted);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<User>> Update([FromBody] User user)
        {
            user = await _userRepositorio.Update(user);

            return Ok(user);
        }

    }
}
