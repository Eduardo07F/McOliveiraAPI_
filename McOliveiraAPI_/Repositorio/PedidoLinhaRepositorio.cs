using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades;
using McOliveiraAPI_.Data;
using McOliveiraAPI_.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace McOliveiraAPI_.Repositorio
{
    public class PedidoLinhaRepositorio : IPedidoLinhaRepositorio
    {
        private readonly MCDbContext _dbContext;

        public PedidoLinhaRepositorio(MCDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PedidoLinha> Add(PedidoLinha pedidoLinha)
        {
            await _dbContext.PedidoLinha.AddAsync(pedidoLinha);
            await _dbContext.SaveChangesAsync();
            return pedidoLinha;
        }

        public async Task<bool> Delete(int id)
        {
            PedidoLinha pedidoLinhaById = await GetById(id);

            if (pedidoLinhaById == null)
            {
                throw new Exception($"Linha do pedido com Id = {id} não encontrado");
            }

            _dbContext.PedidoLinha.Remove(pedidoLinhaById);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<PedidoLinha>> GetAll()
        {
            return await _dbContext.PedidoLinha.ToListAsync();
        }

        public async Task<PedidoLinha> GetById(int id)
        {
            return await _dbContext.PedidoLinha.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<bool> Inativar(int id)
        {
            PedidoLinha pedidoLinhaById = await GetById(id);

            if (pedidoLinhaById == null)
            {
                throw new Exception($"Linha do pedido com Id = {id} não encontrado");
            }

            pedidoLinhaById.ativo = false;

            _dbContext.PedidoLinha.Update(pedidoLinhaById);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<PedidoLinha> Update(PedidoLinha pedidoLinha)
        {
            PedidoLinha pedidoLinhaById = await GetById(pedidoLinha.id);

            if (pedidoLinhaById == null)
            {
                throw new Exception($"Linha do pedido com Id = {pedidoLinha.id} não encontrado");
            }

            pedidoLinhaById.idPedido = pedidoLinha.idPedido;
            pedidoLinhaById.idProduto = pedidoLinha.idProduto;
            pedidoLinhaById.NomeProduto = pedidoLinha.NomeProduto;
            pedidoLinhaById.Quantidade = pedidoLinha.Quantidade;
            pedidoLinhaById.ValorUnitario = pedidoLinha.ValorUnitario;
            pedidoLinhaById.ValorTotal = pedidoLinha.ValorTotal;
            pedidoLinhaById.ativo = pedidoLinha.ativo;

            _dbContext.PedidoLinha.Update(pedidoLinhaById);
            await _dbContext.SaveChangesAsync();
            return pedidoLinhaById;
        }
    }
}
