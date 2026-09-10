using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehiculoRest.Models
{
    [Table("Mantenimientos")]
    public class Mantenimiento
    {
        [Key]
        public int IdMantenimiento { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        [StringLength(50)]
        public string Tipo { get; set; } = string.Empty;

        [StringLength(250)]
        public string Descripcion { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Costo { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Kilometraje { get; set; }

        [Required]
        public bool Estado { get; set; }

        [Required]
        public int IdVehiculo { get; set; }
    }
}