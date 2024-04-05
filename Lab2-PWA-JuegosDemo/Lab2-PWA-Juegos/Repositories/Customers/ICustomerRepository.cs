using Lab2_PWA_Juegos.Models;

namespace Lab2_PWA_Juegos.Repositories.Customers
{
    public interface ICustomerRepository
    {
        void Add(CustomersModel customersModel);
        void Delete(int id);
        void Edit(CustomersModel customersModel);
        IEnumerable<CustomersModel> GetAll();
        CustomersModel? GetById(int id);
    }
}
