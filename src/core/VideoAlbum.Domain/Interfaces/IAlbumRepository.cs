using VideoAlbum.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VideoAlbum.Domain.Interfaces
{
    public interface IAlbumRepository
    {
        Task<IReadOnlyList<Album>> FetchAllAlbums();
        Task AddNewAlbum(Album album);
        Task UpdateAlbum(Album album);
        Task DeleteAlbum(int albumId);
        Task<Album> FetchAlbumDetailByName(string name);
    }
}
