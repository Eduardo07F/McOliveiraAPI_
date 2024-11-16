using Entidades;
using McOliveiraAPI_.Data;
using McOliveiraAPI_.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace McOliveiraAPI_.Repositorio
{
    public class VendedorRepositorio : IVendedorRepositorio
    {
        private readonly MCDbContext _dbContext;

        public VendedorRepositorio(MCDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Vendedor> Add(Vendedor vendedor)
        {
            await _dbContext.Vendedores.AddAsync(vendedor);
            await _dbContext.SaveChangesAsync();
            return vendedor;
        }

        public async Task<bool> Delete(int id)
        {
            Vendedor vendedorById = await GetById(id);

            if (vendedorById == null)
            {
                throw new Exception($"Vendedor com Id = {id} não encontrado");
            }

            _dbContext.Vendedores.Remove(vendedorById);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Vendedor>> GetAll()
        {
            return await _dbContext.Vendedores.ToListAsync();
        }

        public async Task<Vendedor> GetById(int id)
        {
            return await _dbContext.Vendedores.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<bool> Inativar(int id)
        {
            Vendedor vendedorById = await GetById(id);

            if (vendedorById == null)
            {
                throw new Exception($"Vendedor com Id = {id} não encontrado");
            }

            vendedorById.ativo = false;

            _dbContext.Vendedores.Update(vendedorById);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Vendedor> Update(Vendedor vendedor)
        {
            Vendedor vendedorById = await GetById(vendedor.id);

            if (vendedorById == null)
            {
                throw new Exception($"Vendedor com Id = {vendedor.id} não encontrado");
            }

            vendedorById.idUser = vendedor.idUser;
            vendedorById.Nome = vendedor.Nome;
            vendedorById.ativo = vendedor.ativo;

            _dbContext.Vendedores.Update(vendedorById);
            await _dbContext.SaveChangesAsync();
            return vendedorById;
        }
    }
}
