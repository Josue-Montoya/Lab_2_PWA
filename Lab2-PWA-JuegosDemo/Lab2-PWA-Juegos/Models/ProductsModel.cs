namespace Lab2_PWA_Juegos.Models
{
    public class ProductsModel
    {
        public int ProductID { get; set; }

        public string PName { get; set; }

        public string PDescription { get; set; }    

        public decimal Price { get; set; }  

        public int Stock {  get; set; }
        
        public int SupplierID { get; set; } 

        public SuppliersModel? Suppliers { get; set; }
    }
}
