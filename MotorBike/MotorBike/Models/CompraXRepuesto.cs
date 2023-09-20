using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MotorBike.Models
{
    public partial class CompraXRepuesto 
    {

        [Display(Name = "ID")]
        public int IdCompraXRepuesto { get; set; }

        [Display(Name =  "ID Compra")]
        public int FkCompra { get; set; }


        [Required(ErrorMessage = "Ingrese la categoria")]
        [Display(Name = "Categoria")]
        public int FkCategoria { get; set; }
        [Required(ErrorMessage = "Ingresa el repuesto")]
        [Display(Name = "Repuesto")]
        public int FkRepuesto { get; set; }
        [Required(ErrorMessage = "Ingresa la cantidad")]
        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }
        [Required(ErrorMessage = "Ingresa el precio unitario")]
        [Display(Name = "Precio Unitario")]
        public float PrecioUnitario { get; set; }
        [Required(ErrorMessage = "Ingresa el subtotal")]
        [Display(Name = "Subtotal")]
        public float Subtotal { get; set; }
        [Required(ErrorMessage = "Ingresa el total")]
        [Display(Name = "Total")]
        public float PrecioFinal { get; set; }

        public virtual Categorium? FkCategoriaNavigation { get; set; }

        public virtual Compra? FkCompraNavigation { get; set; }

        public virtual Repuesto? FkRepuestoNavigation { get; set; }



    }
}
