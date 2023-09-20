using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MotorBike.Models
{
    public partial class Ventas
    {
        public Ventas()
        {
            VentaXRepuestos = new HashSet<VentaXRepuesto>();
        }

        public int IdVenta { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaVenta { get; set; }
        public decimal Total { get; set; }

        public virtual ICollection<VentaXRepuesto> VentaXRepuestos { get; set; }
    }
}
