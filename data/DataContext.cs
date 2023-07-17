using Microsoft.EntityFrameworkCore;
using WebAPIProducto.Models; //para que me reconozca el model <Producto>

namespace WebAPIProducto.data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {

        }

        public DbSet<Producto> Productos { get; set; }
    }
}