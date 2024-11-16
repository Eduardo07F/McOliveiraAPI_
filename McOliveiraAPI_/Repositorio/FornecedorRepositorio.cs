using System.Threading.Tasks;
using Entidades;
using McOliveiraAPI_.Data;
using McOliveiraAPI_.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace McOliveiraAPI_.Repositorio
{
    public class FornecedorRepositorio : IFornecedorRepositorio
    {
        private readonly MCDbContext _dbContext;
        public FornecedorRepositorio(MCDbContext _MCDbContext)
        {
            _dbContext = _MCDbContext;
        }
        public async Task<Fornecedor> Add(Fornecedor fornecedor)
        {
            await _dbContext.Fornecedores.AddAsync(fornecedor); 
            await _dbContext.SaveChangesAsync();
            return (fornecedor);
        }

        public async Task<bool> Delete(int id)
        {
            Fornecedor fornecedorbyId = await GetById(id);

            if (fornecedorbyId == null)
            {
                throw new Exception($"Id = {id} não encontrado ");
            }
            _dbContext.Fornecedores.Remove(fornecedorbyId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Fornecedor>> GetAll()
        {
            return await _dbContext.Fornecedores.ToListAsync();
        }

        public async Task<Fornecedor> GetById(int id)
        {
            Fornecedor fornecedor = await _dbContext.Fornecedores.FirstOrDefaultAsync(x => x.id == id);
            return fornecedor;
        }

        public async Task<bool> Inativar(int id)
        {
            Fornecedor fornecedorbyid = await GetById(id);

            if (fornecedorbyid == null)
            {
                throw new Exception($"Id = {id} não encontrado ");
            }
            fornecedorbyid.ativo = false;

            _dbContext.Fornecedores.Update(fornecedorbyid);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Fornecedor> Update(Fornecedor fornecedor)
        {

            Fornecedor fornecedorByid = await GetById(fornecedor.id);

            if (fornecedorByid == null)
            {
                throw new Exception($"Id = {fornecedor.id} não encontrado ");
            }

            fornecedorByid.id = fornecedor.id;
            fornecedorByid.Nome = fornecedor.Nome;
            fornecedorByid.CPF_CNPJ = fornecedor.CPF_CNPJ;
            fornecedorByid.Telefone = fornecedor.Telefone;
            fornecedorByid.Email = fornecedor.Email;
            fornecedorByid.IS_CNPJ = fornecedor.IS_CNPJ;
            fornecedorByid.ativo = fornecedor.ativo;

            _dbContext.Fornecedores.Update(fornecedorByid);
            await _dbContext.SaveChangesAsync();
            return fornecedorByid;
        }
    }
}
