using Microsoft.AspNetCore.Mvc;
using WebAPIProducto.data;
using WebAPIProducto.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPIProducto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly ILogger <ProductosController> _logger;
        private readonly DataContext _context;

// Recibo una instacia de log y un context cuando creamos un product controller
        public ProductosController(ILogger<ProductosController> logger, DataContext context) 
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetProductos")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            return await _context.Productos.ToListAsync();
        }

        [HttpGet ("{id}", Name = "GetProducto")]

        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id); //primer producto que encuentra cuando da el id

            if(producto == null){
                return NotFound();
            }

            return producto;
        }

        [HttpPost]
        public async Task<ActionResult<Producto>> Post(Producto producto) // nos regrese el producto cread
        {
            _context.Add(producto);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetProducto", new {id = producto.Id}, producto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Producto producto)
        {
            if(id != producto.Id)
            {
                return BadRequest();
            }

            _context.Entry(producto).State = EntityState.Modified; //al contexto en entry le va a agregar el producto.state y le va a decir que se esta modificando
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Producto>> Delete(int id) // el id no es autoincrementable entonces, si elimino un producto el proximo id va a ser el id del producto + 1
        {
            var producto = await _context.Productos.FindAsync(id);

            if(producto == null){
             return NotFound();
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return producto;
        }

}
}