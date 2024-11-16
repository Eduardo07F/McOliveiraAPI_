using Entidades;

namespace McOliveiraAPI_.Repositorio.Interfaces
{
    public interface IPedidoRepositorio
    {
        Task<List<Pedido>> GetAll();
        Task<Pedido> GetById(int id);
        Task<Pedido> Add(Pedido pedido);
        Task<Pedido> Update(Pedido pedido);
        Task<bool> Delete(int id);
        Task<bool> Inativar(int id);
    }
}
