using Dapper;
using VideoAlbum.Domain.Entities;
using VideoAlbum.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoAlbum.Persistence.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly ISQLDatabaseContext sqlDatabaseContext;
        public AlbumRepository(ISQLDatabaseContext sqlDatabaseContext)
        {
            this.sqlDatabaseContext = sqlDatabaseContext;
        }

        public async Task<IReadOnlyList<Album>> FetchAllAlbums()
        {
            var fetchAlbumsSql = "select * from [dbo].[FetchAllAlbums] order by Id desc";
            using(var connection = this.sqlDatabaseContext.GetSqlConnection())
            {
                var result = (await connection.QueryAsync<Album>(fetchAlbumsSql)).ToList();
                return result;
            }
        }

        public async Task<Album> FetchAlbumDetailByName(string name)
        {
            var fetchAlbumsSql = "select top 1 * from [dbo].[FetchAllAlbums] where Name = @name";
            using (var connection = this.sqlDatabaseContext.GetSqlConnection())
            {
                var result = (await connection.QueryAsync<Album>(fetchAlbumsSql, new { name })).FirstOrDefault();
                return result;
            }
        }

        public async Task AddNewAlbum(Album album)
        {
            using (var connection = this.sqlDatabaseContext.GetSqlConnection())
            {
                var adddNewAlbumsSql = "exec [dbo].[AddNewAlbum] @Name, @Artist, @Label, @TypeId, @Stock";
                var parameters = new DynamicParameters(album);
                await connection.ExecuteAsync(adddNewAlbumsSql, parameters);
            }
        }

        public async Task UpdateAlbum(Album album)
        {
            using (var connection = this.sqlDatabaseContext.GetSqlConnection())
            {
                var updateAlbumsSql = "exec [dbo].[UpdateAlbum] @Id, @Name, @Artist, @Label, @TypeId, @Stock";
                var parameters = new DynamicParameters(album);
                await connection.ExecuteAsync(updateAlbumsSql, parameters);
            }
        }

        public async Task DeleteAlbum(int albumId)
        {
            using (var connection = this.sqlDatabaseContext.GetSqlConnection())
            {
                var updateAlbumsSql = "exec [dbo].[DeleteAlbum] @Id";
                await connection.ExecuteAsync(updateAlbumsSql, new { Id = albumId });
            }
        }
    }
}
