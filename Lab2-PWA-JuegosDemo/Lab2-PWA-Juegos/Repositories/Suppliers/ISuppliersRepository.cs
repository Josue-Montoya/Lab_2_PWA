using Lab2_PWA_Juegos.Models;

namespace Lab2_PWA_Juegos.Repositories.Suppliers
{
    public interface ISuppliersRepository
    {
        void Add(SuppliersModel suppliersModel);
        void Delete(int id);
        void Edit(SuppliersModel suppliersModel);
        IEnumerable<SuppliersModel> GetAll();
        SuppliersModel? GetById(int id);
    }
}