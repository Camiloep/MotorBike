using System;
using System.Collections.Generic;

namespace MotorBike.Models
{
    public partial class VentaXRepuesto
    {
        public int IdVentaXRepuesto { get; set; }
        public int FkVenta { get; set; }
        public int FkCategoria { get; set; }
        public int FkRepuesto { get; set; }
        public int FkMecanico { get; set; }
        public int FkServicio { get; set; }
        public int FkCliente { get; set; }
        public int PrecioManoObra { get; set; }
        public int Cantidad { get; set; }
        public int PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public decimal PrecioFinal { get; set; }

        public virtual Categorium? FkCategoriaNavigation { get; set; }
        public virtual Cliente? FkClienteNavigation { get; set; } 
        public virtual Mecanico? FkMecanicoNavigation { get; set; } 
        public virtual Repuesto? FkRepuestoNavigation { get; set; } 
        public virtual Servicio? FkServicioNavigation { get; set; }
        public virtual Ventas? FkVentaNavigation { get; set; }

    }
}
