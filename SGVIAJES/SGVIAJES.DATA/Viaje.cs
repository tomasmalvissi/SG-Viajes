using System;
using System.ComponentModel.DataAnnotations;

namespace SGVIAJES.DATA
{
    public class Viaje
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Numero")]
        public int NroViaje { get; set; }

        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        public DateTime FechaViaje { get; set; }

        public string Empresa { get; set; }

        public string Origen { get; set; }

        public string Destino { get; set; }

        [Required]
        public float KM { get; set; }

        [Required]
        [Display(Name = "Precio del KM")]
        public float PrecioKM { get; set; }

        [Required]
        [Display(Name = "Espera")]
        public float MinEsper { get; set; }

        [Required]
        [Display(Name = "Precio del minuto de espera")]
        public float PrecioEspera { get; set; }

        [Display(Name = "Peajes y/o Estac")]
        public float PeajeEst { get; set; }

        [Required]
        public float GNC { get; set; }

        [Required]
        public float Nafta { get; set; }

        public float Importe { get; set; }

        [Display (Name = "Total Espera")]
        public float ImporteEsp { get; set; }

        public float Total { get; set; }

    }
}
