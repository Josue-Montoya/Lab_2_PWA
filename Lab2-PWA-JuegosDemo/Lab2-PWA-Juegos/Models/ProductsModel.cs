using System.ComponentModel.DataAnnotations;

namespace Lab2_PWA_Juegos.Models
{
    public class ProductsModel
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MinLength(3, ErrorMessage = "Debe ingresar minimo 3 letras")]
        [MaxLength(255, ErrorMessage = "Debe ingresar maximo 255 letras")]
        [Display(Name = "Nombre")]
        public string? PName { get; set; }

        [Required(ErrorMessage = "La descripción es obligatorio")]
        [MinLength(3, ErrorMessage = "Debe ingresar minimo 3 letras")]
        [MaxLength(255, ErrorMessage = "Debe ingresar maximo 255 letras")]
        [Display(Name = "Descripción")]
        public string? PDescription { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Display(Name = "Precio")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Las existencias es obligatorio")]
        [Display(Name = "Existencias")]
        public int Stock {  get; set; }

        [Required(ErrorMessage = "El proveedor es obligatorio")]
        [Display(Name = "Proveedor")]
        public int SupplierID { get; set; } 

        public SuppliersModel? Suppliers { get; set; }
    }
}
