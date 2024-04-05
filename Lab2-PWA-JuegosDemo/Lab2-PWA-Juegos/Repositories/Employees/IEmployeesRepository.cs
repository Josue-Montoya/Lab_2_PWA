using Lab2_PWA_Juegos.Models;

namespace Lab2_PWA_Juegos.Repositories.Employees
{
    public interface IEmployeesRepository
    {
        void Add(EmployeesModel employeesModel);
        void Delete(int id);
        void Edit(EmployeesModel employeesModel);
        IEnumerable<EmployeesModel> GetAll();
        EmployeesModel? GetById(int id);
    }
}
