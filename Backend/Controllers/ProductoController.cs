using Core.Contracts.Repository;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IConfiguration _configuration;

        public ProductoController(IProductoRepository _productoRepository, IConfiguration configuration)
        {
            this._productoRepository = _productoRepository;
            this._configuration = configuration;
        }

        // GET: api/Producto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetAll()
        {
            return Ok(await _productoRepository.GetAll());
        }

        // GET: api/Producto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProduct(int id)
        {
            var todoItem = await _productoRepository.GetById(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        // PUT: api/Producto/5        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest();
            }

            var oProducto = _productoRepository.GetById(id);

            if (oProducto == null)
            {
                return NotFound();
            }

            await _productoRepository.Update(id, producto);
            return NoContent();
        }

        // POST: api/TodoItem
        [HttpPost]
        public async Task<ActionResult<Producto>> Post(Producto producto)
        {
            await _productoRepository.Add(producto);
            return Ok(new { id = producto.Id, producto });
        }

        // DELETE: api/TodoItem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            var oProducto = _productoRepository.GetById(id);

            if (oProducto == null)
            {
                return NotFound();
            }

            await _productoRepository.Delete(id);
            return NoContent();
        }

    }
}
