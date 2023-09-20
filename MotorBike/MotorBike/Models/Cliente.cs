using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MotorBike.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            VentaXRepuestos = new HashSet<VentaXRepuesto>();
        }

        public int IdCliente { get; set; }
        [Required(ErrorMessage = "Ingresa el nombre del cliente")]
        [Display(Name = "Nombre Cliente")]
        public string NombreCliente { get; set; } = null!;
        [Required(ErrorMessage = "Ingresa el correo del cliente")]
        [EmailAddress]
        [Display(Name = "Correo Electronico")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Ingresa el telefono del cliente")]
        [Phone]
        [Display(Name = "Telefono/Celular")]
        public string TelefonoCliente { get; set; } = null!;
        [Required(ErrorMessage = "Ingresa la direccion del cliente")]
        [Display(Name = "Dirección")]
        public string DireccionCliente { get; set; } = null!;

        public virtual ICollection<VentaXRepuesto> VentaXRepuestos { get; set; }
    }
}
