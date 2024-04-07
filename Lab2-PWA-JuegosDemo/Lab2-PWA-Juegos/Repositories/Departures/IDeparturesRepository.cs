using Lab2_PWA_Juegos.Models;

namespace Lab2_PWA_Juegos.Repositories.Departures
{
    public interface IDeparturesRepository
    {
        void Add(DepartureModel departureModel);
        void Edit(DepartureModel departureModel);
        void Delete(int id);
        IEnumerable<DepartureModel> GetAll();

        IEnumerable<ProductsModel> GetAllProducts();

        IEnumerable<EmployeesModel> GetAllEmployees();

        DepartureModel? GetById(int id);
    }
}
