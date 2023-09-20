using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MotorBike.Models
{
    public partial class Compra
    {

        public Compra()
        {
            CompraXRepuestos = new HashSet<CompraXRepuesto>();
        }

        public int IdCompra { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaCompra { get; set; }
        public float Total { get; set; }
        public virtual ICollection<CompraXRepuesto> CompraXRepuestos { get; set; }




    }
}
