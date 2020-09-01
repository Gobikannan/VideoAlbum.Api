using System.Data.SqlClient;

namespace VideoAlbum.Persistence
{
    public interface ISQLDatabaseContext
    {
        SqlConnection GetSqlConnection();
    }
}
