using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades;
namespace McOliveiraAPI_.Repositorio.Interfaces
{
    public interface IClienteRepositorio
    {
        Task<List<Cliente>> GetAll();
        Task<Cliente> GetById(int id);
        Task<Cliente> Add(Cliente cliente);
        Task<Cliente> Update(Cliente cliente);
        Task<bool> Delete(int id);
        Task<bool> Inativar(int id);
    }
}
