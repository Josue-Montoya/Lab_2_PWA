using Dapper;
using Lab2_PWA_Juegos.Data;
using Lab2_PWA_Juegos.Models;

namespace Lab2_PWA_Juegos.Repositories.Suppliers
{
    public class SuppliersRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public SuppliersRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<SuppliersModel> GetAllSuppliers()
        {
            string query = "SELECT SupplierID, SName, SAddress, Phone, Email FROM Suppliers;";

            using (var connection = _dataAccess.GetConnection())
            {
                return connection.Query<SuppliersModel>(query);
            }
        }
    }
}
