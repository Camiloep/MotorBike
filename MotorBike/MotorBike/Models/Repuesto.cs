using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MotorBike.Models
{
    public partial class Repuesto
    {
        public Repuesto()
        {
            CompraXRepuestos = new HashSet<CompraXRepuesto>();
            VentaXRepuestos = new HashSet<VentaXRepuesto>();
        }

        public int IdRepuesto { get; set; }
        [Display(Name = "Categoria")]
        public int FkCategoria { get; set; }
        [Required(ErrorMessage = "Ingrese el nombre del repuesto")]
        [Display(Name = "Nombre")]
        public string NombreRepuesto { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese la cantidad")]
        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }
        [Required(ErrorMessage = "Ingrese el precio")]
        [Display(Name = "Precio")]
        public int Precio { get; set; }

        public virtual Categorium? FkCategoriaNavigation { get; set; }
        public virtual ICollection<CompraXRepuesto> CompraXRepuestos { get; set; }
        public virtual ICollection<VentaXRepuesto> VentaXRepuestos { get; set; }
    }
}
