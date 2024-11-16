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
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly MCDbContext _dbContext;
        public ClienteRepositorio(MCDbContext _MCDbContext)
        {
            _dbContext = _MCDbContext;
        }

        public async Task<List<Cliente>> GetAll()
        {
            return await _dbContext.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetById(int id)
        {
            return await _dbContext.Clientes.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<Cliente> Add(Cliente cliente)
        {
          await _dbContext.Clientes.AddAsync(cliente);
          await  _dbContext.SaveChangesAsync();
            return cliente;
        }

        public async Task<bool> Delete(int id)
        {
            Cliente clienteByid = await GetById(id);

            if (clienteByid == null)
            {
                throw new Exception($"Id = {id} não encontrado ");
            }
            _dbContext.Clientes.Remove(clienteByid);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Cliente> Update(Cliente cliente)
        {
            Cliente clienteByid = await GetById(cliente.id);

            if (clienteByid == null)
            {
                throw new Exception($"Id = {cliente.id} não encontrado ");
            }

            clienteByid.Nome = cliente.Nome;
            clienteByid.IS_CNPJ = cliente.IS_CNPJ;
            clienteByid.Cpf_Cnpj= cliente.Cpf_Cnpj;
            clienteByid.Telefone= cliente.Telefone;
            clienteByid.Email = cliente.Email;
            clienteByid.Cel = cliente.Cel;
            clienteByid.Ativo = cliente.Ativo;

            _dbContext.Clientes.Update(clienteByid);
           await _dbContext.SaveChangesAsync();
            return clienteByid;
        }

        public async Task<bool> Inativar(int id)
        {
            Cliente clienteByid = await GetById(id);

            if (clienteByid == null)
            {
                throw new Exception($"Id = {id} não encontrado ");
            }
            clienteByid.Ativo = false;
            _dbContext.Clientes.Update(clienteByid);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
