using Lab2_PWA_Juegos.Models;

namespace Lab2_PWA_Juegos.Repositories.Products
{
    public interface IProductsRepository
    {
        void Add(ProductsModel productsModel);
        void Delete(int id);
        void Edit(ProductsModel productsModel);
        IEnumerable<ProductsModel> GetAll();

        IEnumerable<SuppliersModel> GetAllSuppliers();
        ProductsModel? GetById(int id);
    }
}
