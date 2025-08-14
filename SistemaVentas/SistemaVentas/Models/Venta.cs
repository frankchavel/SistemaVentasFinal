using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVentasPOS.Models
{
    [Table("Venta")]
    public class Venta
    {
        [Key]
        public int IdVenta { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime FechaVenta { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Subtotal { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal MontoIGV { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal MontoTotal { get; set; }

        // Propiedades de las llaves foráneas
        public int? IdCliente { get; set; } // Puede ser nulo si la venta es al público general
        public int IdUsuario { get; set; }

        // Propiedades de navegación (para Entity Framework)
        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        // Colección para el detalle de la venta
        public ICollection<DetalleVenta> DetalleVentas { get; set; }
    }
}