using System;
using System.Data.SqlClient;

namespace VideoAlbum.Persistence
{
    public class SQLDatabaseContext : ISQLDatabaseContext, IDisposable
    {
        private readonly string connectionString;
        private SqlConnection SqlConnection;

        public SQLDatabaseContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Dispose()
        {
            if (this.SqlConnection != null)
            {
                this.SqlConnection.Close();
                this.SqlConnection.Dispose();
            }
        }

        public SqlConnection GetSqlConnection()
        {
            this.SqlConnection = new SqlConnection(this.connectionString);
            return this.SqlConnection;
        }
    }
}
