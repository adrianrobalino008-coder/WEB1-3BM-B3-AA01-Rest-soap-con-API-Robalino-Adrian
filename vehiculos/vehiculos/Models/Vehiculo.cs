using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace VehiculosSOAPB.Models
{
    
    public class Vehiculo
    {
        [Key]
        [DataMember]
        public int IdVehiculo { get; set; }

        [DataMember]
        public string Placa { get; set; }

        [DataMember]
        public string Marca { get; set; }

        [DataMember]
        public string Modelo { get; set; }

        [DataMember]
        public int Anio { get; set; }

        [DataMember]
        public decimal Precio { get; set; }

        [DataMember]
        public bool Estado { get; set; }

        [DataMember]
        public int IdCategoria { get; set; }
    }
}