using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contracts.Repository
{
    public interface IProductoRepository
    {
        Task Add(Producto entity);
        Task Delete(int id);
        Task<IEnumerable<Producto>> GetAll();
        Task<Producto> GetById(int id);
        Task Update(int id, Producto entity);
        Task<bool> TodoItemExists(int id);
    }
}
