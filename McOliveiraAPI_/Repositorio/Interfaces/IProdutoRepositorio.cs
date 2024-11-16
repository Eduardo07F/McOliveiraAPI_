using Entidades;

namespace McOliveiraAPI_.Repositorio.Interfaces
{
    public interface IProdutoRepositorio
    {
        Task<List<Produto>> GetAll();
        Task<Produto> GetById(int id);
        Task<Produto> Add(Produto produto);
        Task<Produto> Update(Produto produto);
        Task<bool> Delete(int id);
        Task<bool> Inativar(int id);
    }
}
