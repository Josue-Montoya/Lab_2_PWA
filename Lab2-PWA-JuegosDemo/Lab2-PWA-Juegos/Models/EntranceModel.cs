using System.ComponentModel.DataAnnotations;

namespace Lab2_PWA_Juegos.Models
{
    public class EntranceModel
    {
        public int EntranceID {  get; set; }

        [Required(ErrorMessage = "El producto es obligatorio")]
        [Display(Name = "Producto")]
        public int ProductID { get; set; }

        public ProductsModel? Products { get; set; }

        [Required(ErrorMessage = "El proveedor es obligatorio")]
        [Display(Name = "Proveedor")]
        public int SupplierID { get; set; }

        public SuppliersModel? Suppliers { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatorio")]
        [Display(Name = "Cantidad")]
        public int Quantity {  get; set; }

        [Required(ErrorMessage = "El precio unitario es obligatorio")]
        [Display(Name = "Precio Unitario")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "El total es obligatorio")]
        [Display(Name = "Total")]
        public decimal Total {  get; set; }

        [Required(ErrorMessage = "La fecha y hora es obligatorio")]
        [Display(Name = "Fecha")]
        public DateTime EDate { get; set; } 
    }
}
