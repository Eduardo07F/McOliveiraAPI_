using Entidades;

namespace McOliveiraAPI_.Repositorio.Interfaces
{
    public interface IFornecedorRepositorio
    {
        Task<List<Fornecedor>> GetAll();
        Task<Fornecedor> GetById(int id);
        Task<Fornecedor> Add(Fornecedor fornecedor);
        Task<Fornecedor> Update(Fornecedor fornecedor);
        Task<bool> Delete(int id);
        Task<bool> Inativar(int id);
    }
}
