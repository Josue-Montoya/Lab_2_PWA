using System.Data;

namespace Lab2_PWA_Juegos.Data
{
    public interface ISqlDataAccess
    {
        IDbConnection GetConnection();
    }
}