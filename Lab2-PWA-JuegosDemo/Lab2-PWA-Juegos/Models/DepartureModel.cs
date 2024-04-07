using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Lab2_PWA_Juegos.Models
{
    public class DepartureModel
    {
        public int DepartureID { get; set; }

        public int ProductID { get; set; }

        public ProductsModel? Products { get; set; }

        public int EmployeeID { get; set; }

        public EmployeesModel? Employees { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
        
        public decimal Total {  get; set; }

        public DateTime DDate { get; set; } 
    }
}
