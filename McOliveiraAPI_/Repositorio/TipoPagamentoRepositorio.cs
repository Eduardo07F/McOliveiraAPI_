using Entidades;
using McOliveiraAPI_.Data;
using McOliveiraAPI_.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace McOliveiraAPI_.Repositorio
{
    public class TipoPagamentoRepositorio : ITipoPagamentoRepositorio
    {
        private readonly MCDbContext _dbContext;

        public TipoPagamentoRepositorio(MCDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TipoPagamento> Add(TipoPagamento tipoPagamento)
        {
            await _dbContext.TiposPagamento.AddAsync(tipoPagamento);
            await _dbContext.SaveChangesAsync();
            return tipoPagamento;
        }

        public async Task<bool> Delete(int id)
        {
            TipoPagamento tipoPagamentoById = await GetById(id);

            if (tipoPagamentoById == null)
            {
                throw new Exception($"Id = {id} não encontrado");
            }

            _dbContext.TiposPagamento.Remove(tipoPagamentoById);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<TipoPagamento>> GetAll()
        {
            return await _dbContext.TiposPagamento.ToListAsync();
        }

        public async Task<TipoPagamento> GetById(int id)
        {
            return await _dbContext.TiposPagamento.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<bool> Inativar(int id)
        {
            TipoPagamento tipoPagamentoById = await GetById(id);

            if (tipoPagamentoById == null)
            {
                throw new Exception($"Id = {id} não encontrado");
            }

            tipoPagamentoById.ativo = false;

            _dbContext.TiposPagamento.Update(tipoPagamentoById);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<TipoPagamento> Update(TipoPagamento tipoPagamento)
        {
            TipoPagamento tipoPagamentoById = await GetById(tipoPagamento.id);

            if (tipoPagamentoById == null)
            {
                throw new Exception($"Id = {tipoPagamento.id} não encontrado");
            }

            tipoPagamentoById.NomeTipo = tipoPagamento.NomeTipo;
            tipoPagamentoById.ativo = tipoPagamento.ativo;

            _dbContext.TiposPagamento.Update(tipoPagamentoById);
            await _dbContext.SaveChangesAsync();
            return tipoPagamentoById;
        }
    }
}
