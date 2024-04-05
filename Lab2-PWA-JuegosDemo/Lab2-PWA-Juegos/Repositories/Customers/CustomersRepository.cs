using Dapper;
using Lab2_PWA_Juegos.Data;
using Lab2_PWA_Juegos.Models;
using System.Data;

namespace Lab2_PWA_Juegos.Repositories.Customers
{
    public class CustomersRepository : ICustomerRepository
    {
        private readonly ISqlDataAccess _dataAccess;


        public CustomersRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<CustomersModel> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spCustomers_GetAll";

                return connection.Query<CustomersModel>(
                                        storeProcedure,
                                        commandType: CommandType.StoredProcedure
                                        );
            }
        }

        public CustomersModel? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spCustomers_GetById";

                return connection.QueryFirstOrDefault<CustomersModel>(
                                    storeProcedure,
                                    new { Id = id },
                                    commandType: CommandType.StoredProcedure
                                   );
            }
        }

        public void Add(CustomersModel customersModel)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spCustomers_Insert";

                connection.Execute(
                    storeProcedure,
                    new { customersModel.CName, customersModel.Email, customersModel.Phone },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Edit(CustomersModel customersModel)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spCustomers_Update";

                connection.Execute(
                        storeProcedure,
                        customersModel,
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Delete(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spCustomers_Delete";

                connection.Execute(
                    storeProcedure,
                    new { id },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }
    }
}
