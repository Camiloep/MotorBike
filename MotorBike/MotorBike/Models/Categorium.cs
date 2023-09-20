using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MotorBike.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            CompraXRepuestos = new HashSet<CompraXRepuesto>();
            Repuestos = new HashSet<Repuesto>();
            VentaXRepuestos = new HashSet<VentaXRepuesto>();
        }
        
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "Ingresa el nombre de la categoria")]
        public string NombreCategoria { get; set; } = null!;

        public virtual ICollection<CompraXRepuesto> CompraXRepuestos { get; set; }
        public virtual ICollection<Repuesto> Repuestos { get; set; }
        public virtual ICollection<VentaXRepuesto> VentaXRepuestos { get; set; }
    }
}
