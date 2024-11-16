using Entidades;

namespace McOliveiraAPI_.Repositorio.Interfaces
{
    public interface IUserRepositorio
    {
        Task<List<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> Add(User user);
        Task<User> Update(User user);
        Task<bool> Delete(int id);
        Task<bool> Inativar(int id);
    }
}
