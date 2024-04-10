using Dapper;
using Lab2_PWA_Juegos.Data;
using Lab2_PWA_Juegos.Models;
using System.Data;

namespace Lab2_PWA_Juegos.Repositories.Departures
{
    public class DeparturesRepository : IDeparturesRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public DeparturesRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<DepartureModel> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spDeparture_GetAll";

                var departure = connection.Query<DepartureModel, ProductsModel, EmployeesModel, DepartureModel>(
                    storedProcedure,
                    (departure, product, employee) =>
                    {
                        departure.Products = product;
                        departure.Employees = employee;

                        return departure;
                    },
                    splitOn: "PName, EName",
                    commandType: CommandType.StoredProcedure
                );

                return departure;
            }
        }

        public IEnumerable<EmployeesModel> GetAllEmployees()
        {
            string query = "SELECT EmployeeID, EName FROM Employees";

            using (var connection = _dataAccess.GetConnection())
            {
                return connection.Query<EmployeesModel>(query);
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

        public DepartureModel? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spDeparture_GetByID";
                return connection.QueryFirstOrDefault<DepartureModel>(
                            storedProcedure,
                            new { DepartureID = id },
                            commandType: CommandType.StoredProcedure);
            }
        }

        public decimal GetPriceByIdForDeparture(int productId)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string query = "SELECT Price FROM Products WHERE ProductID = @ProductId";
                return connection.QueryFirstOrDefault<decimal>(query, new { ProductId = productId });
            }
        }

        public void Add(DepartureModel departure)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spDeparture_Insert";
                connection.Execute(
                    storedProcedure,
                    new { departure.ProductID, departure.EmployeeID, departure.Quantity, departure.UnitPrice, departure.Total, departure.DDate },

                    commandType: CommandType.StoredProcedure);
            }
        }

        public void Edit(DepartureModel departure)
        {
            using(var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spDeparture_Update";

                connection.Execute(
                    storedProcedure,
                    new { departure.DepartureID, departure.ProductID, departure.EmployeeID, departure.Quantity, departure.UnitPrice, departure.Total, departure.DDate },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spDeparture_Delete";

                connection.Execute(
                        storedProcedure,
                        new { DepartureID = id },
                        commandType: CommandType.StoredProcedure);
            }
        }


    }
}
