using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MotorBike.Models
{
    public partial class Mecanico
    {
        public Mecanico()
        {
            VentaXRepuestos = new HashSet<VentaXRepuesto>();
        }

        public int IdMecanico { get; set; }
        [Required(ErrorMessage = "Ingrese el nombre del mecanico")]
        [Display(Name = "Nombre")]
        public string NombreMecanico { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese la Cédula del mecanico")]
        [Display(Name = "Cédula")]
        public string Cedula { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese el teléfono del mecanico")]
        [Phone]
        [Display(Name = "Teléfono")]
        public string TelefonoMecanico { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese la dirección del mecanico")]
        [Display(Name = "Direccion")]
        public string DireccionMecanico { get; set; } = null!;

        public virtual ICollection<VentaXRepuesto> VentaXRepuestos { get; set; }
    }
}
