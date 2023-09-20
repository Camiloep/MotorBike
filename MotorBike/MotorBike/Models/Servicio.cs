using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MotorBike.Models
{
    public partial class Servicio
    {
        public Servicio()
        {
            VentaXRepuestos = new HashSet<VentaXRepuesto>();
        }

        public int IdServicio { get; set; }
        [Required(ErrorMessage ="Ingrese el nombre del servicios")]
        [Display(Name ="Nombre servicio")]
        public string NombreServicio { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese la descripcion del servicio")]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<VentaXRepuesto> VentaXRepuestos { get; set; }
    }
}
