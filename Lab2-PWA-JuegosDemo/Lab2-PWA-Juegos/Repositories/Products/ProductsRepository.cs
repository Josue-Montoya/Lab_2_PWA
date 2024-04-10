using Dapper;
using Lab2_PWA_Juegos.Data;
using Lab2_PWA_Juegos.Models;
using System.Data;

namespace Lab2_PWA_Juegos.Repositories.Products
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public ProductsRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<ProductsModel> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spProducts_GetAll";

                var products = connection.Query<ProductsModel, SuppliersModel, ProductsModel>
                    (storedProcedure, (product, supplier) =>
                    {
                        product.Suppliers = supplier;

                        return product;
                    }, splitOn: "SName", commandType: CommandType.StoredProcedure);

                return products;
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

        public ProductsModel? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spProducts_GetByID";
                return connection.QueryFirstOrDefault<ProductsModel>(
                            storedProcedure,
                            new { ProductID = id },
                            commandType: CommandType.StoredProcedure);
            }

        }
        public void Add(ProductsModel products)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spProducts_Insert";
                connection.Execute(
                    storedProcedure,
                    new { products.PName, products.PDescription, products.Price, products.Stock, products.SupplierID },
                    commandType: CommandType.StoredProcedure);
            }

        }

        public void Edit(ProductsModel products)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spProducts_Update";

                connection.Execute(
                    storedProcedure,
                    new {products.ProductID, products.PName, products.PDescription, products.Price, products.Stock, products.SupplierID },
                    commandType: CommandType.StoredProcedure);
            }


        }

        public void Delete(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spProducts_Delete";

                connection.Execute(
                        storedProcedure,
                        new { ProductID = id },
                        commandType: CommandType.StoredProcedure);
            }

        }

        public decimal GetPriceById(int productId)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string query = "SELECT Price FROM Products WHERE ProductID = @ProductId";
                return connection.QuerySingleOrDefault<decimal>(query, new { ProductId = productId });
            }
        }
    }
}
