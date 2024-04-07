using Lab2_PWA_Juegos.Models;

namespace Lab2_PWA_Juegos.Repositories.Entrance
{
    public interface IEntranceRepository
    {
        void Add(EntranceModel entranceModel);
        void Edit(EntranceModel entranceModel);
        void Delete(int id);
        IEnumerable<EntranceModel> GetAll();

        IEnumerable<SuppliersModel> GetAllSuppliers();

        IEnumerable<ProductsModel> GetAllProducts();
        EntranceModel? GetById(int id);
    }
}
