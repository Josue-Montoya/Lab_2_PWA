using Dapper;
using Lab2_PWA_Juegos.Data;
using Lab2_PWA_Juegos.Models;
using System.Data;

namespace Lab2_PWA_Juegos.Repositories.Entrance
{
    public class EntranceRepository : IEntranceRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public EntranceRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<EntranceModel> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spEntrance_GetAll";

                var entrance = connection.Query<EntranceModel, ProductsModel, SuppliersModel, EntranceModel>(
                    storedProcedure,
                    (entrance, product, supplier) =>
                    {
                        entrance.Products = product;
                        entrance.Suppliers = supplier;

                        return entrance;
                    },
                    splitOn: "PName, SName",
                    commandType: CommandType.StoredProcedure
                );

                return entrance;
            }
        }


        public IEnumerable<ProductsModel> GetAllProducts()
        {
            string query = "SELECT ProductID, PName FROM Products";

            using (var connection = _dataAccess.GetConnection())
            {
                return connection.Query<ProductsModel>(query);
            }
        }

        public IEnumerable<SuppliersModel> GetAllSuppliers()
        {
            string query = "SELECT SupplierID, SName FROM Suppliers";

            using (var connection = _dataAccess.GetConnection())
            {
                return connection.Query<SuppliersModel>(query);
            }
        }

        public EntranceModel? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spEntrance_GetByID";
                return connection.QueryFirstOrDefault<EntranceModel>(
                            storedProcedure,
                            new { EntranceID = id },
                            commandType: CommandType.StoredProcedure);
            }
        }
        public void Add(EntranceModel entrance)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spEntrance_Insert";
                connection.Execute(
                    storedProcedure,
                    new { entrance.ProductID, entrance.SupplierID, entrance.Quantity, entrance.UnitPrice, entrance.Total, entrance.EDate },

                    commandType: CommandType.StoredProcedure);
            }
        }
        public void Edit(EntranceModel entrance)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spEntrance_Update";

                connection.Execute(
                    storedProcedure,
                    new { entrance.EntranceID, entrance.ProductID, entrance.SupplierID, entrance.Quantity, entrance.UnitPrice, entrance.Total, entrance.EDate },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spEntrance_Delete";

                connection.Execute(
                        storedProcedure,
                        new { EntranceID = id },
                        commandType: CommandType.StoredProcedure);
            }
        }


    }
}
