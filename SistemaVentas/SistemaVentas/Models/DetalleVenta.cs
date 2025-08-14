using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVentasPOS.Models
{
    [Table("DetalleVenta")]
    public class DetalleVenta
    {
        [Key]
        public int IdDetalleVenta { get; set; }

        public int IdVenta { get; set; }
        public Venta Venta { get; set; }

        public int IdProducto { get; set; }
        public Producto Producto { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal PrecioUnitario { get; set; }
    }
}