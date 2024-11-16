using Entidades;
using McOliveiraAPI_.Data;
using McOliveiraAPI_.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace McOliveiraAPI_.Repositorio
{
    public class ProdutosRepositorio : IProdutoRepositorio
    {
        private readonly MCDbContext _dbContext;
        public ProdutosRepositorio (MCDbContext _MCDbContext)
        {
            _dbContext = _MCDbContext;
        }
        public async Task<Produto> Add(Produto produto)
        {

            await _dbContext.Produtos.AddAsync(produto);
            await _dbContext.SaveChangesAsync();
            return produto;
        }

        public async Task<bool> Delete(int id)
        {
            Produto produtoById = await GetById(id);

            if (produtoById == null)
            {
                throw new Exception($"Id = {id} não encontrado ");
            }
            _dbContext.Produtos.Remove(produtoById);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Produto>> GetAll()
        {
            return await _dbContext.Produtos.ToListAsync();
        }

        public async Task<Produto> GetById(int id)
        {
            Produto produto = await _dbContext.Produtos.FirstOrDefaultAsync(x => x.id == id);
            return produto;
        }

        public async Task<bool> Inativar(int id)
        {
            Produto produtoById = await GetById(id);

            if (produtoById == null)
            {
                throw new Exception($"Id = {id} não encontrado ");
            }
            produtoById.ativo = false;

            _dbContext.Produtos.Update(produtoById);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Produto> Update(Produto produto)
        {

            Produto produtoById = await GetById(produto.id);

            if (produtoById == null)
            {
                throw new Exception($"Id = {produto.id} não encontrado ");
            }

            produtoById.id = produto.id;
            produtoById.idFornecedor = produto.idFornecedor;
            produtoById.Valor = produto.Valor;
            produtoById.Descricao = produto.Descricao; 
            produtoById.Quantidade_Estoque = produto.Quantidade_Estoque;
            produtoById.ativo = produto.ativo;
            produtoById.isBackorder= produto.isBackorder;   


            _dbContext.Produtos.Update(produtoById);
            await _dbContext.SaveChangesAsync();
            return produtoById;
        }
    }
}
