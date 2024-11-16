using System.Threading.Tasks;
using Entidades;
using McOliveiraAPI_.Data;
using McOliveiraAPI_.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace McOliveiraAPI_.Repositorio
{
    public class PedidoRepositorio :IPedidoRepositorio
    {
        private readonly MCDbContext _dbContext;

        public PedidoRepositorio(MCDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Pedido> Add(Pedido pedido)
        {
            await _dbContext.Pedidos.AddAsync(pedido);
            await _dbContext.SaveChangesAsync();
            return pedido;
        }

        public async Task<bool> Delete(int id)
        {
            Pedido pedidoById = await GetById(id);

            if (pedidoById == null)
            {
                throw new Exception($"Pedido com Id = {id} não encontrado");
            }

            _dbContext.Pedidos.Remove(pedidoById);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Pedido>> GetAll()
        {
            return await _dbContext.Pedidos.ToListAsync();
        }

        public async Task<Pedido> GetById(int id)
        {
            return await _dbContext.Pedidos.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<bool> Inativar(int id)
        {
            Pedido pedidoById = await GetById(id);

            if (pedidoById == null)
            {
                throw new Exception($"Pedido com Id = {id} não encontrado");
            }

            pedidoById.ativo = false;

            _dbContext.Pedidos.Update(pedidoById);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Pedido> Update(Pedido pedido)
        {
            Pedido pedidoById = await GetById(pedido.id);

            if (pedidoById == null)
            {
                throw new Exception($"Pedido com Id = {pedido.id} não encontrado");
            }

            pedidoById.idVendedor = pedido.idVendedor;
            pedidoById.idCliente = pedido.idCliente;
            pedidoById.idTipoPagamento = pedido.idTipoPagamento;
            pedidoById.NomeCliente = pedido.NomeCliente;
            pedidoById.Endereco = pedido.Endereco;
            pedidoById.DataCriacao = pedido.DataCriacao;
            pedidoById.DataEntrega = pedido.DataEntrega;
            pedidoById.Observacao = pedido.Observacao;
            pedidoById.Desconto = pedido.Desconto;
            pedidoById.Adicional = pedido.Adicional;
            pedidoById.Total = pedido.Total;
            pedidoById.ativo = pedido.ativo;

            _dbContext.Pedidos.Update(pedidoById);
            await _dbContext.SaveChangesAsync();
            return pedidoById;
        }
    }
}
