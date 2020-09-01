using Dapper;
using VideoAlbum.Domain.Entities;
using VideoAlbum.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoAlbum.Persistence.Repositories
{
    public class GenericDataRepository<T> : IGenericDataRepository<T> where T : BaseEntity
    {
        private readonly ISQLDatabaseContext sqlDatabaseContext;
        public GenericDataRepository(ISQLDatabaseContext sqlDatabaseContext)
        {
            this.sqlDatabaseContext = sqlDatabaseContext;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            using(var connection = this.sqlDatabaseContext.GetSqlConnection())
            {
                var table = typeof(T).Name;
                var sql = $"SELECT * FROM {table}";
                return (await connection.QueryAsync<T>(sql)).ToList();
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            using (var connection = this.sqlDatabaseContext.GetSqlConnection())
            {
                var table = typeof(T).Name;
                var sql = $"SELECT * FROM {table} WHERE Id=@id";
                return (await connection.QueryAsync<T>(sql, new { id })).FirstOrDefault();
            }
        }
    }
}
