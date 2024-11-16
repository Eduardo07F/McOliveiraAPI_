using Entidades;

namespace McOliveiraAPI_.Repositorio.Interfaces
{
    public interface IPedidoLinhaRepositorio
    {
        Task<List<PedidoLinha>> GetAll();
        Task<PedidoLinha> GetById(int id);
        Task<PedidoLinha> Add(PedidoLinha pedidoLinha);
        Task<PedidoLinha> Update(PedidoLinha pedidoLinha);
        Task<bool> Delete(int id);
        Task<bool> Inativar(int id);
    }
}
