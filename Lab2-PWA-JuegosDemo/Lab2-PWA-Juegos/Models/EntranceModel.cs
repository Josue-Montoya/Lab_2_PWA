namespace Lab2_PWA_Juegos.Models
{
    public class EntranceModel
    {
        public int EntranceID {  get; set; }
        
        public int ProductID { get; set; }

        public ProductsModel? Products { get; set; }

        public int SupplierID { get; set; }

        public SuppliersModel? Suppliers { get; set; }

        public int Quantity {  get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Total {  get; set; }

        public DateTime EDate { get; set; } 
    }
}
