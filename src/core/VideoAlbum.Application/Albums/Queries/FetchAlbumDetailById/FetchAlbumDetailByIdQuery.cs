using MediatR;

namespace VideoAlbum.Application.Albums.Queries.FetchAlbumDetailById
{
    public class FetchAlbumDetailByIdQuery : IRequest<FetchAlbumDetailByIdResult>
    {
        public int Id { get; set; }
    }
}
