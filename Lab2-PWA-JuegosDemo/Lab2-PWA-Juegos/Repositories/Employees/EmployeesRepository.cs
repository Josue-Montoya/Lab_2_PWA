using Dapper;
using Lab2_PWA_Juegos.Data;
using Lab2_PWA_Juegos.Models;
using System.Data;

namespace Lab2_PWA_Juegos.Repositories.Employees
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public EmployeesRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<EmployeesModel> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spEmployees_GetAll";

                return connection.Query<EmployeesModel>(
                                        storeProcedure,
                                        commandType: CommandType.StoredProcedure
                                        );
            }
        }

        public EmployeesModel? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spEmployees_GetById";

                return connection.QueryFirstOrDefault<EmployeesModel>(
                                    storeProcedure,
                                    new { EmployeeID = id },
                                    commandType: CommandType.StoredProcedure
                                   );
            }
        }

        public void Add(EmployeesModel employeesModel)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spEmployees_Insert";

                connection.Execute(
                    storeProcedure,
                    new { employeesModel.EName, employeesModel.Lastname, employeesModel.Email, employeesModel.Phone },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Edit(EmployeesModel employeesModel)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spEmployees_Update";

                connection.Execute(
                        storeProcedure,
                        employeesModel,
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Delete(int EmployeeID)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spEmployees_Delete";

                connection.Execute(
                    storeProcedure,
                    new { EmployeeID },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }
    }
}
