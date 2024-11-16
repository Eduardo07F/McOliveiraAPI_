using Entidades;
using McOliveiraAPI_.Data;
using McOliveiraAPI_.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace McOliveiraAPI_.Repositorio
{
    public class UserRepositorio : IUserRepositorio
    {
        private readonly MCDbContext _dbContext;
        public UserRepositorio(MCDbContext _MCDbContext)
        {
            _dbContext = _MCDbContext;
        }
        public async Task<User> Add(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> Delete(int id)
        {
            User userByid = await GetById(id);

            if (userByid == null)
            {
                throw new Exception($"Id = {id} não encontrado ");
            }
            _dbContext.Users.Remove(userByid);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<User>> GetAll()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<bool> Inativar(int id)
        {
            User userByid = await GetById(id);

            if (userByid == null)
            {
                throw new Exception($"Id = {id} não encontrado ");
            }
            userByid.ativo = false;

            _dbContext.Users.Update(userByid);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<User> Update(User user)
        {

            User userByid = await GetById(user.id);

            if (userByid == null)
            {
                throw new Exception($"Id = {user.id} não encontrado ");
            }

            userByid.id = user.id; 
            userByid.password = user.password;  
            userByid.email = user.email;
            userByid.ativo = user.ativo;

            _dbContext.Users.Update(userByid);
            await _dbContext.SaveChangesAsync();
            return userByid;
        }
    }
}
