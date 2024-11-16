using Entidades;

namespace McOliveiraAPI_.Repositorio.Interfaces
{
    public interface ITipoPagamentoRepositorio
    {
        Task<List<TipoPagamento>> GetAll();
        Task<TipoPagamento> GetById(int id);
        Task<TipoPagamento> Add(TipoPagamento tipoPagamento);
        Task<TipoPagamento> Update(TipoPagamento tipoPagamento);
        Task<bool> Delete(int id);
        Task<bool> Inativar(int id);
    }
}
