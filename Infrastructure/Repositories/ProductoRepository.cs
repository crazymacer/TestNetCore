using Core.Contracts.Repository;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductoRepository(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        public async Task Add(Producto entity)
        {
            entity.FechaRegistro = DateTime.Now;
            _context.Producto.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var todoItem = await _context.Producto.FindAsync(id);
            if (todoItem == null)
            {
                throw new Exception("Producto no encontrado");
            }

            _context.Producto.Remove(todoItem);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Producto>> GetAll()
        {
            return await _context.Producto.ToListAsync();
        }

        public async Task<Producto> GetById(int id)
        {
            return await _context.Producto.FindAsync(id);
        }

        public async Task Update(int id, Producto entity)
        {
            try
            {
                var prodcuto = await _context.Producto.FindAsync(id);

                if (prodcuto == null)
                {
                    throw new Exception("Producto no encontrado");
                }

                prodcuto.Nombre = entity.Nombre;
                prodcuto.Stock = entity.Stock;
                //_context.Entry(prodcuto).State = EntityState.Modified;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> TodoItemExists(int id)
        {
            return await _context.Producto.AnyAsync(e => e.Id == id);
        }
    }
}
