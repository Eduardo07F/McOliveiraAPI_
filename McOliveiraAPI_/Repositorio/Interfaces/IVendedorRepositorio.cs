using Entidades;

namespace McOliveiraAPI_.Repositorio.Interfaces
{
    public interface IVendedorRepositorio
    {
        Task<List<Vendedor>> GetAll();
        Task<Vendedor> GetById(int id);
        Task<Vendedor> Add(Vendedor vendedor);
        Task<Vendedor> Update(Vendedor vendedor);
        Task<bool> Delete(int id);
        Task<bool> Inativar(int id);
    }
}
