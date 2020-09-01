using MediatR;

namespace VideoAlbum.Application.Albums.Queries.FetchAlbumDetailByName
{
    public class FetchAlbumDetailByNameQuery : IRequest<FetchAlbumDetailByNameResult>
    {
        public string Name { get; set; }
    }
}
