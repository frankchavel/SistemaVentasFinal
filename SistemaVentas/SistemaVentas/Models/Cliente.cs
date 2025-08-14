using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVentasPOS.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        [Required(ErrorMessage ="El nombre del documento es obligatorio")]
        [StringLength(15)]
        public string TipoDocumento { get; set; }

        [Required(ErrorMessage ="El número del documento es obligatorio")]
        [StringLength(10)]
        public string NumeroDocumento { get; set; }

        [Required(ErrorMessage ="Los nombres es obligatorio.")]
        [StringLength(40)]
        public string Nombres { get; set; }

        [StringLength(40)]
        [Required(ErrorMessage = "Los apellidos es obligatorio.")]
        public string Apellidos { get; set; }

        [StringLength(9)]
        [Required(ErrorMessage = "El telefono es obligatorio.")]
        public string Telefono { get; set; }
    }
}