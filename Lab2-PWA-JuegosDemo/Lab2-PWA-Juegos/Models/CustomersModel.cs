using System.ComponentModel.DataAnnotations;

namespace Lab2_PWA_Juegos.Models
{
    public class CustomersModel
    {
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MinLength(3, ErrorMessage = "Debe ingresar minimo 3 letras")]
        [MaxLength(255, ErrorMessage = "Debe ingresar maximo 255 letras")]
        [Display(Name = "Nombre")]
        public string? CName { get; set; }

        [Required(ErrorMessage = "El correo electronico es obligatorio")]
        [MinLength(3, ErrorMessage = "Debe ingresar minimo 3 letras")]
        [MaxLength(255, ErrorMessage = "Debe ingresar maximo 255 letras")]
        [Display(Name = "Correo Electronico")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [MinLength(3, ErrorMessage = "Debe ingresar minimo 3 numeros")]
        [MaxLength(20, ErrorMessage = "Debe ingresar maximo 20 numeros")]
        [Display(Name = "Teléfono")]
        public string? Phone { get; set; }
    }
}
