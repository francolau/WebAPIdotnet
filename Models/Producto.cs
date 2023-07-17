namespace WebAPIProducto.Models
{
    public class Producto
    {
        public int Id { get; set; } //se toma como id una primary key de default
        public required string Nombre { get; set; } = string.Empty; // para que no se inicialice como null y sea vacio siempre
        public string Descripcion { get; set; } = string.Empty; // Le puedo agregar required
        public decimal Precio { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public bool Activo { get; set; }
    }
}