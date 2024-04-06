using System.Data;
using Dapper;
using Lab2_PWA_Juegos.Data;
using Lab2_PWA_Juegos.Models;

namespace Lab2_PWA_Juegos.Repositories.Suppliers
{
    public class SuppliersRepository : ISuppliersRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public SuppliersRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<SuppliersModel> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spSuppliers_GetAll";

                return connection.Query<SuppliersModel>(
                                        storeProcedure,
                                        commandType: CommandType.StoredProcedure
                                        );
            }
        }

        public SuppliersModel? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spSuppliers_GetById";

                return connection.QueryFirstOrDefault<SuppliersModel>(
                                    storeProcedure,
                                    new { SupplierID = id },
                                    commandType: CommandType.StoredProcedure
                                   );
            }
        }

        public void Add(SuppliersModel suppliersModel)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spSuppliers_Insert";

                connection.Execute(
                    storeProcedure,
                    new { suppliersModel.SName, suppliersModel.SAddress, suppliersModel.Phone, suppliersModel.Email },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Edit(SuppliersModel suppliersModel)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spSuppliers_Update";

                connection.Execute(
                        storeProcedure,
                        suppliersModel,
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Delete(int SupplierID)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spSuppliers_Delete";

                connection.Execute(
                    storeProcedure,
                    new { SupplierID },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }
    }
}
