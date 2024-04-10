using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;

namespace Lab2_PWA_Juegos.Models
{
    public class DepartureModel
    {
        public int DepartureID { get; set; }

        [Required(ErrorMessage = "El producto es obligatorio")]
        [Display(Name = "Producto")]
        public int ProductID { get; set; }

        public ProductsModel? Products { get; set; }

        [Required(ErrorMessage = "El empleado es obligatorio")]
        [Display(Name = "Empleado")]
        public int EmployeeID { get; set; }

        public EmployeesModel? Employees { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatorio")]
        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "El precio unitario es obligatorio")]
        [Display(Name = "Precio Unitario")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "El total es obligatorio")]
        [Display(Name = "Total")]
        public decimal Total {  get; set; }

        [Required(ErrorMessage = "La fecha y hora es obligatorio")]
        [Display(Name = "Fecha")]
        public DateTime DDate { get; set; } 
    }
}
